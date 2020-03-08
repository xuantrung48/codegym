var devices = {} || devices;

$(function(){
	devices.init();
})

devices.init = function() {
	devices.drawTable();
	devices.initBrand();
}

devices.initBrand = function() {
	$.ajax({
		url: "http://localhost:3000/Brands",
		method: "GET",
		datatype: "json",
		success: function(data){
			$.each(data, function(i, v){
				$("#Brand").append(
					"<option value='" + v.id + "'>" + v.Name + "</option>"
				);
			})
		}
	})
}

devices.save = function() {
	if($("#formAddEditDevice").valid()) {
		if($("#id").val() == 0) {
			var deviceObj		= {};
			deviceObj.Name		= $("#Name").val();
			deviceObj.Images	= [];
			if ($("#Images0").val() != "")
				deviceObj.Images.push($("#Images0").val());
			if ($("#Images1").val() != "")
				deviceObj.Images.push($("#Images1").val());
			if ($("#Images2").val() != "")
				deviceObj.Images.push($("#Images2").val());
			var brandObj		= {};
			brandObj.id			= $("#Brand").val();
			brandObj.Name		= $("#Brand option:selected").html();
			deviceObj.Brand		= brandObj;
			deviceObj.Status	= $("#Status").val();
			deviceObj.Price		= $("#Price").val();
			$.ajax({
				url: "http://localhost:3000/Devices",
				method: "POST",
				dataType: "json",
				contentType: "application/json",
				data: JSON.stringify(deviceObj),
				success: function(data) {
					$('#myModal').modal('hide');
					devices.drawTable();
				}
			});
		} else {
			var deviceObj		= {};
			deviceObj.id		= $("#id").val();
			deviceObj.Name		= $("#Name").val();
			deviceObj.Images	= [];
			if ($("#Images0").val() != "")
				deviceObj.Images.push($("#Images0").val());
			if ($("#Images1").val() != "")
				deviceObj.Images.push($("#Images1").val());
			if ($("#Images2").val() != "")
				deviceObj.Images.push($("#Images2").val());
			var brandObj		= {};
			brandObj.id			= $("#Brand").val();
			brandObj.Name		= $("#Brand option:selected").html();
			deviceObj.Brand		= brandObj;
			deviceObj.Status	= $("#Status").val();
			deviceObj.Price		= $("#Price").val();
			$.ajax({
				url: "http://localhost:3000/Devices/" + deviceObj.id,
				method: "PUT",
				dataType: "json",
				contentType: "application/json",
				data: JSON.stringify(deviceObj),
				success: function(data) {
					$('#myModal').modal('hide');
					devices.drawTable();
				}
			});
		}
	}
}

$(document).on("click", '[data-toggle="lightbox"]', function(event) {
	event.preventDefault();
	$(this).ekkoLightbox();
});

devices.openModal = function() {
	devices.reset();
	$('#myModal').modal('show');
}

devices.reset = function() {
	$("#deviceModalTitle").text("Add new device:");
	$("#addButton").text("Add");
	$("#id").val('0');
	$("#Name").val('');
	$("#Images0").val('');
	$("#Images1").val('');
	$("#Images2").val('');
	$("#Brand").val('');
	$("#Status").val('');
	$("#Price").val('');
	var validator = $("#formAddEditDevice").validate();
	validator.resetForm();
}

devices.drawTable = function() {
	$.ajax({
		url: "http://localhost:3000/Devices",
		method: "GET",
		datatype: "json",
		success: function(data){
			$("#tbDevices").empty();
			$.each(data, function(i, v){
				let imagesDevice = "";
				for (let i = 0; i < v.Images.length; i++) {
					imagesDevice += "<a href='" + v.Images[i] + "'data-toggle='lightbox' data-gallery='gallery'><img src='" + v.Images[i] + "' height='50'></a> ";
				}
				$("#tbDevices").append(
					"<tr><td>" + v.id + "</td><td>" + v.Name + "</td><td>" + imagesDevice + "</td><td>" + v.Brand.Name + "</td><td>" + v.Status + " %</td><td>" + v.Price + " VND</td><td><a href='javascript:void(0);' onclick='devices.get(" + v.id + ")'><i class='fa fa-edit' title='Edit this device'></i></a> <a href='javascript:void(0);' onclick='devices.remove(" + v.id + ")'><i class='fa fa-trash' title='Remove this device'></i></a></td></tr>"
				);
			})
		}
	})
}

devices.get = function(id) {
	$.ajax({
		url: "http://localhost:3000/Devices/" + id,
		method: "GET",
		dataType: "json",
		success: function(data) {
			$("#deviceModalTitle").text("Update device details:");
			$("#addButton").text("Update");
			$("#id").val(data.id);
			$("#Name").val(data.Name);
			$("#Images0").val(data.Images[0]);
			$("#Images1").val(data.Images[1]);
			$("#Images2").val(data.Images[2]);
			$("#Brand").val(id);
			$("#Status").val(data.Status);
			$("#Price").val(data.Price);
			var validator = $("#formAddEditDevice").validate();
			validator.resetForm();
			$('#myModal').modal('show');
		}
	});
}

devices.remove = function(id) {
	bootbox.confirm({
		title: "Remove device?",
		message: "Do you really want to remove this device? This cannot be undone.",
		buttons: {
			cancel: {
				label: '<i class="fa fa-times"></i> No'
			},
			confirm: {
				label: '<i class="fa fa-check"></i> Yes'
			}
		},
		callback: function (result) {
			if (result) {
				$.ajax({
					url: "http://localhost:3000/Devices/" + id,
					method: "DELETE",
					dataType: "json",
					success: function(data) {
						devices.drawTable();
					}
				});
			}
		}
	});
}