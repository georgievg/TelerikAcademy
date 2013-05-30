
var newSLider = {
	initSlider : function (id) {
		DoMovingActions(id);
	}
}

function DoMovingActions (id) {
	var imgs = document.querySelectorAll("#"+id+" li img");
	var list = getById(id);
	list.style.display ="none";
	CreateSlider(imgs);
	AttachEventHandlers();
}

function CreateSlider (imgs) {
	var ElementsToAdd = "<div id='sliderContainer'>"
	ElementsToAdd+="<img id='moveLeft' src='imgs/Larrow.png' width='30px' height='30px'/>";
	ElementsToAdd+="<img id='moveRight' src='imgs/Rarrow.png' width='30px' height='30px'/>";
	ElementsToAdd+="</div>"
	var oldUl = getById("slider");
	var parent = oldUl.parentNode;
	parent.innerHTML+=ElementsToAdd;
	var container = getById("sliderContainer");
	for (var i = 1; i < imgs.length; i++) {
	    imgs[i].style.display="none";
	}
	for (var i = 0; i < imgs.length; i++) {
	    container.appendChild(imgs[i]);
	}

}
function AttachEventHandlers () {
	var left = getById("moveLeft");
	var right = getById("moveRight");
	left.addEventListener("click",MoveLeft)
	right.addEventListener("click",MoveRight)
}
var currImage = 0;
function MoveRight () {
	debugger;
	var imgs = document.querySelectorAll("#sliderContainer img");
	var images = [];
	for (var i = 2; i < imgs.length; i++) {
	    images.push(imgs[i]);
	}
	
	images[currImage].style.display = "none";
	if (currImage + 1 >= images.length) {
	    currImage = 0;
	}
	else{
		currImage++;
	}
	images[currImage].style.display = "block"
	images[currImage].style.opacity = "0.0";
	StartAnimation(images[currImage],0.0);
}
function MoveLeft () {
	debugger;
	var imgs = document.querySelectorAll("#sliderContainer img");
	var images = [];
	for (var i = 2; i < imgs.length; i++) {
	    images.push(imgs[i]);
	}	
	images[currImage].style.display = "none";

	if (currImage -1 == -1) {
	    currImage = images.length-1;
	}
	else{
		currImage--;
	}
	images[currImage].style.display ="block";
	images[currImage].style.opacity = "0.0";
	StartAnimation(images[currImage],0.0);
}
function StartAnimation (currImg,opacity) {
	if (opacity >= 1) {
	    return;
	}
	currImg.style.opacity = opacity;
	window.setTimeout(function () {
		StartAnimation(currImg,opacity+0.1)
	},50);
}

function getById (id) {
	return document.getElementById(id);
}