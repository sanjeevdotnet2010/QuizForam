function individual_search_table(id) { var $dt_individual_search = $('#' + id); if ($dt_individual_search.length) { $dt_individual_search.find('tfoot th').each(function () { var title = $dt_individual_search.find('tfoot th').eq($(this).index()).text(); $(this).html('<input type="text" class="md-input" placeholder="' + title + '" />'); }); altair_md.inputs(); var individual_search_table = $dt_individual_search.DataTable(); individual_search_table.columns().every(function () { var that = this; $('input', this.footer()).on('keyup change', function () { that.search(this.value).draw(); }); }); } }

$(function () {
    // enable hires images
    altair_helpers.retina_images();
    // fastClick (touch devices)
    if (Modernizr.touch) {
        FastClick.attach(document.body);
    }
});
$(function () {
    var $switcher = $('#style_switcher'),
        $switcher_toggle = $('#style_switcher_toggle'),
        $theme_switcher = $('#theme_switcher'),
        $mini_sidebar_toggle = $('#style_sidebar_mini'),
        $boxed_layout_toggle = $('#style_layout_boxed'),
        $accordion_mode_toggle = $('#accordion_mode_main_menu'),
        $body = $('body');


    $switcher_toggle.click(function (e) {
        e.preventDefault();
        $switcher.toggleClass('switcher_active');
    });

    $theme_switcher.children('li').click(function (e) {
        e.preventDefault();
        var $this = $(this),
            this_theme = $this.attr('data-app-theme');

        $theme_switcher.children('li').removeClass('active_theme');
        $(this).addClass('active_theme');
        $body
            .removeClass('app_theme_a app_theme_b app_theme_c app_theme_d app_theme_e app_theme_f app_theme_g app_theme_h app_theme_i')
            .addClass(this_theme);

        if (this_theme == '') {
            localStorage.removeItem('altair_theme');
        } else {
            localStorage.setItem("altair_theme", this_theme);
        }

    });

    // hide style switcher
    $document.on('click keyup', function (e) {
        if ($switcher.hasClass('switcher_active')) {
            if (
                (!$(e.target).closest($switcher).length)
                || (e.keyCode == 27)
            ) {
                $switcher.removeClass('switcher_active');
            }
        }
    });

    // get theme from local storage
    if (localStorage.getItem("altair_theme") !== null) {
        $theme_switcher.children('li[data-app-theme=' + localStorage.getItem("altair_theme") + ']').click();
    }


    // toggle mini sidebar

    // change input's state to checked if mini sidebar is active
    if ((localStorage.getItem("altair_sidebar_mini") !== null && localStorage.getItem("altair_sidebar_mini") == '1') || $body.hasClass('sidebar_mini')) {
        $mini_sidebar_toggle.iCheck('check');
    }

    $mini_sidebar_toggle
        .on('ifChecked', function (event) {
            $switcher.removeClass('switcher_active');
            localStorage.setItem("altair_sidebar_mini", '1');
            location.reload(true);
        })
        .on('ifUnchecked', function (event) {
            $switcher.removeClass('switcher_active');
            localStorage.removeItem('altair_sidebar_mini');
            location.reload(true);
        });


    // toggle boxed layout

    if ((localStorage.getItem("altair_layout") !== null && localStorage.getItem("altair_layout") == 'boxed') || $body.hasClass('boxed_layout')) {
        $boxed_layout_toggle.iCheck('check');
        $body.addClass('boxed_layout');
        $(window).resize();
    }

    $boxed_layout_toggle
        .on('ifChecked', function (event) {
            $switcher.removeClass('switcher_active');
            localStorage.setItem("altair_layout", 'boxed');
            location.reload(true);
        })
        .on('ifUnchecked', function (event) {
            $switcher.removeClass('switcher_active');
            localStorage.removeItem('altair_layout');
            location.reload(true);
        });

    // main menu accordion mode
    if ($sidebar_main.hasClass('accordion_mode')) {
        $accordion_mode_toggle.iCheck('check');
    }

    $accordion_mode_toggle
        .on('ifChecked', function () {
            $sidebar_main.addClass('accordion_mode');
        })
        .on('ifUnchecked', function () {
            $sidebar_main.removeClass('accordion_mode');
        });


});





$(document).ready(function () {
    $ = jQuery.noConflict();
    $(document).ajaxStart(function () { $("#loderimg").css("display", "block"); });
    $(document).ajaxComplete(function () { $("#loderimg").css("display", "none"); });
    $(".numericOnly").keypress(function (event) { if ((event.which != 46 || $(this).val().indexOf('.') == -1) && ((event.which < 48 || event.which > 57) && (event.which != 0 && event.which != 8))) { event.preventDefault(); } });
    $(".numericwithdecimal").keypress(function (event) { if ((event.which != 46 || $(this).val().indexOf('.') != -1) && ((event.which < 48 || event.which > 57) && (event.which != 0 && event.which != 8))) { event.preventDefault(); } var text = $(this).val(); if ((text.indexOf('.') != -1) && (text.substring(text.indexOf('.')).length > 2) && (event.which != 0 && event.which != 8) && ($(this)[0].selectionStart >= text.length - 2)) { event.preventDefault(); } });
    $(".numericwithplus").keypress(function (event) { if ((event.which != 43 || $(this).val().indexOf('+') != -1) && ((event.which < 48 || event.which > 57) && (event.which != 0 && event.which != 8)) && (event.which != 32)) { event.preventDefault(); } });
    $(".AlphaNumericWithSpace").keypress(function (event) { if (((event.which < 48 || event.which > 57) && (event.which < 65 || event.which > 90) && (event.which < 97 || event.which > 122) && (event.which != 32))) { event.preventDefault(); } else { } });
});

function isAlphaNumericWithSpace(str) { var code, i, len; for (i = 0, len = str.length; i < len; i++) { code = str.charCodeAt(i); if (!(code > 47 && code < 58) && !(code > 64 && code < 91) && !(code > 96 && code < 123) && !(code = 32)) { return false; } } return true; };

function OnError(xhr, errorType, exception) { var responseText; $("#dialog").html(""); try { responseText = jQuery.parseJSON(xhr.responseText); $("#dialog").append("<div><b>" + errorType + " " + exception + "</b></div>"); $("#dialog").append("<div><u>Exception</u>:<br /><br />" + responseText.ExceptionType + "</div>"); $("#dialog").append("<div><u>StackTrace</u>:<br /><br />" + responseText.StackTrace + "</div>"); $("#dialog").append("<div><u>Message</u>:<br /><br />" + responseText.Message + "</div>"); } catch (e) { responseText = xhr.responseText; $("#dialog").html(responseText); } $("#dialog").show(); };

function GetParameterValues(param) { var url = window.location.href.slice(window.location.href.indexOf('?') + 1).split('&'); for (var i = 0; i < url.length; i++) { var urlparam = url[i].split('='); if (urlparam[0].toLowerCase() == param.toLowerCase()) { return urlparam[1]; } } };

function htmlEncode(value) { return $('<div/>').text(value).html(); };

function htmlDecode(value) { return $('<div/>').html(value).text(); };

function removenull(val) { var res = val == null ? " " : val; return res; };

function SecureString(str) { str = str.replace("'", ""); str = str.replace("&", ""); str = str.replace("-", ""); return str; }

function validateDocs(val) { var ret = false; var fuData = document.getElementById(val); var FileUploadPath = fuData.value; var validFileSize = 2 * 1024 * 1024; var sizeoffile = fuData.files[0].size; if (FileUploadPath == '') { ret = false; } else { if (sizeoffile !== 0 && sizeoffile <= validFileSize) { var Extension = FileUploadPath.substring(FileUploadPath.lastIndexOf('.') + 1).toLowerCase(); if (Extension == "DOC" || Extension == "DOCX" || Extension == "PDF" || Extension == "doc" || Extension == "docx" || Extension == "pdf") { ret = true; } else { ret = false; swal("Invalid File Format only DOC, DOCX, PDF are allowed"); document.getElementById(val).value = ''; } } else { ret = false; swal("File Size Should be Greater than 0 and less than 2 MB"); document.getElementById(val).value = ''; } } return ret; };

function validateEmail(email) { var re = /^(([^<>()\[\]\\.,;:\s@"]+(\.[^<>()\[\]\\.,;:\s@"]+)*)|(".+"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/; return re.test(email) }; if (navigator.userAgent.match(/IEMobile\/10\.0/)) { var msViewportStyle = document.createElement('style'); msViewportStyle.appendChild(document.createTextNode('@-ms-viewport{width:auto!important}')); document.querySelector('head').appendChild(msViewportStyle); };

function ShowClock() { var n = new Date(new Date().getTime()).toLocaleTimeString(); document.getElementById("time").innerHTML = n; t = setTimeout(function () { ShowClock() }, 1000); }

$(function () { $('a[href*=#]:not([href=#])').click(function () { if (($(".user_PC_ctrl").css("display") == "none")) { $("#sidebar").hide(); } if (location.pathname.replace(/^\//, '') == this.pathname.replace(/^\//, '') && location.hostname == this.hostname) { var target = $(this.hash); $(".questions").removeClass("jumped_questions"); $(target).addClass("jumped_questions"); var position = target.offset().top; position = position - 120; target = target.length ? target : $('[name=' + this.hash.slice(1) + ']'); if (target.length) { $('html,body').animate({ scrollTop: position }, 1000); return false; } } }); });




