$(document).keypress(function (e) {
    var keycode = (e.keyCode ? e.keyCode : e.which);
    if (keycode =='13') {
        $("#signup-form").submit();
    }
});

