<html>
<head>
	<title>Form</title>
</head>
<style type="text/css">
	form{
		margin:30px;
	}
	input{
		padding:5px;
		margin:5px;
		display:inline-block;
	}
	input[type="submit"]{
		width:180px;
	}
	.jsValidate{
		display:none;
		padding:5px;
		color:white;
	}
</style>
<script src="jquery-1.9.1.min.js" type="text/javascript" charset="utf-8"></script>
<body>
	<form action="index.php" method="post" accept-charset="utf-8">
		<input type="text" name="numb1" value="" placeholder="Enter a number" id="numb1"><div class="jsValidate" id="numb1Validate"></div><br/>
		<input type="text" name="char" value="" placeholder="Enter a char" id="char"><div class="jsValidate" id="charValidate"></div><br/>
		<input type="text" name="numb2" value="" placeholder="Enter a number" id="numb2"><div class="jsValidate" id="numb2Validate"></div><br/>
		<input type="submit" name="submit" value="Submit" id="submit">
	</form>	
</body>
<script type="text/javascript" src="scripts.js"></script>
</html>
<?php
	if (isset($_POST['numb1']) && isset($_POST['numb2']) && isset($_POST['char'])) {
		$numb1 = $_POST['numb1'];
		$numb2 = $_POST['numb2'];
		$char = $_POST['char'];

		if ( is_numeric($numb1) && is_numeric($numb2) && !is_numeric($char) && strlen($char) < 2) {
			echo "Your data :<br/> $numb1 <br/> $char <br/> $numb2";
		}
		else{
			echo "You inputed wrong data";
		}
	}
	

?>