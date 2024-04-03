{
    var Person = /** @class */ (function () {
        function Person(name, age) {
            this.name = name;
            this.age = age;
        }
        Person.prototype.introduce = function () {
            return "Hello, my name is ".concat(this.name, " and I am ").concat(this.age, " years old.");
        };
        return Person;
    }());
    var john = new Person("Tohirjon", 21);
    console.log(john.introduce());
}
{
    var age = 25;
    age = 30;
    console.log("Age (let):", age);
    var name_1 = "John";
    console.log("Name (const):", name_1);
    var score = 80;
    score = 90;
    console.log("Score (var):", score);
}
{
    var num = 10;
    var str = "Hello";
    var bool = true;
    var undef = undefined;
    console.log("Number:", num);
    console.log("String:", str);
    console.log("Boolean:", bool);
    console.log("Undefined:", undef);
    var sum = num + 5;
    console.log("Sum:", sum);
    var greeting = str + " World!";
    console.log("Greeting:", greeting);
    var isTrue = bool && false;
    console.log("Is True:", isTrue);
    var test = undef;
    console.log("Test:", test);
}
// {
// 	let numberVar: number = 10;
// 	numberVar = "Hello";
// 	console.log("Number Variable:", numberVar);
// }
// {
//     let variable;
//     variable = 10;
//     console.log("First shot: " typeof variable);
//     variable = "hey";
//     console.log("Second shot: " typeof variable);
// }
// {
//     let variable_1: string = "777";
//     let parsed_variable_one: number = <number>variable_1;
//     let parsed_variable_two: number = parseInt(variable_1);
//     console.log("In the first attempt: ", variable_1);
//     console.log("When parsed: ", parsed_variable_one);
//     console.log("When parsed using parseInt: ", parsed_variable_two);
// }
{
    var person1 = {
        name: "John Doe",
        age: 30,
        email: "john@example.com",
    };
    console.log("Name:", person1.name);
    console.log("Age:", person1.age);
    console.log("Email:", person1.email);
}
{
    var numbers = [1, 2, 3, 4, 5];
    numbers.push(6, 7);
    numbers.pop();
    console.log("Array Elements:");
    numbers.forEach(function (num) {
        console.log(num);
    });
}
{
    var Color = void 0;
    (function (Color) {
        Color["One"] = "First";
        Color["Two"] = "Second";
        Color["Three"] = "Third";
        Color["Four"] = "Fourth";
    })(Color || (Color = {}));
    var preferance = Color.Three;
    console.log("Selected one: ", preferance);
}
{
    var isNull = null;
    var isUndefined = undefined;
    console.log("isNull:", isNull);
    console.log("isUndefined:", isUndefined);
}
