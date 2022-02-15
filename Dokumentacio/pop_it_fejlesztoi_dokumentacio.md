# Pop-it! fejlesztői dokumentáció
A Csodacsapat által fejlesztett Pop-it! implementáció C# nyelven, Windows Forms-ban készült. Pop-It! hub ami a szoftver kiegészítő társa pedig PHP nyelven íródott. Ez a dokumentáció a fejlesztőknek szól!

## I. Pop-it! kliens

## II. Pop-it! generátor

## III. Pop-it! hub
### 1. Felhasznált technológiák, könyvtárak

A Pop-it! hub webes része egy PHP alapokon nyugvó webalkalmazás (kiégészülve természetesen a HTML technológiával).\
A backendünk nem használ semmilyen speciális könyvtárat, csak és kizárólag a PHP beépített eljárásait és függvényeit alkalmazza.\
Megjelenítéshez a Bootstrap 5 CSS, a hozzá tartozó JavaScript és jQuery könyvtárakat alkalmaztuk.

### 2. Az oldal strukúrája

### 2.1. Felépítése

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

### 2.2. Részei

Az `index.php` oldal szolgálja ki a főoldalt, amelyen lehetőségünk van feltölteni a térképet.

A `palya_feltoltese.php` oldal intézi a fájlok feltöltését a szerverre, valamint azok ellenőrzését.

A `palyak-lista.php` szkript pedig visszaadja nekünk a pályák listáját. **Figyelem!** Ezt mi nem használjuk, csak és kizárólag a kliens szedi ebből az adatait. (Kicsit olyan mint egy API, kivéve, hogy formailag nem követ semmilyen szabványt.)

### 3. Az oldal működése

Az oldal felhasználók által is látható működését már részletesen ledokumentáltuk a felhasználói dokumentációban (II./2. fejezet), így itt arra nem térnénk ki, viszont a motorháztető alatti működését tekintsük át.

### 3.1. A fájlfeltöltés menete