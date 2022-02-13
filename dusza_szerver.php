<?php
$mappa    = './palyak';
$fajlok = scandir($mappa);
$host = "https://$_SERVER[HTTP_HOST]";

foreach ($fajlok as $key => $value) {
    echo "$key;$value;$host/dusza/palyak/$value\n";
}