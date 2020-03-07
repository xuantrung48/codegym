var devices = {} || devices;

$(function(){
    devices.init();
})

$(document).on("click", '[data-toggle="lightbox"]', function(event) {
    event.preventDefault();
    $(this).ekkoLightbox();
});

devices.drawTable = function() {
    $.ajax({
        url: "http://localhost:3000/Devices",
        method: "GET",
        datatype: "json",
        success: function(data){
            $.each(data, function(i, v){
                let imagesDevice = "";
                for (let i = 0; i < v.Images.length; i++) {
                    imagesDevice += "<a href='" + v.Images[i] + "'data-toggle='lightbox' data-gallery='gallery'><img src='" + v.Images[i] + "' width='30'></a> ";
                }
                $("#tbDevices").append(
                    "<tr><td>" + v.id + "</td><td>" + v.Name + "</td><td>" + imagesDevice + "</td><td>" + v.Brand + "</td><td>" + v.Status + " %</td><td>" + v.Price + " VND</td><td><i class='fa fa-edit' title='Edit this device'></i> <i class='fa fa-trash' title='Remove this device'></i></td></tr>"
                );
            })
        }
    })
}

devices.init = function() {
    devices.drawTable();
}

devices.openModal = function() {
    $('#myModal').modal('show');
}