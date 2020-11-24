$(document).ready(function () {
	$('#search').on("keyup", function () {
		var search = $("#search").val();
		var searchby = $("#searchby").val();
		var see = $('#see').val();
		$("table tr").each(function (results) {
			if (results !== 0) {
				var id = $(this).find("td:nth-child(" + searchby + ")").text();
				if (id.toLowerCase().indexOf(search.toLowerCase()) < 0) {
					$(this).hide();
				}
				else {
					if (id.indexOf(see) < 0) {
						$(this).hide();
					}
					else {
						$(this).show();
                    }
                }
            }
		});
	});
	$('#see').change(function () {
		var search = $("#search").val();
		var see = $('#see').val();
		$("table tr").each(function (results) {
			if (results !== 0) {
				var id = $(this).find("td:nth-child(5)").text();
				if (id.toLowerCase().indexOf(search.toLowerCase()) < 0) {
					$(this).hide();
				}
				else {
					if (id.indexOf(see) < 0) {
						$(this).hide();
					}
					else {
						$(this).show();
					}
				}
			}
		});
	});
});