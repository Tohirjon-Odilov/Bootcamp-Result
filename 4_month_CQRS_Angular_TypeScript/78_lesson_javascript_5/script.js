if (typeof Worker !== undefined) {
	console.log("Web Worker support!");
} else {
	console.log("Web Worker not supported!");
}

let worker = new Worker("test.js");

worker.postMessage("Hello World");

// if (typeof Worker !== "undefined") {
// 	console.log("Web Worker support!");
// 	w = new Worker("test.js");
// } else {
// 	console.log("Sorry! No Web Worker support..");
// }

// w.postMessage("Hello from the main thread");

worker.onmessage = function (event) {
	document.querySelector(".hero").innerHTML = event.data;
};

function s() {
	w.terminate();
	return "Terminate worker";
}
