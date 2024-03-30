const BOT_USERNAME = "@EXAM_VKM_bot"; // place username of your bot here

function getTelegramUserData() {
	if (document.cookie.includes("tg_user")) {
		const auth_data_json = decodeURIComponent(
			document.cookie.replace(
				/(?:(?:^|.*;\s*)tg_user\s*\=\s*([^;]*).*$)|^.*$/,
				"$1"
			)
		);
		const auth_data = JSON.parse(auth_data_json);
		return auth_data;
	}
	return false;
}

if (window.location.search.includes("logout")) {
	document.cookie =
		"tg_user=; expires=Thu, 01 Jan 1970 00:00:00 UTC; path=/;";
	window.location.href = "login_example.php";
}

const tg_user = getTelegramUserData();

if (tg_user !== false) {
	const first_name = tg_user.first_name;
	const last_name = tg_user.last_name;
	let html = `<h1>Hello, ${first_name} ${last_name}!</h1>`;

	if (tg_user.username) {
		const username = tg_user.username;
		html += `<h1>Hello, <a href="https://t.me/${username}">${first_name} ${last_name}</a>!</h1>`;
	}

	if (tg_user.photo_url) {
		const photo_url = tg_user.photo_url;
		html += `<img src="${photo_url}">`;
	}

	html += `<p><a href="?logout=1">Log out</a></p>`;
} else {
	const bot_username = BOT_USERNAME;
	const html = `
    <h1>Hello, anonymous!</h1>
    <script async src="https://telegram.org/js/telegram-widget.js?2" data-telegram-login="${bot_username}" data-size="large" data-auth-url="check_authorization.php"></script>
  `;
}

document.write(`
<!DOCTYPE html>
<html>
  <head>
    <meta charset="utf-8">
    <title>Login Widget Example</title>
  </head>
`);

console.log("salom");
