$(document).ready(function () {
    setInterval(function () {
        $('.txt-min').text($('.swiper-slide-active').data('count'))
    }, 500)

    $('.img-mask').on('click', function () {
        console.log("check");
    })
})