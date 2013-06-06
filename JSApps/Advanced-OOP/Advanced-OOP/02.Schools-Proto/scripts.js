var School = {

    addClass: function (classToPush) {
        this.classes.push(classToPush);
    },

    getClasses: function () {
        return this.classes;
    },

    init: function (name, town) {
        this.name = name;
        this.town = town;
        this.classes = [];
    }
};

var Person = {
    init: function (firstName, lastName, age) {
        this.firstName = firstName;
        this.lastName = lastName;
        this.age = age;
    },

    introduce: function () {
        return "FirstName: " + this.firstName + ", LastName: " + this.lastName + ", Age: " + this.age;
    }
};

var Student = Person.extend({

    init: function (firstName, lastName, age, grade) {
        Person.init.apply(this, arguments);
        this.grade = grade;
    },

    introduce: function () {
        return Person.introduce.apply(this) + ", Grade: " + this.grade;
    }
});

var Teacher = Person.extend({

    init: function (firstName, lastName, age, specialty) {
        Person.init.apply(this, arguments);
        this.specialty = specialty;
    },

    introduce: function () {
        return Person.introduce.apply(this) + ", Specialty: " + this.specialty;
    }
});

var Class = {

    init: function (name, capacity, formTeacher) {
        this.name = name;
        this.capacity = capacity;
        this.formTeacher = formTeacher;
        this.students = [];
    },

    addStudent: function (studentToAdd) {
        if (this.students.length <= this.capacity) {
            this.students.push(studentToAdd);
        }
        else {
            throw "You can not add more than " + this.capacity + " students";
        }
    },

    getStudents: function () {
        return this.students;
    },

    getName: function () {
        return this.name;
    },

    getCapacity: function () {
        return this.capacity;
    }
};

var pesho = Object.create(Student);
pesho.init("Petur", "Atanasov", 5, 7);
console.log(pesho.introduce());

var penka = Object.create(Teacher);
penka.init("Penka", "Stambolova", 5, "Idiot");
console.log(penka.introduce());

var smirnenski = Object.create(School);
smirnenski.init("hr smirnenski", "Boloniq");

var mathClass = Object.create(Class);
mathClass.init("math", 15, penka);
mathClass.addStudent(pesho);
console.log(mathClass.getStudents());

smirnenski.addClass(mathClass);
console.log(smirnenski.getClasses());