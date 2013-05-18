(function () {

    Album = function (title) {
        this.title = htmlEncode(title);
        this.pictures = [];
        this.albums = [];
        this.sorted = false;
    }

    Album.prototype = {
        addPicture: function (picture,html) {
            if (isElement(picture)) {
                var html = html || document;
                this.pictures.push(picture);
                var albumEl = html.querySelector("#" + removeWhiteSpaces(this.title) + " .pictures");
                albumEl.appendChild(picture);
            }
            else {
                throw picture + " is not a HTML element";
            }
        },
        addAlbum: function (album) {
            this.albums.push(album);
            var albumEl = document.querySelector("#" + removeWhiteSpaces(this.title) + " .albums");
            albumEl.innerHTML += album.getHtmlForRender();
            var parent = albumEl.parentElement;
            innerCounterForEvent = 0;
            document.body.addDelegateListener('click', 'button.sort-btn', function (e) {
                if (innerCounterForEvent === 0) {
                    e.preventDefault();
                    e.stopPropagation();
                    var parent = this.parentElement;
                    var albums = document.getElementsByClassName('albums')[0];
                    var albumsInside = convertNodeListToArray(albums.getElementsByClassName('album'));
                    var albumsLength = albumsInside.length;
                    albumsInside.sort(sortById);
                    albums.innerHTML = "";

                    this.sorted = !this.sorted;

                    if (this.sorted === true) {
                        albumsInside.reverse();
                    }

                    for (var i = 0; i < albumsLength; i++) {
                        albums.innerHTML += albumsInside[i].outerHTML;
                    }

                    innerCounterForEvent++;
                }
                else {
                    innerCounterForEvent = 0;
                }
            });
        },
        getHtmlForRender:function () {
            var htmlToRender = "<div id='"+removeWhiteSpaces(this.title)+"' class='album'><h2>" + this.title + "</h2><button class='sort-btn'>Sort</button><div class='pictures'></div><div class='albums'></div></div>";
            
            return htmlToRender;
        }
    }

})();