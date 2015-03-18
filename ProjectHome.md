


# **Rozpoznawanie twarzy, Face recognition** #
Imię i nazwisko autora: <b>Marek Bar</b><br />
Nazwa koła i uczelni: <b>Koło Naukowe Informatyków, Państwowa Wyższa Szkoła Techniczno-Ekonomiczna im. ks. Bronisława Markiewicza w Jarosławiu</b><br />
Opiekun naukowy: <b>dr inż. Lucjan Pelc</b><br />

## Wstęp ##

Tradycyjne formy zabezpieczeń aplikacji i dostępu do usług, takie jak kody PIN, hasła i loginy, są podatne na przechwycenie przez osoby niepowołane, można je zapomnieć lub zgubić zapisane gdzieś na skrawku papieru. Natomiast coraz bardziej popularne stają się zabezpieczenia w postaci klucza zawartego w ciele człowieka. Twarz jest jednym z tych kluczy. Jest unikatowa i niepowtarzalna dla każdego człowieka. System rozpoznawania twarzy można wykorzystać, poza kontrolą dostępu, do przeszukiwania bazy zdjęć – jak np.: automatyczne odszukiwanie zdjęć, na których się znajdujemy, czy też do kontroli dostępu, np.: do pomieszczeń, w których wolno nam przebywać bądź też nie. Ponadto zabezpieczenia w postaci kluczy biologicznych są dużo tańsze niż rozwiązania wykorzystujące karty chipowe, urządzenia zbliżeniowe czy też klucze sprzętowe na pamięci przenośnej.

## Cel badań ##

Celem moich badań było opracowanie sposobu weryfikacji tożsamości osoby z wykorzystaniem twarzy jako biologicznego klucza, który jest unikalny i łatwy w użyciu przez zwykłego użytkownika, ponieważ wystarczy tylko spojrzenie aby dokonać autoryzacji.

## Materiał i metody ##

Zadanie, jakim jest rozpoznanie twarzy polega na podzieleniu danych wejściowych w postaci obrazów na wiele klas, które są odpowiednikami osób. Jak wiadomo, obrazy te mogą zawierać szumy, czyli piksele nie mające związku z twarzą. Ponadto piksele danego obrazu nie są w całości losowe. Pomiędzy tymi losowymi obszarami pojawiają się obszary tworzące pewne wzory, które mogą oznaczać obecność pewnych obiektów, takich jak: nos, oczy czy usta, oraz zawierają względne odległości pomiedzy nimi. Te charakterystyczne wzory/cechy nazywane są eigenfaces lub głównymi składowymi. Cechy charakterystyczne(eigenfaces) dla danej twarzy są odnajdowane z wykorzystaniem PCA(Principal Component Analysis). Każda cecha(eigenface) jest tylko reprezentacją pewnej cechy twarzy, która może być widoczna w obrazie lub nie. Jeśli cecha jest obecna w obrazie w większym stopniu to wtedy jej udział w odpowiadającej jej eigenface jest większy. W przeciwnym wypadku, gdy stopień cechy jest prawie mniejszy lub nieobecny to jej udział jest mniejszy w sumie eigenfaces lub żadny. Opisywany wyżej udział, określa w jakim stopniu określona cecha jest widoczna w obrazie.Wykorzystując wszystkie eigenfaces uzyskane z obrazów wejściowych można odtworzyć pierwotne obrazy z eigenfaces, bądź też dokonać tylko częściowej rekonstrukcji obrazu poprzez aproksymację. Dla rozpoznawania twarzy istotne są tylko wagi otrzymane w wyniku działania algorytmu PCA. Wagi oznaczają wielkość mowiącą o tym czy twarz różni się od typowych twarzy reprezentowanych poprzez eigenfaces. Używanie tych wag pozwala określić czy obraz zawiera twarz i czy istnieją podobne twarze do danej twarzy. Do wykonania tego zadania została wykorzystana biblioteka OpenCV, która posiada zestawy API do wykonywania zadań z dziedziny przetwarzania obrazu.

Aby móc wykonywać operacje sprawdzania tożsamości osoby na podstawie cech charakterystycznych twarzy, wymagane jest jej wcześniejsze wprowadzenie do tzw. bazy twarzy. Baza twarzy w tym przypadku to odpowiednio obrobione i zapisane obrazy tylko samej twarzy danej osoby i pozostałych osób, które są w bazie. W nazwach plików zawarte są dane na temat osób, których twarze są zebrane w tej prostej bazie. Zarówno dla czynności wprowadzania twarzy do bazy jak i jej rozpoznawania można wyróżnić trzy wspólne etapy, wymienione i opisane poniżej:
  1. Akwizycja, czyli pozyskanie obrazu z kamery. Warunki oświetleniowe jak i samo ustawienie kamery mają wpływ na obraz, dlatego powinny być zbliżone podczas wprowadzania twarzy do bazy jak i porównywania jej z nią.
  1. Kolejnym krokiem jest wykrycie twarzy w obrazie i jej zapisanie w pamięci. Wykrywanie twarzy jest to proces wyszukiwania w obrazie twarzy oraz zwrócenia ich pozycji i wymiarów obszaru otaczającego. Do wykrycia twarzy został wykorzystany wytrenowany klasyfikator Haara dostarczany wraz z biblioteką OpenCV. Następnie  jest wykonywane dostosowywanie rozmiaru twarzy wykrytej do rozmiaru pozostałych twarzy w bazie. W przypadku tej aplikacji rozmiar wynosi 100 pikseli szerokości jak i wysokości. Dla pewności, że twarz danej osoby jest skierowana prosto w kamerę, jest dokonywane sprawdzenie widoczności oczu. Stan powiek, zamknięta czy otwarta, nie ma znaczenia.
  1. Następnie obraz zawierający odnalezioną twarz poddawany jest operacjom morfologicznym(przetwarzanie wstępne/przygotowujące), które mają na celu usunięcie szumów, niepotrzebnego tła twarzy, wyrównania jasności. Szum dodany do wartości piksela może skutecznie zmienić jego znaczenie(informację jaką reprezentuje) lub częściowe zniekształcić jego znaczenie. Operacje morfologiczne sprawiają, że skuteczność algorytmu rozpoznawania twarzy wzrasta.

Po wykonaniu powyższych kroków obraz w przypadku dodawania do bazy jest zapisywany do pliku o odpowiedniej nazwie w formacie: imię nazwisko numer godzina minuta sekunda. Dla każdej twarzy zapisywanych jest dziesięć obrazów twarzy(może być mniej lub więcej) dla podniesienia skuteczności algorytmu rozpoznawania, ponieważ twarz zawsze może znajdować się minimalnie w innym położeniu. Wprowadzanie twarzy do bazy jest łatwe. Należy tylko podać swoje dane i popatrzeć w kamerę, a reszta zostanie wykonana automatycznie. Istnieje także możliwość wprowadzenia twarzy do bazy twarzy z plików o nazwie w wyżej wymienionym formacie nazwy pliku. Akceptowane są pliki typu: png, gif, jpg, bmp.
Rozpoznawanie twarzy to proces, w którym próbuje się przypisać nazwę/identyfikator do twarzy weryfikowanej w odnieseniu do paasujących twarzy w tzw. bazie twarzy. Rozpoznawanie twarzy wykorzystuje te same kroki co powyżej, jednakże są one wykonywane zarówno podczas odczytywania cech charakterystycznych przez algorytm, o twarzach zawartych w bazie twarzy, jak i przy sprawdzaniu twarzy poddawanej weryfikacji. Weryfikacja ma na celu stwierdzenie czy dana osoba znajduje się w bazie lub nie.

## Wyniki ##

Wykrywanie twarzy w obrazie pozyskanym z kamery przebiega bez żadnym problemów. Jedynie osoby o czarnym kolorze skóry bądź znajdujące się w mrocznym pomieszczeniu mogą zostać nie zauważone. Dodatkowo przed wykryciem twarzy jest sprawdzana widoczność oczu, ponieważ gdy nie jest to wykonane to otrzymujemy w efekcie inną twarz. Pozyskany obraz twarzy musi zostać poddany operacjom morfologicznym, takim jak: normalizacja histogramu czy usuwanie tła, na którym znajduje się twarz, aby późniejsze wyniki rozpoznawania danej osoby były prawdziwe. Metoda PCA wykorzystana do wydobywania istotnych cech twarzy jest niestety podatna na warunki otoczenia w jakim jest pobierany obraz twarzy do celów weryfikacji tożsamości, dlatego należy przed właściwym rozpoznaniem wykonać czynności przygotowujące obraz danej twarzy do porównania z bazą, bądź przed wprowadzeniem do bazy twarzy. Odpowiednio dobrane metody realizacji mają bezpośredni wpływ na szybkość i jakość rozpoznania twarzy. Im więcej zdjęć zawiera baza dla danej osoby, tym większą skutecznością system rozpoznawania twarzy wykazuje się, dlatego zbyt mała liczba ujęć twarzy wpłynęła by negatywnie na skuteczność rozpoznania, a właściwie jego brak.

## Dyskusja ##

W czasie rozpoznawania twarzy można napotkać na następujące błędy rozpoznania polegające na:
  1. błędnym rozpoznaniu – nastąpiło przypisanie weryfikowanej twarzy do twarzy kogoś kto jest w bazie,
  1. fałszywym odrzuceniu twarzy – gdy twarz wystepuje w bazie, a nie zostanie rozpoznana,
  1. fałszywej akceptacji – przypisaniu twarzy do twarzy kogoś innego, pomimo nie występowania tej twarzy w bazie.

Błędne rezultaty rozpoznawania twarzy z wykorzystaniem PCA są spowodowane w głównej mierze warunkami oświetleniowymi podczas wprowadzania użytkownika do bazy jak i podczas akwizycji obrazu zawierającego twarz do rozpoznania. Ponadto samo tło na jakim znajduje się dana twarz może być mylące dla algorytmu rozpoznawania danego człowieka. Mimo tych niedogodności analiza PCA pozwala na szybkie i pozytywne zweryfikowanie tożsamości, pod warunkiem że wcześniej zostaną wykonane czynności przygotowujące obraz twarzy do rozpoznania, tak aby był jak najmniej mylony przez algorytm z tłem.
Aplikacja demonstrująca działanie systemu rozpoznawania twarzy
W wyniku poszukiwania rozwiązania pozwalającego na weryfikację tożsamości za pomocą twarzy, powstała aplikacja o nazwie iRecognizeYou, która wykorzystuje zaimplementowaną w OpenCV metodę PCA oraz pokazuje działanie systemu rozpoznawania twarzy w wersji offline. Aplikację iRecognizeYou można pobrać ze strony projektu: http://code.google.com/p/i-recognize-you/downloads/list , gdzie można także przeglądać kody źródłowe, zgłaszać błędy, pobrać całość do własnych modyfikacji i przeczytać teoretyczny opis. Aplikacja iRecognizeYou pozwala na wprowadzanie użytkowników do bazy twarzy offline z kamery oraz z  pliku(po wcześniejszym nadaniu odpowiedniej nazwy) i oczywiście główną funkcjonalnością jest rozpoznawanie twarzy. Działanie najważniejszych części aplikacji zostało przedstawoine na rysunkach nr: 1 – wprowadzanie i 2 - rozpoznawanie. Na rysunku obok został przedstawiony interfejs aplikacji.

## Podsumowanie ##

Podsumowując działanie aplikacji do rozpoznawania twarzy opartej na analizie głównych składowych(PCA) można dojść do wniosku, iż ta metoda nie jest niezawodna i pomimo swej szybkości powinna być traktowana jako punkt wyjścia do dalszych poszukiwań. W przypadku twarzy warto wysiłki poszukiwawcze skierować w kierunku ropoznawania twarzy z wykorzystaniem sieci neuronowej, która mogła by być wspomaganiem dla systemu z PCA lub stworzyć sieć neuronową, której zadaniem było by stwierdzanie tożsamości twarzy na podstawie znanych już twarzy. Przy rozpoznawaniu twarzy z wykorzystaniem PCA ważne jest też przetwarzanie wstępne, które ma duży wpływ na jakość rozpoznania(wyrównanie jasności histogramu), ale nieumiejętnie dobrane może pogorszyć wyniki(krawędziowanie).

## Bibliografia ##

  1. Introduction to Face Detection and Face Recognition - Shevrim Emami ze strony: http://www.shervinemami.info/faceRecognition.html
  1. Learning OpenCV, Computer Vision with the OpenCV Library – Gary Bradski, Adrian Kaehler

## Dodatki ##

### Rysunek nr 1: wprowadzanie twarzy do tzw. bazy twarzy, opracowanie własne wykonane  w yEd. ###
![https://sites.google.com/site/napiszprogrampl/home/Wprowadzanie%20twarzy%20do%20bazy%20twarzy.png](https://sites.google.com/site/napiszprogrampl/home/Wprowadzanie%20twarzy%20do%20bazy%20twarzy.png)
### Rysunek nr 2: rozpoznawanie twarzy(inicjacja po prawej), opracowanie własne wykonane w yEd. ###
![https://sites.google.com/site/napiszprogrampl/home/Rozpoznawanie%20twarzy.png](https://sites.google.com/site/napiszprogrampl/home/Rozpoznawanie%20twarzy.png)
### Filmik pokazujący działanie aplikacji ###

<a href='http://www.youtube.com/watch?feature=player_embedded&v=zi7fCxtdUKs' target='_blank'><img src='http://img.youtube.com/vi/zi7fCxtdUKs/0.jpg' width='480' height=' height=344 /></a>