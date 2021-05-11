$(document).ready(function () {
    $(".image").mouseover(function () {
        let x = (this.id);
        let y = `#${x}`;
        let y1 = `.${x}`;
        $(y).css("background-color", "#429341");
        $(y1).css("background-color", "#429341");
    });
    $(".image").mouseout(function () {
        let x = (this.id);
        let y = `#${x}`;
        let y1 = `.${x}`;
        $(y).css("background-color", "#48577D");
        $(y1).css("background-color", "#48577D");
    });
});

let pos = 0;
function openMenu() {
    if (pos === 0) {
        document.getElementById('adminhidden1').classList.toggle('active');
        pos = 1;
    }
}
function closeMenu() {
    if (pos === 1) {
        document.getElementById('adminhidden1').classList.toggle('active');
        pos = 0;
    }
}

