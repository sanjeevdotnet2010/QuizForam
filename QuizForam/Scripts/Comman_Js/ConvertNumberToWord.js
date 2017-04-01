var a = ['', 'one ', 'two ', 'three ', 'four ', 'five ', 'six ', 'seven ', 'eight ', 'nine ', 'ten ', 'eleven ', 'twelve ', 'thirteen ', 'fourteen ', 'fifteen ', 'sixteen ', 'seventeen ', 'eighteen ', 'nineteen '];
var b = ['', '', 'twenty', 'thirty', 'forty', 'fifty', 'sixty', 'seventy', 'eighty', 'ninety'];

//$('#btnSubmit').live('click', function () {
//    inWords($('#rupees').val());
//});

function inWords(input, assignID) {
    //alert($('#' + input).val());
    var NumText =$('#'+ input).val();
    var charindex = NumText.lastIndexOf('.');
    var num = NumText.substr(0, (charindex))
    var num2 = NumText.substr(charindex + 1, (NumText.length - charindex))
    //alert(charindex);
    if ((num = num.toString()).length > 9) return 'overflow';
    n = ('000000000' + num).substr(-9).match(/^(\d{2})(\d{2})(\d{2})(\d{1})(\d{2})$/);
    m = ('000' + num2).substr(-3).match(/^(\d{1})(\d{2})$/);
    //alert(n);
    if (!n) return;
    var str = '';
    str += (n[1] != 0) ? (a[Number(n[1])] || b[n[1][0]] + ' ' + a[n[1][1]]) + 'crore ' : '';
    str += (n[2] != 0) ? (a[Number(n[2])] || b[n[2][0]] + ' ' + a[n[2][1]]) + 'lakh ' : '';
    str += (n[3] != 0) ? (a[Number(n[3])] || b[n[3][0]] + ' ' + a[n[3][1]]) + 'thousand ' : '';
    str += (n[4] != 0) ? (a[Number(n[4])] || b[n[4][0]] + ' ' + a[n[4][1]]) + 'hundred ' : '';
    str += (n[5] != 0) ? (a[Number(n[5])] || b[n[5][0]] + ' ' + a[n[5][1]]) : '';
    if (num2 != '000') {
        str += " AND CENT(S) ";
    }
    str += (m[1] != 0) ? (a[Number(m[1])] || b[m[1][0]] + ' ' + a[m[1][1]]) + 'hundred ' : '';
    str += (m[2] != 0) ? (a[Number(m[2])] || b[m[2][0]] + ' ' + a[m[2][1]]) : '';
    str += 'only';
    $('#' + assignID).text(str)
    //alert(str);
}