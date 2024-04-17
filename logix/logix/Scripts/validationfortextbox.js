
function isNumberKey(evt) {
    var charCode = (evt.which) ? evt.which : event.keyCode
    if (charCode > 31 && (charCode < 48 || charCode > 57) && charCode != 39) {
        alertify.alert("Numbers Only allowed");
        return false;
    }
    return true;
}


function ValidateAlpha(evt) {
    var keyCode = (evt.which) ? evt.which : evt.keyCode
    if ((keyCode < 65 || keyCode > 90) && (keyCode < 97 || keyCode > 123) && keyCode != 32) {
        alertify.alert("characters Only allowed");
        return false;
    }
    return true;
    //alertify.alert(" Only " + long + " characters allowed");
}

function CheckTextLength(text, long) {
    var maxlength = new Number(long); // Change number to your max length.
    if (text.value.length > maxlength) {
        text.value = text.value.substring(0, maxlength);
        alertify.alert(" Only " + long + " characters allowed");
    }
}

function ValidateEmail(objEmail) {
    var reg = /^[a-zA-Z0-9._-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,4}$/;
    if (!reg.test(objEmail.value)) {
        alertify.alert('Not a valid e-mail Address');
        return false;
    }
}


//*******************Guru*******************


function isAlplaNumeric(evt) {
    var charCode = (evt.which) ? evt.which : event.keyCode
    if (charCode > 31 && (charCode < 48 || charCode > 57) && charCode != 39)

        return true;
    alertify.alert("Alphabetic and symbols  only allowed");
    return false;
}