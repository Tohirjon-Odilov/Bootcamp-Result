let input = document.querySelector(".input");

document.querySelector(".add").addEventListener("click", function () {
	let li = document.createElement("li");
	li.innerHTML = input.value;
	document.querySelector("ol").appendChild(li);
	input.value = "";
});
