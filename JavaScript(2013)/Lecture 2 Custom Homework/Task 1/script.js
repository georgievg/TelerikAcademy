window.onload = addEventHandlers;
function addEventHandlers() {
	var elements = document.querySelectorAll("ul.accordionMain>li");	
	for (var i = 0; i < elements.length; i++) {
	    elements[i].addEventListener("click",callAnimate,false);	    
	}
	elements = document.querySelectorAll("ul.accordionMain>button#X");
	for (var i = 0; i < elements.length; i++) {
	    elements[i].addEventListener("click",callFadeOut,false);	    
	}
}

function callAnimate() {
	debugger;
	var height = this.childNodes[1].clientHeight;
	if (height <= 0) {
		removeEventHandlers();
		checkForExpanded();
		animate(height,this.childNodes[1],true)
	}
	else if (height >= 200) {
	    animate(height,this.childNodes[1],false)
	}	
	
	
	
}
function removeEventHandlers () {
	var elements = document.querySelectorAll("ul.accordionMain>li");	
	for (var i = 0; i < elements.length; i++) {
	    elements[i].removeEventListener("click",callAnimate);
	}
}
function checkForExpanded () {
	var elements = document.querySelectorAll("ul.accordionMain>li>ul");
	for (var i = 0; i < elements.length; i++) {
	    if(elements[i].className == "expanded"){
	    	animate(elements[i].clientHeight,elements[i],false)
	    }
	}
}
function animate (height,element,down) {
	if (height >= 210) {  
		element.className = "expanded";
		addEventHandlers();
	    return;
	}
	else if (height < 0) {
	    element.className = "";
	    addEventHandlers();
	    return;
	}
	else{
		if (down) {
				element.style.height = height+"px";
			window.setTimeout(function () {
				animate(height+3,element,down)
			},2);
		}
		else if(!down){
			element.style.height = height+"px";
			window.setTimeout(function () {
				animate(height-3,element,down)
			},2);
		}
	}
}

function callFadeOut () {
	debugger;
	var element = this.nextSibling.nextSibling;	
	animateFadeOut(element,1.0);
}

function animateFadeOut (element,opacity) {
	debugger;
	if (opacity < 0.2) {
		animateSlideOut(element,0)
	    return;
	}
	element.style.opacity = opacity;
	window.setTimeout(function () {
		animateFadeOut(element,opacity-0.2);
	},100);
}
function animateSlideOut (element,margin) {
	if (margin > 200) {
	    element.style.display = "none";
	    return;
	}
	element.previousSibling.previousSibling.style.display = "none";
	element.style.marginLeft = margin;
	element.style.position = "absolute;"
	window.setTimeout(function () {
		animateSlideOut(element,margin+10)
	},1);
}

