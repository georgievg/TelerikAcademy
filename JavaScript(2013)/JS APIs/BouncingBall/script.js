(function () {
    var canvas = document.getElementById('canvas');

    var ctx = canvas.getContext('2d');

    ctx.fillStyle = '#fff';
    ctx.strokeStyle = "#fff";
    ctx.lineWidth = 1;

    function rndNumb(min, max) {
        return Math.floor(Math.random() * (max - min + 1)) + min;
    }
    function Ball(initX, initY) {

        this.dirX = rndNumb(0, 10);
        this.dirY = rndNumb(0, 10);

        this.X = initX;
        this.Y = initY;


        this.move = function () {
            this.X += this.dirX;
            this.Y += this.dirY;
        }
    }

    var ball = new Ball(55, 10);
    var CANVAS_WIDTH = 600;
    var CANVAS_HEIGHT = 600;
    
    document.onkeydown = function (e) {
        if (e.keyCode === 13) {
            ball.dirX = rndNumb(-10, 10);
            ball.dirY = rndNumb(-10, 10);
        }

    }

    setInterval(function () {
        if (ball.X + ball.dirX > CANVAS_WIDTH || ball.X < 0) {
            //ball.dirX = rndNumb(-10, -1);
            ball.dirX = -ball.dirX;
        }
        if (ball.Y + ball.dirY > CANVAS_HEIGHT || ball.Y < 0) {
            //ball.dirY = rndNumb(-10, -1);
            ball.dirY = -ball.dirY;
        }
        ctx.clearRect(0, 0, 600, 600);
        ctx.moveTo(0, 0);
        ctx.beginPath();
        ball.move();
        ctx.arc(ball.X, ball.Y, 15, 0, 2 * Math.PI, false);
        ctx.closePath();
        ctx.fill();

    }, 20);




})();

