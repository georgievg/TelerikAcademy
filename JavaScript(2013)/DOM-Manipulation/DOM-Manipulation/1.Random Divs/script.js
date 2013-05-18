var btn = document.getElementById('generateBtn');
function isNumber(n) {
    return !isNaN(parseFloat(n)) && isFinite(n);
}
btn.addEventListener('click', function () {
    var content = document.getElementById('content');
    var amount = (function () {
        var text = document.getElementById('textField');
        if (isNumber(text.value)) {
            return text.value;
        }
        else {
            return "Invalid Number";
        }
    })();
    content.innerHTML = '';
    if (isNumber(amount)) {
        var fragment = document.createDocumentFragment();
        for (var i = 0; i < amount; i++) {
            var div = document.createElement("div");
            div.style.width = rndGenerator(10, 100) + 'px';
            div.style.height = rndGenerator(10, 100) + 'px';
            div.style.backgroundColor = rndRgbColor();
            div.style.position = "absolute";
            div.style.color = rndRgbColor();
            div.style.left = rndGenerator(0, window.innerWidth) + 'px';
            div.style.top = rndGenerator(0, window.innerHeight) + 'px';
            div.innerHTML = '<strong>div</strong>';
            div.style.borderRadius = rndGenerator(0, 100) + "px";
            div.style.borderColor = rndRgbColor();
            div.style.borderWidth = rndGenerator(1, 20) + 'px';
            fragment.appendChild(div);
        }
        content.appendChild(fragment);
    }
    else {
        content.innerHTML = amount;
    }

});
function rndRgbColor() {
    return "rgb(" + rndGenerator(0, 255) + "," + rndGenerator(0, 255) + "," + rndGenerator(0, 255) + ")";
}

function rndGenerator(min, max) {
    return Math.floor(Math.random() * (max - min + 1)) + min;
}