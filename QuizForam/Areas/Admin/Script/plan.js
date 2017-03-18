
$(document).ready(function () {

    var oTable = $('#DataTable').dataTable({
       "lengthMenu": [[10, 25, 50, 100, -1], [10, 25, 50, 100, "All"]],
        "sScrollY": "305px",
    });



    $("#BtnAddPlan").click(function () {
   

        $.ajax({
            url: "../admin/plan/Create", 
            type: "GET", dataType: "html",
            success: function (data) {
                $("#FormModal").modal('show');
                $("#DivForm").html(data);
            }
        });

    });

    $("#BtnResetTest").click(function () {
        swal({
            title: "Are you sure you want to reset all tests ?",
            type: "warning",
            showCancelButton: true, confirmButtonColor: "#DD6B55", confirmButtonText: "Yes, Reset it!", cancelButtonText: "No, cancel plx!",
            closeOnConfirm: true,
            closeOnCancel: true
        },
        function (isConfirm) {
            if (isConfirm) {
                $("#formReset").submit();
            } else {
                return false;
            }
        });
    });

    $("#BtnPublishTest").click(function () {
        swal({
            title: "Are you sure you want to publish test ?",
            type: "warning",
            showCancelButton: true, confirmButtonColor: "#DD6B55", confirmButtonText: "Yes, Publish it!", cancelButtonText: "No, cancel plx!",
            closeOnConfirm: true,
            closeOnCancel: true
        },
        function (isConfirm) {
            if (isConfirm) {
                $("#formpublish").submit();
            } else {
                return false;
            }
        });
    });

});






function EditProgSteram(rfn) {
    $.ajax({
        url: "EditProgStream", data: { "id": rfn },
        type: "GET", dataType: "html",
        success: function (data) {
            $("#FormModal").modal('show');
            $("#DivForm").html(data);
        }
    });
}

function EditProgAllied(rfn) {
    $.ajax({
        url: "EditAllied", data: { "id": rfn },
        type: "GET", dataType: "html",
        success: function (data) {
            $("#FormModal").modal('show');
            $("#DivForm").html(data);
        }
    });
}

function ViewProgAllied(rfn) {
    $.ajax({
        url: "ViewAllied", data: { "id": rfn },
        type: "GET", dataType: "html",
        success: function (data) {
            $("#FormModal").modal('show');
            $("#DivForm").html(data);
        }
    });
}