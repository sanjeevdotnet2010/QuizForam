var isIE8 = false, isIE9 = false;
var Login = function () {
    "use strict";
    var runBoxToShow = function () {
        var el = $('.admin-login-widget');
        if (getParameterByName('box').length) {
            switch (getParameterByName('box')) {
                case "register":
                    el = $('.admin-widget-register');
                    break;
                case "forgot":
                    el = $('.admin-widget-forgot');
                    break;
                default:
                    el = $('.admin-login-widget');
                    break;
            }
        }

        el.show().addClass("animated flipInX").on('webkitAnimationEnd mozAnimationEnd MSAnimationEnd oanimationend animationend', function () {
            $(this).removeClass("animated flipInX");
        });
    };
    var runLoginButtons = function () {
        $('.forgot-pass').on('click', function () {
            $('.admin-login-widget').removeClass("animated flipInX").addClass("animated bounceOutRight").on('webkitAnimationEnd mozAnimationEnd MSAnimationEnd oanimationend animationend', function () {
                $(this).hide().removeClass("animated bounceOutRight");

            });
            $('.admin-widget-forgot').show().addClass("animated bounceInLeft").on('webkitAnimationEnd mozAnimationEnd MSAnimationEnd oanimationend animationend', function () {
                $(this).show().removeClass("animated bounceInLeft");

            });
        });
        $('.register').on('click', function () {
            $('.admin-login-widget').removeClass("animated flipInX").addClass("animated bounceOutRight").on('webkitAnimationEnd mozAnimationEnd MSAnimationEnd oanimationend animationend', function () {
                $(this).hide().removeClass("animated bounceOutRight");

            });
            $('.admin-widget-register').show().addClass("animated bounceInLeft").on('webkitAnimationEnd mozAnimationEnd MSAnimationEnd oanimationend animationend', function () {
                $(this).show().removeClass("animated bounceInLeft");

            });

        });
        $('.have-account').click(function () {
            var boxToShow;
            if ($('.admin-widget-register').is(":visible")) {
                boxToShow = $('.admin-widget-register');
            } else {
                boxToShow = $('.admin-widget-forgot');
            }
            boxToShow.addClass("animated bounceOutLeft").on('webkitAnimationEnd mozAnimationEnd MSAnimationEnd oanimationend animationend', function () {
                boxToShow.hide().removeClass("animated bounceOutLeft");

            });
            $('.admin-login-widget').show().addClass("animated bounceInRight").on('webkitAnimationEnd mozAnimationEnd MSAnimationEnd oanimationend animationend', function () {
                $(this).show().removeClass("animated bounceInRight");

            });
        });
    };
    //function to return the querystring parameter with a given name.
    var getParameterByName = function (name) {
        name = name.replace(/[\[]/, "\\\[").replace(/[\]]/, "\\\]");
        var regex = new RegExp("[\\?&]" + name + "=([^&#]*)"), results = regex.exec(location.search);
        return results == null ? "" : decodeURIComponent(results[1].replace(/\+/g, " "));
    };
    var runSetDefaultValidation = function () {
        $.validator.setDefaults({
            errorElement: "span", // contain the error msg in a small tag
            errorClass: 'help-block',
            errorPlacement: function (error, element) {// render error placement for each input type
                if (element.attr("type") == "radio" || element.attr("type") == "checkbox") {// for chosen elements, need to insert the error after the chosen container
                    error.insertAfter($(element).closest('.form-group').children('div').children().last());
                } else if (element.attr("name") == "card_expiry_mm" || element.attr("name") == "card_expiry_yyyy") {
                    error.appendTo($(element).closest('.form-group').children('div'));
                } else {
                    error.insertAfter(element);
                    // for other inputs, just perform default behavior
                }
            },
            ignore: ':hidden',
            success: function (label, element) {
                label.addClass('help-block valid');
                // mark the current input as valid and display OK icon
                $(element).closest('.form-group').removeClass('has-error');
            },
            highlight: function (element) {
                $(element).closest('.help-block').removeClass('valid');
                // display OK icon
                $(element).closest('.form-group').addClass('has-error');
                // add the Bootstrap error class to the control group
            },
            unhighlight: function (element) {// revert the change done by hightlight
                $(element).closest('.form-group').removeClass('has-error');
                // set error class to the control group
            }
        });
    };
    var runLoginValidator = function () {
        var form = $('.form-loginVal');
        var formErrorRed = $('.formErrorRed', form);
        form.validate({
            rules: {
                username: {
                    minlength: 2,
                    required: true
                },
                password: {
                    minlength: 6,
                    required: true
                }
            },
            submitHandler: function (form) {
                formErrorRed.hide();
                form.submit();
            },
            invalidHandler: function (event, validator) {//display error alert on form submit
                formErrorRed.show();
            }
        });
    };
    var runForgotValidator = function () {
        var form2 = $('.form-forgotVAl');
        var formErrorRed2 = $('.formErrorRed', form2);
        form2.validate({
            rules: {
                email: {
                    required: true
                }
            },
            submitHandler: function (form) {
                formErrorRed2.hide();
                form2.submit();
            },
            invalidHandler: function (event, validator) {//display error alert on form submit
                formErrorRed2.show();
            }
        });
    };
    var runRegisterValidator = function () {
        var form3 = $('.form-registerVAL');
        var formErrorRed3 = $('.formErrorRed', form3);
        form3.validate({
            rules: {
                id: {
                    minlength: 2,
                    required: true
                },
                address: {
                    minlength: 2,
                    required: true
                },
                city: {
                    minlength: 2,
                    required: true
                },
                gender: {
                    required: true
                },
                email: {
                    required: true
                },
                password: {
                    minlength: 6,
                    required: true
                },
                password_again: {
                    required: true,
                    minlength: 5,
                    equalTo: "#password"
                },
                agree: {
                    minlength: 1,
                    required: true
                }
            },
            submitHandler: function (form) {
                formErrorRed3.hide();
                form3.submit();
            },
            invalidHandler: function (event, validator) {//display error alert on form submit
                formErrorRed3.show();
            }
        });
    };
    return {
        //main function to initiate template pages
        init: function () {
          
            runBoxToShow();
            runLoginButtons();
            runSetDefaultValidation();
            runLoginValidator();
            runForgotValidator();
            runRegisterValidator();
        }
    };
}();

(function ($, sr) {
    "use strict";
    // debouncing function from John Hann
    // http://unscriptable.com/index.php/2009/03/20/debouncing-javascript-methods/
    var debounce = function (func, threshold, execAsap) {
        var timeout;
        return function debounced() {
            var obj = this, args = arguments;

            function delayed() {
                if (!execAsap)
                    func.apply(obj, args);
                timeout = null;
            };

            if (timeout)
                clearTimeout(timeout);
            else if (execAsap)
                func.apply(obj, args);

            timeout = setTimeout(delayed, threshold || 100);
        };
    };
    // smartresize
    jQuery.fn[sr] = function (fn) {
        return fn ? this.on('resize', debounce(fn)) : this.trigger(sr);
    };

})(jQuery, 'espressoResize');
