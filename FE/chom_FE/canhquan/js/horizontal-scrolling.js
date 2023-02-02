// $(document).ready(function () {
//   $("owl-stage-outer").mousewheel(function (e, delta) {
//     this.scrollLeft -= delta * 200;
//     e.preventDefault();
//   });
// });
const scrollalbe = document.querySelector(".owl-stage");

scrollalbe.addEventListener(
  "wheel",
  function (e) {
    // if (e.deltaY > 0) item.scrollLeft += 100;
    // else item.scrollLeft -= 100;
    if (e.wheelDelta > 0) {
      this.scrollLeft -= 100;
    } else {
      this.scrollLeft += 100;
    }
  },
  { passive: true }
);
