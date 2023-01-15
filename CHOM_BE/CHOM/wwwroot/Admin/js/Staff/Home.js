﻿
$(document).ready(function () {
    var _id;
    $('.btn-success-delete').on('click', function () {
        console.log("111");
        $.ajax({
            type: "POST",
            dataType: "Json",
            url: '/Admin/Staff/Delete',
            data: {
                id: _id
            },
            success: function (res) {
                if (res.status == true) {
                    var _elementString = ".btn-" + _id;
                    $('#exampleModal').modal('hide');
                    $(_elementString).remove();
                } else {
                    console.log("khong thanh công");
                }
            }
        })
    })

    $('.btn-delete').on('click', function () {
        _id = $(this).data('id');
    });

});