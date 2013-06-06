(function (){
	var parent = document.getElementById('items-container');
	var folders = [];

	function createUrlWithPrompt(){
		var urlName = prompt('Enter New Url Name');
		var urlAddress = prompt("Enter Url Address");
		var url = new Url().init(urlName, urlAddress);
		return url;
	}

	var Folder = function (){
	this.urls = [];
	this.name;
	this.htmlEl;

	this.init = function (folderName){
		var that = this;
		this.name = folderName;
		this.htmlEl = document.createElement('div');
		this.htmlEl.id = folderName;
		this.htmlEl.className = 'folder';
		var folderTitle = document.createElement('div');
		folderTitle.className = 'folder-title';
		folderTitle.innerHTML = this.name;
		this.htmlEl.appendChild(folderTitle);
		this.htmlEl.addEventListener('click', function (e) {
			if (e.target.parentElement === that.htmlEl) {
				var url = createUrlWithPrompt();
				that.addUrl(url);
				that.render(parent);
			};
			
		}, false)

		return this;
	}
}

Folder.prototype = {
	addUrl: function (urlToAdd) {		
		this.urls.push(urlToAdd.htmlEl);
	},

	render: function (parentEl) {
		parentEl.appendChild(this.htmlEl);
		for (var i = 0; i < this.urls.length; i++) {
			this.htmlEl.appendChild(this.urls[i]);
		};
	}
}

var Url = function (){
	this.url;
	this.name;
	this.htmlEl;

	this.init = function (name, url){
		this.name = name;
		this.url = url;
		this.htmlEl = document.createElement('div');
		this.htmlEl.id = this.name;
		this.htmlEl.className = 'url';
		var url = document.createElement('a');
		url.href = this.url;
		url.innerHTML = this.name;
		url.target = '_blank';
		this.htmlEl.appendChild(url);
		return this;
	}
}

var addFolderBtn = document.getElementById('add-folder');
addFolderBtn.addEventListener('click',function () {
	var folderName = prompt('Enter Folder Name');
	var folder = new Folder().init(folderName);
	folder.render(parent);
	folders.push(folder);
}, false)

var addUrlBtn = document.getElementById('add-url');
addUrlBtn.addEventListener('click',function () {
	var url = createUrlWithPrompt();
	parent.appendChild(url.htmlEl);
}, false);

})();