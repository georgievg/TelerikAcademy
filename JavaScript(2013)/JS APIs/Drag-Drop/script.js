var startBtn = document.getElementById('start-btn');
var timer;
var time = 0;
var timeEl = document.getElementById('time');
var score = 5000;
var startLayer = document.getElementById('start-wrap');

loadStorage();

function loadStorage() {
    var endHtml = '<ul>';
    var MAX_SCORES = 5;
    var scoresArr = [];

    for (var i = 0; i < localStorage.length; i++) {
        scoresArr.push(localStorage.getItem(localStorage.key(i)));
    }
    scoresArr.sort();
    scoresArr.reverse();
    for (var i = 0; i < MAX_SCORES; i++) {
        endHtml += '<li> Score - ' + scoresArr[i] + '</li>';
    }
    endHtml += '</ul>';
    var scores = document.getElementById('scores');
    scores.innerHTML = endHtml;
}

function clearTimer() {
    timer.clearInterval();
}

startBtn.addEventListener('click', function () {
    timer = window.setInterval(function () {
        time++;
        timeEl.innerHTML = time;
        score -= rndNumber(100, 200);
        var balls = document.getElementsByClassName('ball');
        if (balls.length == 0) {
            localStorage.setItem('Score' + new Date(), score);
            startLayer.style.display = 'block';
            loadStorage();
            clearInterval(this);
            score = 5000;
            time = 0;
        }
    }, 1000);
    
    startLayer.style.display = 'none';
}, false);

function rndNumber (min, max) {
    return Math.floor(Math.random() * (max - min + 1)) + min;
}

function drag(ev) {
    ev.dataTransfer.setData('dragged-id', ev.target.id);
}

function allowDrop(ev) {
    ev.preventDefault();
    var basket = document.getElementById('basket');
    basket.src = 'img/open-basket.jpg';
}

function drop(ev) {
    ev.preventDefault();
    var data = ev.dataTransfer.getData('dragged-id');
    var el = document.getElementById(data);
    el.className = 'no-ball';
    el.style.display = 'none';
    var basket = document.getElementById('basket');
    basket.src = 'img/closed-basket.jpg';
}
