$(document).ready(function () {

    CreateAutocomplete();
});

function CreateAutocomplete() {
    var inputsToProcess = $('[data-autocomplete]').each(function (index, element) {
        var requestUrl = $(element).attr('data-action');
        var CallBackFun = $(element).attr('callback-fun');
        var NoofPara = $(element).attr('Noof-para');

        $(element).autocomplete({
            minLength: 1,
            source: function (request, response) {
                $.ajax({
                    url: requestUrl,
                    dataType: "json",
                    data: { query: request.term },
                    success: function (data) {
                        response($.map(data, function (item) {
                            return {
                                para: NoofPara,
                                fun: CallBackFun,
                                label: item.Label,
                                value: item.Label,
                                realValue: item.Value
                            };
                        }));
                    },
                });
            },
            select: function (event, ui) {

                if (ui.item.fun != null || ui.item.para == 1)
                    window[ui.item.fun](ui.item.realValue);
                if (ui.item.fun != null && ui.item.para == 2)
                    window[ui.item.fun](ui.item.realValue, ui.item.value);
                var hiddenFieldName = $(this).attr('data-value-name');
                $('#' + hiddenFieldName).val(ui.item.realValue);
            }
        });
    });
}

//For Enable Autocomplete For Dynamic Created Text Box
function enable_autocomplete(InputField, actionUrl, hiddenFieldName) {

    $(InputField).autocomplete({
        source: function (request, response) {
            $.ajax({
                url: actionUrl, // "/ContractCon/GetAutoCompProd",
                dataType: "json",
                data: { query: request.term },
                success: function (data) {
                    response($.map(data, function (item) {
                        return {

                            label: item.Label,
                            value: item.Label,
                            realValue: item.Value
                        };
                    }));
                },

            });
        },
        select: function (event, ui) {

            //   window[funName](ui.item.realValue,input1,input2);
            $(hiddenFieldName).val(ui.item.realValue);
        }
    });
}

// enable AutoComplete ON popup
function enable_autocompleteOnPopUp(InputField, actionUrl, hiddenFieldName) {
    $(InputField).autocomplete({
        source: function (request, response) {
            $.ajax({
                url: actionUrl, // "/ContractCon/GetAutoCompProd",
                dataType: "json",
                data: { query: request.term },

                success: function (data) {
                    response($.map(data, function (item) {
                        return {

                            label: item.Label,
                            value: item.Label,
                            realValue: item.Value
                        };
                    }));
                },

            });
        },
        select: function (event, ui) {

            //   window[funName](ui.item.realValue,input1,input2);
            $(hiddenFieldName).val(ui.item.realValue);
        }
    });
}


// when we need only autocompleate without id
function Getautocomplete(InputField, actionUrl) {
    $(InputField).autocomplete({
        source: function (request, response) {
            $.ajax({
                url: actionUrl, // "/ContractCon/GetAutoCompProd",
                dataType: "json",
                data: { query: request.term },
                success: function (data) {
                    response($.map(data, function (item) {
                        return {
                            label: item.Label,
                            value: item.Label,
                            realValue: item.Value
                        };
                    }));
                },
            });
        }
    });

}




//Ashish

function GetAutoforMultipleInput(InputField, actionUrl, input1, input2, input3) {
    
    $(InputField).autocomplete({

        source: function (request, response) {
            $.ajax({
                url: actionUrl, // "/ContractCon/GetAutoCompProd",
                dataType: "json",
                data: { query: request.term, mode: $('#t_sp_Name').val(), n_PerInID: $('#n_PerInID').val(), n_PaymentId: $('#n_PaymentsId').val() },
                success: function (data) {
                    response($.map(data, function (item) {
                        return {

                            label: item.Label,
                            value: item.Label,
                            realValue: item.Value
                        };
                    }));
                },

            });
        }
    });

}

function GetAutoforAppliMngt(InputField, actionUrl, input1) {

    $(InputField).autocomplete({

        source: function (request, response) {
            $.ajax({
                url: actionUrl, // "/ContractCon/GetAutoCompProd",
                dataType: "json",
                data: { query: request.term, mode: $('#t_sp_Name').val(), n_PerInID: $('#n_PerInID').val()},
                success: function (data) {
                    response($.map(data, function (item) {
                        return {

                            label: item.Label,
                            value: item.Label,
                            realValue: item.Value
                        };
                    }));
                },

            });
        }
    });

}
//






//For Enable Autocomplete For Dynamin Created TextBox on Contract Genration Page
function enable_autocompleteCon(InputField, actionUrl, hiddenFieldName, input1, input2, input3, tableId, funName) {
    $(InputField).autocomplete({
        source: function (request, response) {
            $.ajax({
                url: actionUrl, // "/ContractCon/GetAutoCompProd",
                dataType: "json",
                data: { query: request.term },
                success: function (data) {
                    response($.map(data, function (item) {
                        return {
                            label: item.Label,
                            value: item.Label,
                            realValue: item.Value
                        };
                    }));
                },

            });
        },
        select: function (event, ui) {
            //alert(ui.item.realValue);
            var mt = 0;
            $('#' + tableId + ' tbody tr').each(function (row, tr) {
                var val = ($(tr).children("td:nth-child(1)")).children("input[type=hidden]").val()
                if (ui.item.realValue == val) {
                    // alert(mt);
                    mt = val;
                }
                //else {
                //  mt = 0;
                //}
            });
            if (mt == 0) {
                window[funName](ui.item.realValue, input1, input2, input3);
                $(hiddenFieldName).val(ui.item.realValue);
                $('#sp_msg').empty();
            }
            else {

                $('#sp_msg').html('Product Already Added');
                $(InputField).val("");

            }
        }
    });
}


//For Currency Code
function fn_SetCurrencyCode(input, input1, input2, input3, input4) {
    // alert($('#'+input)[0].tagName);
    if ($('#' + input).val() != ' ') {
        var CurrencyText;
        var str;
        if ($('#' + input)[0].tagName == 'SELECT') {
            CurrencyText = ($('#' + input + ' option:selected').text());
            var charindex = CurrencyText.lastIndexOf('(');
            str = CurrencyText.substr(charindex + 1, (CurrencyText.length - charindex) - 2)
        }
        else {
            str = GetCurrencyCode(input);
        }

        $('#' + input1).html(str);
        $('#' + input2).html(str);
        $('#' + input3).html(str);
        $('#' + input4).html(str);
    }
}

function GetCurrencyCode(input) {
    var CurrencyText = $('#' + input).val();
    var charindex = CurrencyText.lastIndexOf('(');
    var str = CurrencyText.substr(charindex + 1, (CurrencyText.length - charindex) - 2)
    return str;
}