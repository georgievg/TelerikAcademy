var a = ['2','2','2','1','2','2','2','1','2','2','2','1','2','2','2','1','2','2','2','1','2','2','2','1','2','2','2','1','2','2','2','1','2','2','2','1','2','2','2','1','2','2','2','1','2','2','2','1'];

generateTagCloud(a);
function rndGenerator(min, max) {
    return Math.floor(Math.random() * (max - min + 1)) + min;
}
function generateTagCloud (tags, minFont, maxFont) {
  var generatedTags = {};
  for(var i=0,j=tags.length; i<j; i++){
    generatedTags[tags[i]] = createTag(tags[i]);
  };
  for(var i=0,j=tags.length; i<j; i++){
    if (generatedTags[tags[i]]) {
    	if (generatedTags[tags[i]].font < 50) {
    		generatedTags[tags[i]].font+=2;
    	};
    	
    };
  };
  for(var i in generatedTags){
    document.body.innerHTML+="<p style='font-size:"+generatedTags[i].font+"px;font-weight:bold'>" + generatedTags[i].text + "</p>";
  };
}
function createTag (tag) {
  return {
  	text:tag,
  	font:10 	
  }
}