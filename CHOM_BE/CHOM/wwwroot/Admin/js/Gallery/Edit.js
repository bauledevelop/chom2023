$(document).ready(function () {
    $('.check-img').on('change', function () {
        var _size = this.files[0].size;
        var _mathSize = (_size / 1048576).toFixed(2);
        if (_mathSize > 1) {
            $('.txt-notification').css('display', 'block');
            $('.txt-notification').text('Vui lòng upload hình dưới 1MB');
            $('.check-img').val('');
        }
        else {
            $('.txt-notification').css('display', 'none');
            $('.txt-notification').text('');

        }
    })
})