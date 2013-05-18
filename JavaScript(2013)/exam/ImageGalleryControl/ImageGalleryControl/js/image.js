(function () {

    Picture = function (source, title) {
        this.source = source;
        this.title = htmlEncode(title);
        var newImage = document.createElement("img");
        newImage.src = this.source;
        newImage.title = this.title;
        newImage.width = '240';
        newImage.height = '200';

        return newImage;
    }


})();