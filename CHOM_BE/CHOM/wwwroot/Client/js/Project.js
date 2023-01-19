var count = 1;
var total = $('.total').data('id');
var btnTang = document.getElementById("btnTang");
var btnGiam = document.getElementById("btnGiam");
var disp = document.getElementById("display");
var header = document.getElementById("itemsWrapper");
var item = header.getElementsByClassName("swiper-slide");
var itemactive = header.getElementsByClassName("swiper-slide-active");

btnTang.onclick = function () {
    console.log(total);
    setTimeout(() => {
        count++;
        if (count > total) {
            count = 1;
        }
        disp.innerHTML = count;
    }, 600);
    };
btnGiam.onclick = function() {
    setTimeout(() => {
        count--;
        if (count == 0) {
            count = total;
        }

        disp.innerHTML = count;
    }, 600);
    };

function scrolled() {
    alert("scroll");
count++;
console.log(count);
    }

window.addEventListener("scroll", scrolled);

    // for (var i = 0; i < item.length; i++) {
    //     console.log(item[i]);
    // }
