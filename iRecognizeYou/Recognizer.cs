using System;
using System.Drawing;
using Emgu.CV;
using Emgu.CV.Structure;
using Emgu.CV.CvEnum;
using System.IO;


namespace iRecognizeYou
{
	/// <summary>
	/// Obiekt odpowiedzialny za rozpoznawanie twarzy.
	/// </summary>
	public class Recognizer
	{
		/// <summary>
		/// Tablica twarzy ładowana podczas inicjacji obiektu.
		/// </summary>
		private Image<Gray,Byte> [] faces;
		/// <summary>
		/// Etykiety przypisane do twarzy w bazie - identyfikatory tekstowe.
		/// </summary>
		private String [] labels;
		/// <summary>
		/// Obiekt z biblioteki OpenCV odpowiedzialny za rozpoznawanie twarzy.
		/// </summary>
		private EigenObjectRecognizer eor;
		/// <summary>
		/// Obiekt odpowiedzialny za akwizycję obrazu.
		/// </summary>
		private Capture cap = null;
		/// <summary>
		/// Obiekt przeznaczony na kaskadę Haara, czyli wzorzec twarzy bądź oka w przypadku tego programu.
		/// </summary>
		private HaarCascade haar;

		/// <summary>
		/// Jedyny konstruktor. Odczytuje twarze z bazy i inicjuje wewnętrzny obiekt odpowiedzialny za rozpoznawanie twarzy.
		/// </summary>
		public Recognizer(){
			readFiles();//odczyt twarzy z bazy

			//ustawienie etykiet i dokładności z jaką ma być wykonywane ropoznawanie
			MCvTermCriteria criteria = new MCvTermCriteria(labels.Length, 0.001);

			//utworzenie nowego obiektu do rozpoznawania twarzy
			//obiekt ten wylicza eigenvectors dla każdej twarzy w bazie
			//oraz dla każdej sprawdzanej twarz, po czym wartości wyliczone
			//dla sprawdzanej twarzy porównuje z wartościami wyliczonymi dla tych
			//twarzy z bazy
			eor = new EigenObjectRecognizer(
				faces,//tablica twarzy
				labels,//etykiety odpowiadające twarzom
				3000,//poziom progowania pomiędzy poszczególnymi eigenvectors
				ref criteria//kryterium
				);

			//utwórz wzorzec do wykrywania twarzy
			haar = new HaarCascade("haarcascade_frontalface_default.xml");
		}

		/// <summary>
		/// Funkcja odpowiedzialna za odczyt twarzy z plików w określonym katalogu, gdzie są one przechowywane, oraz pobranie z ich nazw etykiet przypisanych do konkretnych twarzy.
		/// </summary>
		private void readFiles(){
			//pobierz nazwy wszystkich plików z rozszerzeniem jpg z określonej lokalizacji
			//czyli miejsca gdzie trzymasz twarze
			FileInfo [] files = new DirectoryInfo(getFilesLocation()).GetFiles("*.jpg");

			//jeśli nie ma twarzy w bazie to zakończ
			if (files.Length == 0)
				return;

			//utwórz kontenery na obrazki z twarzami
			faces = new Image<Gray, byte> [files.Length];
			//to samo wykonaj, twrząc tablicę na etykiety
			labels = new String [files.Length];

			//wczytaj twarze i etykiety
			for (int i = 0; i < labels.Length; i++)
			{
				//nazwa pliku zawiera:
				//imię nazwisko numer godzina minuta sekunda
				//rozdziel ten powyższy ciąg
				String [] splitted = files [i].Name.Split(' ');

				//do etykiety przypisz imie i nazwisko
				labels [i] = splitted [0] + " " + splitted [1];

				//wczytaj twarz
				faces [i] = new Image<Gray, Byte>(getFilesLocation()+"\\"+files [i].Name);
			}
		}

		/// <summary>
		/// Pobierz lokalizację bazy twarzy na dysku twardym.
		/// </summary>
		/// <returns></returns>
		private String getFilesLocation( )
		{
			return Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) +
				"\\" + "iRecognizeYou";
		}

		/// <summary>
		/// Właściwe rozpoznawanie twarzy. Jako jedyny argument jest przyjmowany obraz zawierający jakąś twarz, która ma zostać poddana weryfikacji.
		/// </summary>
		/// <param name="frame"></param>
		/// <returns></returns>
		public String recognize( Image<Bgr, Byte> frame )
		{
			//1   - konwersja obrazu na skalę szarości
			//2   - wykrycie wszystkich twarzy  obrazie
			//3   - utworzenie pojemnika na położenie i wymiary twarzy
			//4   - sprawdzenie czy jakieś twarze wykryto
			//4a  - pobierz informacje o pierwszej twarzy
			//4b  - wyodrębnianie największej twarzy w obrazie
			//4b1 - porównywanie wielkości twarzy z inną twarzą
			//4b2 - jeśli ta druga większa to zapamiętaj jej położenie i wymiary
			//4c  - ustaw region zainteresowania na twarz
			//4d  - skopiuj obszar twarzy ograniczony regionem zainteresowania
			//4e  - dostosuj rozmiar twarzy do 100x100 
			//4f  - dokonaj właściwego rozpoznania twarzy z wykorzystaniem obiektu dostarczonego poprzez bibliotekę OpenCV(można także bardziej niskopoziomowo bez gotowych api tego typu, aby dostosować do swojego rozwiązania).
			//5   - nie wykryto żadnych twarzy, więc zwróć pustą etykietę
			
					Image<Gray, byte> grayframe = frame.Convert<Gray, byte>();//1
					var faces = haar.Detect(grayframe, 1.4, 4,
						HAAR_DETECTION_TYPE.DO_CANNY_PRUNING,
						new Size(frame.Width / 8, frame.Height / 8));

						Rectangle rect = new Rectangle();//3
						if (faces.Length > 0)//4
						{
							rect = faces [0].rect;//4a
							for (int i = 1; i < faces.Length; i++)//4b
							{
								if (faces [i].rect.Width > rect.Width &&
									faces [i].rect.Height > rect.Height)//4b1
								{
									rect = faces [i].rect;//4b2
								}
							}
							grayframe.ROI = rect;//4c
							Image<Gray, Byte> face = grayframe.Clone();//4d
							Image<Gray, Byte> faceResized = face.Resize(100, 100,
								Emgu.CV.CvEnum.INTER.CV_INTER_LINEAR);//4e
			
							return eor.Recognize(faceResized);//4f
						}
						else//5
						{
							return "";
						}
			
		}
	}
}
