
	  document.querySelectorAll = function (cmd) {
	  		var cleanCmd = cmd.substring(1);
			if (cmd.charAt(0) === '#') {
				alert(cleanCmd);
				return document.getElementById(cleanCmd);
			}
			else if (cmd.charAt(0) === ".") {
				return document.getElementsByClassName(cleanCmd);
			}
			else {
				return document.getElementsByTagName(cmd);
			}
		}
		document.querySelector = function querySelector(cmd) {
	  		var cleanCmd = cmd.substring(1);
			if (cmd.charAt(0) === '#') {
				return document.getElementById(cleanCmd);
			}
			else if (cmd.charAt(0) === ".") {
				return document.getElementsByClassName(cleanCmd)[0];
			}
			else {
				return document.getElementsByTagName(cmd)[0];
			}
		
		}
	
