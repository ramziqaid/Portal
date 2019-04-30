var popup, dataTable;

//$(document).ready(function () {
//    dataTable = $('#example1').DataTable({
//        "ajax": {
//            "url": "Order/Amendments/Index",
//            "type": "GET",
//            "datatype": "json"
//        },
//        "columns": [
//            { "data": "id" },
//            {
//                "data": "id",
//                "render": function (data) {
//                    return "<a class='btn btn-default btn-sm' onclick=ShowPopup('/Home/AddEditTodo/"+data+"')><i class='fa fa-pencil'></i> Edit</a><a class='btn btn-danger btn-sm' style='margin-left:5px' onclick=Delete(" + data + ")><i class='fa fa-trash'></i> Delete</a>";
//                }
//            }
//        ],
//        "language": {
//            "emptyTable": "no data found."
//        }
//    });
//});

function ShowPopup(url, height, width) {
    var formDiv = $('<div/>');
    $.get(url)
        .done(function (response) {
            formDiv.html(response);
            popup = formDiv.dialog({
                autoOpen: true,
                resizeable: false,
                width: width,
                height: height,
                title: 'Add or Edit Data',
                close: function () {
                    popup.dialog('destroy').remove();
                }
            });
        });
}


function SubmitAddEdit(form) {
    $.validator.unobtrusive.parse(form);
    if ($(form).valid()) {
        var data = $(form).serializeJSON();
        data = JSON.stringify(data);
        $.ajax({
            type: 'POST',
            url: '/api/todo',
            data: data,
            contentType: 'application/json',
            success: function (data) {
                if (data.success) {
                    popup.dialog('close');
                    ShowMessage(data.message);
                    dataTable.ajax.reload();
                }
            }
        });
        
    }
    return false;
}

function Delete(id, ControlName, FileName) {
    swal({
        title: "Are you sure want to Delete?",
        text: "You will not be able to restore the file!",
        type: "warning",
        showCancelButton: true,
        confirmButtonColor: "#DD6B55",
        confirmButtonText: "Yes, delete it!",
        closeOnConfirm: true
    }, function () {
        $.ajax({
            type: 'POST',
            url: '/Order/Requests/Delete/?id=' + id + '&ControlName=' + ControlName + '&FileName=' + FileName,
            success: function (data) { 
                //if (data.success) {
                ShowMessage("Delete success.");
                    
                //}
            }
        });
    });


}


function ShowMessage(msg) {
    toastr.options = {
        "closeButton": true,
        "debug": false,
        "newestOnTop": false,
        "progressBar": false,
        "positionClass": "toast-bottom-full-width",
        "preventDuplicates": false,
        "onclick": null,
        "showDuration": "300",
        "hideDuration": "1000",
        "timeOut": "5000",
        "extendedTimeOut": "1000",
        "showEasing": "swing",
        "hideEasing": "linear",
        "showMethod": "fadeIn",
        "hideMethod": "fadeOut"
    };
    toastr["warning"](msg);
}

