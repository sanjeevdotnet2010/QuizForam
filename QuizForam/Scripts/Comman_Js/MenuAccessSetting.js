var MenuArray = new Array();
$(function () {
    // alert('t2');
    //  alert($('#Session_PrimaryID_').val());
    $.getJSON("/ApplicationManagement/GetParrentMenu", {}, function (data) {
        //   alert('t1');
        $('#ul_ParrentMenu').empty();
        //  MenuArray = new Array();
        $(data).each(function (row, tr) {
           
            //alert(tr.t_ControllerName);
            //alert('test');
            $('#ul_ParrentMenu').append('<li class="optionsMenuli">' +
               '<a href="#" id=id_' + tr.a_MenuID + '  onclick="BindMenu(\'/' + tr.t_ControllerName + '/' + tr.t_ActionName + '\',' + tr.a_MenuID + ',\'#dv_MenuCon\');" class="optionClose1">' +
                   '<span class="menuIcon"><img src=../Images/icons/' + tr.t_IconImages + '  width="40" /> </span><b id=' + tr.a_MenuID + '>' + tr.t_MenuTitle + '</b></a>' +
         '<span class="blueBorder"></span>' +
     '</li>');
            //  abc(tr.n_ULCharNO, $('#' + tr.a_MenuID).get());
            MenuArray.push(
                { "MenuID": "id_" + tr.a_MenuID, "U_Char": getUChar(tr.t_MenuTitle, tr.n_ULCharNO) }
                );
        })
        // alert($.toJSON(MenuArray));
        GetCurrencyRate();
    });
});


function getUChar(id, uNo) {
   
    return id.charAt(uNo - 1)
}
$(function () {
    $(document).keyup(function (e) {
        $(MenuArray).each(function (row, tr) {
            if (e.ctrlKey && e.altKey && e.keyCode == tr.U_Char.toUpperCase().charCodeAt()) {
                $('#' + tr.MenuID).click();
            }
        })
    })
});


function LeftMenuList() {
   
   
    $('#dv_MenuCon ul li').each(function (row, tr) {
        
        MenuArray.push(
              { "MenuID": $(tr).find('a').attr('id'), "U_Char": getUChar($(tr).find('a').text(), $(tr).find('a').attr('rel')) }
            );
    });
}
$(function () {
    $(document).keyup(function (e) {
        if (e.ctrlKey && e.altKey && e.keyCode == 87) {
            $(".optionsSection").slideToggle();
        }
    })
});

function menuliset() {
    $(".mainLi").each(function (index, element) {
       
        if ($(this).find("a").length == 0)
            $(this).remove();
    });
}
function getDashBoard(ControllerName, ActionName, ReplaceDivID, fnName) {
    $.ajax({
        type: "post",
        url: '/' + ControllerName + '/' + ActionName + '/',
        data: {},
        success: function (data) {
            $('#' + ReplaceDivID).html(data);
            window[fnName]();
        }
    });
}
//$(document).ready(function () {
//    alert("yes");
//$("#id_1").click(function () {
//    alert('al');
//    $(".togglNav").trigger("click");
//});
//});
function BindMenu(ActionUrl, id, dv_Id) {
   
    $(".optionsSection").slideUp();
    $('#bs-example-navbar-collapse-1').slideUp();
    $.ajax({
        type: "POST",
        url: ActionUrl,
        data: { ModuleID: id },
        success: function (data) {
         
            //  alert(data);
            $(dv_Id).empty();
            // $(data).each(function (row, tr) {

            $(dv_Id).html(data);
            LeftMenuList();
            menuliset();

            /*switch (id) {
                case 1:
                {
                    getDashBoard('DashBoard', 'HomeDashBoard', 'dv_PartialView', 'removeDftVal');
                    $('#nav').css('width', '0px');
                    $('.container').css('width', '100%');
                    //$(".togglNav").trigger("click");
                   // $('#id_1').trigger('click', navcontwidth())
                    break;
                }
                case 2:
                { getDashBoard('DashBoard', 'AdminDashBoard', 'dv_PartialView', 'removeDftVal'); break; }
                case 6:
                { getDashBoard('DashBoard', 'HomeDashBoard', 'dv_PartialView', 'removeDftVal'); break; }
                case 7:
                { getDashBoard('DashBoard', 'InventoryDashBoard', 'dv_PartialView', 'removeDftVal'); break; }
                case 9:
                { getDashBoard('DashBoard', 'HomeDashBoard', 'dv_PartialView', 'removeDftVal'); break; }
                case 46:
                { getDashBoard('DashBoard', 'ProductionDashBoard', 'dv_PartialView', 'removeDftVal'); break; }
                case 48:
                { getDashBoard('DashBoard', 'SaleDashBoard', 'dv_PartialView', 'removeDftVal'); break; }
                case 50:
                { getDashBoard('DashBoard', 'PurchaseDashBoard', 'dv_PartialView', 'removeDftVal'); break; }
                case 71:
                    { getDashBoard('DashBoard', 'ExportDashBoard', 'dv_PartialView', 'removeDftVal'); break; }
                    default:
                    getDashBoard('DashBoard', 'HomeDashBoard', 'dv_PartialView');
            }*/
        }
    });

}

function fn_GetAllMenuDetails() {
   
    if ($('#n_RoleID').val() != " ") {
        $.ajax({
            type: "POST",
            url: "/ApplicationManagement/GetAllMenuDetails/",
            beforeSubmit: $('#spinner').show(),
            data: { n_Role: $('#n_RoleID').val(), n_EmployeeID: $('#n_EmployeeId').val() },
            success: function (data) {
              
                $('#dv_AccessMenu').html(data);
                $('#spinner').hide();
                //$(".newArrow").parent().addClass("expend");
                $('#dv_AccessMenuDiv').show();
            }
        });
    }
    else {
        bootbox.alert("Select Role");
    }
}

function fn_CheckUnCheckAll(input) {

    var par = $(input).parent().find("ul");

    if (par.find('li input[type=checkbox]').is(':checked')) {
        par.find('li input[type=checkbox]').attr("checked", false);
    }
    else {
        par.find('li input[type=checkbox]').attr("checked", true);

    }

}

//$(function () {
//    alert("klsdfhfiuy");
//    $(".newArrow").parent().addClass("expend");
//});


function fn_menu(input) {

    $(input).parent().find("ul").slideToggle();
}

//dfgdfg
//function BindMenu1(ActionUrl, id, dv_Id) {
//   // var tr = $(dv_Id).parent();
//    //alert(tr.find('ul').html());

//    //alert($('li [id='+dv_Id+'1]').html());
//    alert($(dv_Id).html());
//    $(".optionsSection").slideUp();
//    $.ajax(
//        {
//            type: "POST",
//            url: ActionUrl,
//            data: { ModuleID: id },
//            success: function (data) {
//               // alert($(data).html());
//               $(dv_Id).find('ul').empty();
//                //$(data).each(function (row, tr) {

//               $(dv_Id).find('ul').html($(data).html());
//               $(this).find(".subMenu").slideDown();
//               $(this).find(".arrowRight").toggleClass("rotate");
//               $(this).siblings().children().next().slideUp();
//                    // optionClose();
//                    //.append('<li>@Ajax.ActionLink(' + tr.t_TitleName + ',' + tr.t_ActionName + ',' + tr.t_ControllerName + ',ajaxOptions: new AjaxOptions { HttpMethod = "POST", UpdateTargetId = "dv_PartialView", InsertionMode = InsertionMode.Replace, LoadingElementId = "spinner" }, routeValues: new { a_EnumTypeID=-1}, htmlAttributes: new {id="btn_EnumType" })</li>');
//               // });

//            }
//        });
////}
//a_Menu_Acceess_ID	n_Role	n_MenuID	b_Deleted	n_Created_By	d_Created_On	n_Host_ID	b_flag	n_EmployeeID

//var i = 0;
//function SetTableVal() {
//    var MenuData = new Array();
//    $("#dv_AccessMenu ul li").each(function (row, tr) {
//        // alert($(tr).html());
//        if ($(tr).find("input[type=checkbox]:first").is(":checked")) {
//            //   i++;
//            MenuData[row] = {
//                "n_MenuID": $(tr).find("input[type=hidden]:first").val()
//            }
//        }
//        // alert($(tr).find("input[type=hidden]:first").val());
//    });
//    //MenuData.shift();
//    // var TableData=
//    // TableData.shift();
//    $('#Error').hide();
//    $.ajax({
//        type: "POST",
//        url: "/ApplicationManagement/SetSelectedMenuDetails/",
//        data: { SelectedMenuList: $.toJSON(MenuData), n_Role: $('#n_RoleID').val(), n_EmployeeID: $('#n_EmployeeId').val() },
//        success: function (data) {
//            CnfMsg("Successfully Added");
//            $('#n_RoleID').focus();
//        }
//    });
//    //  alert(i);
//    // console.log($.toJSON(MenuData));
//}
function ConfirmationMsg(msg) {
    $('#Error').html(msg);
    $('#Error').removeClass("errormsg");
    $('#Error').addClass("confirmationmsg");
    $('#Error').show();
}
function ValidateForm(FormId) {

    $('#' + FormId).validationEngine('attach', { promptPosition: "topLeft" });
}

function hideAllErrMsg(FormId) {
    $('#' + FormId).validationEngine('hideAll')
}


function IsFormValidate(formID) {
    return $('#' + formID).validationEngine('validate');
}


function Cnfmsg(msg) {
    $('#Error').html(msg);
    $('#Error').removeClass("errormsg");
    $('#Error').removeClass("confirmationmsgTop");
    $('#Error').addClass("confirmationmsg");
    $('#Error').show();
    $('#Error').show().delay(2000).hide(0);
}

function CnfmsgTop(msg) {
    $('#Error').html(msg);
    $('#Error').removeClass("errormsg");
    $('#Error').removeClass("confirmationmsg");
    $('#Error').addClass("confirmationmsgTop");
    $('#Error').show();
    $('#Error').show().delay(2000).hide(0);
}


function Errmsg(msg) {
   
    $('#Error').html(msg);
    $('#Error').removeClass("errormsg");
    $('#Error').removeClass("confirmationmsg");
    $('#Error').removeClass("confirmationmsgTop");
    $('#Error').addClass("errormsg");
    $('#Error').show();
    $('#Error').show().delay(2000).hide(0);
}

function Warmsg(msg) {
    $('#Error').html(msg);
    $('#Error').removeClass("errormsg");
    $('#Error').removeClass("confirmationmsg");
    $('#Error').removeClass("confirmationmsgTop");
    $('#Error').addClass("warnningmsg");
    $('#Error').show();
    $('#Error').show().delay(2000).hide(0);
}

function ConditionalDatePicker(ValidateId, DatePickInId, msg) {
    $('#' + ValidateId).focusin(function () {
        $('#' + ValidateId).removeClass('hasDatepicker');
        if ($('#' + DatePickInId).val()) {
            $('#' + ValidateId).datepicker({
                dateFormat: 'd-M-y',
                minDate: new Date($('#' + DatePickInId).val()),
            });
        }
        else {
            Warmsg(msg);
        }
    });
}


function CndlDatePickerByClass(ClassName, DatePickInId, msg) {
    $('.' + ClassName).focusin(function () {
        $('.' + ClassName).removeClass('hasDatepicker');
        if ($('#' + DatePickInId).val()) {
            $('.' + ClassName).datepicker({
                dateFormat: 'd-M-y',
                minDate: new Date($('#' + DatePickInId).val()),
            });
        }
        else {
            Warmsg(msg);
        }
    });
}


function DfltDatePickerOnId(inputId) {
    $('#' + inputId).focusin(function () {
        $('#' + inputId).removeClass('hasDatepicker');
        $('#' + inputId).datepicker({
            dateFormat: 'd-M-y',
        });
    });
}

function DfltDatePickerOnClass(ClassName) {
    $('.' + ClassName).focusin(function () {
        $('.' + ClassName).removeClass('hasDatepicker');
        $('.' + ClassName).datepicker({
            dateFormat: 'd-M-y',
        });
    });
}

function enabletab(ulId) {
    $(document.body).on("click", "#" + ulId + "li a", function () {
        var rel = $(this).attr("rel");
        $("#" + ulId + "li a").removeClass("selected");
        $(".tabcontent").hide();
        $(this).addClass("selected");
        $("#" + rel).show();
    });
}
// Comman Function


function GetCurrencyRate() {
    $.ajax({
        type: 'GET',
        url: 'http://rate-exchange.appspot.com/currency',
        //url: 'http://api.exchangeratelab.com/api/single/{base}?apikey=8E4DD5A3D4DDA5CDC5F8571134C803F1',
        data: { from: $('#drpFrom').val(), to: $('#drpTo').val() },
        dataType: 'jsonp',
        success: function (data) {
            $('#n_Result').html(data.rate + ' ' + data.to);
        },
        error: function (e) {
            // Warmsg('Currently This Services is Unavailable please Try After Some Time')
        }
    });
}


function removeDftVal() {
    $('#t_FDate').val('');
    $('#t_LDate').val('');
}