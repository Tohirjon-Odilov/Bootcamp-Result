console.log("salom");
self.addEventListener(
	"message",
	function (e) {
		self.postMessage(e.data);
		console.log(e.data);
	},
	false
);
