
   

$(function () {
             $(document).keyup(function (e) {
                 
                 if (e.altKey && e.keyCode == 107) {
                     AddNewRow();
                 }
                     
                 //if (e.ctrlKey && e.altKey && e.keyCode == 77) {
                 //    //alert($(".togglNav").);
                 //    $(".togglNav").click();
                 //    //$(".togglNav").click(function () {
                 //    //    var toggleWidth = $("#nav").width() == navw ? "0px" : navw;
                 //    //    var toggle2Width = $(".container").width() == (navw + conw) ? ($(".container").width() - navw) : (navw + $(".container").width());
                 //    //    $("#nav").animate({ width: toggleWidth });
                 //    //    $(".container").animate({ width: toggle2Width });
                 //    //});

                 //} 
                 //if (e.ctrlKey && e.altKey && e.keyCode == 71) {
                 //   // alert('hi');
                 //    $('#id_Grn').click();
                 //}
                 //if (e.ctrlKey && e.altKey && e.keyCode == 88) {
                 //    $('#id_Exp').click();
                 //}
                 //if (e.ctrlKey && e.altKey && e.keyCode == 79) {
                 //    $('#id_PO').click();
                 //}
                 //if (e.ctrlKey && e.altKey && e.keyCode == 83) {
                    
                 //    $(".optionsSection").slideToggle();
            
                 //}
                 //if (e.ctrlKey && e.altKey && e.keyCode == 73) {
                 //    $('#id_pi').click();
                 //}
                 //if (e.ctrlKey && e.altKey && e.keyCode == 80) {
                 //    $('#id_party').click();
                 //}
                 //if (e.ctrlKey && e.altKey && e.keyCode == 0) {
                 //    $('#id_dash').click();
                 //}
                 // if (e.ctrlKey && e.altKey && e.keyCode == 67) {
                 //    $('#id_CC').click();
                 // }
                 // if (e.ctrlKey && e.altKey && e.keyCode == 69) {
                 //     $('#id_ProductMaster').click();
                 // }
                 // if (e.ctrlKey && e.altKey && e.keyCode == 89) {
                 //     $('#id_payment').click();
                 // }
                 // if (e.ctrlKey && e.altKey && e.keyCode == 68) {
                 //     $('#id_dispatch').click();
                 // }
                 // if (e.ctrlKey && e.altKey && e.keyCode == 85) {
                 //     $('#id_PurEntry').click();
                 // }
                  if (e.keyCode == 27)
                  {
                     
                      closePop();
                     // $(focusid).focus();
                  }

             });
 });
 var focusid;
 function GetFocusID(input)
 {
     focusid = input;
 }