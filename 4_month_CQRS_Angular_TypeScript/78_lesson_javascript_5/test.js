self.addEventListener("message", (e) => {
	console.log(e.data);
});

let i = 0;

function itrerate() {
	i++;
	postMessage(i);

	// setTimeout("itrerate()", 500);
}

itrerate();

// self.addEventListener("message", function (e) {
// 	// self.postMessage(e.data);
// 	console.log(e.data);
// });

// let i = 0;

// function timedCount() {
// 	i++;
// 	postMessage(i);
// 	setTimeout("timedCount()", 500);
// }

// timedCount();
