// JScript File
var ctrlList = new Array();
var msgList = new Array();
var dtypeList = new Array();
var flag = 0;

var validInt = '-0123456789';
var validDbl = '-0123456789.';

function IsValid(ctrlName, displayMsg, dataType) {
    flag = 0;
    ctrlList = ctrlName.split('~');
    msgList = displayMsg.split('~');
    dtypeList = dataType.split('~');

    for (var i = 0; i < ctrlList.length; i++) {

        var cntrlPosition;
        cntrlPosition = ControlValid(ctrlList[i]);
        var tempCtrl = document.forms[0].elements[cntrlPosition];

        if (dtypeList[i] == "DropDown") {

            if (IsDropdown(tempCtrl) == 0) {
                alertify.alert('Please Enter ' + msgList[i]);
                flag = 1;
                break;
            }

        }
        if (dtypeList[i] == "AutoComplete") {

            if (tempCtrl.value == 0) {
                alertify.alert('InValid ' + msgList[i]);
                cntrlPosition = ControlValid(ctrlList[i - 1]);
                tempCtrl = document.forms[0].elements[cntrlPosition];
                tempCtrl.focus();
                flag = 1;
                break;
            }

        }
        if (dtypeList[i] == "Password") {
            if (validatePwd(tempCtrl) == 0) {
                flag = 1;
                alertify.alert("Password should be minimum 6 and maximum 10 characters.One alphapet(capital letter),Number and Special character should be there in the password.Space will not be accepted .");
                tempCtrl.focus();
                break;
            }
        }

        if (IsEmpty(tempCtrl) == 1) {
            flag = 1;
            alertify.alert("Please Enter " + msgList[i]);
            tempCtrl.focus();
            break;
        }
        else {
            if (dtypeList[i] == "Integer") {
                if (IsIntegerCheck(tempCtrl) == 0) {
                    alertify.alert('Please Check ' + msgList[i]);
                    tempCtrl.focus();
                    flag = 1;
                    break;
                }
            }
            else if (dtypeList[i] == "Double") {
                if (IsDouble(tempCtrl) == 0) {
                    alertify.alert('Please Check ' + msgList[i]);
                    tempCtrl.focus();
                    flag = 1;
                    break;
                }
            }

        }
    }
    if (flag == 1) {
        return false;
    }
    else {
        return true;
    }
}

function IsEmpty(CtrlN) {
    if (CtrlN.value == '') {
        return 1;
    }
    else {
        return 0;
    }
}

function ControlValid(ctrlName) {
    var intResult = 1;
    for (var i = 0; i < document.forms[0].elements.length; i++) {
        var ctrlNameWotDoll;
        var temp = new Array();
        var tempCtrlName = document.forms[0].elements[i].name;

        temp = tempCtrlName.split('$');
        if (temp.length == 4)
        { ctrlNameWotDoll = temp[temp.length - 2]; }
        else if (temp.length == 3)
        { ctrlNameWotDoll = temp[2]; }
        else
        { ctrlNameWotDoll = temp[temp.length - 1]; }

        if (ctrlNameWotDoll == ctrlName) {
            intResult = i;
            break;
        }
    }
    return intResult;
}


function IsIntegerCheck(CtrlN) {
    var tempArray = new Array();
    tempArray = CtrlN.value.split('');
    flag = 0;

    for (var i = 0; i < tempArray.length; i++) {
        if (validInt.indexOf(tempArray[i]) == -1) {
            flag = 1;
        }
    }
    if (flag == 0) {
        return 1;


    }
    else {
        return 0;

    }
}

function IsDouble(CtrlN) {
    var tempArray = new Array();
    tempArray = CtrlN.value.split('');
    flag = 0;

    if (CtrlN.value.indexOf('.') != CtrlN.value.lastIndexOf('.')) {
        flag = 1;
    }
    else {
        for (var i = 0; i < tempArray.length; i++) {
            if (validDbl.indexOf(tempArray[i]) == -1) {
                flag = 1;
            }
        }
    }

    if (flag == 0) {
        return 1;
    }
    else {
        return 0;
    }
}
function IsDoubleCheck(CtrlN) {
    var validChars = '0123456789.';
    var temp = document.forms[0].elements[ControlValid(CtrlN)];
    var Tempval = temp.value;
    if (Tempval.split(".").length - 1 > 1) {
        alertify.alert("Please Enter Numeric Values");
        temp.focus();
        temp.value = "";
        return false;
    }
    for (var i = 0; i < Tempval.length; i++) {
        if (validChars.indexOf(Tempval.charAt(i)) == -1) {
            alertify.alert("Please Enter Numeric Values");
            temp.focus();
            temp.value = "";
            return false;
        }
    }
    return true;
}
function IsDropdown(CtrlN) {

    var temp;
    temp = CtrlN.value;

    flag = 0;

    if (temp == 0) {
        flag = 1;
    }

    if (flag == 0) {
        return 1;
    }
    else {
        return 0;
    }
}

function CheckSamePort(ddFrm, ddto) {
    var ddlFrom = document.forms[0].elements[ControlValid(ddFrm)];
    var ddlTo = document.forms[0].elements[ControlValid(ddto)];

    if (ddlFrom.value == "--Select--" && ddlTo.value == "--Select--") {
        alertify.alert("Please Select From & To Port");
        return false;
    }
    else if (ddlFrom.value == ddlTo.value) {
        alertify.alert("From & To Port Should Not Be Same");
        return false;
    }
    else if (ddlFrom.value == "--Select--") {
        alertify.alert("Please Select From Port");
        return false;
    }
    else if (ddlTo.value == "--Select--") {
        alertify.alert("Please Select To Port");
        return false;
    }
    else {
        return true;
    }
}
function CheckSamePort_BL(ddFrm, ddto, Frmport, Toport) {
    var ddlFrom = document.forms[0].elements[ControlValid(ddFrm)];
    var ddlTo = document.forms[0].elements[ControlValid(ddto)];

    if (ddlFrom.value == "" && ddlTo.value == "") {
        alertify.alert("Please Select " + Frmport + " And " + Toport);
        ddlTo.focus();
        return false;
    }
    else if (ddlFrom.value == ddlTo.value) {
        alertify.alert(Frmport + " And " + Toport + " Should Not Be Same");
        ddlTo.focus();
        return false;
    }
    else if (ddlFrom.value == "") {
        alertify.alert("Please Select " + Frmport);
        return false;
    }
    else if (ddlTo.value == "") {
        alertify.alert("Please Select " + Toport);
        return false;
    }
    else {
        return true;
    }
}

function DOIssue() {
    var button = document.forms[0].elements[ControlValid("Btn_Print")];
    if (button.value == "Update") {
        var header = document.forms[0].elements[ControlValid("hid_head")];
        if (confirm("Do you want Letter Head?"))
        { header.value = "S"; }
        else
        { header.value = "N"; }
        return true;
    }
}

function IntegerCheck(e) {

    var keycode;


    if (window.event)
        keycode = e.keyCode;
    else if (e.which)

        keycode = e.which;

    if (keycode != undefined) {
        if ((keycode >= 48 && keycode <= 57) || (keycode == 8) || (keycode == 127) || (keycode == 13)) {

            return true;
        }

        else {
            alertify.alert(" Enter Numeric Values");
            return false;


        }
    }
}
function DoubleCheck(e) {

    var keycode;


    if (window.event)
        keycode = e.keyCode;
    else if (e.which)

        keycode = e.which;

    if (keycode != undefined) {
        if ((keycode >= 48 && keycode <= 57) || (keycode == 8) || (keycode == 127) || (keycode == 13) || (keycode == 46)) {

            return true;
        }

        else {
            alertify.alert(" Enter Numeric Values");
            return false;


        }
    }
}

function DateCheck(e) {

    return false;
}
function Check(objRef) {


    var row = objRef.parentNode.parentNode;

    var GridView = row.parentNode;



    var inputList = GridView.getElementsByTagName("input");

    for (var i = 0; i < inputList.length; i++) {


        var headerCheckBox = inputList[0];

        var checked = true;

        if (inputList[i].type == "checkbox" && inputList[i] != headerCheckBox) {

            if (!inputList[i].checked) {

                checked = false;

                break;
            }


        }

    }

    headerCheckBox.checked = checked;


}


function checkAll(objRef) {

    var GridView = objRef.parentNode.parentNode.parentNode;

    var inputList = GridView.getElementsByTagName("input");

    for (var i = 0; i < inputList.length; i++) {

        var row = inputList[i].parentNode.parentNode;

        if (inputList[i].type == "checkbox" && objRef != inputList[i]) {

            if (objRef.checked) {



                inputList[i].checked = true;

            }

            else {

                inputList[i].checked = false;

            }

        }

    }

}

function IsMonthCheck(From, To, Msg) {
    var ddlFrom = document.forms[0].elements[ControlValid(From)];
    var ddlTo = document.forms[0].elements[ControlValid(To)];

    if (ddlFrom.value > ddlTo.value) {
        alertify.alert(Msg + " - To Month must be greater than From Month");
        ddlFrom.focus();
        return false;
    }
    else {
        return true;
    }
}

function IsYearCheck(From, To, Msg) {
    var ddlFrom = document.forms[0].elements[ControlValid(From)];
    var ddlTo = document.forms[0].elements[ControlValid(To)];

    if (ddlFrom.value > ddlTo.value) {
        alertify.alert(Msg + " - To Year must be greater than From Year");
        ddlFrom.focus();
        return false;
    }
    else {
        return true;
    }
}


function IsMonth(From, To, Msg) {
    if (typeof Msg === 'undefined') {
        Msg = "To Month must be greater than From Month";
      }
    var ddlFrom = document.forms[0].elements[ControlValid(From)];
    var ddlTo = document.forms[0].elements[ControlValid(To)];

    var FromList = new Array();
    var ToList = new Array();

    FromList = ddlFrom.value.split('/');
    ToList = ddlTo.value.split('/');

    if (FromList[2] > ToList[2]) {
        alertify.alert(Msg);
        ddlFrom.focus();
        return false;
    }
    else if (FromList[1] > ToList[1] && FromList[2] == ToList[2]) {
        alertify.alert(Msg);
        ddlFrom.focus();
        return false;
    }
    else if (FromList[0] > ToList[0] && FromList[1] == ToList[1] && FromList[2] == ToList[2]) {
        alertify.alert(Msg);
        ddlFrom.focus();
        return false;
    }
    else {
        return true;
    }
}
function IsDate(ctrlName,Msg) {
    var ctrlList = new Array();
    var flag = 0;
    ctrlList = ctrlName.split('~');

    for (var i = 0; i < ctrlList.length; i++) {
        var cntrlPosition;
        cntrlPosition = ControlValid(ctrlList[i]);
        var strDate = document.forms[0].elements[cntrlPosition];
        var validformat = /^\d{1,2}\/\d{1,2}\/\d{4}$/;
        if (!validformat.test(strDate.value)) {
            alertify.alert('Enter Date Format DD/MM/YYYY')
            strDate.value = "";
            strDate.focus();
            return false;
        }
        else {
            var DateText = new Array();
            DateText = strDate.value.split('/');
            var day = DateText[0];
            var month = DateText[1];
            var year = DateText[2];
            if (DateText[0] <= 0 || DateText[0] > 31) {
                alertify.alert('Enter Day between 1 to 31')
                strDate.value = "";
                strDate.focus();
                return false;
            }
            else if (DateText[1] <= 0 || DateText[1] > 12) {
                alertify.alert('Enter Month between 1 to 12')
                strDate.value = "";
                strDate.focus();
                return false;
            }
            else if (DateText[2] < 1900 || DateText[2] > 2079) {
                alertify.alert('Enter Year between 1900 to 2079')
                strDate.value = "";
                strDate.focus();
                return false;
            }
            else
                flag = 1;

        }
    }
    if (flag = 1) {
        if (ctrlList.length == 2) {
            return IsMonth(ctrlList[0], ctrlList[1],Msg);
        }
        else {
            return true;
        }
    }
}
function IsDoubleCheck_Grid(CtrlN) {
    var validChars = '0123456789.';
    var Tempval = CtrlN.value;
    if (Tempval.split(".").length - 1 > 1) {
        CtrlN.value = "0.00";
        alertify.alert("Please Enter Numeric Values");
       
    }
    for (var i = 0; i < Tempval.length; i++) {
        if (validChars.indexOf(Tempval.charAt(i)) == -1) {
            CtrlN.value = "0.00";
            alertify.alert("Please Enter Numeric Values");
        }
    }

}
function IsConfirm(Msg,CtrlN) {
    if (confirm(Msg)) {
        document.forms[0].elements[ControlValid(CtrlN)].value = "Y";
    }
    else {
        document.forms[0].elements[ControlValid(CtrlN)].value = "N";
    }

}
function IsPrecentageCheck(CtrlN) {
    var validChars = '0123456789.%';
    var temp = document.forms[0].elements[ControlValid(CtrlN)];
    var Tempval = temp.value;
    if (Tempval.split(".").length - 1 > 1) {
        alertify.alert("Please Enter Numeric Values");
        temp.focus();
        temp.value = "";
        return false;
    }
    for (var i = 0; i < Tempval.length; i++) {
        if (validChars.indexOf(Tempval.charAt(i)) == -1) {
            alertify.alert("Please Enter Numeric Values");
            temp.focus();
            temp.value = "";
            return false;
        }
    }
    return true;
}
function Get_EmpCode(txtBox, txtBoxSrc) {
    //alertify.alert(txtBox);
    
    var txtPtn = GetTextBoxPosition(txtBox);
    var txt = this.opener.document.forms[0].elements[txtPtn];
    txt.value = txtBoxSrc;
    txt.focus();
    window.close();
    return false;
}


function GetTextBoxPosition(txtname) {

    for (var i = 0; i < this.opener.document.forms[0].elements.length; i++) {
        var temp = new Array();
        temp = this.opener.document.forms[0].elements[i].name.split('$');
        if (txtname == temp[temp.length - 1]) {
            return i;
            break;
        }
    }
}
function validateFloatKeyPress(el, evt) {

    var charCode = (evt.which) ? evt.which : event.keyCode;
    if (charCode != 46 && charCode > 31
        && (charCode < 48 || charCode > 57)) {
        alertify.alert('Accept only number!')
        return false;
    }

    if (charCode == 46 && el.value.indexOf(".") !== -1) {
        alertify.alert('Invalid Value!')
        return false;
    }

    return true;
}

function numerical() {
    var charcode = event.keyCode
    if (charcode > 31 && (charcode < 48 || charcode > 57)) {
        alertify.alert("Accept only number!");
        return false;
    }
    return true;
}
function validatePwd(ctrlName) {
    var invalid = " "; // Invalid character is a space
    var minLength = 6; // Minimum length
    var maxLength = 10;
    var lower = /[a-z]/g;
    var upper = /[A-Z]/g;
    var num = /[0-9]/g;
    var special = /[\W_]/g;
    var pw1 = ctrlName.value;

    if (pw1 == '') {
        return 0;
    }
    else if (pw1.indexOf(invalid) > -1) {
        return 0;
    }
    else if (!lower.test(ctrlName.value) || !upper.test(ctrlName.value) || !num.test(ctrlName.value) || !special.test(ctrlName.value)) {
        return 0;
    }
    else if (pw1.length < minLength && pw1.length > maxLength) {
        return 0;
    } else {
        return 1;
    }

}
