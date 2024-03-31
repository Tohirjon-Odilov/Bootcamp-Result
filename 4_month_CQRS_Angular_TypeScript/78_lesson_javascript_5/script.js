let test = new Worker("test.js");
// test.onmessage = function (e) {
// 	console.log(e.data);
// 	console.log(e.data.length);
// };

test.postMessage("hello");