using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.IO;
using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;
namespace iRecognizeYou
{
	class Tools
	{
		/// <summary>
		/// Gets String array of filenames without full path for chosen file types and folder location
		/// </summary>
		/// <param name="extensions">file extensions like: png,jpg,bmp - given without *.</param>
		/// <param name="dir">files location</param>
		/// <returns></returns>
		public static string [] fileFilter( string extensions, string dir )
		{
			var files = new ArrayList();
			foreach (var ext in (extensions.Split(new char [] { ',' })))
				foreach (var file in (new DirectoryInfo(dir).GetFiles("*." + ext)))
					files.Add(file.Name);
			return (string [])files.ToArray(typeof(string));
		}

		/// <summary>
		/// Odczytaj etykietę z nazwy pliku.
		/// </summary>
		/// <param name="filename">nazwa pliku</param>
		/// <returns></returns>
		public static String getUserLabel( String filename )
		{
			String [] splitted = filename.Split(' ');
			return splitted [0] + " " + splitted [1];
		}

		/// <summary>
		/// Wygeneruj unikalną nazwę pliku zawierającą w nazwie parametry.
		/// </summary>
		/// <param name="name">imię</param>
		/// <param name="surname">nazwisko</param>
		/// <param name="number">numer fotki</param>
		/// <returns></returns>
		public static String createFileName( String name, String surname, int number )
		{
			String mainDir = "iRecognizeYou";
			string dokumenty = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
			if (!Directory.Exists(dokumenty + "\\" + mainDir))
				Directory.CreateDirectory(dokumenty + "\\" + mainDir);

			DateTime data = DateTime.Now;
			String filename = (String.Format("{0}\\{1}\\{2} {3} {4} {5} {6} {7}.jpg",
				dokumenty, mainDir,
				name, surname, number.ToString(),
				data.Hour, data.Minute, data.Second));

			while (File.Exists(filename))
			{
				filename = (String.Format("{0}\\{1}\\{2} {3} {4} {5} {6} {7}.jpg",
					dokumenty, mainDir,
					name, surname, (++number).ToString(),
					data.Hour, data.Minute, data.Second));
			}

			return filename;
		}
		/// <summary>
		/// Save image on Desktop
		/// </summary>
		/// <param name="image">image data as Image Gray,float </param>
		/// <param name="filename">your file name with ext like jpg</param>
		public static void saveImage(Image<Gray,float> image,String filename){
			String dir = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
			String path = dir + "\\" + filename;
			image.Save(path);
		}
		/// <summary>
		/// Save image on Desktop
		/// </summary>
		/// <param name="image">image data as Image Gray,Byte </param>
		/// <param name="filename">your file name with ext like jpg</param>
		public static void saveImage( Image<Gray, Byte> image, String filename )
		{
			String dir = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
			String path = dir + "\\" + filename;
			image.Save(path);
		}
		/// <summary>
		/// Save Eigen images on Desktop
		/// </summary>
		/// <param name="images">Image Gray,float array</param>
		/// <param name="labels">images labels</param>
		public static void saveEigenImages(Image<Gray,float>[] images,String [] labels){
			for (int i = 0; i < labels.Length; i++)
			{
				saveImage(images [i], labels [i] + ".jpg");
			}

			}

		/// <summary>
		/// Saves eigen values connected with each label
		/// </summary>
		/// <param name="eigenValues">eigen values</param>
		/// <param name="labels">labels</param>
		/// <param name="filename">output filename</param>
		public static void saveLabelsWithEigenValues( Emgu.CV.Matrix<float> [] eigenValues, String [] labels, String filename )
		{
			if (eigenValues.Length == labels.Length)
			{
				String content="";
				for(int i=0;i<labels.Length;i++){
					content += "\r\n" +labels [i] + "   ";
					for (int j=0;j<eigenValues[i].Cols;j++)
					{
						for (int a = 0; a < eigenValues [i].Rows; a++)
						{
							for (int b = 0; b < eigenValues [i].Cols; b++)
							{
								content += eigenValues [i].Data [a, b] + "||";
							}
						}
					}
				content += "\t" + labels[i] + "\r\n";
				}
				saveToTextFile(content,filename);
			}
		}
		/// <summary>
		/// Save as text file
		/// </summary>
		/// <param name="content">text goes here</param>
		/// <param name="filename">filename without extension</param>
		public static void saveToTextFile( String content, String filename )
		{
			String dir = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
			String path = dir + "\\" + filename + ".txt";
			System.IO.StreamWriter file = new System.IO.StreamWriter(path);
			file.WriteLine(content);
			file.Close();
		}

		/// <summary>
		/// Information about this class
		/// </summary>
		/// <returns>info</returns>
		public override string ToString( )
		{
			return "This class only provides static method used by others.";
		}
	}//end of Tools class
}//end of namespace
