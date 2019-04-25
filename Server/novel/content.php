<?php

//Make sure that the content type of the POST request has been set to application/json
	$contentType = isset($_SERVER["CONTENT_TYPE"]) ? trim($_SERVER["CONTENT_TYPE"]) : '';
	if(strcasecmp($contentType, 'application/json') != 0){
		throw new Exception('Content type must be: application/json');
	}

//Receive the RAW post data.
	$content = trim(file_get_contents("php://input"));

?>