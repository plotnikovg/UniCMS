function openAuth() {
    document.getElementById("authorizationPage").classList.toggle("Visible");
    document.getElementById("hidden").classList.toggle("Visible1");

    document.getElementById("header").classList.toggle("blur");
    document.getElementById("main").classList.toggle("blur");

};
function closeAuth() {
    document.getElementById("authorizationPage").classList.toggle("Visible");
    document.getElementById("hidden").classList.toggle("Visible1");

    document.getElementById("header").classList.toggle("blur");
    document.getElementById("main").classList.toggle("blur");
};


$(document).ready(function () {
    $('.bg').mouseover(function () {
        $(this).addClass('active');
        $(this).children('.priceHover').addClass('visible');
    });
    $('.bg').mouseout(function () {
        $(this).removeClass('active');
        $(this).children('.priceHover').removeClass('visible');

    });
});

