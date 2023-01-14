

var count = 1;
var btnTang = document.getElementById("btnTang");
var btnGiam = document.getElementById("btnGiam");
var disp = document.getElementById("display");

btnTang.onclick = function () {
    if (count < 30) {
        count++;
    }

    disp.innerHTML = count;
}
btnGiam.onclick = function () {
    if (count > 30 || count < 0) {
        count = 30;
    }

    else count--;

    disp.innerHTML = count;
}

        // var header = document.getElementById("itemsWrapper");
        // var item = header.getElementsByClassName("swiper-slide");
        // for (var i = 0; i < btns.length; i++){
        //     var current = document.getElementsByClassName("active");
        // }