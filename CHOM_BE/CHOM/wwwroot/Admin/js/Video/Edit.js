

$(document).ready(function () {
    $('.uploadVideo').on('change', function () {
        if ($(this).val() == '') {
            return;
        }
        $('.spinner-single').css('display', 'block');
        $('.txt-notification-gt').css('display', 'none');
        $(this).prop('disabled', true);
        var _size = this.files[0].size;
        var _mathSize = (_size / 1048576).toFixed(2);
        if (_mathSize > 24) {
            $('.txt-notification-gt').css('display', 'block');
            $('.txt-notification-gt').text('Vui lòng upload video dưới 24MB');
            $('.uploadVideo').val('');
            $('.spinner-single').css('display', 'none');
            $(this).prop('disabled', false);
            return;
        }
        setTimeout(function () {
            var files = $('.uploadVideo').prop("files");
            var url = "/Admin/Video/ChangeVideo?handler=File";
            formData = new FormData();
            formData.append("File", files[0]);
            $.ajax({
                url: url,
                type: "POST",
                dataType: "JSON",
                data: formData,
                contentType: false,
                processData: false,
                cache: false,
                success: function (res) {
                    if (res.status === true) {
                        var link = "/contact/" + res.data;
                        $('.loadingVideo').attr('src', link);
                        $('.reloadVideo')[0].load();
                    } else {

                    }
                    $('.spinner-single').css('display', 'none'); 
                    $('.uploadVideo').prop('disabled', false);
                }
            })
        })
    })
})