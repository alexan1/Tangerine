var MyClass = function (x, y) {
    "use strict";

    this.first = x;
    this.second = y;
};

MyClass.prototype.sayHi = function () {
    $("#result").html(this.first + " " + this.second);
    setTimeout(function () {
        MyClass.prototype.sayHi.bind(this)
    }, 1);
};

var c = new MyClass("Hello", "World");
c.sayHi();