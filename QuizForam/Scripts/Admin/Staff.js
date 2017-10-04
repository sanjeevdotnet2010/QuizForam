
$(document).ready(function () {

    var myTable = $('#DataTable').dataTable({
        "lengthMenu": [[10, 25, 50, 100, -1], [10, 25, 50, 100, "All"]],
        bAutoWidth: false,
        "aoColumns": [{ "bSortable": false }, null, null, null, null, null, null, { "bSortable": false }]


    });



    $("#BtnAddStaff").click(function () {
        $("#loderimg").show();
        $.post("/Admin/Staff/CreateStaff").done(function (data) {
            $("#loderimg").hide();
            $("#FormModal").modal('show');
            $("#DivForm").html(data);
        });
    });



});

function EditStaffForm(rfn) {
    $("#loderimg").show();
    $.post("/Admin/Staff/EditStaff", { "id": rfn }).done(function (data) {
        $("#loderimg").hide();
        $("#FormModal").modal('show');
        $("#DivForm").html(data);
    });
}


function ViewStaff(rfn) {
    $("#loderimg").show();
    $.post("/Admin/Staff/View", { "id": rfn }).done(function (data) {
        $("#loderimg").hide();
        $("#FormModal").modal('show');
        $("#DivForm").html(data);
    });
}

function ToggleStaff(rfn, name) {
    var result;
    swal({
        title: "Are you sure to Change Status ",
        text: "Staff : " + name,
        type: "warning",
        showCancelButton: true,
        confirmButtonColor: "#DD6B55",
        confirmButtonText: "Yes, Change it!",
        cancelButtonText: "No, cancel pls!",
        closeOnConfirm: true,
        closeOnCancel: true
    },
    function () {
        swal("Deleted!", "Your imaginary file has been deleted.", "success");
    });

    return result;

}