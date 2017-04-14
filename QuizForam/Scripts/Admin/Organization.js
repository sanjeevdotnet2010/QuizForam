
$(document).ready(function () {

    var myTable = $('#OrganizationTable').dataTable({
        "lengthMenu": [[10, 25, 50, 100, -1], [10, 25, 50, 100, "All"]],
        bAutoWidth: false,
        "aoColumns": [
          { "bSortable": false },
         null, null, null, null, null, null,
          { "bSortable": false },
          { "bSortable": false }
        ],
        "aaSorting": [],
        select: {
            style: 'multi'
        }
    });



    $("#BtnAddOrganization").click(function () {
        $("#loderimg").show();
        $.post("/Admin/Organization/CreateOrganization").done(function (data) {
            $("#loderimg").hide();
            $("#FormModal").modal('show');
            $("#DivForm").html(data);
        });
    });



});

function EditPlanForm(rfn) {
    $("#loderimg").show();
    $.post("/Admin/Organization/EditOrganization", { "id": rfn }).done(function (data) {
        $("#loderimg").hide();
        $("#FormModal").modal('show');
        $("#DivForm").html(data);
    });
}

function DeletePlan(rfn, name) {
    swal({
        title: "Are you sure to Inactive",
        text:"plan : "+ name,
        type: "warning",
        showCancelButton: true, confirmButtonColor: "#DD6B55", confirmButtonText: "Yes, Delete it!", cancelButtonText: "No, cancel plx!",
        closeOnConfirm: true,
        closeOnCancel: true
    },
     function (isConfirm) {
         if (isConfirm) {
             $("#form" + rfn).submit();
         } else {
             return false;
         }
     });
}