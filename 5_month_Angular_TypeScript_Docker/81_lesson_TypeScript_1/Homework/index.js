// function login() {
// 	const username = document.getElementById("username").value;
// 	const password = document.getElementById("password").value;

// 	fetch("https://api.sardorsohinazarov.uz/api/Auth/Login", {
// 		method: "POST",
// 		headers: {
// 			"Content-Type": "application/json",
// 		},
// 		body: JSON.stringify({ username, password }),
// 	})
// 		.then((response) => {
// 			console.log(response);
// 			if (!response.ok) {
// 				throw new Error("Login failed");
// 			}
// 			return response.json();
// 		})
// 		.then((data) => {
// 			// Handle successful login, e.g., redirect to dashboard
// 			console.log("Login successful:", data);

// 			document.querySelector(".login-container").style.display = "none";

// 			// Displaying devices as a list
// 			var deviceList = document.getElementById("device-list");
// 			deviceList.innerHTML = "<h3>List of Devices:</h3>";
// 			var table = document.createElement("table");
// 			var thead = document.createElement("thead");
// 			var tbody = document.createElement("tbody");

// 			// Creating table header
// 			var headerRow = document.createElement("tr");
// 			var headers = ["ID", "Full Name", "Phone Number", "Car Number"]; // Add carNumber here
// 			headers.forEach((headerText) => {
// 				var th = document.createElement("th");
// 				th.textContent = headerText;
// 				headerRow.appendChild(th);
// 			});
// 			thead.appendChild(headerRow);
// 			table.appendChild(thead);

// 			// Creating table body
// 			data.forEach((device) => {
// 				var tr = document.createElement("tr");
// 				var values = [
// 					device.id,
// 					device.fullName,
// 					device.phoneNumber,
// 					device.carNumber,
// 				]; // Add carNumber here
// 				values.forEach((value) => {
// 					var td = document.createElement("td");
// 					td.textContent = value;
// 					tr.appendChild(td);
// 				});
// 				tbody.appendChild(tr);
// 			});
// 			table.appendChild(tbody);

// 			deviceList.appendChild(table);
// 			alert("Login successful!");
// 		})

// 		.catch((error) => {
// 			// Handle login failure
// 			console.error("Login error:", error);
// 			// alert("Login failed. Please check your credentials.");
// 		});
// }

document
	.getElementById("login-form")
	.addEventListener("submit", function (event) {
		event.preventDefault();

		var username = document.getElementById("username").value;
		var password = document.getElementById("password").value;

		fetch("https://api.sardorsohinazarov.uz/api/Auth/Login", {
			method: "POST",
			headers: {
				"Content-Type": "application/json",
			},
			body: JSON.stringify({
				username: username,
				password: password,
			}),
		})
			.then((response) => {
				if (!response.ok) {
					throw new Error("Network response was not ok");
				}
				return response.json();
			})
			.then((data) => {
				fetch("https://api.sardorsohinazarov.uz/api/Devices/GetAll", {
					method: "GET",
					headers: {
						Authorization: "Bearer " + data.accessToken,
					},
				})
					.then((response) => {
						if (!response.ok) {
							throw new Error("Network response was not ok");
						}
						return response.json();
					})
					.then((data) => {
                        document.querySelector(".login-container").style.display = "none"
						// Displaying devices as a list
						var deviceList = document.getElementById("device-list");
						deviceList.innerHTML = "<h3>List of Devices:</h3>";
						var table = document.createElement("table");
						var thead = document.createElement("thead");
						var tbody = document.createElement("tbody");

						// Creating table header
						var headerRow = document.createElement("tr");
						var headers = [
							"ID",
							"Full Name",
							"Phone Number",
							"Car Number",
						]; // Add carNumber here
						headers.forEach((headerText) => {
							var th = document.createElement("th");
							th.textContent = headerText;
							headerRow.appendChild(th);
						});
						thead.appendChild(headerRow);
						table.appendChild(thead);

						// Creating table body
						data.forEach((device) => {
							var tr = document.createElement("tr");
							var values = [
								device.id,
								device.fullName,
								device.phoneNumber,
								device.carNumber,
							]; // Add carNumber here
							values.forEach((value) => {
								var td = document.createElement("td");
								td.textContent = value;
								tr.appendChild(td);
							});
							tbody.appendChild(tr);
						});
						table.appendChild(tbody);

						deviceList.appendChild(table);
						alert("Login successful!");
					})
					.catch((error) => {
						console.error("Fetch request failed:", error);
					});
			})
			.catch((error) => {
				console.error("Fetch request failed:", error);
				alert("Login failed. Please try again.");
			});
	});
