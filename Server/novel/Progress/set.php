<?php

//Make sure that it is a POST request.
if(strcasecmp($_SERVER['REQUEST_METHOD'], 'POST') != 0){
	throw new Exception('Request method must be POST!');
}

include '../content.php';

//Attempt to decode the JSON 
$progress = json_decode($content);

//If json_decode failed, the JSON is invalid.
if (json_last_error() !== JSON_ERROR_NONE) {
	throw new Exception('Received content contained invalid JSON!');
}

require_once('../DB.php');

$headers = apache_request_headers();
$id = $headers['Authorization'];

function SetSaveData($conn,$id,$save_data) {
	$save_data = $conn->real_escape_string($save_data);
	$sql = "UPDATE `progress` SET `save_data` = '$save_data'
	WHERE (`id_user` = '".$id."')";
	$result = $conn->query($sql);
	return $result;
}

$result = SetSaveData($conn,$id,$progress->data);

if ($result) {
	echo 'true';
}else{
	echo 'false';
}

?>