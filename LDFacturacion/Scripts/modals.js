// Abrir Modal.
$(document).ready(function () {
        $('#myModal').modal('toggle');
});

$(document).keypress(function(e) {
    if (e.keyCode === 13) {

        $(".formArt").submit();
    }
});

$('#nombreCliente').on('keypress', function (e) {
 
    $('#nombreCliente').attr('maxlength', '31');
});

$('#codProducto').on('keypress', function (e) {
   if (!$.isNumeric(String.fromCharCode(e.which))) {
      e.preventDefault();
}
  $('#codProducto').attr('maxlength', '31');
});

$('#money').on('keypress', function (e) {
    if (!$.isNumeric(String.fromCharCode(e.which))) {
        e.preventDefault();
    }
    $('#money').attr('maxlength', '31');
});

$('#desc').on('keypress', function (e) {
    $('#desc').attr('maxlength', '31');
});

$('#cantidad').on('keypress', function (e) {
    if (!$.isNumeric(String.fromCharCode(e.which))) {
        e.preventDefault();
    }
    $('#cantidad').attr('maxlength', '2');
});