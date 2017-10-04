
$(document).ready(function () {

    var myTable = $('#PlanTable').dataTable({
        "lengthMenu": [[10, 25, 50, 100, -1], [10, 25, 50, 100, "All"]],
        bAutoWidth: false//,
      //  "aoColumns": [{ "bSortable": false }, null, null, null, null, null, null, { "bSortable": false }]


    });



    $("#BtnAddPlan").click(function () {
        $("#loderimg").show();
        $.post("/Admin/Plan/CreatePlan").done(function (data) {
            $("#loderimg").hide();
            $("#FormModal").modal('show');
            $("#DivForm").html(data);
        });
    });



});

function EditPlanForm(rfn) {
    $("#loderimg").show();
    $.post("/Admin/Plan/EditPlan", { "id": rfn }).done(function (data) {
        $("#loderimg").hide();
        $("#FormModal").modal('show');
        $("#DivForm").html(data);
    });
}


function ViewPlan(rfn) {
    $("#loderimg").show();
    $.post("/Admin/Plan/View", { "id": rfn }).done(function (data) {
        $("#loderimg").hide();
        $("#FormModal").modal('show');
        $("#DivForm").html(data);
    });
}

function TogglePlan(rfn, name) {
    swal({
        title: "Are you sure to Change Status ",
        text: "plan : " + name,
        type: "warning",
        showCancelButton: true, confirmButtonColor: "#DD6B55", confirmButtonText: "Yes, Delete it!", cancelButtonText: "No, cancel plx!",
        closeOnConfirm: true,
        closeOnCancel: true
    },
     function (isConfirm) {
         if (isConfirm) {
             return false;
         } else {
             return false;
         }
     });
}