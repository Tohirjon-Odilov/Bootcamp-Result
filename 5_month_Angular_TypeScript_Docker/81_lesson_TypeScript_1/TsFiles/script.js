// import { Product } from "./ProductModel";
// var product1 = new Product("Redmi 11", 1200);
// console.log(product1.name)
var Product = /** @class */ (function () {
    function Product(name, price) {
        this.name = name;
        this.price = price;
    }
    return Product;
}());
// var list: Array<Product> = [];
var tbody = document.querySelector("tbody");
var createRow = document.querySelector(".create-row");
var index = 1;
console.log(tbody);
createRow === null || createRow === void 0 ? void 0 : createRow.addEventListener("click", function () {
    // Create a new Date object
    var currentDate = new Date();
    // Get the current time components
    var hours = currentDate.getHours(); // 0-23
    var minutes = currentDate.getMinutes(); // 0-59
    var seconds = currentDate.getSeconds(); // 0-59
    // const milliseconds = currentDate.getMilliseconds(); // 0-999
    // tbody = null;
    // console.log(tbody);
    // tbody?.innerHTML = ""
    var productName = (document.querySelector(".productName")).value;
    var productPrice = +(document.querySelector(".productPrice")).value;
    var product = new Product(productName, productPrice);
    console.log(product.name);
    tbody === null || tbody === void 0 ? void 0 : tbody.insertAdjacentHTML("beforeend", "<tr>\n                <th scope=\"row\">".concat(index++, "</th>\n                <td>").concat(product.name, "</td>\n                <td>").concat(product.price, " $</td>\n                <td>").concat(hours, ":").concat(minutes, "</td>\n                <td><button class=\"btn btn-danger\">Delete</button><button class=\"btn btn-success\">Update</button></td>\n            </tr>"));
});
// var deleteBtn = document.querySelector(".btn-danger")
// var updateBtn = document.querySelector(".btn-success")
tbody === null || tbody === void 0 ? void 0 : tbody.addEventListener("click", function (e) {
    // if(e.target.className == "btn-")
    console.dir(e.target);
    // deleteBtn?.remove()
});
updateBtn === null || updateBtn === void 0 ? void 0 : updateBtn.addEventListener("click", function () { });
