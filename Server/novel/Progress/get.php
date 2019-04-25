<?php

//Make sure that it is a GET request.
if(strcasecmp($_SERVER['REQUEST_METHOD'], 'GET') != 0){
	throw new Exception('Request method must be GET!');
}

require_once('../DB.php');

$headers = apache_request_headers();
$id = $headers['Authorization'];

function GetSaveData($conn,$id) {
	$sql = "SELECT `save_data` FROM `progress`
	WHERE (`id_user` = '".$id."')";
	$result = $conn->query($sql);
	return $result;
}

$result = GetSaveData($conn,$id);

if ($result->num_rows < 0) {
	//no user
	echo false;
	exit();
}

$row = $result->fetch_assoc();

$date = $row['save_data'];

echo $date;

?>