$(function(){
	init();
})

init = function() {
	productsList();
}

displayPriceWithDot = function(price) {
	return price.toString().replace(/\B(?=(\d{3})+(?!\d))/g, ".");
}

productsList = function() {
	$.ajax({
		url: "http://localhost:3000/Devices",
		method: "GET",
		datatype: "json",
		success: function(data){
			$("#Products").empty();
			$.each(data, function(i, v){
				$("#Products").append(
					'<div class="col-md-4 mb-5"><div class="card h-100"><img class="card-img-top" src="' + v.Images[0] + '" alt=""><div class="card-body"><h4 class="card-title">' + v.Name + '</h4><div class="card-text">' + 'Brand: ' + v.Brand.Name + '<br>CPU: ' + v.CPU + '<br>Screen: '  + v.Screen + '<br>OS: ' + v.OS + '<br>Rear Camera: ' + v.RearCamera + '<br>Front Camera: ' + v.FrontCamera + '<br>Ram: ' + v.Ram + ' GB<br>Rom: ' + v.Rom + ' GB<br>Status: ' + v.Status + ' %<br><span class="btn btn-primary">Price: ' + displayPriceWithDot(v.Price) + ' ₫</span></div></div></div></div>'
				);
			})
		}
	})
}