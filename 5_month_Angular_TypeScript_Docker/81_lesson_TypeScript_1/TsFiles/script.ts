class Product {
	readonly name: string;
	readonly price: number;

	constructor(name: string, price: number) {
		this.name = name;
		this.price = price;
	}
}

var tbody = document.querySelector("tbody");
var container = document.querySelector(".container");
var createRow = document.querySelector(".create-row");

var index: number = 1;
// console.log(tbody);

var productName: unknown;
var productPrice: unknown;

createRow?.addEventListener("click", () => {
	// Create a new Date object
	const currentDate = new Date();

	// Get the current time components
	const hours = currentDate.getHours(); // 0-23
	const minutes = currentDate.getMinutes(); // 0-59
	const seconds = currentDate.getSeconds(); // 0-59

	productName = (<HTMLInputElement>document.querySelector(".productName"))
		.value;
	productPrice = +(<HTMLInputElement>(
		document.querySelector("#floatingPassword")
	)).value;
	var product: Product = new Product(
		productName as string,
		productPrice as number
	);

	tbody?.insertAdjacentHTML(
		"beforeend",
		`<tr>
                <th scope="row">${index++}</th>
                <td>${product.name}</td>
                <td>${product.price} $</td>
                <td>${hours}:${minutes}</td>
                <td><button class="btn btn-danger">Delete</button><button class="btn btn-success" data-bs-toggle="modal" data-bs-target="#exampleModal">Update</button></td>
            </tr>`
	);
});

var namee: HTMLTableRowElement;
var price: HTMLTableRowElement;

var inputName: HTMLInputElement;
var inputPrice: HTMLInputElement;

tbody?.addEventListener("click", (e) => {
	var el = <Element>e.target;
	if (el.classList[1] == "btn-danger") {
		el.parentElement?.parentElement?.remove();
	} else if (el.classList[1] == "btn-success") {
		namee = el.parentElement?.parentElement as HTMLTableRowElement;
		price = el.parentElement?.parentElement as HTMLTableRowElement;

		inputName = document.querySelector("#nameModal") as HTMLInputElement;
		inputPrice = document.querySelector("#priceModal") as HTMLInputElement;

		inputName.value = namee?.childNodes[3].textContent as string;
		inputPrice.value = price?.childNodes[5].textContent?.slice(
			0,
			-2
		) as string;
	}
});

document.addEventListener("click", (e) => {
	var el = e.target as HTMLElement;

	if (el.classList[2] == "save") {
		console.log(
			el.parentElement?.parentElement?.parentElement?.parentElement
				?.parentElement?.childNodes[3].childNodes[1].childNodes[1]
				.childNodes[5].childNodes[3].childNodes[0].childNodes[3]
		);

		namee.childNodes[3].textContent = inputName.value;
		price.childNodes[5].textContent = inputPrice.value;
	}
});
