<?php
	$servername = "localhost";
	$username = "root";
	$password = "";
	$dbName = "noveldb";
	//make connection
	$conn = new mysqli($servername,$username,$password,$dbName);
	//check
	if(!$conn){
		die("Connection Faild.".mysql_connect_error());
	}
?>