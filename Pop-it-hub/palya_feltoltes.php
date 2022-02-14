<!DOCTYPE html>
<html lang="hu">
<head>
    <meta charset="UTF-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Pop-it hub [feltöltés]- by Csodacsapat</title>
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
    <?php
    if($_SERVER["REQUEST_METHOD"] == "POST"){
        $target_dir = "palyak/";
        $random_name = bin2hex(random_bytes(20));
        $target_file = $target_dir . basename($random_name . ".txt");
        $check_dir = "pre/";
        $check_file = $check_dir . basename($_FILES["fileToUpload"]["name"]);
        $uploadOk = 1;
        $fileType = strtolower(pathinfo($target_file,PATHINFO_EXTENSION));

        if($fileType != "txt") {
            echo "<div class=\"card\"><div class=\"card-body text-light\" style='background-color: #d6475a'>Csak .txt kiterjesztésű állományok fogadhatóak el!</div></div>";
            $uploadOk = 0;
        }
        
        if ($uploadOk == 0) {
            echo "<div class=\"card\"><div class=\"card-body text-light\" style='background-color: #d6475a'>A feltöltött fájlod valamely specifikációnknak nem felelt meg. Kérlek javítsd ki a fájlodat és próbáld meg újra!</div></div>";
        } else {
            if (move_uploaded_file($_FILES["fileToUpload"]["tmp_name"], $check_file)) {
                $fileFormatOK = fileCheck($check_file);

                if($fileFormatOK == 1){
                    if(rename($check_file, $target_file)){
                        echo "<div class=\"card\"><div class=\"card-body text-light\" style='background-color: #3bd14a'>Sikeres feltöltés!</div></div>";
                    } else {
                        echo "<div class=\"card\"><div class=\"card-body text-light\" style='background-color: #d6475a'>Elnézést, rendszerhiba történt. Próbáld meg újra!</div></div>";
                    }
                } else {
                    echo "<div class=\"card\"><div class=\"card-body text-light\" style='background-color: #d6475a'>A feltöltött fájlod valamely specifikációnknak nem felelt meg. Kérlek javítsd ki a fájlodat és próbáld meg újra!</div></div>";
                    unlink($check_file);
                }
            } else {
                echo "<div class=\"card\"><div class=\"card-body text-light\" style='background-color: #d6475a'>Elnézést, rendszerhiba történt. Próbáld meg újra!</div></div>";
            }
        }
    }

    function fileCheck($file){
        $return_value = 1;
        $file_lines = explode("\n", file_get_contents($file));
        $map_size = explode(";", $file_lines[1]);
        if(intval($map_size[0]) != intval($map_size[1])){
            $return_value = 0;
            echo "<div class=\"card\"><div class=\"card-body text-light\" style='background-color: #d6475a'>A térkép dimenziói nem egyeznek meg!</div></div>";
        }
        $trimmed_array = array_filter(array_map('trim', $file_lines));
        if(count($trimmed_array)-2 != intval($map_size[0])){
            $return_value = 0;
            echo "<div class=\"card\"><div class=\"card-body text-light\" style='background-color: #d6475a'>A térkép sorainak száma nem egyezik meg!</div></div>";
        }
        for ($i=2; $i < count($trimmed_array); $i++) {
            if((strlen($trimmed_array[$i]) != intval($map_size[1])) || empty($trimmed_array[$i])){
                $return_value = 0;
                echo "<div class=\"card\"><div class=\"card-body text-light\" style='background-color: #d6475a'>A térkép oszlopainak száma nem egyezik meg!</div></div>";
                break;
            }
        }
        $folder    = './palyak';
        $files = scandir($folder);
        $map_names = array();
        foreach ($files as $key => $value) {
            if($value != ".." && $value != "."){
                $f = fopen("palyak/".$value, 'r');
                $line = trim(fgets($f));
                fclose($f);
                array_push($map_names, $line);
            }
        }
        if (in_array(trim($file_lines[0]), $map_names)) {
            echo "<div class=\"card\"><div class=\"card-body text-light\" style='background-color: #d6475a'>Ez a pályanév foglalt, kérlek nevezd át a pályádat a fájlban!</div></div>";
            $return_value = 0;
        }
        return $return_value;
    }
    ?>
                        <div class="text-center mt-3">
                            <a class="btn btn-success" href="index.php" role="button">Visszatérés a főoldalra!</a>
                        </div>   
                    </div>
                </div>
            </div>
        </div>
    </div>
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.1.3/dist/js/bootstrap.bundle.min.js" integrity="sha384-ka7Sk0Gln4gmtz2MlQnikT1wXgYsOg+OMhuP+IlRH9sENBO0LRn5q+8nbTov4+1p" crossorigin="anonymous"></script>
</body>
</html>