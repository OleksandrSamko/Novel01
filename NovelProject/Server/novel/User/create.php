<?php

//Make sure that it is a POST request.
if(strcasecmp($_SERVER['REQUEST_METHOD'], 'POST') != 0){
	throw new Exception('Request method must be POST!');
}

include '../content.php';

//Attempt to decode the incoming 
$user_data = json_decode($content);

//If json_decode failed, the JSON is invalid.
if (json_last_error() !== JSON_ERROR_NONE) {
	throw new Exception('Received content contained invalid JSON!');
}

require_once('../DB.php');
require_once('id_access.php');

//create user
$sql = "INSERT INTO users (id, login, password)
VALUES (NULL,'".$user_data->login."', '".$user_data->password."')";

if ($conn->query($sql) !== TRUE)
{
	throw new Exception("false\n" . $sql . "<br>" . $conn->error);
}

//return id, make json answer
$result = GetId($conn, $user_data);

if ($result->num_rows <= 0) {
	throw new Exception("false\n".$sql."\n".$conn->error);
}

// output data of each row
$row = $result->fetch_assoc();

 //create progress
$sql = "INSERT INTO progress (id, id_user, save)
VALUES (NULL,'".$row["id"]."', NULL)";

if ($conn->query($sql) !== TRUE)
{
	throw new Exception("false\n" . $sql . "<br>" . $conn->error);
}
//send ID result in JSON
echo '{"id":"'.$row["id"].'"}';

?>