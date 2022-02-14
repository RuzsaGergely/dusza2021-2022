<?php
$folder    = './palyak';
$files = scandir($folder);
$host = "https://$_SERVER[HTTP_HOST]";

foreach ($files as $key => $value) {
    if($value != ".." && $value != "."){
        $f = fopen("palyak/".$value, 'r');
        $line = trim(fgets($f));
        fclose($f);
        echo "$key;$line;$host/dusza/palyak/$value\n";
    }
}