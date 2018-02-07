window.onkeyup = function (e) {
    var event = e.which || e.keyCode || 0; // .which with fallback

    if (event === 27) { // ESC Key
        window.location.href = 'http://' + window.location.hostname + ":" + window.location.port + '/account/login'; // Navigate to URL
    }
};

$(document).ready(function () {
    // Copy meta fields
    $('.value-copy').on('input', function () {
        var target = '#' + $(this).attr('data-target');
        $(target).val($(this).val());
    });

    // create date time picker
    $('.date-picker').datepicker({ autoclose: true, todayBtn: 'linked' });
});