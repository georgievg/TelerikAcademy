var School = function () {
    var _name, _town;
    var _classes = [];

    this.init = function (name, town) {
        _name = name;
        _town = town;
        return this;
    };

    this.getName = function () {
        return _name;
    };

    this.getTown = function () {
        return _town;
    };

    this.addClass = function (classToAdd) {
        _classes.push(classToAdd);
    };
};

var Person = function () {
    var _firstName, _lastName, _age;

    this.init = function (firstName, lastName, age) {
        _firstName = firstName;
        _lastName = lastName;
        _age = age;
        return this;
    };

    this.introduce = function () {
        return "FirstName: " + _firstName + ", LastName: " + _lastName + ", Age: " + _age;
    };
};

var Student = function () {
    var _grade;

    this.init = function (firstName, lastName, age, grade) {
        _super.init(firstName, lastName, age);
        _grade = grade;
        return this;
    };

    this.introduce = function () {
        return _super.introduce() + ", Grade: " + _grade;
    };

}.inherits(Person);

var Teacher = function () {
    var _specialty;

    this.init = function (firstName, lastName, age, specialty) {
        _super.init(firstName, lastName, age);
        _specialty = specialty;
        return this;
    };

    this.introduce = function () {
        return _super.introduce() + ", Specialty: " + _specialty;
    };
}.inherits(Person);

var Class = function () {
    var _name, _capacity, _formTeacher;
    var _students = [];

    this.init = function (name, capacity, formTeacher) {
        _name = name;
        _capacity = capacity;
        _formTeacher = formTeacher;
        return this;
    };

    this.addStudent = function (studentToAdd) {
        if(_students.length <= _capacity){
            _students.push(studentToAdd);            
        }
        else{
            throw "You can not add more than " + _capacity + " students";
        }
    };

    this.getStudents = function () {
        return _students;
    };

    this.getFormTeacher = function () {
        return _formTeacher;
    };

    this.getName = function () {
        return _name;
    };

    this.getCapacity = function () {
        return _capacity;
    };

};

var school = new School().init('hr smirnenski', 'sofia');
var pesho = new Student().init("petur", "Borisov", 9, 2);
var canka = new Teacher().init("canka", "petkova", 22, "moron");
console.log(pesho.introduce());
console.log(canka.introduce());
var historyClass = new Class().init("History", 10, canka);
historyClass.addStudent(pesho);
console.log(historyClass.getFormTeacher().introduce());
console.log(historyClass.getName());
console.log(historyClass.getStudents());
