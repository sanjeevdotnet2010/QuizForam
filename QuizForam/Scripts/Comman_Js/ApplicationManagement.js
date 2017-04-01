$(function () {
    $("#AppMgtFrom").validationEngine('attach', { promptPosition: "topLeft" });
});
//AppMgtFrom is a form id

function hideAllErrMsg() { // for validation hide
    $("#AppMgtFrom").validationEngine('hideAll')
    $('.hidden').fadeOut()
}


function GetAppSettingVal() {      //get dropdownlist value and text 
    var a = $('#n_SettingType').val();
    var b = $('#n_SettingType option:selected').text();

    $.ajax({
        url: "/ApplicationSetting/CallbyDropdown/",
        beforsubmit: $("#spinner").show(),
        type: "POST",
        data: { SettingType: a, SettingTypeText: b },

        success: function (data) {
            $('#dv_role').html(data);
            $("#spinner").hide();

        }
    });
    SuccessMsg();
}


function seteditvalue(obj) {
    var tr = $(obj).parent().parent();
    var edittext = $(tr).children("td:first").text();
    var editId = $(tr).children("td:last").children("input[type=hidden]").val();
    $('#Setting_Name').val(edittext);
    $('#a_Enum_ID').val(editId);
}



function SuccessMsg() {

    if ($('#b_check').val() == "True") {
        Cnfmsg('Save Successfully!! ');
    }
    else {
        Warmsg('Plz Insert Correct Data Somthing Wrong');
    }
}


//paging ddl  
function OnDdlSelectionChange(ddl) {

    GetSerachField();
    $.ajax({
        type: "GET",
        url: "/ApplicationSetting/DdlPageSelectedIndexChange/",
        data: { selectedValue: ddl.value, SettingType: $('#n_SettingType').val() },
        success: function (data) {
            var partialView = $('#dv_Contant');
            partialView.empty();
            partialView.html(data);
            SetSearchField();
        }
    });
}



var SettingName;
function GetSerachField() {
    SettingName = $('#SettingName').val();
}

function SetSearchField() {
    $('#SettingName').val(SettingName);
}

function setAuto() {
    Getautocomplete('#SettingName', '/ApplicationSetting/GetAutoSettingName');
}

function SearchApplMngt() {
    $.ajax({
        type: "GET",
        url: "/ApplicationSetting/SearchApplicationMngt/",
        data: { SettingName: $('#SettingName').val(), SettingType: $('#n_SettingType').val() },
        success: function (data) {
            $('#dv_role').html(data);
            $("#spinner").hide();
        }

    });
}

function fnGetEmployeeList(input) {
   
    if ($(input).val() == " ") {

    }
    else {
        $.getJSON("/Employee/GetEmployee/",
       { n_Role: $(input).val() },
       function (data) {
           $('#n_EmployeeID').empty();
           $.each(data, function (i, item) {
               $('#n_EmployeeID').append($('<option/>', {
                   value: item.Value,
                   text: item.Text
               }));
           });
           $('#n_EmployeeID option:first').before('<option value="">-- Select Employee --</option>');
       });
    }
}


function fn_GetAllMenuDetails() {
   
    $('#btnAssignMenu').hide();
    $('#btnAssignMenu').show(1000);
    if ($('#n_Role').val() != '') {
        $.ajax({
            type: "POST",
            url: "/ApplicationManagement/GetAllMenuDetails/",
            beforeSubmit: $('#spinner').show(),
            data: { n_Role: $('#n_Role').val(), n_EmployeeID: $('#n_EmployeeID').val() },
            success: function (data) {
               
                $('#dv_AccessMenu').html(data);
               // alert("#dv_AccessMenu").val();
                $('#spinner').hide();
                //$(".newArrow").parent().addClass("expend");
                $('#dv_AccessMenuDiv').show();
                $('#dv_AssignRole').show();
            }
        });
    }
    else {
        bootbox.alert("Please Select Role");
        $('#dv_AccessMenuDiv').html();
        $('#dv_AccessMenuDiv').hide();
        $('#dv_AssignRole').hide();
    }
}

function fn_CheckTotalValue(menuID, input) {
   
    var tr = $(input).closest('td').siblings().find('input:checkbox');
    if ($(input).prop('checked') == true) {
        $(input).closest('tr').parent().parent().parent().find('input:first:checkbox').prop('checked', true);
        $(input).closest('tr').parent().parent().parent().parent().parent().find('input:first:checkbox').prop('checked', true);
        $(input).closest('tr').parent().parent().parent().parent().parent().parent().parent().find('input:first:checkbox').prop('checked', true);
        //$(input).closest('ul').parent().parent().find('li > input:first:checkbox').prop('checked', true);
        //$(input).closest('ul').parent().parent().parent().find('input:first:checkbox').prop('checked', true);
    }
    else {
        var i = 0;
        $(tr).each(function (row, td) {
            if ($(td).prop('checked') == true) {
                i++;
                var t = $(input).closest('tr').siblings().find('input:checkbox');
            }
        });
        if (i > 1) {
            $(input).closest('tr').parent().parent().parent().find('input:first:checkbox').prop('checked', true);
            $(input).closest('tr').parent().parent().parent().parent().find('input:first:checkbox').prop('checked', true);
            $(input).closest('ul').parent().parent().find('li > input:first:checkbox').prop('checked', true);
            $(input).closest('ul').parent().parent().parent().find('input:first:checkbox').prop('checked', true);
        }
        else if (i <= 0) {
            $(input).closest('tr').parent().parent().parent().find('input:first:checkbox').prop('checked', false);
            //$(input).closest('tr').parent().parent().parent().parent().parent().find('input:first:checkbox').prop('checked', false);
            //$(input).closest('tr').parent().parent().parent().parent().parent().parent().parent().find('input:first:checkbox').prop('checked', false);
            // $(input).closest('tr').parent().parent().parent().parent().find('input:first:checkbox').prop('checked', false);
            //$(input).closest('ul').parent().parent().find('li > input:first:checkbox').prop('checked', false);
            // $(input).closest('ul').parent().parent().parent().find('input:first:checkbox').prop('checked', false);
        }
    }
}

function fn_menu(input) {
    $(input).parent().find("ul").slideToggle();

}

function fn_CheckUnCheckAll(input) {
   
    var par = $(input).parent().find("ul");

    if ($(input).prop('checked') == false) {
        $(input).parent().find('input[type=checkbox]').prop("checked", false)

        //$(input).closest('ul').parent().parent().find('li > input:first:checkbox').prop('checked', false);
        //$(input).closest('ul').parent().parent().parent().find('input:first:checkbox').prop('checked', false);
        $(input).closest('li').parent().parent().parent().find('li > input:first:checkbox').prop('checked', true);
        //$(input).closest('li').parent().parent().parent().find('input:first:checkbox').prop('checked', false);
        //$(input).closest('li').parent().find('li > ul > li > input:first:checkbox').prop('checked', false);
        //par.find('li > ul > li > input:first:checkbox').prop('checked', false);
        //par.find('li input[type=checkbox]').prop("checked", false);
        //par.find('ul input[type=checkbox]').prop("checked", false);
    }
    else {
        if (par.length == 0) {
            $(input).parent().find('input[type=checkbox]').prop("checked", true)
            $(input).closest('ul').parent().parent().find('li > input:first:checkbox').prop('checked', true);
            $(input).closest('ul').parent().parent().parent().find('input:first:checkbox').prop('checked', true);
        }
        else
            par.find('li input[type=checkbox]').prop("checked", true);
    }

}

function SetTableVal() {
   // $("#dv_AccessMenu").html('');
   
    $('#btnsave').hide();
    $('#btnsave').show(1000);
    if ($('#n_Role').val() == '') {
        bootbox.alert("Please Select Role");
        return false;
    }
    var MenuData = new Array();
    $("#dv_AccessMenu ul li").each(function (row, tr) {
        if ($(tr).find("input[type=checkbox]:first").is(":checked")) {
            MenuData[row] = {
                "n_MenuID": $(tr).find("input[type=hidden]:first").val(),
                "n_Permission": fn_PermissionTotalValue($(tr).find("input[type=hidden]:first").val(), tr)
            }
        }
    });
    if (MenuData == '') {
        bootbox.alert("Please Give Atleast One Menu Permission");
        return false;
    }
    $('#Error').hide();
    $.ajax({
        type: "POST",
        url: "/ApplicationManagement/SetSelectedMenuDetails/",
        data: { SelectedMenuList: JSON.stringify(MenuData), n_Role: $('#n_Role').val(), n_EmployeeID: $('#n_EmployeeID').val() },
        success: function (data) {
            //$('#Error').show();
            // $('#Error').html("Save Successfully");
            bootbox.alert("Save Successfully");
            $('#n_RoleID').focus();
        }
    });
}

function fn_PermissionTotalValue(main, tr) {
   
    var i = 0;
    $(tr).find('td').each(function (row1, tr1) {
        if ($(tr1).find('input[type=checkbox]').is(':checked')) {
            var arr = $(tr1).find('input[type=checkbox]').map(function () {
                return this.id;
            }).get();
            if (parseInt(main) == parseInt(arr))
                i += parseInt($(tr1).find('input[type=checkbox]').val());
        }
    });
    return i;
}

function ConfirmationMsg(msg) {
    $('#Error').html(msg);
    $('#Error').removeClass("errormsg");
    $('#Error').addClass("confirmationmsg");
    $('#Error').show();
}