document.getElementById("addPoint").addEventListener("click", addPoint, false);
var points = [];
function reAddEventListeners() {
    document.getElementById("addPoint").addEventListener("click", addPoint, false)
};
function addPoint() {
    document.getElementById('pointContainer').innerHTML = "</br><input type='text' id='x' placeholder='X'><input type='text' id='y' placeholder='Y'><button id='save'>Save</button>";
    if (document.getElementById('save') != null) {
        document.getElementById('save').addEventListener('click', function () {
            points.push(createPoint(document.getElementById('x').value, document.getElementById('y').value));
            document.getElementById('pointContainer').innerHTML = null;
            updateStats();
        }, false);
    }
    reAddEventListeners();
}

function updateStats () {
    var stats = document.getElementById('stats');
    stats.innerHTML = null;
        var lines = [];
        for (var i = 0; i < points.length; i++) {
            debugger;
            if (i == points.length -1) {
                stats.innerHTML = 'Add another point';
                break;
            }
            else{
                if (points[i].x != points[i+1].x && points[i].y != points[i+1].y ) {                    
                    stats.innerHTML+='</br>Point(' + points[i].x+')('+points[i].y+') and Point(' + points[i+1].x+')('+points[i+1].y+') can make line';
                    lines.push(createLine(points[i],points[i+1]));                    
                    ++i;
                }
            }
        }
        var calculated = [];
        for (var i = 0; i < points.length; i++) {
            for (var e = i; e < points.length; e++) {
                if (e != i) {
                    if (points[e] != points[i]) {
                        var xd =  points[i].x - points[e].x;
                        var yd =  points[i].y - points[e].y;
                        stats.innerHTML += '</br>The Distance between Point(' + points[i].x+')('+points[i].y+') and Point(' + points[e].x+')('+points[e].y+') is ' + calcDistance(xd,yd);
                    } 
                }
            }
        }
        for (var i = 0; i < lines.length; i+=3) {
            if (i % 3 == 0) {
                if (calcDistance(lines[i].p1,lines[i].p2) < calcDistance(lines[i+1].p2,lines[i+1].p1) +calcDistance(lines[i+2].p2,lines[i+2].p1) &&
                    calcDistance(lines[i+1].p1,lines[i+1].p2) < calcDistance(lines[i].p2,lines[i].p1) +calcDistance(lines[i+2].p2,lines[i+2].p1) &&
                    calcDistance(lines[i+2].p1,lines[i+2].p2) < calcDistance(lines[i].p2,lines[i].p1) +calcDistance(lines[i+1].p2,lines[i+1].p1)) {
                    stats.innerHTML += 'You made a triangle !!';
                }
            }
        }
    
}
function calcDistance(xd,yd){
    return Math.sqrt(xd*xd+yd*yd);
}
function createLine(point1,point2){
    return{
        p1:point1,
        p2:point2

    }
}

function createPoint(x, y) {
    return {
        x: x,
        y: y
    }
}