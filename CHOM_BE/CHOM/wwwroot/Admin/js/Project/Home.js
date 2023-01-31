

$(document).ready(function () {
    var _id;
    $('.dataTables_length').css('display', 'none')
    $('.btn-success-delete').on('click', function () {
        $.ajax({
            type: "POST",
            dataType: "Json",
            url: '/Admin/Project/Delete',
            data: {
                id: _id
            },
            success: function (res) {
                if (res.status == true) {
                    var _elementString = ".btn-" + _id;
                    $('#exampleModal').modal('hide');
                    $(_elementString).remove();
                }
            }
        })
    })

    $('.btn-delete').on('click', function () {
        _id = $(this).data('id');
    });

});