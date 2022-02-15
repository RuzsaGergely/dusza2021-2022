<style>
.system {
    color: rgb(216, 160, 223);
}
</style>

# Pop-it! fejlesztői dokumentáció

A Csodacsapat által fejlesztett Pop-it! implementáció C# nyelven, Windows Forms-ban készült. Pop-It! hub ami a szoftver kiegészítő társa pedig PHP nyelven íródott. Ez a dokumentáció a fejlesztőknek szól!

## I. Pop-it! kliens

### 1. Menü

A menü a nyitó eleme a programunknak, a felszínen csak gombokat látunk, amelyek különböző, más funkcióval bíró formokat nyitnak meg. Ennél többet tényleg nem is csinál a menü, kivéve azt az egyet, hogy a form elindulásakor ellenőrzi, hogy a `palyak` nevű mappa létezik-e. Amennyiben nem, úgy legyártja. Valamint logolja, hogy ez megtörtént (a `logger` osztályról az 5. fejezetben olvashat).

```csharp
if (!Directory.Exists("palyak"))
{
    Directory.CreateDirectory("palyak");
    logger.LogDebug($"Palyak mappa elkészítve");
}
```

### 2. Pályaválasztó

A pályaválasztó ablakkal/formmal van lehetőségünk pályát választani, majd elindítani a játékot vele.\
Ezen a formon van egy ListBox ami a pályák neveit tárolja, egy előnézeti ablak ami piciben betölti a pályát. Emellett van egy CheckBox elem, amivel előre definiálni tudjuk, hogy egy másik játékos ellen vagy a gép ellen akarunk játszani.

Ez a form is rendelkezik egy példánnyal a `logger` osztályból a logolás végett. Emellett van egy példány a `szinek` osztályból, amivel szineket tudunk kérni az egyes karaktereknek (ez a preview miatt érdekes).

Fontosabb eljárások a `PalyakBeolvasas()` ami a pályákat olvassa be a mappából és listázza ki, valamint állítja össze belőle a listánkat a pályákról (ehhez a `palya` osztályt használja a lista), a `JatekIndit()` ami átadja a pályát a JatekForm-nak (Játéktér). A `listbox_palyak_SelectedIndexChanged()` esemény bázisú eljárásunk felelős azért, hogy a pálya kiválasztásakor a preview ki legyen rajzolva.

**Megjegyzés**: a preview, akár csak a Játéktér, DataGridView elemként jelenik meg, tehát gyakorlatban egy táblázatot renderelünk ki.

#### 2.1 Gép elleni játék
A szegmensért a JatekosGep (`JatekosGep.cs`) osztály felel. Ezen osztály teszi lehetővé a gép ellen történő - egyszemélyes - játékot. Az osztály statikus hiszen a példányok létrehozása egy felesleges lépés lenne amely memória-pazarlást is jelentene.

##### 2.1.1 Részei
`map` - karakterekből álló mátrix
Ezen változón keresztül látja az osztály a térképet.
`makeMove()` - eljárás
Ezen eljárás felel a gép lépéseinek generálásáért, valamint azok helyzetének kijelöléséért

Az első for ciklus feltölti az előzetesen létrehozott dictionary-t a jelenleg elérhető cellák karaktereivel, valamint azok darabszámával

Az itt létrehozott véletlenszerű változók (`character`, `amount`, `skip`) alapján választjuk ki a cellákat

A második for ciklus kijelöli a kisorsolt cellákat, amelyeket így a `JatekEllenor()` véglegesíthet

### 3. Játéktér

A JatekForm (játéktér) a lelke az egész programnak. Itt játszhatják le a játékosok (vagy a gép és egy játékos) a meccseket. Áll egy táblázatból (DataGridView elem), egy gombból, amellyel hitelesíteni lehet a lépést (be van rá kötve a Space gomb lenyomása ugyanarra az eseményre), valamint egy címke ami nyilván tartja, hogy éppen melyik játékos következik.

A játéktér legfőbb osztálya a `JatekMenedzser` osztály, ami számon tartja a játékosok statisztikáit, ellenőrzi, hogy a lépés amit a felhasználó lépni kíván az érvényes-e. Emellett felelős azért, hogy a pályát kirenderelje (kirajzolja).\
Fontosabb metódusai:
- `Render()` - kirendereli a pályát
- `JatekEllenor()` - ellenőrzi, hogy érvényes-e a lépés, kezeli azt ha vége van a játéknak
- `KijelolesTorlese()` - törli a felhasználó kijelőlését a játéktérben

### 4. Pop-it! - hub

A Hub form segítségével tudunk tudunk pályákat letölteni a Hubról magáról. Ez a form is használja a `logger` osztályt, valamint van egy `MapObject` osztályunk létrehozva itt, ami azt a célt szolgálja, hogy a lekért pályáknak a neveit és linkjeit objektumokba foglaljuk és úgy irassuk ki a ListBox-ba azokat. A `MapObject` osztály:

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

### 5. Többször felhasznált osztályok

## II. Pop-it! generátor

### Bevezetés

A szegmens teljes egészéért a PalyaGenerator (`Palyagenerator.cs`) osztály felel. Ezen statikus osztály önálló modulként képes generálni pályákat, amelyekkel a `Palya` osztály által meghatározott formátumban vissza is tud térni. A `General()` függvény 3 paramétere alapján 4-től 10-ig bármekkora pálya generálható, melynek indexe, neve valamint hajlításainak száma is szabadon változtatható. Ezt 4 privát eljárással valósítja meg.

### Eljárások és változók

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
- `Minimalise()`
    - Ezen függvény megjelenítési célból jött létre. Célja a `Kanyarhen()` által végrehajtott esetlegesen felesleges `mod` növelések eltűnjenek, valamint bal felső sarokból abc sorrendben növekvő sorredben osztja ki a karaktereket
- `toChar()`
    - Az eddig használt számokat konvertálja át ASCII karakterekké

## III. Pop-it! hub
### 1. Felhasznált technológiák, könyvtárak

A Pop-it! hub webes része egy PHP alapokon nyugvó webalkalmazás (kiégészülve természetesen a HTML technológiával).\
A backendünk nem használ semmilyen speciális könyvtárat, csak és kizárólag a PHP beépített eljárásait és függvényeit alkalmazza.\
Megjelenítéshez a Bootstrap 5 CSS, a hozzá tartozó JavaScript és jQuery könyvtárakat alkalmaztuk.

### 2. Az oldal strukúrája

#### 2.1. Felépítése

Az oldal hiearchiája a következő:
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

Az `index.php` oldal szolgálja ki a főoldalt, amelyen lehetőségünk van feltölteni a térképet.

A `palya_feltoltese.php` oldal intézi a fájlok feltöltését a szerverre, valamint azok ellenőrzését.

A `palyak-lista.php` szkript pedig visszaadja nekünk a pályák listáját. **Figyelem!** Ezt mi nem használjuk, csak és kizárólag a kliens szedi ebből az adatait. (Kicsit olyan mint egy API, kivéve, hogy formailag nem követ semmilyen szabványt.)

### 3. Az oldal működése

Az oldal felhasználók által is látható működését már részletesen ledokumentáltuk a felhasználói dokumentációban (II./2. fejezet), így itt arra nem térnénk ki, viszont a motorháztető alatti működését tekintsük át.

#### 3.1. A pályafeltöltés menete

Az `index.php` által kiszolgált felületen ki kell választani a fájlt amit fel akarunk tölteni. Ezt egy POST request keretében továbbadja a `palya_feltoltese.php` oldalnak/szkriptnek. Ekkor sorrendben a következők történnek:
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

A pályákat a kliens a `palyak-lista.php` fájl meghívásával tudja lekérni. A lekérdezésben visszatérő lista pontosvesszővel elválasztva adja vissza a pálya azonosítóját, nevét és elérhetőségét. Azok alapján tudja a kliens kilistázni és letölteni a pályákat.

Példa egy ilyen lekérdezés eredményére:
```
2;palya_vivi;https://dev.ruzger.hu/dusza/palyak/37810fa01a36262625ad6650ef8c4275eb7e7229.txt
3;palya_asd;https://dev.ruzger.hu/dusza/palyak/8845a0afbae063cd96048f136bb41036ec86876d.txt
```

Fontos megjegyezni, hogy a pálya azonosítója relatív, a fájlok sorrendjétől függ. Például, tegyük fel, hogy van egy `a.txt`, `b.txt` és egy `c.txt` nevű fájlunk. Ebben az esetben az alábbi mintát fogja követni a listázásunk: **(0 -> ., 1 -> ..,) 2 -> a.txt, 3 -> b.txt, 4 -> c.txt** \
Viszont ha kitöröljük a `b.txt` fájlunkat akkor: **(0 -> ., 1 -> ..,) 2 -> a.txt, 3 -> c.txt** a sorrend 