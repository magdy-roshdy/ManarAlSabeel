<?php
/*
*	!!! THIS IS JUST AN EXAMPLE !!!, PLEASE USE ImageMagick or some other quality image processing libraries
*/

/*$imgUrl = $_POST['imgUrl'];*/
$imgUrl = $_POST['file_name'];
$imgInitW = $_POST['imgInitW'];
$imgInitH = $_POST['imgInitH'];
$imgW = $_POST['imgW'];
$imgH = $_POST['imgH'];
$imgY1 = $_POST['imgY1'];
$imgX1 = $_POST['imgX1'];
$cropW = $_POST['cropW'];
$cropH = $_POST['cropH'];

$jpeg_quality = 100;

$output_filename = "../croppic-php/temp/cropped.jpg";


$response = array(
		"status" => 'success',
		"url" => $output_filename
		);
		
print json_encode($response);

?>