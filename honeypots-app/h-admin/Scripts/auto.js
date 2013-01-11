var timer = 10;
var refreshId = setInterval(function () {
    timer--;
    if (timer != 0) {
        $('#autoTimer').html(timer);
    } else {
        location.reload(true);
        stopAuto();
    }
}, 1000);

function stopAuto() {
    if (refreshId !== undefined) {
        clearInterval(refreshId);
    }
}