var list = document.getElementById('list');
var hidden = list.getElementsByTagName('ul');
var lists = list.getElementsByTagName('a');
for(var i=0,j=hidden.length; i<j; i++){
	hidden[i].style.display = 'none';
};

for(var i=0,j=lists.length; i<j; i++){
  lists[i].addEventListener('click',expandList,false)
};
function expandList () {
	var ul = this.parentNode.getElementsByTagName('ul')[0];	
	ul.style.display = "block";	
	this.addEventListener('click',shrinkList,false);
}
function shrinkList () {
  	var uls = this.parentNode.getElementsByTagName('ul');
  	for (var i=0; i < uls.length; i++) {
		uls[i].style.display = 'none';
	  };	  
	this.removeEventListener('click',shrinkList);
  	
}




