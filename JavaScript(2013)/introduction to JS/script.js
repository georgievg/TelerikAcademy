window.onload = function () {
	
	var form = document.getElementsByName("formBtns")[0];
	inputs = form.getElementsByTagName("input");
	for (var i = 0; i < inputs.length-1; i++) {	   
	    inputs[i].addEventListener("click",changeColors,false);	    
	}
	inputs[inputs.length-1].addEventListener("click",changeAllColors,false);
};
function changeAllColors () {
	for (var i = 0; i < inputs.length; i++) {
		toggleClass(inputs[i]);
		inputs[i].style.background = "";
		inputs[i].style.color = "";
	}
}
function toggleClass (El) {
 	if (El.className != "white") {
		El.className = "white"
	} 
	else{
		El.className = "black";
	};
}
function changeColors () {
	var bgColor = chooseRndColor();
	var textColor = chooseRndColor();
	this.style.background = bgColor;
	this.style.color = textColor;

}
function chooseRndColor () {
	var baseColor = new Array()
	for (var i = 0; i < 6; i++) {
	    var rndNumber = Math.floor((Math.random()*10)+1);
	    baseColor.push(rndNumber-1);
	}
	return "#"+baseColor.join("");
}