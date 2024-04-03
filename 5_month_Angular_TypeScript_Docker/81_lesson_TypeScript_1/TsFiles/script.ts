// import { Product } from "./ProductModel";

// var product1 = new Product("Redmi 11", 1200);

// console.log(product1.name)

class Product {
	readonly name: string;
	readonly price: number;

	constructor(name: string, price: number) {
		this.name = name;
		this.price = price;
	}
}

// var list: Array<Product> = [];

var tbody = document.querySelector("tbody");
var createRow = document.querySelector(".create-row");

var index: number = 1;
console.log(tbody);

createRow?.addEventListener("click", () => {
	// Create a new Date object
	const currentDate = new Date();

	// Get the current time components
	const hours = currentDate.getHours(); // 0-23
	const minutes = currentDate.getMinutes(); // 0-59
	const seconds = currentDate.getSeconds(); // 0-59
	// const milliseconds = currentDate.getMilliseconds(); // 0-999

	// tbody = null;
	// console.log(tbody);
	// tbody?.innerHTML = ""

	var productName: string = (<HTMLInputElement>(
		document.querySelector(".productName")
	)).value;
	var productPrice: number = +(<HTMLInputElement>(
		document.querySelector(".productPrice")
	)).value;
	var product: Product = new Product(productName, productPrice);

	console.log(product.name);
	tbody?.insertAdjacentHTML(
		"beforeend",
		`<tr>
                <th scope="row">${index++}</th>
                <td>${product.name}</td>
                <td>${product.price} $</td>
                <td>${hours}:${minutes}</td>
                <td><button class="btn btn-danger">Delete</button><button class="btn btn-success">Update</button></td>
            </tr>`
	);
});

// var deleteBtn = document.querySelector(".btn-danger")
// var updateBtn = document.querySelector(".btn-success")

tbody?.addEventListener("click", (e) => {
	// if(e.target.className == "btn-")
	console.dir(e.target);
	// deleteBtn?.remove()
});

updateBtn?.addEventListener("click", () => {});
