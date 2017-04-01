
$(document).ready(function () {
    var sidemenua=0;
    //var alpha = setInterval(function () { alphaa(); }, 1000);
   
    $(".sidemenulink").click(function () {
       
        if (sidemenua == 0)
        {
            $(".sidemenulink").css("transform","rotate(180deg)");
            $(".fixedslide").animate({ "right": 0 }); sidemenua = 1;
        }
        else
        {
            $(".sidemenulink").css("transform", "rotate(0deg)");
            $(".fixedslide").animate({ "right": -260 }); sidemenua = 0;
        }
    });
    $(".togglNav").trigger("click");
  //  getDashBoard('DashBoard', 'HomeDashBoard', 'partialView', 'removeDftVal');
  
    //function alphaa() {
    //    if (anpf == 0)
    //    {
    //        anpf++; Barchart(); navcontwidth();
    //    }
    //    clearInterval(alpha);
    //}
   
    
   
    //$("#barchartbtn").delay(2000).click(function () {
     //   Barchart();
    //});
   // $("#barchartbtn").trigger("click");
});

function StartClock12() {
    Time12 = new Date();
    Cur12Hour = Time12.getHours();
    Cur12Mins = Time12.getMinutes();
    Cur12Secs = Time12.getSeconds();
    The12Time = (Cur12Hour > 12) ? Cur12Hour - 12 : Cur12Hour;
    The12Time += ((Cur12Mins < 10) ? ':0' : ':') + Cur12Mins;
    The12Time += ((Cur12Secs < 10) ? ':0' : ':') + Cur12Secs;
    The12Time += (Cur12Hour >= 12) ? ' PM' : ' AM';
    document.CForm.Clock12.value = The12Time;
    window.status = The12Time;
    setTimeout('StartClock12()', 1000);
}

var a
var d
function abc(a, d) {
    //alert("hello"+d);
    var text = $(d).html();
    var first = "";
    for (i = 0; i < a - 1; i++) {
        //alert(text.charAt(i)+"abcs");
        first = first + text.charAt(i);
    }
    first = first + '<u style="text-transform:uppercase; color:#464646; font-weight: bold; text-decoration:underline;">' + text.charAt(a - 1) + '</u>'
    //var first = text.charAt(0)+text.charAt(1)+text.charAt(2)+'<span style=color:red;>'+text.charAt(3)+'</span>';
    //alert(first);
    $(d).html(text.substring(a)).prepend(first);
   
}
//$("#ul_ParrentMenu").focusin(function () {
//    alert("alert2");
//    var cvf = $("#21").get();
//    abc(8, cvf);

//    var cvf = $("#id_pi").get();
//    abc(10, cvf);

//    var cvf = $("#id_payment").get();
//    abc(3, cvf);

//    var cvf = $("#id_dispatch").get();
//    abc(1, cvf);

//    var cvf = $("#id_Grn").get();
//    abc(9, cvf);

//    var cvf = $("#id_PurEntry").get();
//    abc(2, cvf);

//    var cvf = $("#id_Exp").get();
//    abc(2, cvf);

//    var cvf = $("#id_ProductMaster").get();
//    abc(7, cvf);

//    var cvf = $("#id_party").get();
//    abc(1, cvf);

//});


/*changes data 4/5/2014*/
var conw2 = $(".container").width();

$(document).ready(function () {
    //alert('yes');
    //$('.nav .mainMenu').css('border', 'solid 1px red');
    //$('.navbar-toggle').click(function () {
    //    var wh = $(window).height();
    //    var nh = $('.navbar').height();
    //    $('.nav .mainMenu').css('border','solid 1px red');
    //});
	 $('#bs-example-navbar-collapse-1').hide();
    $(document.body).on("click", ".navbar-toggle", function () {
    
    //$('.navbar-toggle').click(function () {
        //alert('yes')
        // $('#bs-example-navbar-collapse-1').slideToggle();
		if ($('#bs-example-navbar-collapse-1').is(':hidden')) {
            $('#bs-example-navbar-collapse-1').show();
			$('#bs-example-navbar-collapse-1').css('visibility', 'visible');
        }
        else {
            $('#bs-example-navbar-collapse-1').hide();
			 $('#bs-example-navbar-collapse-1').css('visibility', 'hidden');
        }
    });
    
    var ww = $(window).width();

    if (ww > 769) {
        //alert('yes')
    var $mainContainer = $('.container');
    $mainContainer.css('width','100%');
    var mainCont = $mainContainer.width();
    var navWidthOld = $('#nav').css('width'); 
    $('.togglNav').on('click', function () {
       // $(this).attr("disabled", true);
        //
        //alert('yes');
        var $nav = $('#nav');
        var navWidth = $nav.css('width');
        if (navWidth == '0px') {
            $nav.animate({ width: ww * 17 / 100 });
            $mainContainer.animate({ width: mainCont - ww * 17 / 100 });
            // console.log('yes');
        }
        else {
            $nav.animate({ width: 0 });
            $mainContainer.animate({ width: '100%' });
        }

        setTimeout(function () {
            $(".nav_toggle").removeAttr("disabled");
        }, 500);

    });
    $(document.body).on("click", ".optionsMenuli", function () {
        $('#nav').animate({ width: ww * 17 / 100 });
        $mainContainer.animate({ width: mainCont - ww * 17 / 100 });
    });
    }


    

    if (ww < 768) {

        $('.togglNav').off().on('click', function () {
            // $(this).attr("disabled", true);
            //alert('yes');
            var $nav = $('#nav');
            var navWidth = $nav.css('width');
            if (navWidth != '0px') {
                $nav.animate({ width: 0 });
                // console.log('yes');
            }
            else {
                $nav.animate({ width: 200 });
            }

        });

    $(document.body).on('click', '.subMenu a', function () {
        $('#nav').animate({ "width": '0' });
        //$("#bs-example-navbar-collapse-1").hide();
    });
    }
    
    navcontwidth();
});
function navcontwidth() {
     
  
    //var conw = $(".container").width();
    //var navw = $("#nav").width();

    //$(".container").width($(".container").width());
    //$("#nav").width($("#nav").width());

    //$(".togglNav").on("click", function () {
    //    $(this).attr("disabled", true);
    //    var toggleWidth = $(".main_nav").width() == navw ? "0px" : navw;
    //    var toggle2Width = $(".main_container").width() == (navw + conw) ? ($(".main_container").width() - navw) : (navw + $(".main_container").width());
    //    $("#nav").animate({ width: toggleWidth });
        
    //    $(".container").animate({ width: toggle2Width });
    //    setTimeout(function () {
    //        $(".togglNav").removeAttr("disabled");
    //    }, 500);

    //});



   
    $(window).resize(function () {
        $(".container").width(conw2);
    });
    $(".time").attr("disabled","disabled");
   
   



    $(".dropModuala").unbind("click").click(function () {
       
        $(".optionsSection").slideToggle();
    });
    $("li.optionsMenuli").click(function () {
       
        //alert("hi");
        //$(".optionsSection").slideUp();
    });

    $(".optionClose").click(function () {
        $(".optionsSection").slideUp();
    });
    //$(".optionClose1").click(function () {
    //    $(".optionsSection").slideUp();
    //});
    

    // $(".mainMenu li").on("click", function () {

    //});
    $(".form .formCol :input:visible:enabled:first").focus();
    $(".formCol select").change(function () {


    });

    //$(".formCol").blur(function () {
    //alert("alert");
    //$("#").focus();
    //});

}
/*changes data 4/5/2014*/
$(document).ready(function () {
    $(".delete").click(function (e) {
        e.preventDefault();
    });
    $(".subMenu").parent().addClass("arrowRight");
    $(document.body).on("click",".mainMenu li a",function(){
    //$(".mainMenu li").click(function () {
        //alert("chk");
        $(".mainMenu li a").each(function () {
            $(this).removeClass("activeli");
        });
        if ($(this).parent().find("ul").length == 0)
            $(this).addClass("activeli");
        
        if ($(this).parent().find("ul").is(':visible'))
            $(this).parent().find("ul").slideUp();
        else
            $(this).parent().find(".subMenu").slideDown();
        //$(this).parent().find(".arrowRight").toggleClass("rotate");
        $(this).parent().siblings().children().next().slideUp();
        // $(this).find("a").toggleClass("active");
        // $(this).parent().siblings().children().next().slideUp();
       
        });
           

    $(document.body).on("click", ".basicArrow>a", function () {
        $(this).parent().toggleClass("basicArrow");
        $(this).parent().toggleClass("basicArrowa");
    });

    $(document.body).on("click", ".basicArrowa>a", function () {
        $(this).parent().toggleClass("basicArrow");
        $(this).parent().toggleClass("basicArrowa");
    });

    $(".subMenu li a").on("click", function () {
        $(".subMenu li a").removeClass("active");
        $(this).addClass("active");
    });

    //$(".mainMenu li a").on("click", function () {
    //  $(this).next(".mainMenu li a").removeClass("active2");
    // $(this).addClass("active2");
    //});

    $(".subMenu li a").click(function () {
        $(".subMenu li a").removeClass("active2");
    });
   
});





/*custum dropdown*/
             $(document).ready(function(){
                           $(".clickdiv").click(function (event) {
                               if ($(".etdiv").is(":hidden")) {
                                   $(".etdiv").css("display", "block");
                                   $(".clickdiv").addClass("clidivhover");
                               }
                               else {
                                   $(".etdiv").css("display", "none");
                                   $(".clickdiv").removeClass("clidivhover");
                               }
                               event.stopPropagation();
                           });
                           $(".etdiv li").click(function () {
                               
                               $("#t_ContractNo_autocomplete").val($(this).text())

                               $(".etdiv").css("display","none");
                               $("#t_ContractNo_autocomplete").attr("for", $(this).attr("id"));
                               
                           });
                           $(document).click(function () {
                               //console.log($(this).attr("class"));
                               if ($(this).attr("class") != 'clickdiv' || $(this).attr("class")==undefined) {
                                   $(".etdiv").hide();
                                   $(".clickdiv").removeClass("clidivhover");
                               }

                           });
                           $("header").click(function () {
                               //alert("yes");
                               $(".confirmationmsg").hide();
                           });

                           //$(document.body).on("click", "header,#nav,.confirmationmsg,.errormsg,.warnningmsg", function () {
                           //   // alert("yes");
                           //    $(".confirmationmsg,.errormsg,.warnningmsg").slideUp();
                           //});
             });

/*custun dropdown end*/

