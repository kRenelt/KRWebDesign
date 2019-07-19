$(function () {
    var canvas = document.getElementById("myCanvas");

    var ctx = canvas.getContext("2d");
    var lives = 3; 
    var x = canvas.width / 2;
    var y = canvas.height - 30;
    var dx = 3;
    var dy = -3;
    var ballRadius = 10;
    var paddleHeight = 10;
    var paddleWidth = 75;
    var paddleX = (canvas.width - paddleWidth) / 2;
    var brickRowCount = 3;
    var brickColumnCount = 5;
    var brickWidth = 75;
    var brickHeight = 20;
    var brickPadding = 10;
    var brickOffsetTop = 30;
    var brickOffsetLeft = 30;
    var startSpeed = 7;
    var score = 0;
    var brickColors = ["#0033cc", "#cc0000", "#66ff00", "#ffcc00"];
    var shouldPlay = false;

    $('#playButton').click(function () {
        shouldPlay = !shouldPlay;
        $('#score').text("shouldPlay: " + shouldPlay);
    });

    var bricks = [];

    for (var c = 0; c < brickColumnCount; c++) {
        bricks[c] = [];
        for (var r = 0; r < brickRowCount; r++) {
            var randomBrickColor = Math.floor((Math.random() * 10) + 1);
            bricks[c][r] = { x: 0, y: 0, status: 1, color: brickColors[randomBrickColor]};
        }
    }

    function refreshBricks() {
        bricks.length = 0;
        for (var c = 0; c < brickColumnCount; c++) {
            bricks[c] = [];
            for (var r = 0; r < brickRowCount; r++) {
                var randomBrickColor = Math.floor((Math.random() * 10) + 1);
                bricks[c][r] = { x: 0, y: 0, status: 1, color: brickColors[randomBrickColor] };
            }
        }
    }

    function drawBricks() {
        for (var c = 0; c < brickColumnCount; c++) {
            for (var r = 0; r < brickRowCount; r++) {
                if (bricks[c][r].status == 1) {
                    var brickX = (c * (brickWidth + brickPadding)) + brickOffsetLeft;
                    var brickY = (r * (brickHeight + brickPadding)) + brickOffsetTop;
                    bricks[c][r].x = brickX;
                    bricks[c][r].y = brickY;
                    ctx.beginPath();
                    ctx.rect(brickX, brickY, brickWidth, brickHeight);

                    ctx.fillStyle = bricks[c][r].color;
                    ctx.fill();
                    ctx.closePath();
                }
            }
        }
    }

    function draw() {
        ctx.clearRect(0, 0, canvas.width, canvas.height);
        drawBricks();
        drawBall();
        drawPaddle();

        if (x + dx > canvas.width - ballRadius || x + dx < ballRadius) {
            dx = -dx;
        }
    }

    function drawPaddle() {
        ctx.beginPath();
        ctx.rect(paddleX, canvas.height - paddleHeight, paddleWidth, paddleHeight);
        ctx.fillStyle = "#9a1616";
        ctx.fill();
        ctx.closePath();
    }

    var rightPressed = false;
    var leftPressed = false;

    document.addEventListener("mousemove", mouseMoveHandler, false);
    document.addEventListener("keydown", keyDownHandler, false);
    document.addEventListener("keyup", keyUpHandler, false);
    
    function mouseMoveHandler(e) {
        var relativeX = e.clientX - canvas.offsetLeft;
        if (relativeX > 0 && relativeX < canvas.width)
            paddleX = relativeX - paddleWidth / 2;
    }

    function keyDownHandler(e) {
        if (e.keyCode == 39) {
            rightPressed = true;
        }
        else if (e.keyCode == 37) {
            leftPressed = true;
        }
    }

    function keyUpHandler(e) {
        if (e.keyCode == 39) {
            rightPressed = false;
        }
        else if (e.keyCode == 37) {
            leftPressed = false;
        }
    }
    function drawBall() {
        ctx.beginPath();
        ctx.arc(x, y, 10, 0, Math.PI * 2);
        ctx.fill();
        ctx.closePath();
    }

    function draw() {
        ctx.clearRect(0, 0, canvas.width, canvas.height);
        drawBall();
        drawPaddle();
        collisionDetection();
        drawBricks();
        if (shouldPlay) {
            $('#score').text("Score: " + score);
            $('#lifeCounter').text("Lives: " + lives.toString());
            if (x + dx > canvas.width - ballRadius || x + dx < ballRadius) {
                dx = -dx;
                ctx.fillStyle = "#9a1616";
            }

            if (y + dy < ballRadius) {
                dy = -dy;
            }
            else if (y + dy > canvas.height - ballRadius) {
                if (x > paddleX && x < paddleX + paddleWidth) {
                    dy = -dy;

                } else {
                    lives--;
                    if (!lives) {
                        alert("GAME OVER");
                        //$.ajax({
                        //    url: "/Index",
                        //    data: {
                        //    }
                        //})
                        document.location.reload();
                    }
                    else {
                        x = canvas.width / 2;
                        y = canvas.height - 30;
                        paddleX = (canvas.width - paddleWidth) / 2;
                    }
                }
            }

            if (rightPressed && paddleX < canvas.width - paddleWidth) {
                paddleX += 5;
            }
            else if (leftPressed && paddleX > 0) {
                paddleX -= 5;
            }

            x += dx;
            y += dy;
        }
        requestAnimationFrame(draw);
    }

    function collisionDetection() {
        for (var c = 0; c < brickColumnCount; c++) {
            for (var r = 0; r < brickRowCount; r++) {
                var b = bricks[c][r];

                if (b.status == 1) {
                    if (x > b.x && x < b.x + brickWidth && y > b.y && y < b.y + brickHeight) {
                        dy = -dy;
                        b.status = 0;
                        score += 10;

                        if (score == brickColumnCount * brickRowCount * 10) {
                            alert("You win!");
                            refreshBricks();
                            //document.location.reload();
                        }
                    }
                }
            }
        }
    }

     draw();

})
