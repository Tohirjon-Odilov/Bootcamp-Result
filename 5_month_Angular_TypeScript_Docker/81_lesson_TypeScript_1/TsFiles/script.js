var Product = /** @class */ (function () {
    function Product(name, price) {
        this.name = name;
        this.price = price;
    }
    return Product;
}());
var tbody = document.querySelector("tbody");
var container = document.querySelector(".container");
var createRow = document.querySelector(".create-row");
var index = 1;
// console.log(tbody);
var productName;
var productPrice;
createRow === null || createRow === void 0 ? void 0 : createRow.addEventListener("click", function () {
    // Create a new Date object
    var currentDate = new Date();
    // Get the current time components
    var hours = currentDate.getHours(); // 0-23
    var minutes = currentDate.getMinutes(); // 0-59
    var seconds = currentDate.getSeconds(); // 0-59
    productName = document.querySelector(".productName")
        .value;
    productPrice = +(document.querySelector("#floatingPassword")).value;
    var product = new Product(productName, productPrice);
    console.log(product.price);
    tbody === null || tbody === void 0 ? void 0 : tbody.insertAdjacentHTML("beforeend", "<tr>\n                <th scope=\"row\">".concat(index++, "</th>\n                <td>").concat(product.name, "</td>\n                <td>").concat(product.price, " $</td>\n                <td>").concat(hours, ":").concat(minutes, "</td>\n                <td><button class=\"btn btn-danger\">Delete</button><button class=\"btn btn-success\" data-bs-toggle=\"modal\" data-bs-target=\"#exampleModal\">Update</button></td>\n            </tr>"));
});
// <button
// 				type="button"
// 				class="btn btn-primary"
// 				data-bs-toggle="modal"
// 				data-bs-target="#exampleModal"
// 				data-bs-whatever="@getbootstrap"
//                 id="add"
// 			>
// 				Add
// 			</button>
var namee;
var price;
var inputName;
var inputPrice;
tbody === null || tbody === void 0 ? void 0 : tbody.addEventListener("click", function (e) {
    var _a, _b, _c, _d, _e;
    var el = e.target;
    if (el.classList[1] == "btn-danger") {
        (_b = (_a = el.parentElement) === null || _a === void 0 ? void 0 : _a.parentElement) === null || _b === void 0 ? void 0 : _b.remove();
    }
    else if (el.classList[1] == "btn-success") {
        namee = (_c = el.parentElement) === null || _c === void 0 ? void 0 : _c.parentElement;
        price = (_d = el.parentElement) === null || _d === void 0 ? void 0 : _d.parentElement;
        inputName = document.querySelector("#nameModal");
        inputPrice = document.querySelector("#priceModal");
        // var inputName = el.parentElement?.parentElement?.parentElement
        // 	?.parentElement?.parentElement?.childNodes[3].childNodes[1]
        // 	.childNodes[1] as HTMLInputElement;
        // var inputPrice = el.parentElement?.parentElement?.parentElement
        // 	?.parentElement?.parentElement?.childNodes[3].childNodes[3]
        // 	.childNodes[1] as HTMLInputElement;
        inputName.value = namee === null || namee === void 0 ? void 0 : namee.childNodes[3].textContent;
        inputPrice.value = (_e = price === null || price === void 0 ? void 0 : price.childNodes[5].textContent) === null || _e === void 0 ? void 0 : _e.slice(0, -2);
    }
});
document.addEventListener("click", function (e) {
    var _a, _b, _c, _d, _e;
    var el = e.target;
    // console.log("         ");
    console.log(namee.childNodes);
    if (el.classList[2] == "save") {
        console.log((_e = (_d = (_c = (_b = (_a = el.parentElement) === null || _a === void 0 ? void 0 : _a.parentElement) === null || _b === void 0 ? void 0 : _b.parentElement) === null || _c === void 0 ? void 0 : _c.parentElement) === null || _d === void 0 ? void 0 : _d.parentElement) === null || _e === void 0 ? void 0 : _e.childNodes[3].childNodes[1].childNodes[1].childNodes[5].childNodes[3].childNodes[0].childNodes[3]);
        // var a = el.parentElement?.parentElement?.parentElement?.parentElement
        // 	?.parentElement?.childNodes[3].childNodes[1].childNodes[1]
        // 	.childNodes[5].childNodes[3].childNodes[0]
        // 	.childNodes[3] as HTMLElement;
        // var b = el.parentElement?.parentElement?.parentElement?.parentElement
        // 	?.parentElement?.childNodes[3].childNodes[1].childNodes[1]
        // 	.childNodes[5].childNodes[3].childNodes[0]
        // 	.childNodes[5] as HTMLElement;
        namee.childNodes[3].textContent = inputName.value;
        price.childNodes[5].textContent = inputPrice.value;
    }
});
