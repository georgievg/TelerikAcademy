var checks = [false,false,false];
function isNumber(n) {
  return !isNaN(parseFloat(n)) && isFinite(n);
}
$("#numb1").bind("input",function () {
	var text = $(this).val();
	if (isNumber(text)) {
		setValidInput("#numb1Validate");
		checks[0] = true;
	}
	else{
		setInvalidInput("#numb1Validate");
		checks[0] = false;
	}
})

$("#numb2").bind("input",function () {
	var text = $(this).val();
	if (isNumber(text)) {
		setValidInput("#numb2Validate");
		checks[2] = true;
	}
	else{
		setInvalidInput("#numb2Validate");
		checks[2] = false;
	}
})

$("#char").bind("input",function () {
	var text = $(this).val();
	if (!isNumber(text) && text.length < 2) {
		setValidInput("#charValidate");
		checks[1] = true;
	}
	else{
		setInvalidInput("#charValidate");
		checks[1] = false;
	}
})

$("form").submit(function () {
	if (checkALl() === true) {
		return true;
	}
	else
		return false;
})
function checkALl () {
	if(checks[0] === true && checks[1] === true && checks[2] === true)
		return true;
	return false;
}
function setValidInput (el) {
	$(el).css({
			"display":"inline-block",
			"background-color":"green"
		}).html("Input valid")
}
function setInvalidInput (el) {
	$(el).css({
			"display":"inline-block",
			"background-color":"red"
		}).html("Input invalid")
}