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
        if (count >= total) {
            count = 1;
        } else {
            count++;
        }
        disp.innerHTML = count;
    }, 400);
    };
btnGiam.onclick = function() {
    setTimeout(() => {
        if (count > total || count == 1) {
            count = total;
        } else count--;

        disp.innerHTML = count;
    }, 400);
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
