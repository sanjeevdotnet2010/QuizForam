/// <reference path="jquery-ui-1.10.3.js" />

$(function () {
    $('.datepicker').datepicker();
    //$(document).tooltip();
});

//paging ddl
function OnDdlSelectionChangePaging(ddl, url) {
    //alert("hi");
    $.ajax({
        type: "GET",
        url: url,
        beforeSubmit: $('#spinner').show(),
        data: { selectedValue: ddl.value },
        success: function (data) {
            var partialView = $('#partialView');
            partialView.empty();
            partialView.html(data);
            $('#spinner').hide();
        }
    });

}
//this secrip check duplicate Like Name,code..on onblur event of text box---jyoti--date -13.2.2014
function ChkUniqeness(obj, url, t_spname, txtid, Modeid, id) {

    var x = document.getElementById(Modeid).value;
    var y = document.getElementById(id).value;
    // alert(Modeid);
    // alert(x);
    // alert(y);
    $.getJSON(url, { searchTerm: obj, t_spname: t_spname, Mode: x, id: y },
      function (data) {
          if (data != "") {
              document.getElementById(txtid).value = "";
          }
          else {
          }
      })

};

//add new in enum table---jyoti--date -15.2.2014
function AddWithOutParentValueEnum(n_EnumType, url, id, SettingID, Display) {
    $.ajax(
{
    type: "POST",
    url: "/Enum/Index/",
    data: { n_EnumType: n_EnumType, url: url, id: id, SettingID: SettingID, Display: Display },
    success: function (data) {
        $('#dv_Enum').html(data);
    }
});



    openPopup('t_Display', id, 'dv_Enum', '230', '410');
}
//@*Add Child i
//@*Add Child in Enum Table*@----jyoti--date -15.2.2014


function AddWithParentValueEnum(n_EnumType, n_PEnumType, n_PEnumVal, url, id, SettingID, Display) {
    // alert(SettingID);
    $.ajax(
{
    type: "POST",
    url: "/Enum/Create/",
    data: { n_EnumType: n_EnumType, n_PEnumType: n_PEnumType, n_PEnumVal: $('#' + n_PEnumVal).val(), url: url, id: id, SettingID: SettingID, Display: Display },
    success: function (data) {

        $('#dv_Enum').html(data);
    }
});
    openPopup('t_Display', id, 'dv_Enum', '230', '500');

}

function CnfSubmenumsg(msg, Url) {
    $.ajax(
       {
           url: Url,
           beforeSend: function () {
               $('#spinner').show();
           },
           type: "Get",
           success: function (data) {
               $('#spinner').hide();
               $("#dv_PartialView").html(data);
               $('#Error').removeClass("errormsg");
               $('#Error').removeClass("confirmationmsgTop");
               $('#Error').removeClass("warnningmsg");
               $('#Error').addClass("confirmationmsg");
               $('#Error').html(msg);
               $('#Error').show().delay(4000).hide(0);
           }
       });
}


function CnfSubmenumsgonTop(msg, Url) {
    $.ajax(
       {
           url: Url,
           beforeSend: function () {
               $('#spinner').show();
           },
           type: "Get",
           success: function (data) {
               $('#spinner').hide();
               $("#dv_PartialView").html(data);
               $('#Error').removeClass("errormsg");
               $('#Error').removeClass("warnningmsg");
               $('#Error').removeClass("confirmationmsg");
               $('#Error').addClass("confirmationmsgTop");
               $('#Error').html(msg);
               $('#Error').show().delay(4000).hide(0);
           }
       });
}

//function CnfSubmenumsgonTop1(msg, Url) {
//    $.ajax(
//       {
//           url: Url,
//           beforeSend: function () {
//               $('#spinner').show();
//           },
//           type: "Get",
//           success: function (data) {
//               $('#spinner').hide();
//               $("#dv_PartialView").html(data);
//               $('#Error').removeClass("errormsg");
//               $('#Error').removeClass("warnningmsg");
//               $('#Error').addClass("confirmationmsgTop");
//               $('#Error').html(msg);
//               $('#Error').show().delay(4000).hide(0);
//           }
//       });
//}



$(document).keypress(function (e) {
    var code = e.keyCode || e.which;

    //When press enter
    if (code == 13)
        return false;
    ////When press backspace
    //if (code == 8)
    //    return false;
});



$(window)
    .off('resize.chosen')
    .on('resize.chosen', function () {
        $('.chosen-select').each(function () {
            var $this = $(this);
            $this.next().css({ 'width': $this.parent().width() });
        })
    }).trigger('resize.chosen');

//$('.chosen-select').chosen({ allow_single_deselect: true });
//resize the chosen on window resize

$(function () {
    $('.datepicker').datepicker(
        {
            changeMonth: true,
            changeYear: true,
            yearRange: "1900:+nn"
        });
});

//function Popup(data, title) {
//    var mywindow = window.open('', 'my div', 'height=400,width=600');
//    mywindow.document.write('<html><head><title></title>');
//    mywindow.document.write('<link rel="stylesheet" href="http://www.test.com/style.css" type="text/css" />');
//    mywindow.document.write('<style type="text/css">.test { color:red; } </style></head><body>');
//    mywindow.document.write(data);
//    mywindow.document.write('</body></html>');
//    mywindow.document.close();
//    mywindow.print();
//}

function printdiv(elem, title) {
   
    var options = { mode: "iframe", popClose: true, popTitle: title, popHt: 500, popWd: 400, popX: 500, popY: 600, retainAttr: "style:{font-size:1000px}" };
    $(elem).printArea(options);
}


//function Popup1(printpage) {
//   
//   // var mywindow = window.open('', title, 'height=600,width=600');
//   // var headstr = "<html><head><title>" + title + "</title></head><body><h2 style='text-align:center'>" + title + "</h2>";
//   // var footstr = "</body>";
//   // //  var newstr = document.all.item(printpage).innerHTML;
//   // var newstr = $(printpage).html();
//   //// var oldstr = document.body.innerHTML;
//   //// document.body.innerHTML = headstr + newstr + footstr;
//   // mywindow.document.write(data);
//   // mywindow.document.write('</body></html>');
//   // mywindow.document.close();
//   // mywindow.print();
//   // document.body.innerHTML = oldstr;
//    // return false;
//    var mywindow = window.open('', 'my div', 'height=400,width=600');
//    mywindow.document.write('<html><head><title></title>');
//    mywindow.document.write('<link rel="stylesheet" href="http://www.test.com/style.css" type="text/css" />');
//    mywindow.document.write('<style type="text/css">.test { color:red; } </style></head><body>');
//    mywindow.document.write(printpage);
//    mywindow.document.write('</body></html>');
//    mywindow.document.close();
//    mywindow.print();
//}

function printExporter(divid, title) {

    var options = { mode: "iframe", popClose: true, popTitle: title, popHt: 500, popWd: 400, popX: 500, popY: 600, printBodyOptions: { styleToAdd: 'margin-left:10px;display:none'} };
    $(divid).printArea(options);


    //var headstr = "<html><head><title>" + title + "</title></head><body><h2 style='text-align:center'>" + title + "</h2>";
    //var footstr = "</body>";
    ////var newstr = document.all.item($("#Prinsu")).innerHTML;
    //var newstr = divid;
    //var oldstr = document.body.innerHTML;
    //document.body.innerHTML = headstr + newstr + footstr;

    //window.print();
    //document.body.innerHTML = oldstr;
    //return false;
}

function formatTime(date) {
    var d = new Date(date);
    var k = '' + (1 + d.getMonth()) + '-' + d.getDate() + '-' + d.getFullYear().toString().slice(-2);
    var hh = d.getHours();
    var m = d.getMinutes();
    var s = d.getSeconds();
    var dd = "AM";
    var h = hh;
    if (h >= 12) {
        h = hh - 12;
        dd = "PM";
    }
    if (h == 0) {
        h = 12;
    }
    m = m < 10 ? "0" + m : m;
    s = s < 10 ? "0" + s : s;
    var pattern = new RegExp("0?" + hh + ":" + m + ":" + s);
    var replacement = h + ":" + m;
    replacement += " " + dd;
    return replacement;
}

function formatDate(date) {
    var d = new Date(parseInt(date.slice(6, -2)));
    var monthNames = ["January", "February", "March", "April", "May", "June",
  "July", "August", "September", "October", "November", "December"
    ];
    var k = d.getDate() + '-' + monthNames[(d.getMonth())] + '-' + d.getFullYear();
    return k;
}