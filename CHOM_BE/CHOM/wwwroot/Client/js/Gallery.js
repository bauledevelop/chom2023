


var gallery = document.querySelector("#gallery");
var getVal = function (elem, style) {
    return parseInt(window.getComputedStyle(elem).getPropertyValue(style));
};
var getHeight = function (item) {
    return item.getBoundingClientRect().height;
};
var resizeAll = function () {
    var altura = getVal(gallery, "grid-auto-rows");
    var gap = getVal(gallery, "grid-row-gap");
    gallery.querySelectorAll(".gallery-item").forEach(function (item) {
        var el = item;
        el.style.gridRowEnd =
            "span " + Math.ceil((getHeight(item) + gap) / (altura + gap));
    });
};
gallery.querySelectorAll("img").forEach(function (item) {
    var altura = getVal(gallery, "grid-auto-rows");
    var gap = getVal(gallery, "grid-row-gap");
    var gitem = item.parentElement.parentElement;
    const height = getHeight(gitem);
    gitem.parentElement.style.gridRowEnd =
        "span " + Math.ceil((height + gap) / (altura + gap));
});