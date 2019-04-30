var popup, dataTable;

$(document).ready(function () {
    dataTable = $('#gridTodo').DataTable({
        "ajax": {
            "url": "/api/Requests",
            "type": "GET",
            "datatype": "json"
        },
        "columns": [
            { "data": "id", autowidth: true },
            { "data": "requestTypeID", autowidth: true },
            { "data": "statusID", autowidth: true },
            { "data": "createdDate", autowidth: true }, 
             
            {
                "data": "id",  
                "render": function (data, type, row) {
                    return " <div class='btn-group'><a class='btn btn-success ' onclick=ShowPopup('/Order/Requests/AddAction/?RequestID=" + data + "&StageTypeID=" + row.stageTypeID +"','800','800')><span class='glyphicon glyphicon-flash'></span>Action</a> " +
                        "<a class='btn btn-primary'   onclick=ShowPopup('/Order/" + row.controllerName +"/Details/" + data + "','800','1200') > <i class='glyphicon glyphicon-option-vertical'></i> Details</a >  </div > ";
                }
            }
        ],
        "language": {
            "emptyTable": "no data found."
        }
    });
});
 