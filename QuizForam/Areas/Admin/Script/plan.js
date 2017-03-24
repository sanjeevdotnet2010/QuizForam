
$(document).ready(function () {

    var tablehight = ($(window).height() - 315);
    //swal(tablehight+"Px");
    $('#DataTable').dataTable({
        "lengthMenu": [[10, 25, 50, 100, -1], [10, 25, 50, 100, "All"]],
        "sScrollY": tablehight + "Px"
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
