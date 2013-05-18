(function () {

    MainController = (function () {

        return {
            createImageGallery: function (selector, html) {
                var imgGallery = new ImageGallery(selector,html);
                imgGallery.mainContainer.addDelegateListener('click', 'h2', function () {
                    var album = this.parentElement;
                    if (album.className.indexOf("hidden") === -1) {
                        album.className += " hidden";
                        album.style.height = "50px";
                        album.style.overflow = "hidden";
                    }
                    else {
                        var hiddenClass = album.className;
                        hiddenClass = hiddenClass.replace("hidden", "");
                        album.className = hiddenClass;
                        album.style.height = "";
                        album.style.overflow = "";
                    }

                });
                imgGallery.mainContainer.addDelegateListener('click', 'img', function () {
                    if (this.parentElement.className !== 'largeImg') {
                        var largeImgHolder = document.getElementsByClassName('largeImg')[0];
                        var newImg = document.createElement('img');
                        newImg.src = this.src;
                        newImg.title = this.title;
                        newImg.width = this.width * 2;
                        newImg.height = this.height * 2;
                        largeImgHolder.innerHTML = "";
                        largeImgHolder.appendChild(newImg);
                    }
                    else {
                        this.parentElement.innerHTML = "";
                    }
                });
                
                return imgGallery;
            },
            saveToLocalRepository: function (title,item) {
                localStorage.setItem(title, item.mainContainer.outerHTML);
            },
            loadFromLocalRepository: function (title) {
                var repoHTML = localStorage.getItem(title);
                var newItem = document.createElement('div');
                newItem.innerHTML = repoHTML;
                var newImgGallery = this.createImageGallery(" div > div", newItem);
                var albums = newItem.getElementsByClassName("album");
                var albumsCount = albums.length;
                if (albums) {                    
                    for (var i = 0; i < albumsCount; i++) {
                        var currNewAlbum = new Album(albums[i].id);
                        var images = cloneAllNodes(albums[i].getElementsByTagName('img'));
                        var imagesCount = images.length;
                        if (i === 0) {
                            imagesCount = 1;
                        }
                        newImgGallery.addAlbum(currNewAlbum);                        
                        for (var j = 0; j < imagesCount; j++) {
                            currNewAlbum.addPicture(images[j],albums[i]);
                        }
                        
                    }
                }

                return newImgGallery;
            }
        }
    })();



    
})();