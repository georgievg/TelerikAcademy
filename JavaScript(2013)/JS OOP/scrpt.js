'use strict'
    

var PropulsionUnits = function () {

    this.wheel = function (setRadius) {
        this.getRadius = function () {
            return radius;
        }

        var radius = (function () {
            if (setRadius > 1) {
                return setRadius;
            }
            else {
                throw 'Not valid radius, must be more than 1'
            }
        })();

        this.acceleration = function () {
            return radius / 2;
        }
    };
        
    this.propellingNozles = function (setPower) {
        this.afterBurner = 1;
        this.acceleration = function () {
            return this.power * this.afterBurner;
        }

        this.power = setPower;
    }
    //clockwise || counter-clockwise
    this.propeller = function (fins,direction) {
        this.privateDirection = (function () {
            if (direction === 'clockwise' || direction === 'counter-clockwise') {
                return direction;
            }
            else{
                throw 'Invalid direction';
            }
        })();

        this.getDirection = function () {
            return this.privateDirection;
        }
        
        var privateFins = (function () {
            if (fins > 1) {
                return fins;
            }
            else {
                throw 'Fins must be more than 1';
            }
        })();

        this.getFins = function () {
            return privateFins;
        }

        this.acceleration = function () {
            if (this.getDirection() === 'clockwise') {
                return this.getFins();
            }
            else {
                return this.getFins() * -1;
            }
        }
            

    }

    return {
        wheel: this.wheel,
        propellingNozles: this.propellingNozles,
        propeller: this.propeller,
        name: function () {
            return 'PropulsionUnits';
        }
                
    }
}
    

function Venicle(setSpeed) {
    this.speed = setSpeed;
}

function LandVenicle(setSpeed) {
    Venicle.call(this, setSpeed);
    var PropulsionUnitsContainer = [];
    var UNITS_LENGTH = 4;
        
    for (var i = 0; i < UNITS_LENGTH; i++) {
        var newProp = new PropulsionUnits();
        var newWheel = new newProp.wheel(20);
        PropulsionUnitsContainer.push(newWheel);
    }

    this.accelerate = function () {
        for (var i = 0; i < UNITS_LENGTH; i++) {
            this.speed += PropulsionUnitsContainer[i].acceleration();
        }
    }
       
}

function AirVenicle(setSpeed) {
    Venicle.call(this,setSpeed);
    var newProp = new PropulsionUnits();
    var proUnit = new newProp.propellingNozles(50);

    this.accelerate = function () {
        this.speed += proUnit.acceleration();
    }
    this.turnOnAfterburner = function () {
        proUnit.afterBurner = 2;
    }
    this.turnOffAfterburner = function () {
        proUnit.afterBurner = 1;
    }
}
    
function WaterVenicle(setSpeed,setPropellers) {
    Venicle.call(this, setSpeed);

    this.accelerate = function () {        
        for (var i = 0; i < setPropellers.length; i++) {
            this.speed += setPropellers[i].acceleration();
        }
    }
    this.setDirection = function (setDirection) {
        if (setDirection === 'clockwise' || setDirection === 'counter-clockwise') {
            for (var i = 0; i < setPropellers.length; i++) {
                if (setPropellers[i].privateDirection) {
                    setPropellers[i].privateDirection = setDirection;
                }
            }
        }
        else {
            throw 'Invalid direction';
        }
    }

}
//propellers -> []
//initialState -> land || sea
function AmphibiousVenicle(setSpeed,initialState,propellers) {
    Venicle.call(this, setSpeed);
    var length;
    var state = initialState;
    var initialSpeed = this.speed;
    var wheels = [];
    var propells = [];
    for (var i = 0; i < propellers.length; i++) {
        if (propellers[i].getRadius) {
            wheels.push(propellers[i]);
        }
        else {
            propells.push(propellers[i]);
        }
    }
    
    
    this.calcSpeed = function () {
        
        this.speed = initialSpeed;
        if (state === 'land') {
            length = wheels.length;
        }
        else {
            length = propells.length;
        }
        for (var i = 0; i < length; i++) {
            if (state === 'land') {
                this.speed += wheels[i].acceleration();
            }
            else {
                this.speed += propells[i].acceleration();
            }
        }
    }
    this.calcSpeed();
    this.changeMode = function (mode) {
        if (mode === 'land' || mode === 'sea') {
            state = mode;
            this.calcSpeed();
        }
        else {
            throw 'Invalid mode';
        }
        
        
    }

    this.accelerate = function () {
        for (var i = 0; i < length; i++) {
            if (state == 'land') {
                this.speed += wheel[i].acceleration();
            }
            else {
                this.speed += propells[i].acceleration();
            }
        }

    }


}
    

LandVenicle.prototype = new Venicle();
LandVenicle.prototype.constructor = Venicle;
AirVenicle.prototype = new Venicle();
AirVenicle.prototype.constructor = Venicle;
WaterVenicle.prototype = new Venicle();
WaterVenicle.prototype.constructor = Venicle;
AmphibiousVenicle.prototype = new Venicle();
AmphibiousVenicle.prototype.constructor = Venicle;

var landVenicle = new LandVenicle(50);
landVenicle.accelerate();
console.log("land venicle speed " + landVenicle.speed);
var airVenicle = new AirVenicle(50);
airVenicle.accelerate();
console.log("air venicle speed " + airVenicle.speed);

var newProp = new PropulsionUnits();
var nozzles = new newProp.propellingNozles(50);
var wheel = new newProp.wheel(30);
var propeller = new newProp.propeller(50, "clockwise");
var waterVenicle = new WaterVenicle(50, [nozzles, wheel,propeller]);
waterVenicle.accelerate();
console.log(waterVenicle.speed);
console.log(propeller.getDirection());
waterVenicle.setDirection("counter-clockwise");
console.log(propeller.getDirection());


var ambfib = new AmphibiousVenicle(60, 'sea', [wheel, propeller, nozzles]);
console.log("amfib speed " + ambfib.speed);
ambfib.accelerate();
console.log(ambfib.speed);
ambfib.changeMode('sea');
console.log(ambfib.speed);