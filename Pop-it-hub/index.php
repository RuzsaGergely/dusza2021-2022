<!DOCTYPE html>
<html lang="hu">
<head>
    <meta charset="UTF-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Pop-it hub - by Csodacsapat</title>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.1.3/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-1BmE4kWBq78iYhFldvKuhfTAU6auU8tT94WrHftjDbrCEXSU1oBoqyl2QvZ6jIW3" crossorigin="anonymous">
</head>
<body>
    <nav class="navbar navbar-light bg-light">
    <div class="container-fluid">
        <span class="navbar-brand mb-0 h1">Pop-it! hub - by Csodacsapat</span>
    </div>
    </nav>
    <div class="container">
        <div class="row">
            <div class="col mt-3">
                <div class="card">
                    <div class="card-body">
                        <h2 class="text-center">Pop-it! hub - pálya feltöltés</h2>
                        <p>Van egy tök jó pályád amit a generátorunkkal csináltál? Esetleg szabadkézzel írtál egyet? Akkor itt most fel tudod tölteni a rendszerünkbe, hogy minden játékosunk kipróbálhassa!</p>
                        <p>A feltöltés menetéről és az állományok formai követelményeiről lentebb olvashatsz! Kérünk, tedd meg, hiszen ha a fájlod nem felel meg, nem megy át a szűrőinken!</p>
                    </div>
                </div>
            </div>
        </div>
        <div class="row">
            <div class="col mt-3">
                <div class="card">
                    <div class="card-body">
                    <form action="palya_feltoltes.php" method="post" enctype="multipart/form-data" id="form">
                        <div class="mb-3">
                            <label for="formFile" class="form-label">Feltöltendő pálya fájlja:</label>
                            <input class="form-control" type="file" id="fileToUpload" name="fileToUpload">
                        </div>
                        <button type="submit" class="btn btn-success">Feltöltés</button>
                        </form>
                    </div>
                </div>
            </div>
        </div>
        <div class="row">
            <div class="col mt-3">
                <div class="card">
                    <div class="card-body">
                        <h2>Feltöltés menete</h2>
                        <ol>
                            <li>Gyárts egy térképet ami megfelel a specifikációinknak (lásd lentebb)</li>
                            <li>Az oldalunkon válaszd ki a fájlt és nyomj rá a feltöltés gombra</li>
                            <li>Amennyiben a térképed megfelelt a formai követelményeknek, a térképed elérhető a kínálatunkban!</li>
                        </ol>
                    </div>
                </div>
            </div>
        </div>
        <div class="row">
            <div class="col mt-3">
                <div class="card">
                    <div class="card-body">
                        <h2>Formai követelmények (specifikáció)</h2>
                        <ul>
                            <li>A fájlnak <strong>.txt</strong> kiterjesztésűnek kell lennie!</li>
                            <li>A fájl első sora tartalmazza a pálya nevét. <strong>Figyelem!</strong> Ennek a névnek egyedinek kell lennie! Amennyiben egy már létező pályának a nevét használja fel, úgy a rendszer visszadobja a feltöltött állományt!</li>
                            <li>A fájl második sora tartalmazza a pálya dimenzióit <strong>x;y</strong> formában.</li>
                            <li>A fájl további részében a második sorban leirtaknak megfelelő sorok és oszlopok következnek. Ez maga a pálya amivel a játékosok játszhatnak. Színkód könyvtárunk jelenleg <strong>105</strong> féle karaktert támogat.</li>
                        </ul>
                        <h2>Példák:</h2>
                        <div class="row mt-3">
                            <div class="col">
                                <div class="card">
                                    <div class="card-body text-light" style='background-color: #3bd14a'>
                                        palya_ok1<br>
                                        5;5<br>
                                        ABCCC<br>
                                        DBEEE<br>
                                        FBGGG<br>
                                        HIIII<br>
                                        JKLLI<br>
                                    </div>
                                </div>
                            </div>
                            <div class="col">
                                <div class="card">
                                    <div class="card-body text-light" style='background-color: #3bd14a'>
                                    palya_ok2<br>
                                    5;5<br>
                                    AABCDEEEEE<br>
                                    FFBGDHHHHH<br>
                                    IIBJDKKKKK<br>
                                    LLBMDNNNNN<br>
                                    OOBDDNPPPP<br>
                                    </div>
                                </div>
                            </div>
                            <div class="col">
                                <div class="card">
                                    <div class="card-body text-light" style='background-color: #d6475a'>
                                        palya_bad1<br>
                                        10;5<br>
                                        ABCCC<br>
                                        DBEEE<br>
                                        FBGGG<br>
                                        HIIII<br>
                                        JKLLI<br>
                                    </div>
                                </div>
                            </div>
                            <div class="col">
                                <div class="card">
                                    <div class="card-body text-light" style='background-color: #d6475a'>
                                        palya_bad2<br>
                                        ABCCC<br>
                                        DBEEE<br>
                                        FBGGG<br>
                                        HIIII<br>
                                        JKLLI<br>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div class="row">
            <div class="col mt-3 mb-3">
                <div class="card">
                    <div class="card-body">
                       <h2>Aktuálisan elérhető pályáink:</h2>
                        <?php
                            $folder    = './palyak';
                            $files = scandir($folder);
                            $host = "https://$_SERVER[HTTP_HOST]";
                            foreach ($files as $key => $value) {
                                if($value != ".." && $value != "."){
                                    $f = fopen("palyak/".$value, 'r');
                                    $line = trim(fgets($f));
                                    fclose($f);
                                    echo "<a href='$host/dusza/palyak/$value'>$key - " . htmlspecialchars($line)."</a><br>";
                                }
                            }
                        ?>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.1.3/dist/js/bootstrap.bundle.min.js" integrity="sha384-ka7Sk0Gln4gmtz2MlQnikT1wXgYsOg+OMhuP+IlRH9sENBO0LRn5q+8nbTov4+1p" crossorigin="anonymous"></script>
    <script src="https://cdn.jsdelivr.net/npm/jquery@3.6.0/dist/jquery.min.js"></script>
    <script>
        $(function() {
        $('form').submit(function() {
            if(!$("form input[type=file]").val()) {
                alert('Kérlek válassz fájlt!');
                return false;
            }
        });
        });
    </script>
</body>
</html>