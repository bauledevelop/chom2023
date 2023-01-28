


$(document).ready(function () {
    function deleteFile() {
        if ($('.txt-Img').val()) {
            $.ajax({
                url: "/Admin/Image/DeleteImageGT",
                dataType: "Json",
                type: "POST",
                data: {
                    deleteFile: $('.txt-Img').val()
                },
            });
            $('.txt-Img').attr("value", "");
        }
    }
    $('.img-gt').on("change", function () {
        var files = $('.addFile').prop("files");
        var url = "/Admin/Image/AddImage?handler=File";
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
                    var link = "/fileImages/" + res.fileName;
                    $('.uploadFile').attr("src", link);
                    $('.txt-Img').val(res.fileName);
                }
            }
        });
    })
})