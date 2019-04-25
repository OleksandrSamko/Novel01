<?php

//Make sure that it is a POST request.
if(strcasecmp($_SERVER['REQUEST_METHOD'], 'POST') != 0){
	throw new Exception('Request method must be POST!');
}

include '../content.php';

//Attempt to decode the JSON 
$user_data = json_decode($content);

//If json_decode failed, the JSON is invalid.
if (json_last_error() !== JSON_ERROR_NONE) {
	throw new Exception('Received content contained invalid JSON!');
}

require_once('../DB.php');
require_once('id_access.php');

$result = GetId($conn, $user_data);

if ($result->num_rows < 0) {
	//no user
	echo false;
	exit();
}

$row = $result->fetch_assoc();
//make json answer
echo '{"id": "'.$row["id"].'"}';

?>