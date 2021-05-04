<?php

	//Tomo del form que viene de Unity los strings que guarde con los respectivos nombres
	$servername = $_POST["host"];
	$database = $_POST["database"];
	$server_username = $_POST["dbuser"];
	$server_password = $_POST["dbpw"];

	//mysqli_connect() intenta abrir una conexión al servidor MySQL
	//En caso exitoso, regresará un objeto representando la conexión a la base de datos, o FALSE en caso contrario
	$con = mysqli_connect($servername, $server_username, $server_password, $database);

	//Chequeo si no hubo problema en la conexion
	if (mysqli_connect_errno())
	{
		echo ("1: Connection failed"); //Si hubo, devuelvo un string
		exit(); //y salgo de la ejecucion
	}


	//Tomo el dato del form creado en Unity (en este caso es la sentencia completa)

	$username = $_POST["user"];
	$estado = $_POST["estado"];
	


	$insertquery = "SELECT ID, Solicitante, Invitado, Estado FROM `friendlist` WHERE (Solicitante = ('".$username."') OR Invitado = ('".$username."')) and (('".$estado."') = 0 OR Estado = ('".$estado."'));";
	//$insertquery = "SELECT ID, Solicitante, Invitado, Estado FROM `friendlist` ;";

	//Envio la sentencia a la conexion establecida (por eso utilizo la variable donde hice mi conexion $con)
	$result = mysqli_query($con, $insertquery); 


	//Como hice un SELECT, se me va a devolver la busqueda que hice
	//En este caso me deberia devolver el username que sea igual al que vino de Unity siempre y cuando coincida la password
	//Por ende pregunto si el resultado de la ejecucion de la sentencia me devolvio algun registro.
	//Si no tiene ningun registro quiere decir que ningun usuario registrado coincide con los datos llegados de Unity
	if (mysqli_num_rows($result) == 0)
	{
		echo("User without friends");
		exit();
	}
	
	//Si llego hasta aca quiere decir que no hubo ningun problema y devuelvo un 0 para luego utilizarlo como condicion en Unity
	echo("0");
	
	while($row = mysqli_fetch_array($result))
	{
		$ret = $ret . "\n" . $row["ID"] . "\t" . $row["Solicitante"] . "\t" . $row["Invitado"] . "\t" . $row["Estado"];
	}
	
	echo($ret);
	//Cierro la conexion
	mysqli_close($con);

?>