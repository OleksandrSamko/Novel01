<?php

function GetId($conn,$user_data) {
//select user
$sql = "SELECT id FROM users
	WHERE (login = '".$user_data->login
	."' AND password = '".$user_data->password."')";

	$result = $conn->query($sql);
	
	return $result;
}

?>