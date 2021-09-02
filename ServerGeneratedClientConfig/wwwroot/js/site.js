// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

$(() => {

	let str = "CONFIG!<br />";

	for (let i in window.global) {
		if (!window.global.hasOwnProperty(i)) {
			continue;
		}
		str += i + " = " + window.global[i] + "<br />";
	}

	$("#config").html(str);
});
