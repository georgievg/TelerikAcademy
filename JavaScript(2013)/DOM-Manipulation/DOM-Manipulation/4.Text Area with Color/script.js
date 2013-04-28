var bg = document.getElementById('bgColor');
bg.addEventListener('input',function(){
	document.getElementById('area').style.backgroundColor = bg.value;
},false);
var col = document.getElementById('fontColor');
col.addEventListener('input',function(){
	document.getElementById('area').style.color = col.value;
},false);
