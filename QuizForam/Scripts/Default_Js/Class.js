

$(document).ready(function () {
    $ = jQuery.noConflict();
    $(document).ajaxStart(function () { $("#loderimg").css("display", "block"); });
    $(document).ajaxComplete(function () { $("#loderimg").css("display", "none"); });
    $(".numericOnly").keypress(function (event) { if ((event.which != 46 || $(this).val().indexOf('.') == -1) && ((event.which < 48 || event.which > 57) && (event.which != 0 && event.which != 8))) { event.preventDefault(); } });
    $(".numericwithdecimal").keypress(function (event) { if ((event.which != 46 || $(this).val().indexOf('.') != -1) && ((event.which < 48 || event.which > 57) && (event.which != 0 && event.which != 8))) { event.preventDefault(); } var text = $(this).val(); if ((text.indexOf('.') != -1) && (text.substring(text.indexOf('.')).length > 2) && (event.which != 0 && event.which != 8) && ($(this)[0].selectionStart >= text.length - 2)) { event.preventDefault(); } });
    $(".numericwithplus").keypress(function (event) { if ((event.which != 43 || $(this).val().indexOf('+') != -1) && ((event.which < 48 || event.which > 57) && (event.which != 0 && event.which != 8)) && (event.which != 32)) { event.preventDefault(); } });

    $(".AlphaNumericWithSpace").keypress(function (event) { if (((event.which < 48 || event.which > 57) && (event.which < 65 || event.which > 90) && (event.which < 97 || event.which > 122) && (event.which != 32))) { event.preventDefault(); } else { } });

    $.validator.setDefaults({
        highlight: function (element) {
            $(element).closest('.form-group').addClass('has-error');
            $(element).focus();
        },
        unhighlight: function (element) {
            $(element).closest('.form-group').removeClass('has-error');
        },
        errorElement: 'span',
        errorClass: 'help-block',
        errorPlacement: function (error, element) {
            if (element.parent('.input-group').length) {
                error.insertAfter(element.parent());
            } else {
                error.insertAfter(element);
            }
        }
    });
});

function isAlphaNumericWithSpace(str) { var code, i, len; for (i = 0, len = str.length; i < len; i++) { code = str.charCodeAt(i); if (!(code > 47 && code < 58) && !(code > 64 && code < 91) && !(code > 96 && code < 123) && !(code = 32)) { return false; } } return true; };

function OnError(xhr, errorType, exception) { var responseText; $("#dialog").html(""); try { responseText = jQuery.parseJSON(xhr.responseText); $("#dialog").append("<div><b>" + errorType + " " + exception + "</b></div>"); $("#dialog").append("<div><u>Exception</u>:<br /><br />" + responseText.ExceptionType + "</div>"); $("#dialog").append("<div><u>StackTrace</u>:<br /><br />" + responseText.StackTrace + "</div>"); $("#dialog").append("<div><u>Message</u>:<br /><br />" + responseText.Message + "</div>"); } catch (e) { responseText = xhr.responseText; $("#dialog").html(responseText); } $("#dialog").show(); };
function GetParameterValues(param) { var url = window.location.href.slice(window.location.href.indexOf('?') + 1).split('&'); for (var i = 0; i < url.length; i++) { var urlparam = url[i].split('='); if (urlparam[0].toLowerCase() == param.toLowerCase()) { return urlparam[1]; } } };
function htmlEncode(value) { return $('<div/>').text(value).html(); };
function htmlDecode(value) { return $('<div/>').html(value).text(); };
function passmsgtoMassagepage(msg, title) { $.ajax({ type: "POST", url: "/message/setsession", data: '{ MSG: "' + msg + '",TITLE:"' + title + '" }', contentType: "application/json; charset=utf-8", dataType: "json", success: function (response) { location.replace('/message/Index'); } }); };
function removenull(val) { var res = val == null ? " " : val; return res; };
function SecureString(str) { str = str.replace("'", ""); str = str.replace("&", ""); str = str.replace("-", ""); return str; }
function validateDocs(val) { var ret = false; var fuData = document.getElementById(val); var FileUploadPath = fuData.value; var validFileSize = 2 * 1024 * 1024; var sizeoffile = fuData.files[0].size; if (FileUploadPath == '') { ret = false; } else { if (sizeoffile !== 0 && sizeoffile <= validFileSize) { var Extension = FileUploadPath.substring(FileUploadPath.lastIndexOf('.') + 1).toLowerCase(); if (Extension == "DOC" || Extension == "DOCX" || Extension == "PDF" || Extension == "doc" || Extension == "docx" || Extension == "pdf") { ret = true; } else { ret = false; swal("Invalid File Format only DOC, DOCX, PDF are allowed"); document.getElementById(val).value = ''; } } else { ret = false; swal("File Size Should be Greater than 0 and less than 2 MB"); document.getElementById(val).value = ''; } } return ret; };
function validateEmail(email) { var re = /^(([^<>()\[\]\\.,;:\s@"]+(\.[^<>()\[\]\\.,;:\s@"]+)*)|(".+"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/; return re.test(email) }; if (navigator.userAgent.match(/IEMobile\/10\.0/)) { var msViewportStyle = document.createElement('style'); msViewportStyle.appendChild(document.createTextNode('@-ms-viewport{width:auto!important}')); document.querySelector('head').appendChild(msViewportStyle); };

function ShowClock() { var n = new Date(new Date().getTime()).toLocaleTimeString(); document.getElementById("time").innerHTML = n; t = setTimeout(function () { ShowClock() }, 1000); }

$(function () { $('a[href*=#]:not([href=#])').click(function () { if (($(".user_PC_ctrl").css("display") == "none")) { $("#sidebar").hide(); } if (location.pathname.replace(/^\//, '') == this.pathname.replace(/^\//, '') && location.hostname == this.hostname) { var target = $(this.hash); $(".questions").removeClass("jumped_questions"); $(target).addClass("jumped_questions"); var position = target.offset().top; position = position - 120; target = target.length ? target : $('[name=' + this.hash.slice(1) + ']'); if (target.length) { $('html,body').animate({ scrollTop: position }, 1000); return false; } } }); });