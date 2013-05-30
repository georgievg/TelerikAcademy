
window.onload = function () {
    attachEventHandlers();
    var button = document.getElementById("addTODO");
    button.addEventListener("click",addTODO,false);

}

function attachEventHandlers () {
	var listItems = document.getElementsByTagName("li");
	for (var i = 0; i < listItems.length; i++) {
        listItems[i].addEventListener("mouseover", toggleClass, false);
        listItems[i].addEventListener("mouseout", toggleClass, false);
        listItems[i].addEventListener("click",strikeOutString,false);
    }
}

function toggleClass() {
	if (this.className != "liHovered") {
	    this.className = "liHovered";
	}
	else if (this.className == "liHovered") {
	    this.className = "";
	}
}
function addTODO () {
	var text = document.getElementById("textTODO").value;
	if (text.length > 2) {
		var toAppend = "<li>" + text + "</li>";
		var todoList = document.getElementById("todoList");
		todoList.innerHTML+=toAppend;
		text = document.getElementById("textTODO");
		text.value = "";		
		attachEventHandlers();
	}
	else
		alert("TODO too short");
	
}
var textArr = [];
function strikeOutString () {
	var textInLi = this.innerHTML;
	for (var i = 0; i < textInLi.length; i++) {
	   	textArr.push(textInLi[i]);
	}
	var el = this;
	recStrikeOut(0,textArr,el)
}
function recStrikeOut (index,arr,element) {
    if(index == arr.length) {
		textArr = [];
	    return;
	}
	var endText = "<s>";
	endText+=arr[index];
	endText+="</s>";
	arr.splice(index,1);
	arr.splice(index,0,endText);
	element.innerHTML = arr.join('');
	window.setTimeout(function () {
		recStrikeOut(++index,arr,element)
	},10); 
}