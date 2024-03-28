let raund1 = document.querySelector(".raund1");
let raund3 = document.querySelector(".raund3");
let res = document.querySelector(".input");

let refresh = document.querySelector(".refresh");
let check = document.querySelector(".check");

let puzzleParent = document.querySelector(".puzzle");
let refreshPuzzle = document.querySelector(".refreshPuzzle");
let hack = document.querySelector(".hack");

raund1.textContent = Math.floor(Math.random() * 100);
raund3.textContent = Math.floor(Math.random() * 100);

refresh.addEventListener("click", () => {
	raund1.textContent = Math.floor(Math.random() * 100);
	raund3.textContent = Math.floor(Math.random() * 100);
});

check.addEventListener("click", () => {
	let ress = Number(raund1.textContent) + Number(raund3.textContent);
	if (ress == res.value) {
		alert("To'g'ri");
	} else {
		alert("Noto'g'ri");
	}
});

function shuffle(array) {
	for (let i = array.length - 1; i > 0; i--) {
		let j = Math.floor(Math.random() * (i + 1));
		[array[i], array[j]] = [array[j], array[i]];
	}
}

// puzzle move
let puzzle = document.querySelector(".puzzle");
let puzzleItems = [
	"1",
	"2",
	"3",
	"4",
	"5",
	"6",
	"7",
	"8",
	"9",
	"10",
	"11",
	"12",
	"13",
	"14",
	"15",
	" ",
];

let purePuzzle = puzzleItems.map((a) => a);

shuffle(puzzleItems);
for (let index = 0; index < 16; index++) {
	puzzle.innerHTML += `<button class="puzzle-item btn btn-primary">${puzzleItems[index]}</button>`;
	if (index % 4 == 3) {
		puzzle.innerHTML += `<br>`;
	}
}

let puzzleItemsArray = Array.from(puzzle.children);

let emptyIndex = puzzleItemsArray.indexOf(
	puzzleItemsArray.find((item) => item.textContent == " ")
);

refreshPuzzle.addEventListener("click", () => {
	shuffle(puzzleItems);
	puzzle.innerHTML = "";
	for (let index = 0; index < 16; index++) {
		puzzle.innerHTML += `<button class="puzzle-item btn btn-primary">${puzzleItems[index]}</button>`;
		if (index % 4 == 3) {
			puzzle.innerHTML += `<br>`;
		}
	}
	puzzleItemsArray = Array.from(puzzle.children);
	emptyIndex = puzzleItemsArray.indexOf(
		puzzleItemsArray.find((item) => item.textContent == " ")
	);
});

function checkWin() {
	if (
		Array(...puzzleItemsArray.map((item) => item.textContent))
			.filter((item) => item != "")
			.every((item, index) => item == purePuzzle[index])
	) {
		alert("You win");
	}
}

puzzleParent.addEventListener("click", (e) => {
	if (e.target.textContent == " ") {
		return;
	}
	let clickedIndex = puzzleItemsArray.indexOf(e.target);
	if (
		clickedIndex == emptyIndex - 1 ||
		clickedIndex == emptyIndex + 1 ||
		clickedIndex == emptyIndex - 5 ||
		clickedIndex == emptyIndex + 5
	) {
		[
			puzzleItemsArray[clickedIndex].textContent,
			puzzleItemsArray[emptyIndex].textContent,
		] = [
			puzzleItemsArray[emptyIndex].textContent,
			puzzleItemsArray[clickedIndex].textContent,
		];
		emptyIndex = clickedIndex;
	}
	checkWin();
});

hack.addEventListener("click", () => {
	puzzle.innerHTML = "";
	for (let index = 0; index < 16; index++) {
		puzzle.innerHTML += `<button class="puzzle-item btn btn-primary">${purePuzzle[index]}</button>`;
		if (index % 4 == 3) {
			puzzle.innerHTML += `<br>`;
		}
	}
	puzzleItemsArray = Array.from(puzzle.children);
	emptyIndex = puzzleItemsArray.indexOf(
		puzzleItemsArray.find((item) => item.textContent == " ")
	);
	checkWin();
});
