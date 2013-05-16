(function () {
    var canvas = document.getElementById('canvas');
    var ctx = canvas.getContext('2d');
    var CANVAS_DIMENSIONS = 600;
    var GRID_SIZE = 10;
    var globalTimer;
    var score = 0;

    loadStorage();

    var FoodPiece = function (x, y, color) {
        this.color = color || 'green';
        this.X = x;
        this.Y = y;

        this.draw = function () {
            ctx.fillStyle = this.color;
            ctx.fillRect(this.X, this.Y, GRID_SIZE, GRID_SIZE);
        }
    }

    var foodHolder = [];

    var SnakePart = function (x, y, color) {
        this.color = color || "#fff";
        this.X = x;
        this.Y = y;
    }

    var Snake = function () {
        this.parts = [new SnakePart(0, 0), new SnakePart(10, 0), new SnakePart(20, 0)];

        this.head = function () {
            return this.parts[this.parts.length - 1];
        }

        this.bodyLength = 3;
        this.direction = 'right';

        this.Draw = function () {
            for (var i = 0; i < this.parts.length; i++) {
                ctx.fillStyle = this.parts[i].color;
                ctx.fillRect(this.parts[i].X, this.parts[i].Y, GRID_SIZE, GRID_SIZE);
            }
        }
        this.checkBoudaries = function () {
            if (this.head().X > CANVAS_DIMENSIONS || this.head().X < 0 || this.head().Y > CANVAS_DIMENSIONS || this.head().Y < 0) {
                return false;
            }
            return true;
        }

        this.reset = function () {
            this.parts = [new SnakePart(0, 0), new SnakePart(10, 0), new SnakePart(20, 0)];
        }

        this.Update = function () {
            var newX = this.head().X;
            var newY = this.head().Y;

            if (this.checkBoudaries()) {
                if (this.direction === 'right') {
                    newX += GRID_SIZE;
                }
                if (this.direction === 'down') {
                    newY += GRID_SIZE
                }
                if (this.direction === 'left') {
                    newX -= GRID_SIZE;
                }
                if (this.direction === 'up') {
                    newY -= GRID_SIZE;
                }
                this.parts.push(new SnakePart(newX, newY));
                this.parts.splice(0, 1);

            } else {
                gameOver();
            }
        }

        this.checkForFood = function () {
            for (var i = 0; i < foodHolder.length; i++) {
                var currHead = this.head();
                if (currHead.X === foodHolder[i].X && currHead.Y === foodHolder[i].Y) {
                    updateScore();
                    var lastPart = this.parts[0];
                    foodHolder.splice(0, 1);
                    foodHolder.push(new FoodPiece(rndNumb(0 + GRID_SIZE, CANVAS_DIMENSIONS - GRID_SIZE, true), rndNumb(0 + GRID_SIZE, CANVAS_DIMENSIONS - GRID_SIZE, true)));
                    pushNewPart(lastPart);

                }
            }
        }

        function pushNewPart(lastPart) {
            if (this.direction === 'right') {
                this.parts.unshift(new SnakePart(lastPart.X + GRID_SIZE, lastPart.Y));
            }
            if (this.direction === 'left') {
                this.parts.unshift(new SnakePart(lastPart.X - GRID_SIZE, lastPart.Y));
            }
            if (this.direction === 'up') {
                this.parts.unshift(new SnakePart(lastPart.X, lastPart.Y + GRID_SIZE));
            }
            if (this.direction === 'down') {
                this.parts.unshift(new SnakePart(lastPart.X, lastPart.Y - GRID_SIZE));
            }
        }
        this.checkForSelfEat = function () {
            for (var i = 0; i < this.parts.length - 2; i++) {
                if (this.head().X === this.parts[i].X && this.head().Y === this.parts[i].Y) {
                    gameOver();
                }

            }
        }
    }

    function updateScore() {
        score += rndNumb(50, 200);
        var currScoreWindow = document.getElementById('current-score');
        currScoreWindow.innerHTML = score;
        loadStorage();
    }

    function loadStorage() {
        var scores = document.getElementById('best-scores')
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
        scores.innerHTML = endHtml;
    };

    function gameOver() {
        clearInterval(globalTimer);
        localStorage.setItem('Score' + new Date(), score);
        var currScore = document.getElementById('current-score');
        currScore.innerHTML = "You have died, your score is " + score;
    }

    function rndNumb(min, max, round) {
        var num = Math.floor(Math.random() * (max - min + 1)) + min;
        if (!round) {
            return num;
        }

        var leftOut = (600 - num);
        var leftOutStr = leftOut + "";
        var lastNum = leftOutStr.charAt(leftOutStr.length - 1);
        var numToAdd = parseInt(lastNum);

        return num + numToAdd;

    }

    var snake = new Snake();
    foodHolder.push(new FoodPiece(rndNumb(0 + GRID_SIZE, CANVAS_DIMENSIONS - GRID_SIZE, true), rndNumb(0 + GRID_SIZE, CANVAS_DIMENSIONS - GRID_SIZE, true)));

    document.onkeydown = function (e) {
        //left
        if (e.keyCode === 37) {
            if (snake.direction !== 'right') {
                snake.direction = 'left';
            }
        }
        //right
        if (e.keyCode === 39) {
            if (snake.direction !== 'left') {
                snake.direction = 'right';
            }
        }
        //up
        if (e.keyCode === 38) {
            if (snake.direction !== 'down') {
                snake.direction = 'up';
            }
        }
        //down
        if (e.keyCode === 40) {
            if (snake.direction !== 'up') {
                snake.direction = 'down';
            }
        }
    }

    function drawAllFood() {
        for (var i = 0; i < foodHolder.length; i++) {
            foodHolder[i].draw();
        }

    }

    function startGame() {
        globalTimer = setInterval(function () {
            ctx.clearRect(0, 0, CANVAS_DIMENSIONS, CANVAS_DIMENSIONS);
            ctx.beginPath();

            snake.Update();
            snake.Draw();
            snake.checkForFood();
            snake.checkForSelfEat();

            drawAllFood();

            ctx.closePath();
            ctx.stroke();
            ctx.fill();

        }, 50);
    }

    startGame();
})();