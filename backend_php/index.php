<?php
route();

function route(){
    $method = "index";
    $parameter = array();
    
    $path = '';
    if(isset($_SERVER['PATH_INFO']))
        $path = $_SERVER['PATH_INFO'];
    $path = trim($path, '/');
    if($path != ''){
        $segment = explode('/', $path);
        $method = $segment[0];
        $parameter = array_slice($segment, 1);
    }
    if(!function_exists($method)){
        header($_SERVER['SERVER_PROTOCOL'] . " 404 Not Found");
        echo "<h1>Function not found!</h1>";
        die();
    }
    call_user_func($method, $parameter);
}

function index(){
    echo "<h1>Selamat datang di Fake API PHP</h1>";
    $base_url = "http://" . $_SERVER['SERVER_NAME'] . ":" . $_SERVER['SERVER_PORT'] . "/index.php";
    echo "<a href='". $base_url ."/books'>Data Buku</a>";
}

function books(){
    header('Content-Type : application/json');
    echo file_get_contents(dirname(__FILE__) . '/books.json');
}

function bookdetail($parameter) {
    $f = dirname(__FILE__) . '/book_' . $parameter[0] . '.json';
    if(file_exists($f)) {
        header($_SERVER['SERVER_PROTOCOL'] . " 200 OK");
        header('Content-Type : application/json');
        echo file_get_contents($f);
    } else {
        header($_SERVER['SERVER_PROTOCOL'] . " 404 Not Found");
        echo "<h1>File not found!</h1>";
    }
}

function login() {
    $konten = file_get_contents('php://input');
    $data = json_decode($konten, true);
    $user = $data["userName"];
    $passwd = $data["passwd"];

    $response = array(
        'status' => false,
        'user' => '',
        'token' => ''
    );

    if($user == 'ekoheri@gmail.com' && $passwd == 'asd') {
        $response = array(
            'status' => true,
            'user' => $user,
            'token' => '123456789'
        );
    }
    echo json_encode($response);
}
?>
