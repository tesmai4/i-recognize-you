


# **Tehnologija prepoznavanja lica, Face Detection** #
Autor: Marek <b> Bar </b> <br />
Studentska organizacija i sveučilišni ime: <b> Studenckie Koło Informatyków w Państwowej Wyższej Szkole Techniczno-Ekonomicznej im. ks. Bronislaw Markiewicz u Jarosław </b> <br />
Znanstveni savjetnik: <b> dr. sc. Lucjan Pelc </b> <br />

## Uvod ##

Tradicijski oblici zahtjeva sigurnosti i pristup uslugama, suha kao igle, lozinke i prijave su osjetljivi na presretanje od strane neovlaštenih osoba, možete zaboraviti ili izgubiti pohranjene negdje na komadu papira. S druge strane, sve više postaju popularni kao sigurnosni ključ sadržan u tijelu. Lice je jedan od onih tipki. To je jedinstven i poseban za svakoga. Raspoznavanje lica Sustav se može koristiti, izvan kontrole pristupa slike za pretraživanje baze podataka - suhim što su automatsko pretraživanje slika, gdje smo, ili za kontrolu pristupa, npr. za područja gdje bismo trebali ostati ili ne. Osim toga, sigurnost u obliku biološke tipke su puno jeftiniji od rješenja korištenjem pametnih kartica, neposrednu blizinu uređaja ili dongles na memory stick.

## Svrha istraživanja ##

Svrha je ovog istraživanja bio je razviti metodu provjere identiteta osobe koja koristi lice kao ključni biološki To je jedinstven i jednostavan za povremeni korisnik, jer ćete samo morati gledati napraviti odobrenja.

## Materijal i metode ##

Zadaća detekcije lica je podijeliti ulazne podatke u obliku slike u više razrede, koji su jednako ljudi. Kao što znate, ove slike mogu SADRŽAVATI buku, ili piksela bez veze s lica. Osim toga, slike pikseli nisu u potpunosti slučajne. Između tih područja postoje Stvaranje slučajnih područja koja Neki obrasci mogu ukazati na prisutnost određenih objekata, kao suho nos, oči ili usta, a uključuju relativnu udaljenost između njih. Ove obrasce karakteristične značajke / nazivaju eigenfaces ili glavne komponente. Ključne značajke (eigenfaces) za lice su se razvili pomoću PCA (Principal Component Analysis). Svaka značajka (eigenface) je samo prikaz lica, što se može vidjeti na slici ili ne. Ako značajka je prisutan na slici više od njegov udio u odgovarajućem eigenface je veća. Inače, kada stupanj mogućnosti su gotovo odsutan ili manje od njegov udio je manji u ukupnim eigenfaces ili ne. Opisani način, dio, odrediti u kojoj mjeri posebnost je očita u svim eigenfaces obrazie.Wykorzystując dobivene iz ulazne slike mogu reproducirati izvorne slike iz eigenfaces, ili bi samo djelomično rekonstrukciju slike po aproksimacije. Za prepoznavanja lica su važni samo utezi dobiveni PCA algoritma. Stanje Sredstva u iznosu od govoriti o tome ili se suočiti razlikuje od tipične lice zastupa u eigenfaces. Korištenje tih utega vam omogućuje da odredite da li slika sadrži lice, i da li postoje slične licem u lice. Ovaj zadatak je korišten OpenCV knjižnice, koja ima skup API-ja za obavljanje poslova u oblasti za obradu slike.

Da biste mogli provjeriti identitet poslovanja na temelju značajki lica, potrebno je prethodno uvođenje tzv. baza lice. Face baza podataka u ovom slučaju ispravno je liječiti i pohranjuju slike lica samo osobe i druge osobe koje su u bazi podataka. Imena datoteka nalaze se na datum pojedinaca čija lica se okupio u ovoj jednostavnoj bazi podataka. Oba su djela njegova lica na bazu i njegova priznanja mogu se podijeliti u tri zajedničke faze, navedene i opisane u nastavku:
  1. Nabava, stjecanje na slici. Rasvjetni i pozicioniranje kamera uvjeti utječu na samu sliku, i stoga bi trebao biti u blizini vaše lice Kada uđete u bazu podataka i uspoređujući ga s njom.
  1. Sljedeći korak je otkriti lica u slici i pohraniti u memoriju. Face Detection je proces pronalaženja sliku lica i vratio se na položaj i dimenzije okolnom području. Za otkrivanje lice je korišten trenirao Haar klasifikatora isporučen s OpenCV knjižnici. Zatim podesite veličinu koja je u veličini otkrivena lica drugih lica u bazi podataka. Ako je zahtjev veličina je 100 piksela široka i visoka. To osigurava da osoba lice je usmjeren ravno u kameru, izrađen je provjeriti vidljivost očiju. Status kapaka, zatvoreni ili otvoreni, to ne smeta.
  1. Zatim, slika sadrži licem pronašao je podvrgnut morfoloških operacija (pre-obrada / pripreme), koji su dizajnirani za uklanjanje nepotrebnih pozadinsku buku i lice, ujednačenosti svjetline. Buke dodan u vrijednosti piksela možete promijeniti svoje značenje učinkovito (koji predstavlja podatke) ili djelomično narušiti njegovo značenje. Morfološke operacije, provjerite učinkovitost prepoznavanja lica povećava algoritma.

Prethodne mjere za dodavanje slike u bazu podataka se sprema u datoteku s odgovarajućim imena u formatu: ime prezime broj sati minuta sekundi. Za svako lice je lice slike spremljene (može biti više ili manje) za poboljšanje učinkovitog prepoznavanja algoritam, jer je lice uvijek biti barem u neko drugo mjesto. Unesite Vaše lice u bazu je jednostavno. Vi jednostavno unesite Vaše detalje i gledati u kameru, a ostatak će se obaviti automatski. Tu je i mogućnost licem u lice s bazom podataka u datoteku pod nazivom gore formatu, naziv datoteke. Prihvaćeni vrste datoteka: png, gif, jpg, bmp.
Raspoznavanje lica je proces koji pokušava Koji dodijeliti ime / ID u lice odnieseniu potvrđena u lice tzv paasujących. temelji se na lice. Prepoznavanje lica koristi isti način kao gore, ali su oba provodi tijekom čitanja svojstva algoritma, s lica lica u bazi podataka, kao i za provjeru lica predmet provjere. Provjera je utvrditi namijenjen je li osoba u bazi podataka ili ne.

## Stranice ##

Face Detection u dobivena slika iz kamere prolazi bez ikakvih problema. Samo ljudi s crnim boje kože ili smješteni u mračnoj prostoriji se ne može uočiti. Osim toga, prije otkrića lice je vidljivo očima provjeriti, jer to nije učinjeno da se u stvari drugačije lice. Acquired lica slika mora biti podvrgnut morfoloških operacija, suhim kao normalizacije ili histogram, pozadinska uklanjanje, u kojoj je lice na naknadno priznanje jedne osobe rezultati su točni. PCA metoda koja se koristi za izdvajanje bitnih značajki lica je nažalost podložna uvjetima zaštite okoliša u kojoj je lice slika je poduzela u svrhu provjere identiteta i treba biti dijagnosticiran prije odgovarajuće korake kako pripremiti sliku lica usporediti s baze podataka, ili prije na baznu lice. Pravilno odabrane metode provedbe imati izravan utjecaj na brzinu i kvalitetu detekcije lica. Što više slika pruža osnovu za osobe, učinkovitiji prepoznavanje lica sustav prikazan je zbog toga premalo lice metak koji negativno utječu na učinkovitost dijagnostike, odnosno nedostatak istih.

## Rasprava ##

Dok prepoznavanje lica, možete naići na sljedeće pogreške dijagnozu na temelju:
  1. Pogrešna dijagnoza - atribucija ovjerenom licem u lice nekoga tko je u bazi podataka,
  1. Lažna odbacivanje lice - lice pojavljuje u bazi podataka, a ne priznaju,
  1. True prihvaćanje - licem u lice je dodijeljen nekom drugom, bez obzira na pojavu tog lica nije u bazi podataka.

Pogrešne rezultate prepoznavanja lica pomoću PCA je uglavnom zbog svjetlosnim uvjetima Prilikom unosa korisnika u bazu podataka, kao i slike stjecanja Tijekom uključuje licem-u-prepoznati. Štoviše, ista pozadina na kojoj je lice može biti zbunjujuće za algoritam za prepoznavanje čovjeka. Unatoč tim neugodnosti, PCA omogućuje brzo i pozitivno provjere identiteta, pod uvjetom da se prethodnim koracima obavljen u pripremi za lica raspoznavanje slika, tako da je najmanje zbunjeni algoritma s pozadini.
Zahtjev pokazuje rad sustava za prepoznavanje lica
Kao rezultat traženja rješenja za provjeru identiteta lica, a ime je dobio iRecognizeYou da aplikacija koristi OpenCV način implementiran u ZOP-a i pokazuje performanse sustava za prepoznavanje lica u offline verziji. IRecognizeYou Zahtjev se može skinuti s projekta: http://code.google.com/p/i-recognize-you/downloads/list~~HEAD=pobj, gdje također možete pregledavati izvorni kod, prijavite bugove, dobiti sve naše promjene i čitati teorijski opis. IRecognizeYou aplikacija vam omogućuje unos korisnika u bazu podataka izvanmrežne suočiti s kamerom i datoteka (nakon dodjeljivanje odgovarajuće ime), i, naravno, glavna je značajka Face Detection. Rad mosta važnih dijelova prijave je przedstawoine crteži broj: 1 - Uvod i 2 - priznanje. Dijagram je predstavljen aplikacija sučelje.

## Sažetak ##

To sažima svoju aplikaciju za prepoznavanje lica na temelju analize glavnih komponenata (PCA) može se zaključiti da je ova metoda nije pouzdana, i unatoč svojoj brzini treba uzeti kao polazište za daljnje istraživanje. Ako je vaše lice je vrijedan trud usmjeren lice istraživanje ropoznawania pomoću neuronske mreže koje bi mogle biti potpomognuto od strane ZOP-sustav, ili stvoriti neuronske mreže, čiji je zadatak bio utvrđivanje identiteta lica na temelju poznatog lica. Uz tehnologija prepoznavanja lica pomoću PCA je također važno pre-obrada, koja ima veliki utjecaj na kvalitetu dijagnoze (svjetlina izjednačavanje histogram), ali nepravilno izabrao svibanj pogoršati rezultate (sklopivi).

## Literatura ##

  1. Uvod Face Detection i Face Recognition - Shevrim Emami od: http://www.shervinemami.info/faceRecognition.html
  1. Učenje OpenCV, Computer Vision s OpenCV knjižnice - Gary Bradski, Adrian Kaehler

## Dodaci ##

### Slika 1: Uvod u tzv lice. lice baza podataka, razvoja vlastitog made in yEd. ###
![https://sites.google.com/site/napiszprogrampl/home/Wprowadzanie%20twarzy%20do%20bazy%20twarzy.png](https://sites.google.com/site/napiszprogrampl/home/Wprowadzanie%20twarzy%20do%20bazy%20twarzy.png)
### Slika 2: Face Detection (Pokretanje na desnoj strani), razviti vlastitu je u yEd. ###
![https://sites.google.com/site/napiszprogrampl/home/Rozpoznawanie%20twarzy.png](https://sites.google.com/site/napiszprogrampl/home/Rozpoznawanie%20twarzy.png)
### Film - to pokazuje vaš zahtjev ###

<a href='http://www.youtube.com/watch?feature=player_embedded&v=zi7fCxtdUKs' target='_blank'><img src='http://img.youtube.com/vi/zi7fCxtdUKs/0.jpg' width='480' height=' height=344 /></a>