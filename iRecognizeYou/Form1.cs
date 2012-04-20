using System;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;
using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;


namespace iRecognizeYou
{
	/// <summary>
	/// GUI programiku
	/// </summary>
	public partial class Forma : Form
	{
		#region Constructor & fields
		/// <summary>
		/// Obiekt odpowiadający za rozpoznawanie
		/// </summary>
		private Recognizer rec;
		/// <summary>
		/// Obiekt odpowiadający za kamerkę
		/// </summary>
		private Capture cap;

		private Boolean stop = false;
		private Thread trainThread;
		/// <summary>
		/// Wprowadzenie nowej twarzy wymaga przeładowania. Można to ominąć stosując
		/// bezpośrednio funkcje z OpenCV bez wrappera - tutaj nie ma sensu
		/// </summary>
		private Boolean needToReload = false;
		#endregion

		#region Constructor
		/// <summary>
		/// Domyślny konstruktor - przygotowuje interfejs
		/// </summary>
		public Forma( )
		{
			InitializeComponent();
			Region = System.Drawing.Region.FromHrgn(
				CreateRoundRectRgn(
				0,
				0,
				Width - 10, 
				Height - 10, 
				Width-50, 
				Height-50));

			foundPerson.Visible = false;
			foundPersonName.Visible = false;
			foundPerson.Left = this.Width / 2 - foundPerson.Width / 2;
			
		}
		[DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
		private static extern IntPtr CreateRoundRectRgn
		(
		int nLeftRect, // x-coordinate of upper-left corner
		int nTopRect, // y-coordinate of upper-left corner
		int nRightRect, // x-coordinate of lower-right corner
		int nBottomRect, // y-coordinate of lower-right corner
		int nWidthEllipse, // height of ellipse
		int nHeightEllipse // width of ellipse
		);
		#endregion

		#region Moving
		private bool dragging = false;
		private Point dragCursorPoint;
		private Point dragFormPoint;

		private void FormMain_MouseDown( object sender, MouseEventArgs e )
		{
			dragging = true;
			dragCursorPoint = Cursor.Position;
			dragFormPoint = this.Location;
		}

		private void FormMain_MouseMove( object sender, MouseEventArgs e )
		{
			if (dragging)
			{
				Point dif = Point.Subtract(Cursor.Position, new Size(dragCursorPoint));
				this.Location = Point.Add(dragFormPoint, new Size(dif));
			}
		}

		private void FormMain_MouseUp( object sender, MouseEventArgs e )
		{
			dragging = false;
		}

		#endregion

		#region Interface and camera aquisition
		/// <summary>
		/// Zatrzymywanie rozpoznawania twarzy
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void exit_stop_Click( object sender, MouseEventArgs e )
		{
			if (stop)
			{
				stop = false;
				exitButton.Text = "Exit";
				exitButton.BackColor = Color.WhiteSmoke;
				foundPerson.Visible = false;
				foundPersonName.Visible = false;
				timerRecognize.Stop();
				timerRecognize.Enabled = false;
				if (cap != null)
					cap.Dispose();
				return;
			}
			Application.Exit();
		}

		/// <summary>
		/// Pokazanie info o programie
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void info_Click( object sender, MouseEventArgs e )
		{
			MessageBox.Show("iRecognizeYou\nRozpoznawanie twarzy - Face recognition\nMarek Bar\nKoło Naukowe Informatyków PWSTE w Jarosławiu.");
		}

		/// <summary>
		/// Uruchamianie rozpoznawania twarzy
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void recognize_Click( object sender, MouseEventArgs e )
		{
	
				cap = new Capture(0);//połącz się z kamerką
			
			if (cap == null)
				return;//no camera
			//sprawdź czy nie potrzeba przeładować obiektu rozpoznawania twarzy
			if (needToReload)
			{
				needToReload = false;//oznacz, że potrzeba
				rec = null;//porzuć stary, aby móc utworzyć nowy
			}
			if (rec == null)rec = new Recognizer();//jak nie istnieje to utwórz
			
				
			foundPersonName.Visible = true;
			foundPerson.Visible = true;

			timerRecognize.Enabled = true;
			timerRecognize.Start();

			stop = true;
			exitButton.Text = "Stop";
			exitButton.BackColor = Color.Red;
		}

		/// <summary>
		/// Uruchom dodawanie do bazy
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void train_Click( object sender, MouseEventArgs e )
		{
			trainThread = new Thread(
				delegate( )
				{
					Application.Run(new Learn());
					needToReload = true;
				});
			trainThread.Start();

		}
	
		/// <summary>
		/// Odbieranie klatek z kamerki i przekazywanie od obiektu, który zajmuje się wykrywaniem i rozpoznawaniem twary.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void timerRecognize_Tick( object sender, EventArgs e )
		{
			using (Image<Bgr, byte> nextFrame = cap.QueryFrame())
			{
				if (nextFrame != null)
				{
					foundPerson.Image = nextFrame.ToBitmap();//podgląd
					
					String answer = rec.recognize(nextFrame);

					foundPersonName.Text = answer;
				}//if
			}//using
		}

		#endregion

		#region Adding faces to database from files
		/// <summary>
		/// Choose folder from which you want to analyse images and maybe detect faces.
		/// Images must be named as "name surname number" - like a "John Smith 1"
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void detectFacesFromFolder(object sender,EventArgs e){
		chooseDir.RootFolder = Environment.SpecialFolder.Desktop;
		chooseDir.Description = "Choose folder with faces/face in" + 
			"images which will be added to face database" + 
			" - only *.jpg files will be checked";
		if(chooseDir.ShowDialog() == DialogResult.OK){
			String dir = chooseDir.SelectedPath;
			
			progressBar.Maximum = new DirectoryInfo(dir).GetFiles("*.jpg").Length;
			progressBar.Minimum = 0;

			if (progressBar.Maximum == 0)
			{
				MessageBox.Show("No images with *.jpg extension found - " + 
					"it is not accepted to use other image file format");
				return;
			}
			progressBar.Visible = true;
			addImagesWorker.RunWorkerAsync(dir);

			
		}//if folder chosen
	}

		/// <summary>
		/// Adding to face database new faces - background worker
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
	private void addImagesWorker_DoWork( object sender, System.ComponentModel.DoWorkEventArgs e )
	{
		String dir = (String)e.Argument;
		FileInfo [] files = new DirectoryInfo(dir).GetFiles("*.jpg");
		

		var haar = new HaarCascade("haarcascade_frontalface_default.xml");
		int count = 0;
	
		foreach (FileInfo file in files)
		{
			var image = new Image<Gray, Byte>(dir + "\\" + file.Name);
			Image<Gray, byte> img = image.Convert<Gray, byte>();
			var faces = haar.Detect(img, 1.4, 4, HAAR_DETECTION_TYPE.DO_CANNY_PRUNING,
									new Size(img.Width / 8, img.Height / 8));

			Rectangle rect = new Rectangle();

			if (faces.Length > 0)
			{
				rect = faces [0].rect;

				for (int i = 1; i < faces.Length; i++)
				{
					if (faces [i].rect.Width > rect.Width &&
						faces [i].rect.Height > rect.Height)
					{
						rect = faces [i].rect;
					}
				}//find the biggest face in detected

				img.ROI = rect;
				Image<Gray, Byte> face = img.Clone();
				Image<Gray, Byte> faceResized = face.Resize(100, 100,
								Emgu.CV.CvEnum.INTER.CV_INTER_LINEAR);

				if (faceResized != null)
				{
					var splitted = file.Name.Substring(0, file.Name.Length - 4).Split(' ');
					int tmp;
					if(int.TryParse(splitted[2],out tmp)){
					faceResized.Save(Learn.createFileName(splitted [0], splitted [1], int.Parse(splitted [2])));
					}
				}//if resized
			}//if found any face
			count++;
			addImagesWorker.ReportProgress(count, DateTime.Now);
		}//check each jpg file
	}

		/// <summary>
		/// Reporting adding faces progress
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
	private void addImagesWorker_ProgressChanged( object sender, System.ComponentModel.ProgressChangedEventArgs e )
	{
		progressBar.Value = e.ProgressPercentage;
	}

		/// <summary>
		/// Report end of adding new faces to database
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
	private void addImagesWorker_RunWorkerCompleted( object sender, System.ComponentModel.RunWorkerCompletedEventArgs e )
	{
		progressBar.Visible = false;
		String dir = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\iRecognizeYou";
		if(Directory.Exists(dir))
		System.Diagnostics.Process.Start(dir);
	}//function
		#endregion
	}//class
}//ns
