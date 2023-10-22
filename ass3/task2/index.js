$(document).ready(function () {
    $("#changeclr_button").click(function () {
        var colorR = Math.floor((Math.random() * 256));
        var colorG = Math.floor((Math.random() * 256));
        var colorB = Math.floor((Math.random() * 256));
        $("#circle").css("background-color", "rgb(" + colorR + "," + colorG + "," + colorB + ")");
    });
    $("#resize_button").click(function () {
        var size = Math.floor((Math.random() * 400) + 10) + "px";
        $("#circle").css({ "width": size, "height": size });
    });
});