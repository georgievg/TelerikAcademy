<?php 
	$max = 1000;
	for ($i=0; $i < $max; $i++) { 
		if ($i % 3 === 0 && $i % 7 == 0) {
			echo "$i <br>";
		}
	}
?>