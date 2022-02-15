<style>
.system {
    color: rgb(216, 160, 223);
}
body {
    background-color: #1E1E1E;
    color: white;
}

a {
    color: white;
    text-decoration: underline;
}
</style>

# Pop-it! fejlesztői dokumentáció
<a id="markdown-pop-it!-fejleszt%C5%91i-dokument%C3%A1ci%C3%B3" name="pop-it!-fejleszt%C5%91i-dokument%C3%A1ci%C3%B3"></a>

A Csodacsapat által fejlesztett Pop-it! implementáció C# nyelven, Windows Forms-ban készült. Pop-It! hub ami a szoftver kiegészítő társa pedig PHP nyelven íródott. Ez a dokumentáció a fejlesztőknek szól!

## Tartalomjegyzék
<a id="markdown-tartalomjegyz%C3%A9k" name="tartalomjegyz%C3%A9k"></a>

<!-- TOC -->

- [Pop-it! fejlesztői dokumentáció](#pop-it-fejleszt%C5%91i-dokument%C3%A1ci%C3%B3)
    - [Tartalomjegyzék](#tartalomjegyz%C3%A9k)
    - [I. Pop-it! kliens](#i-pop-it-kliens)
        - [Menü](#men%C3%BC)
        - [Pályaválasztó](#p%C3%A1lyav%C3%A1laszt%C3%B3)
            - [Gép elleni játék](#g%C3%A9p-elleni-j%C3%A1t%C3%A9k)
                - [Részei](#r%C3%A9szei)
        - [Játéktér](#j%C3%A1t%C3%A9kt%C3%A9r)
        - [Pop-it! - hub](#pop-it---hub)
        - [Többször felhasznált osztályok](#t%C3%B6bbsz%C3%B6r-felhaszn%C3%A1lt-oszt%C3%A1lyok)
            - [Logger](#logger)
            - [Palya](#palya)
            - [Szinek](#szinek)
    - [II. Pop-it! generátor](#ii-pop-it-gener%C3%A1tor)
        - [Bevezetés](#bevezet%C3%A9s)
        - [Eljárások és változók](#elj%C3%A1r%C3%A1sok-%C3%A9s-v%C3%A1ltoz%C3%B3k)
    - [III. Pop-it! hub](#iii-pop-it-hub)
        - [Felhasznált technológiák, könyvtárak](#felhaszn%C3%A1lt-technol%C3%B3gi%C3%A1k-k%C3%B6nyvt%C3%A1rak)
        - [Az oldal struktúrája](#az-oldal-strukt%C3%BAr%C3%A1ja)
            - [Felépítése](#fel%C3%A9p%C3%ADt%C3%A9se)
            - [Részei](#r%C3%A9szei)
        - [Az oldal működése](#az-oldal-m%C5%B1k%C3%B6d%C3%A9se)
            - [A pályafeltöltés menete](#a-p%C3%A1lyafelt%C3%B6lt%C3%A9s-menete)
            - [Pályák lekérdezése](#p%C3%A1ly%C3%A1k-lek%C3%A9rdez%C3%A9se)

<!-- /TOC -->

## I. Pop-it! kliens
<a id="markdown-i.-pop-it!-kliens" name="i.-pop-it!-kliens"></a>

### 1. Menü
<a id="markdown-men%C3%BC" name="men%C3%BC"></a>

A menü a nyitó eleme a programunknak, a felszínen csak gombokat látunk, amelyek különböző, más funkcióval bíró formokat nyitnak meg. Ennél többet tényleg nem is csinál a menü, kivéve azt az egyet, hogy a form elindulásakor ellenőrzi, hogy a `palyak` nevű mappa létezik-e. Amennyiben nem, úgy legyártja. Valamint logolja, hogy ez megtörtént (a `logger` osztályról az 5. fejezetben olvashat).

```csharp
if (!Directory.Exists("palyak"))
{
    Directory.CreateDirectory("palyak");
    logger.LogDebug($"Palyak mappa elkészítve");
}
```
<br><br><br>

### 2. Pályaválasztó
<a id="markdown-p%C3%A1lyav%C3%A1laszt%C3%B3" name="p%C3%A1lyav%C3%A1laszt%C3%B3"></a>

A pályaválasztó ablakkal/formmal van lehetőségünk pályát választani, majd elindítani a játékot vele.\
Ezen a formon van egy ListBox ami a pályák neveit tárolja, egy előnézeti ablak ami piciben betölti a pályát. Emellett van egy CheckBox elem, amivel előre definiálni tudjuk, hogy egy másik játékos ellen vagy a gép ellen akarunk játszani.

Ez a form is rendelkezik egy példánnyal a `logger` osztályból a logolás végett. Emellett van egy példány a `szinek` osztályból, amivel szineket tudunk kérni az egyes karaktereknek (ez a preview miatt érdekes).

Fontosabb eljárások a `PalyakBeolvasas()` ami a pályákat olvassa be a mappából és listázza ki, valamint állítja össze belőle a listánkat a pályákról (ehhez a `palya` osztályt használja a lista), a `JatekIndit()` ami átadja a pályát a JatekForm-nak (Játéktér). A `listbox_palyak_SelectedIndexChanged()` esemény bázisú eljárásunk felelős azért, hogy a pálya kiválasztásakor a preview ki legyen rajzolva.

**Megjegyzés**: a preview, akár csak a Játéktér, DataGridView elemként jelenik meg, tehát gyakorlatban egy táblázatot renderelünk ki.

#### 2.1 Gép elleni játék
<a id="markdown-g%C3%A9p-elleni-j%C3%A1t%C3%A9k" name="g%C3%A9p-elleni-j%C3%A1t%C3%A9k"></a>
A szegmensért a JatekosGep (`JatekosGep.cs`) osztály felel. Ezen osztály teszi lehetővé a gép ellen történő - egyszemélyes - játékot. Az osztály statikus hiszen a példányok létrehozása egy felesleges lépés lenne, amely memória-pazarlást is jelentene.

##### 2.1.1 Részei
<a id="markdown-r%C3%A9szei" name="r%C3%A9szei"></a>
`map` - karakterekből álló mátrix
Ezen változón keresztül látja az osztály a térképet.
`makeMove()` - eljárás
Ezen eljárás felel a gép lépéseinek generálásáért, valamint azok helyzetének kijelöléséért

Az első for ciklus feltölti az előzetesen létrehozott dictionary-t a jelenleg elérhető cellák karaktereivel, valamint azok darabszámával

Az itt létrehozott véletlenszerű változók (`character`, `amount`, `skip`) alapján választjuk ki a cellákat

A második for ciklus kijelöli a kisorsolt cellákat, amelyeket így a `JatekEllenor()` véglegesíthet

### 3. Játéktér
<a id="markdown-j%C3%A1t%C3%A9kt%C3%A9r" name="j%C3%A1t%C3%A9kt%C3%A9r"></a>

A JatekForm (játéktér) a lelke az egész programnak. Itt játszhatják le a játékosok (vagy a gép és egy játékos) a meccseket. Áll egy táblázatból (DataGridView elem), egy gombból, amellyel hitelesíteni lehet a lépést (be van rá kötve a Space gomb lenyomása ugyanarra az eseményre), valamint egy címke, ami nyilván tartja, hogy éppen melyik játékos következik.

A játéktér legfőbb osztálya a `JatekMenedzser` osztály, ami számontartja a játékosok statisztikáit, ellenőrzi, hogy a lépés amit a felhasználó lépni kíván az érvényes-e. Emellett felelős azért, hogy a pályát kirenderelje (kirajzolja).\
Fontosabb metódusai:
- `Render()` - kirendereli a pályát
- `JatekEllenor()` - ellenőrzi, hogy érvényes-e a lépés, kezeli azt ha vége van a játéknak
- `KijelolesTorlese()` - törli a felhasználó kijelölését a játéktérben

<br><br><br><br><br>

### 4. Pop-it! - hub
<a id="markdown-pop-it!---hub" name="pop-it!---hub"></a>

A Hub form segítségével tudunk pályákat letölteni a Hubról magáról. Ez a form is használja a `logger` osztályt, valamint van egy `MapObject` osztályunk létrehozva itt, ami azt a célt szolgálja, hogy a lekért pályáknak a neveit és linkjeit objektumokba foglaljuk és úgy írassuk ki a ListBox-ba azokat. A `MapObject` osztály:

```csharp
public class MapObject
{
    public int Id { get; set; }
    public string MapName { get; set; }
    public string MapUrl { get; set; }
    public MapObject(string[] row)
    {
        Id = Convert.ToInt32(row[0]);
        MapName = row[1].Trim();
        MapUrl = row[2];
    }
}
```

A Hub form konstruktorában történik a Hub tartalmának lekérése, feldolgozása, kiiratása.

A *Letöltés* gomb eljárása (`btn_letoltes_Click()`) elindítja a fájl letöltését, valamint további eseményeket definiálunk. Ezek a `WebClient` osztály `DownloadProgressChanged` és `DownloadFileCompleted` eseményei. Mint azt olvashatjuk, az egyik esemény a letöltés állapotának változásakor (például a letöltött adatmennyiség változása) és a fájl letöltésekor lefutó események.\
Az előbbihez társuló eljárás a formon található ProgressBar-t viszi előre, valamint tájékoztat a letöltött adatmennyiségről, az utóbbi pedig kiírja, ha elkészült a letöltés.

```csharp
void client_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
{
    double bytesIn = double.Parse(e.BytesReceived.ToString());
    double totalBytes = double.Parse(e.TotalBytesToReceive.ToString());
    double percentage = bytesIn / totalBytes * 100;
    lbl_download_status.Text = "Letöltve: " + e.BytesReceived + " / " + e.TotalBytesToReceive;
    pbar_status.Value = int.Parse(Math.Truncate(percentage).ToString());
}
void client_DownloadFileCompleted(object sender, AsyncCompletedEventArgs e)
{
    lbl_download_status.Text = "Letöltve!";
    
}
```

A *Feltöltés* gomb megnyitja a hoszt gép alapértelmezett böngészőjében a Hub weboldalát. A jövőben akár lehet integrálni a szoftverbe a feltöltést.

<br><br><br><br><br>

### 5. Többször felhasznált osztályok
<a id="markdown-t%C3%B6bbsz%C3%B6r-felhaszn%C3%A1lt-oszt%C3%A1lyok" name="t%C3%B6bbsz%C3%B6r-felhaszn%C3%A1lt-oszt%C3%A1lyok"></a>

#### 5.1 Logger
<a id="markdown-logger" name="logger"></a>

A `logger` osztály felelős azért, hogy a játék közben előforduló hibákat és egyéb adatokat naplózzon.

```csharp
public class Logger
{
    private string LogFile;
    public Logger(string File_name)
    {
        LogFile = File_name;
    }
    public void LogError(string Message)
    {
        File.AppendAllText(LogFile, $"[Error] {Message}\n\r");
    }
    public void LogDebug(string Message)
    {
        File.AppendAllText(LogFile, $"[Debug] {Message}\n\r");
    }
}
```

#### 5.2 Palya
<a id="markdown-palya" name="palya"></a>

A `palya` osztályt adattároláshoz használjuk a programban. Ez felel azért, hogy a pályáinkat strukturáltan tárolhassuk a listánkban.

```csharp
public class Palya
{
    public int id { get; set; }
    public string palya_neve { get; set; }
    public char[,] palya { get; set; }
    public Palya(int ID, string PALYA_NEVE, char[,] PALYA)
    {
        id = ID;
        palya_neve = PALYA_NEVE;
        palya = PALYA;
    }
}
```

<br><br><br><br><br><br><br><br><br>

#### 5.3 Szinek
<a id="markdown-szinek" name="szinek"></a>

A `szinek` osztály felel azért, hogy mindenhol ugyanazokat a színeket érjük el, ugyanabból a listából.

```csharp
using System.Drawing;

internal class Szinek
{
    public Dictionary<char, Color> szinkodok = new Dictionary<char, Color>();
    public Szinek()
    {
        szinkodok.Add('a', Color.AliceBlue);
        szinkodok.Add('b', Color.FromArgb(255, 180, 211, 178));
        szinkodok.Add('c', Color.Beige);
        szinkodok.Add('d', Color.FromArgb(255, 248, 234, 252));
        ...
    }
}
```

## II. Pop-it! generátor
<a id="markdown-ii.-pop-it!-gener%C3%A1tor" name="ii.-pop-it!-gener%C3%A1tor"></a>

### Bevezetés
<a id="markdown-bevezet%C3%A9s" name="bevezet%C3%A9s"></a>

A szegmens teljes egészéért a PalyaGenerator (`Palyagenerator.cs`) osztály felel. Ezen statikus osztály önálló modulként képes generálni pályákat, amelyekkel a `Palya` osztály által meghatározott formátumban vissza is tud térni. A `General()` függvény 3 paramétere alapján 4-től 10-ig bármekkora pálya generálható, melynek indexe, neve valamint hajlításainak száma is szabadon változtatható. Ezt 4 privát eljárással valósítja meg.

### Eljárások és változók
<a id="markdown-elj%C3%A1r%C3%A1sok-%C3%A9s-v%C3%A1ltoz%C3%B3k" name="elj%C3%A1r%C3%A1sok-%C3%A9s-v%C3%A1ltoz%C3%B3k"></a>

 - `mod` - <span class="system">int</span> változó
    - meghatározza a jelenleg használt karaktert, amely a hajlított vonalakhoz elengedhetetlen
- `Direction` - <span class="system">int</span> változó
    - 1 és 4 közti értékeket vehet fel
    - meghatározza a `KanyarGen()`-ben lévő `step()` függvény haladási irányát
- `KanyarGen()`
    - Az üres pályára ezen függvény helyezi el a hajlított vonalakat
    - Az egy vonalon lévő hajlítások száma itt történik kisorsolásra
    - Rendelkezik 2 belső függvénnyel, ezek a `step()` valamint az `isIdentical()` néven hívhatók meg
    - Lépésenként valósítja meg a vonalak generálását
    - Véletlenszerű mennyiségben lép, majd fordul
    - Amennyiben egy már létező vonalba fut, a `mod` változót növeli, majd elhalad alatta. Ezzel biztosítva, hogy nem létezik 2 ugyan olyan karakterrel rendelkező, nem összekötött sor
- `Feltolt()`
    - A függvény, amely egy hajlított vonalakkal rendelkező mátrixot lát el triviális karakterekkel (jobbról balra haladó vonalak)
    - Amennyiben egy már elhelyezett, hajlított vonalba fut bele, a `mod` változó növelésével áthalad "alatta"
    <br><br><br><br><br>
- `Minimalise()`
    - Ezen függvény megjelenítési célból jött létre. Célja a `Kanyarhen()` által végrehajtott esetlegesen felesleges `mod` növelések eltűnjenek, valamint bal felső sarokból abc sorrendben osztja ki a karaktereket
- `toChar()`
    - Az eddig használt számokat konvertálja át ASCII karakterekké

## III. Pop-it! hub
<a id="markdown-iii.-pop-it!-hub" name="iii.-pop-it!-hub"></a>

### 1. Felhasznált technológiák, könyvtárak
<a id="markdown-felhaszn%C3%A1lt-technol%C3%B3gi%C3%A1k%2C-k%C3%B6nyvt%C3%A1rak" name="felhaszn%C3%A1lt-technol%C3%B3gi%C3%A1k%2C-k%C3%B6nyvt%C3%A1rak"></a>

A Pop-it! hub webes része egy PHP alapokon nyugvó webalkalmazás (kiegészülve természetesen a HTML technológiával).\
A backendünk nem használ semmilyen speciális könyvtárat, csak és kizárólag a PHP beépített eljárásait és függvényeit alkalmazza.\
Megjelenítéshez a Bootstrap 5 CSS, a hozzá tartozó JavaScript és jQuery könyvtárakat alkalmaztuk.

### 2. Az oldal struktúrája
<a id="markdown-az-oldal-strukt%C3%BAr%C3%A1ja" name="az-oldal-strukt%C3%BAr%C3%A1ja"></a>

#### 2.1. Felépítése
<a id="markdown-fel%C3%A9p%C3%ADt%C3%A9se" name="fel%C3%A9p%C3%ADt%C3%A9se"></a>

Az oldal hierarchiája a következő:
```
├── palyak/
│   ├── 37810fa01a36262625ad6650ef8c4275eb7e7229.txt
│   ├── 25414fa01a36123123225ad6621eb9c4275eb7c9992.txt
│   └── ...
├── pre/
│   ├── feltoltott_1.txt
│   ├── feltoltott_2.txt
│   └── ...
├── index.php
├── palya_feltoltes.php
└── palyak-lista.php
```

#### 2.2. Részei
<a id="markdown-r%C3%A9szei" name="r%C3%A9szei"></a>

Az `index.php` oldal szolgálja ki a főoldalt, amelyen lehetőségünk van feltölteni a térképet.

A `palya_feltoltese.php` oldal intézi a fájlok feltöltését a szerverre, valamint azok ellenőrzését.

A `palyak-lista.php` szkript pedig visszaadja nekünk a pályák listáját. **Figyelem!** Ezt mi nem használjuk, csak és kizárólag a kliens szedi ebből az adatait. (Kicsit olyan, mint egy API, kivéve, hogy formailag nem követ semmilyen szabványt.)

<br><br><br><br><br><br><br><br><br><br><br>

### 3. Az oldal működése
<a id="markdown-az-oldal-m%C5%B1k%C3%B6d%C3%A9se" name="az-oldal-m%C5%B1k%C3%B6d%C3%A9se"></a>

Az oldal felhasználók által is látható működését már részletesen ledokumentáltuk a felhasználói dokumentációban (II./2. fejezet), így itt arra nem térnénk ki, viszont a motorháztető alatti működését tekintsük át.

#### 3.1. A pályafeltöltés menete
<a id="markdown-a-p%C3%A1lyafelt%C3%B6lt%C3%A9s-menete" name="a-p%C3%A1lyafelt%C3%B6lt%C3%A9s-menete"></a>

Az `index.php` által kiszolgált felületen ki kell választani a fájlt, amit fel akarunk tölteni. Ezt egy POST request keretében továbbadja a `palya_feltoltese.php` oldalnak/szkriptnek. Ekkor sorrendben a következők történnek:
- Létrehozza a szkript az esetlegesen jó pályának a randomizált nevét (ezt `random_bytes()` és `bin2hex()` függvényekkel érjük el)
- Ellenőrzi, hogy a fájl kiterjesztése txt vagy sem. Amennyiben nem, akkor már bukottnak jelöli a feltöltést. Ennek megfelelően megjelenik egy hibaüzenet
- Ha az előző ellenőrzésen átment a fájl, akkor azt egy ideiglenes mappába, a `pre/` mappába felmásolja. Majd arra a fájlra meghívja a `fileCheck()` eljárásunkat. Az alábbi ellenőrzéseket futtatja le:
    - Ellenőrzi, hogy a térkép dimenziói megegyeznek-e (x;y), ha nem akkor elbukik a teszt.
    - Ellenőrzi, hogy a fájl a dimenzióknak megfelelő mennyiségű sor van-e a fájlban, ha nem akkor elbukik a teszt.
    - Ellenőrzi, hogy a fájl a dimenzióknak megfelelő mennyiségű oszlop van-e az egyes sorokban, ha nem akkor elbukik a teszt.
    - Ellenőrzi, hogy a fájlnak a neve, tartalmaz-e speciális karaktert. Amennyiben igen, úgy elbukik a teszt.
    - Végezetül, ellenőrzi, hogy található-e a listánkban már ugyanolyan nevű pálya (a fájl első sora!). Amennyiben igen, úgy elbukik a teszt.
- Amennyiben a fájl ellenőrzés is lefutott rendben, akkor a már random generált fájlnevünknek megfelelően áthelyezi a `palyak/` mappába.
- Amennyiben minden tesztünk sikeres volt és a fájlt is átmásolta, egy zöld keretben pozitív üzenet jelenik meg.

#### 3.2. Pályák lekérdezése
<a id="markdown-p%C3%A1ly%C3%A1k-lek%C3%A9rdez%C3%A9se" name="p%C3%A1ly%C3%A1k-lek%C3%A9rdez%C3%A9se"></a>

A pályákat a kliens a `palyak-lista.php` fájl meghívásával tudja lekérni. A lekérdezésben visszatérő lista pontosvesszővel elválasztva adja vissza a pálya azonosítóját, nevét és elérhetőségét. Azok alapján tudja a kliens kilistázni és letölteni a pályákat.

Példa egy ilyen lekérdezés eredményére:
```
2;palya_vivi;https://dev.ruzger.hu/dusza/palyak/37810fa01a36262625ad6650ef8c4275eb7e7229.txt
3;palya_asd;https://dev.ruzger.hu/dusza/palyak/8845a0afbae063cd96048f136bb41036ec86876d.txt
```

Fontos megjegyezni, hogy a pálya azonosítója relatív, a fájlok sorrendjétől függ. Például, tegyük fel, hogy van egy `a.txt`, `b.txt` és egy `c.txt` nevű fájlunk. Ebben az esetben az alábbi mintát fogja követni a listázásunk: **(0 -> ., 1 -> ..,) 2 -> a.txt, 3 -> b.txt, 4 -> c.txt** \
Viszont ha kitöröljük a `b.txt` fájlunkat akkor: **(0 -> ., 1 -> ..,) 2 -> a.txt, 3 -> c.txt** a sorrend

<div style="width:100%; height:106px"></div>