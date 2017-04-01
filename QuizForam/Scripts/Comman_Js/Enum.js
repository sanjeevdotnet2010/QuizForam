
$(function () {
    ValidateForm('EnumForm');
})
function ShowHide() {
    $('#btnsubmit').hide();
    $('#btnsubmit').show(1000);
}
function CheckValidform() {
    IsFormValidate('EnumForm')
    {
        ValidateForm('EnumForm');
    }
}




function fn_ShowSaleDiscountDiv() {
   
    var n_EnumType = $("#n_EnumType").val();
    if (n_EnumType == 20) {
        $("#dv_Store").show();
    }
    else {
        $("#dv_Store").hide();
        $('#n_StoreId option:selected').val("");
    }
}


function btnchange() {
    $('#btnsubmit').val("Update");
}

$(document).ready(function () {
   
    var controller = "Comman/Enum";
    var columns =
		[
			{
			    'data': "Id",
			    'title': "S.No",
			    'visible': false
			},
            {
                "data": "SNo",
                'title': "Sr No",
            },
            {
                "data": "EnumTypeName",
                'title': "Enum Type Name",
            },
            {
                "data": "storename",
                'title': "Store Name",
            },
            {
                "data": "EnumName",
                'title': "Enum Name",
            },
            {
                "data": "EnumDate",
                'title': "Enum Date",
            },
            {
                'data': null,
                'title': "Actions",
                'width': "95px",
                'class': "text-center",
                'sortable': false,
                'defaultContent':
                    '<div>' +
                        '<a class="edit" title="Edit" data-toggle="modal" href="javascript:void(0);">' +
                            '<i class="fa fa-pencil"></i>' +
                        '</a> &nbsp' +
                         '<a class="delete" title="Delete" data-toggle="modal">' +
                            '<i class="fa fa-times"></i>' +
                        '</a> &nbsp' +
                     '</div>'
            }
		];

    var dataTable = new RetailERPDataTable(controller, columns, 10);


    dataTable.EditRecord = function (row, data) {
        $("#spinner ").show();
        $.post("/Comman/Enum/EditEnum", { a_EnumID: data.Id, ViewName: 'pv_AddEnum' }).done(function (data) {
            $("#spinner ").hide();
            $("#dv_PartialView").html(data);
            fn_Showdiv();
            btnchange();
        })
    }

    dataTable.DeleteRecord = function (row, data) {
        bootbox.confirm("Are you sure you want to delete this Record?", function (result) {
            if (result) {
                $("#spinner ").show();
                $.post("/Comman/Enum/DeleteEnum", { a_EnumID: data.Id }).done(function (message) {
                    if (message == "Delete Successfully") {
                        dataTable.ReloadTable();
                    }
                    else {
                        Errmsg("Dependant child is exists. It can't be deleted");
                    }
                    $("#spinner ").hide();
                });
            }
        });
    }

    //dataTable.ViewRecord = function (row, data) {
    //    $("#spinner ").show();
    //    $.post("/Admin/Exporters/EditOrViewExporters", { a_EnumID: data.Id, ViewName: 'pv_ViewExporter' }).done(function (data) {
    //        $("#spinner ").hide();
    //        $("#dv_PartialView").html(data);
    //    })

    //}

    //dataTable.DeleteRecord = function (row, data) {
    //    bootbox.confirm("Are you sure you want to delete this Record?", function (result) {
    //        if (result) {
    //            $("#spinner ").show();
    //            $.post("/Admin/Exporters/DeleteExpoters", { a_EnumID: data.Id }).done(function (message) {
    //                $("#spinner ").hide();

    //                if (message == "Delete Successfully") {
    //                    dataTable.ReloadTable();
    //                }
    //                else {
    //                    Errmsg(message);
    //                }
    //            });
    //        }
    //    });
    //}

    dataTable.Create();
})

