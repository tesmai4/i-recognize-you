using System;
using System.Drawing;
using System.Windows.Forms;
using Emgu.CV;
using Emgu.CV.Structure;
using Emgu.CV.CvEnum;
using System.Runtime.InteropServices;
using System.IO;
namespace iRecognizeYou
{
	/// <summary>
	/// Odpowiada za wprowadzanie twarzy do bazy.
	/// </summary>
	public partial class Learn : Form
	{
		#region Constructor & variables
		/// <summary>
		/// Obiekt obsługujący połączenie z kamerką
		/// </summary>
		private Capture cap;
		/// <summary>
		/// Obiekty przechowujące wzorce wyglądu oka i twarzy.
		/// </summary>
		private HaarCascade haarFace,haarEye;
		/// <summary>
		/// Rodzaj akcji dla przycisku Start/Exit
		/// </summary>
		private Boolean actionType;
		/// <summary>
		/// Licznik zebranych twarzy
		/// </summary>
		private int faceCounter;
		/// <summary>
		/// Pamięć na zebrane twarze
		/// </summary>
		private Image<Gray,Byte> [] grayFaces;
		
		/// <summary>
		/// Domyślny konstruktor - przygotowuje wygląd interfejsu
		/// </summary>
		public Learn( )
		{
			InitializeComponent();
			Region = System.Drawing.Region.FromHrgn(
				CreateRoundRectRgn(
				0,
				0,
				Width,
				Height,
				Width - 50,
				Height - 50));
			actionType = true;
			startButton.Left = this.Width / 2 - startButton.Width / 2;
			startButton.Top = this.Height / 2 - startButton.Height / 2;
			display.Left = this.Width / 2 - display.Width / 2;
			display.Top = this.Height - display.Height;
			nameLabel.Left = this.Width / 2 - nameLabel.Width / 2;
			nameLabel.Top = startButton.Top + startButton.Height;
			nameTextBox.Left = nameLabel.Left;
			nameTextBox.Width = nameLabel.Width;
			nameTextBox.Top = nameLabel.Top + nameLabel.Height;
			display.Visible = false;
			closeButton.Left = this.Width / 2 - closeButton.Width / 2;
			closeButton.Top = closeButton.Height * 2;

			grayFaces = new Image<Gray,byte>[10];
		}
		#endregion

		/// <summary>
		/// Automat do wprowadzania twarzy do bazy.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void timer1_Tick( object sender, EventArgs e )
		{
			if (faceCounter < 10)//musi być 10 ujęć twarzy
			{
				//pobierz kolejną klatkę z kamerki
				using (Image<Bgr, byte> nextFrame = cap.QueryFrame())
				{
					if (nextFrame != null)//jeśli klatka dodarła to
					{
						
						//przekonwertuj klatkę na skalę szarości
						Image<Gray, byte> grayframe = nextFrame.Convert<Gray, byte>();
					
						//wykryj oczy, aby mieć pewność że dana osoba patrzy prosto w kamerę
						var eyes = haarEye.Detect(grayframe, 1.1, 1,
							HAAR_DETECTION_TYPE.DO_CANNY_PRUNING,
							new Size(nextFrame.Width / 8, nextFrame.Height / 8));
						

						if (eyes.Length > 0){//gdy oczy są widoczne
							//wykryj twarz w obrazie
							var faces = haarFace.Detect(grayframe, 1.4, 4,
								HAAR_DETECTION_TYPE.DO_CANNY_PRUNING,
								new Size(nextFrame.Width / 8, nextFrame.Height / 8));
							

							Rectangle rect = new Rectangle();
							if (faces.Length > 0){//gdy twarz jest widoczna
								display.Text = (faceCounter + 1).ToString();
								rect = faces [0].rect;
								for (int i = 1; i < faces.Length; i++)
								{
									if (faces [i].rect.Width > rect.Width &&
										faces [i].rect.Height > rect.Height)
									{
										rect = faces [i].rect;
									}//if
								}//for
								rememberFace(nextFrame, rect);//zapamiętaj twarz
								nextFrame.Draw(rect, new Bgr(0, 255, 0), 3);//potem pokaż jej położenie na podglądzie
							}//do you see any face
							foreach (var eye in eyes)//oczy również zaznacz, aby było wiadomo co się dzieje
							{
								nextFrame.Draw(eye.rect, new Bgr(0, 255, 255), 2);
							}
						}//got visible eyes ?
						//na końcu niezależnie co wykryto, pokaż podgląd klatki
						imageFromCamera.Image = nextFrame.ToBitmap();
						}//nextFrame not null
				}//using
			}//if faceCounter < 10
			else//gdy już zebrane zostanie 10 twarzy to
			{
				saveRememberedFaces();//zapisz
				faceCounter = 0;//wyzeruj licznik twarzy 
				timer1.Stop();//zatrzymaj pobieranie klatek
				timer1.Enabled = false;//i zablokuj
				startButton.Visible = true;
				display.Visible = false;//ukryj podgląd
				imageFromCamera.Image = null;
				nameLabel.Text = "Enrolled as " + nameTextBox.Text;//pokaż info o zakończeniu
				//nameLabel.Left = this.Width / 2 - nameLabel.Width / 2;
				nameLabel.Visible = true;
			}
		}

		/// <summary>
		/// Oblicz wartości eigenvectors dla poszczególnych twarzy
		/// </summary>
		private void calculateEigenValues( )
		{
			MCvTermCriteria cryteria = new MCvTermCriteria(10,0.001);
			String [] labels = new String [10];
			EigenObjectRecognizer eor = 
				new EigenObjectRecognizer(grayFaces,labels, ref cryteria);
			
		}

		/// <summary>
		/// Zapamiętaj w pamięci wykrytą twarz.
		/// </summary>
		/// <param name="imageWithFace">obraz z twarzą</param>
		/// <param name="rect">region określający położenie twarzy</param>
		private void rememberFace(Image<Bgr,Byte> imageWithFace,Rectangle rect)
		{
			using(Image<Bgr,Byte> imageCopy = imageWithFace.Clone()){
				imageCopy.ROI = rect;
				
				using(Image<Bgr,Byte> colorFace = imageCopy.Clone()){
					using(Image<Gray,Byte> grayFace = colorFace.Convert<Gray,Byte>()){
						grayFaces[faceCounter] = grayFace.Resize(100, 100,
								Emgu.CV.CvEnum.INTER.CV_INTER_LINEAR);
					}
				}
			}
			faceCounter++;
		}

		/// <summary>
		/// Zapisz zapamiętane twarze.
		/// </summary>
		private void saveRememberedFaces( )
		{
			String [] splitted = nameTextBox.Text.Split(' ');
			for (int i = 0; i < faceCounter; i++)
			{
				if(grayFaces[i] != null)
				grayFaces [i].Save(Tools.createFileName(splitted [0], splitted [1], i));// ?
			}
		}
		

		/// <summary>
		/// Posprzątaj
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void Learn_FormClosing( object sender, FormClosingEventArgs e )
		{
			if (cap!=null)
			{
				cap.Dispose();
			}
		}

		#region Moving & layout
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

		#region The only button
		/// <summary>
		/// Przycisk włączający wprowadzanie twarzy do bazy, a po zakończeniu zamyka okno wprowadzania.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void startButton_MouseClick( object sender, MouseEventArgs e )
		{
			if (actionType)
			{
				if (nameTextBox.Text != String.Empty)
				{
					actionType = false;
					startButton.Text = "Done";
					startButton.Visible = false;
					display.Visible = true;
					faceCounter = 0;

					cap = new Capture(0);
					haarFace = new HaarCascade("haarcascade_frontalface_default.xml");
					haarEye = new HaarCascade("haarcascade_eye.xml");
					
					timer1.Enabled = true;
					timer1.Start();
					
					nameLabel.Visible = false;
					nameTextBox.Visible = false;
					closeButton.Visible = false;
				}
				else
				{
					MessageBox.Show("Must enter your name and surname to continue");
				}
			}
			else
			{
				this.Close();
			}

		}

		private void closeButton_MouseClick( object sender, MouseEventArgs e )
		{
			this.Close();
		}
		#endregion

		public override string ToString( )
		{
			return "This class is responsible for adding images to face database.";
		}
	}//class
}//ns
