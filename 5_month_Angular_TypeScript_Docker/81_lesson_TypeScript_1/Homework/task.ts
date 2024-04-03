// task1
{
	class Person {
		private name: string;
		private age: number;

		constructor(name: string, age: number) {
			this.name = name;
			this.age = age;
		}

		introduce(): string {
			return `Hello, my name is ${this.name} and I am ${this.age} years old.`;
		}
	}

	const john = new Person("Tohirjon", 21);
	console.log(john.introduce());
}

// task2
{
	let age: number = 25;
	age = 30;
	console.log("Age (let):", age);

	const name: string = "John";
	console.log("Name (const):", name);

	var score: number = 80;
	score = 90;
	console.log("Score (var):", score);
}

// task3
{
	let num: number = 10;
	let str: string = "Hello";
	let bool: boolean = true;
	let undef: undefined = undefined;

	console.log("Number:", num);
	console.log("String:", str);
	console.log("Boolean:", bool);
	console.log("Undefined:", undef);

	let sum: number = num + 5;
	console.log("Sum:", sum);

	let greeting: string = str + " World!";
	console.log("Greeting:", greeting);

	let isTrue: boolean = bool && false;
	console.log("Is True:", isTrue);

	let test: undefined = undef;
	console.log("Test:", test);
}

// task4
// {
// 	let numberVar: number = 10;

// 	numberVar = "Hello";

// 	console.log("Number Variable:", numberVar);
// }

// task5
// {
//     let variable;

//     variable = 10;
//     console.log("First shot: " typeof variable);

//     variable = "hey";
//     console.log("Second shot: " typeof variable);
// }

// task6
// {
//     let variable_1: string = "777";

//     let parsed_variable_one: number = <number>variable_1;

//     let parsed_variable_two: number = parseInt(variable_1);

//     console.log("In the first attempt: ", variable_1);
//     console.log("When parsed: ", parsed_variable_one);
//     console.log("When parsed using parseInt: ", parsed_variable_two);
// }

// task7
{
	type Person = {
		name: string;
		age: number;
		email: string;
	};

	let person1: Person = {
		name: "John Doe",
		age: 30,
		email: "john@example.com",
	};

	console.log("Name:", person1.name);
	console.log("Age:", person1.age);
	console.log("Email:", person1.email);
}

// task8
{
	let numbers: number[] = [1, 2, 3, 4, 5];

	numbers.push(6, 7);
	numbers.pop();

	console.log("Array Elements:");
	numbers.forEach((num) => {
		console.log(num);
	});
}

// task9
{
	enum Color {
		One = "First",
		Two = "Second",
		Three = "Third",
		Four = "Fourth",
	}

	let preferance: Color = Color.Three;

	console.log("Selected one: ", preferance);
}

// task10
{
	let isNull: null = null;

	let isUndefined: undefined = undefined;

	console.log("isNull:", isNull);
	console.log("isUndefined:", isUndefined);
}
