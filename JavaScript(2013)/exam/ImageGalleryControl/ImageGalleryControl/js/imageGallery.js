(function () {

    ImageGallery = function (selector, html) {
        this.mainContainer = (function () {
            html = html || document;
            html.innerHTML += "<button class='sort-btn'>sort</button><div class='pictures'></div><div class='albums'></albums>";
            var galleryFound = html.querySelector(selector);
            html.innerHTML += "<div class='largeImg'></div>";
            var classOfGal = galleryFound.className;
            if (classOfGal.indexOf("gallery") === -1) {
                galleryFound.className += 'gallery';
            }
            return galleryFound;
        })();

        if (html) {
            this.html = html.outerHTML || this.mainContainer.outerHTML;
        }

        this.albums = [];
        
    }

    ImageGallery.prototype = {
        addAlbum: function (album) {
            this.albums.push(album);
            var albumHtml;
            if (album.getHtmlForRender) {
                albumHtml = album.getHtmlForRender();
            }
            else{
                albumHtml = album.outerHTML;
            }
            this.mainContainer.innerHTML = albumHtml;
        },
        renderReadyGallery: function (selector,append) {
            var container = document.querySelector(selector);
            if (append === true) {
                container.innerHTML += this.html;
            }
            else {
                container.innerHTML = this.html;
            }
        }
    }


})();