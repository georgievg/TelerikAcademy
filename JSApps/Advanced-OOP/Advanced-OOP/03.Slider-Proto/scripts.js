var Slider = {

    init: function (initialImage) {
        this.images = [];
        this.images.push(initialImage);
        this.currentImageIndex = 0;
        this.currentImage = this.images[this.currentImageIndex];
    },

    addImage: function (imageToAdd) {
        this.images.push(imageToAdd);
    },

    prevImage: function () {
        if (this.currentImageIndex > 0) {
            this.currentImageIndex--;
            this.currentImage = this.images[this.currentImageIndex];
        }
    },

    nextImage: function () {
        if (this.currentImageIndex < this.images.length) { 
            this.currentImageIndex++;
            this.currentImage = this.images[this.currentImageIndex];
        }
    },

    render: function (selector) {
        var i;
        var images = [];
        var that = this;
        var element = document.querySelector(selector);
        var slider = document.createElement('div');
        slider.id = 'slider';

        var btnsHolder = document.createElement('div');
        slider.appendChild(btnsHolder);
        slider.appendChild(createNewImage());

        var leftBtn = document.createElement('button');
        leftBtn.id = 'left-btn';
        leftBtn.innerHTML = "<----";
        btnsHolder.appendChild(leftBtn);
        var rightBtn = document.createElement('button');
        rightBtn.id = 'right-btn';
        rightBtn.innerHTML = "---->";
        btnsHolder.appendChild(rightBtn);
        element.appendChild(slider);

        leftBtn.addEventListener('click',function(){ 
            if (that.currentImageIndex > 0){
                var parent = removeOldImage();
                that.prevImage();
                parent.appendChild(createNewImage());
            }
        },false)
        
        rightBtn.addEventListener('click',function(){
            if (that.currentImageIndex < that.images.length - 1){
                var parent = removeOldImage();
                that.nextImage();
                parent.appendChild(createNewImage());
            }
        },false)

        function removeOldImage(){
            var elToRemove = document.getElementById(that.currentImage.title);
            var parent = document.getElementById('slider');
            parent.removeChild(elToRemove);

            return parent;
        }

        function createNewImage(){
            var newImg = document.createElement('img');
            newImg.src = that.currentImage.thumbnailUrl;        
            that.currentImage = that.images[that.currentImageIndex];
            newImg.addEventListener('click', function () {
                that.currentImage.toggleUrl();
                this.src = that.currentImage.currentUrl;
            }, false);        
            newImg.title = that.currentImage.title;
            newImg.id = that.currentImage.title;
            slider.appendChild(newImg);

            return newImg;
        }

    }
};

var SliderImage = {

    init: function (title, thumbnailUrl, largeUrl) {
        this.title = title;
        this.thumbnailUrl = thumbnailUrl;
        this.largeUrl = largeUrl;
        this.currentUrl = this.thumbnailUrl;
    },

    toggleUrl: function () {
        if (this.currentUrl === this.thumbnailUrl) {
            this.currentUrl = this.largeUrl;
        }
        else {
            this.currentUrl = this.thumbnailUrl;
        }
    },
};

var img = Object.create(SliderImage);
img.init("First", "http://placehold.it/350x100",
    "http://placehold.it/350x500");
var slider = Object.create(Slider);
slider.init(img);

var newImg = Object.create(SliderImage);
newImg.init("Second",
    "http://placehold.it/450x250",
     "http://placehold.it/750x250");
slider.addImage(newImg);

var lastImage = Object.create(SliderImage);
lastImage.init("Thirth",
    "http://placehold.it/400x400",
     "http://placehold.it/800x800");

slider.addImage(lastImage);
slider.render("#slider-container");