


$(document).ready(function () {
    function deleteFile() {
        if ($('.txt-Img').val()) {
            $.ajax({
                url: "/Admin/Project/DeleteImage",
                dataType: "Json",
                type: "POST",
                data: {
                    deleteFile: $('.txt-Img').val()
                },
            });
            $('.txt-Img').attr("value", "");
        }
    }
    $('.btn-uploadfile').on('click', function () {
        var files = $('.addFile').prop("files");
        var url = "/Admin/Project/AddImage?handler=File";
        formData = new FormData();
        formData.append("File", files[0]);
        deleteFile();
        $.ajax({
            url: url,
            type: "POST",
            dataType: "JSON",
            data: formData,
            contentType: false,
            processData: false,
            cache: false,
            success: function (res) {
                if (res.status == false) {
                    console.log(res.message);
                    $('.txt-notification').text(res.message);
                    $('.txt-notification').css('display', 'block');
                }
                else {
                    $('.txt-notification').css('display', 'none');
                    var link = "/uploadFiles/" + res.fileName;
                    $('.uploadFile').attr("src", link);
                    $('.txt-Img').val(res.fileName);
                }
            }
        });
    });
});