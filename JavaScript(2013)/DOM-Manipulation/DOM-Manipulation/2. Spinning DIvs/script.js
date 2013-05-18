function rndRgbColor() {
    return "rgb(" + rndGenerator(0, 255) + "," + rndGenerator(0, 255) + "," + rndGenerator(0, 255) + ")";
}

function rndGenerator(min, max) {
    return Math.floor(Math.random() * (max - min + 1)) + min;
}
var frag = document.createDocumentFragment();
var left = 40;
var topp = 40;
for (var i = 0; i < 5; i++) {
    var div = document.createElement('div');
    div.className = "circle";
    div.backgroundColor = rndRgbColor();
    div.style.borderRadius = '1000px';
    div.style.width = "50px";
    div.style.height = '50px';
    div.style.backgroundColor = rndRgbColor();
    div.style.position = "absolute";
    left += 60;
    div.style.left = left + "px";
    topp += 60;
    div.style.top = topp + "px";
    frag.appendChild(div);
};
document.body.appendChild(frag);
var count = 5;
var divs = document.getElementsByClassName("circle");
var timer;
var maxWidth = screen.width - 100;
var maxHeight = screen.height - 300;
var radius = 150;
var angleStep = 5;
var doublePI = 2 * Math.PI;
var currentAngle = 0;

circleDivsAround();

function circleDivsAround() {
    timer = setInterval(function () {
        for (var i = 0, len = divs.length; i < len; i++) {
            actuallyMove(divs[i]);
        }
    }, 100);
    s
    return false;
}

function actuallyMove(movingDIv) {
    currentAngle += angleStep;

    var topPos = parseInt(maxHeight / 5);
    var x = topPos + Math.cos(currentAngle) * radius;
    movingDIv.style.top = x + "px";

    var left = parseInt(maxWidth / 5);
    var y = left + Math.sin(currentAngle) * radius;
    movingDIv.style.left = y + "px";
}