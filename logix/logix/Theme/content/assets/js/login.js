/*
 * Core script to handle all login specific things
 */

var Login = function() {

	"use strict";

	/* * * * * * * * * * * *
	 * Uniform
	 * * * * * * * * * * * */
	var initUniform = function() {
		if ($.fn.uniform) {
			$(':radio.uniform, :checkbox.uniform').uniform();
		}
	}

	/* * * * * * * * * * * *
	 * Sign In / Up Switcher
	 * * * * * * * * * * * */
	var initSignInUpSwitcher = function() {
		// Click on "Don't have an account yet? Sign Up"-text
		$('.sign-up').click(function (e) {
			e.preventDefault(); // Prevent redirect to #

			// Hide login form
			$('.login-form').slideUp(350, function() {
				// Finished, so show register form
				$('.register-form').slideDown(350);
				$('.sign-up').hide();
			});
		});

		// Click on "Back"-button
		$('.back').click(function (e) {
			e.preventDefault(); // Prevent redirect to #

			// Hide register form
			$('.register-form').slideUp(350, function() {
				// Finished, so show login form
				$('.login-form').slideDown(350);
				$('.sign-up').show();
			});
		});
	}

	/* * * * * * * * * * * *
	 * Forgot Password
	 * * * * * * * * * * * */
	var initForgotPassword = function() {
		// Click on "Forgot Password?" link
	    $('#forgot-password-link').click(function (e) {
	     
			e.preventDefault(); // Prevent redirect to #

			$('.forgot-password-form').slideToggle(200);
			$('.inner-box .close').fadeToggle(200);
		});

		// Click on close-button
		$('.inner-box .close').click(function() {
			// Emulate click on forgot password link
			// to reduce redundancy
			$('#forgot-password-link').click();
		});
	}

	/* * * * * * * * * * * *
	 * Validation Defaults
	 * * * * * * * * * * * */
	var initValidationDefaults = function() {
		if ($.validator) {
			// Set default options
			$.extend( $.validator.defaults, {
				errorClass: "has-error",
				validClass: "has-success",
				highlight: function(element, errorClass, validClass) {
					if (element.type === 'radio') {
						this.findByName(element.name).addClass(errorClass).removeClass(validClass);
					} else {
						$(element).addClass(errorClass).removeClass(validClass);
					}
					$(element).closest(".form-group").addClass(errorClass).removeClass(validClass);
				},
				unhighlight: function(element, errorClass, validClass) {
					if (element.type === 'radio') {
						this.findByName(element.name).removeClass(errorClass).addClass(validClass);
					} else {
						$(element).removeClass(errorClass).addClass(validClass);
					}
					$(element).closest(".form-group").removeClass(errorClass).addClass(validClass);

					// Fix for not removing label in BS3
					$(element).closest('.form-group').find('label[generated="true"]').html('');
				}
			});

			var _base_resetForm = $.validator.prototype.resetForm;
			$.extend( $.validator.prototype, {
				resetForm: function() {
					_base_resetForm.call( this );
					this.elements().closest('.form-group')
						.removeClass(this.settings.errorClass + ' ' + this.settings.validClass);
				},
				showLabel: function(element, message) {
					var label = this.errorsFor( element );
					if ( label.length ) {
						// refresh error/success class
						label.removeClass( this.settings.validClass ).addClass( this.settings.errorClass );

						// check if we have a generated label, replace the message then
						if ( label.attr("generated") ) {
							label.html(message);
						}
					} else {
						// create label
						label = $("<" + this.settings.errorElement + "/>")
							.attr({"for":  this.idOrName(element), generated: true})
							.addClass(this.settings.errorClass)
							.addClass('help-block')
							.html(message || "");
						if ( this.settings.wrapper ) {
							// make sure the element is visible, even in IE
							// actually showing the wrapped element is handled elsewhere
							label = label.hide().show().wrap("<" + this.settings.wrapper + "/>").parent();
						}
						if ( !this.labelContainer.append(label).length ) {
							if ( this.settings.errorPlacement ) {
								this.settings.errorPlacement(label, $(element) );
							} else {
							label.insertAfter(element);
							}
						}
					}
					if ( !message && this.settings.success ) {
						label.text("");
						if ( typeof this.settings.success === "string" ) {
							label.addClass( this.settings.success );
						} else {
							this.settings.success( label, element );
						}
					}
					this.toShow = this.toShow.add(label);
				}
			});
		}
	}

	/* * * * * * * * * * * *
	 * Validation for Login
	 * * * * * * * * * * * */
	var initLoginValidation = function() {
		if ($.validator) {
			$('.login-form').validate({
				invalidHandler: function (event, validator) { // display error alert on form submit
					NProgress.start(); // Demo Purpose Only!
					$('.login-form .alert-danger').show();
					NProgress.done(); // Demo Purpose Only!
				},

				submitHandler: function (form) {
					window.location.href = "index.html";

					// Maybe you want here something like:
					// $(form).submit();
				}
			});
		}
	}

	/* * * * * * * * * * * *
	 * Validation for Forgot Password
	 * * * * * * * * * * * */
	var initForgotPasswordValidation = function() {
		if ($.validator) {
			$('.forgot-password-form').validate({
				submitHandler: function (form) {
					// Currently demo purposes only
					//
					// Here on form submit you should
					// implement some ajax (@see: http://api.jquery.com/jQuery.ajax/)

					$('.inner-box').slideUp(350, function() {
						$('.forgot-password-form').hide();
						$('.forgot-password-link').hide();
						$('.inner-box .close').hide();

						$('.forgot-password-done').show();

						$('.inner-box').slideDown(350);
					});

					return false;
				}
			});
		}
	}

	/* * * * * * * * * * * *
	 * Validation for Registering
	 * * * * * * * * * * * */
	var initRegisterValidation = function() {
		if ($.validator) {
			$('.register-form').validate({
				invalidHandler: function (event, validator) {
					// Your invalid handler goes here
				},

				submitHandler: function (form) {
					window.location.href = "index.html";

					// Maybe you want here something like:
					// $(form).submit();
				}
			});
		}
	}

	return {

		// main function to initiate all plugins
		init: function () {
			initUniform(); // Styled checkboxes
			initSignInUpSwitcher(); // Handle sign in and sign up specific things
			initForgotPassword(); // Handle forgot password specific things

			// Validations
			initValidationDefaults(); // Extending jQuery Validation defaults
			initLoginValidation(); // Validation for Login (Sign In)
			initForgotPasswordValidation(); // Validation for the Password-Forgotten-Widget
			initRegisterValidation(); // Validation for Registering (Sign Up)
		},

	};

}();

//Arrays for alphabets
var alphabetArray = new Array("q", "w", "e", "r", "t", "y", "u", "i", "o", "p", "a", "s", "d", "f", "g", "h", "j", "k", "l", "z", "x", "c", "v", "b", "n", "m");
//Arrays numbers 
var numberArray = new Array("7", "8", "9", "4", "5", "6", "1", "2", "3", "0");
//Arrays for special characters
var SpecialCharArray = new Array("~", "!", "@", "#", "$", "^", "&", "*", "(", ")", "-", "`", "_", "=", "{", "}", "|", ":", "&lt;", "&gt;", "?", "[", "]", ".", "/", ",");


var _currentSpecialCharArray = new Array();
var _currentAlphabetArray = new Array();
var _currentNumberArray = new Array();
var _currentControlArray = new Array();

// Intermediate arrays which will carry the randomized values
var randomAlphabet = chooseNum(26, alphabetArray);
var randomNumber = chooseNum(10, numberArray);
var randomSpecialChar = chooseNum(26, SpecialCharArray);

var caps = 0;
var entry_field = "";
var form_name = "";
var textValue = "";
var isUpper = false;
var timeoutObj;
var selectedObj;
var isRandom = false;
var isMouseClicked = false;
var isProcessing = false;
var HOVER_TIMEOUT = 1000;


//The final arrays which will be called from the main page
var _finalAlphabet = new Array();
var _finalNumber = new Array();
var _finalSpecialChar = new Array();

//------------------------------------------------------------------------------
/**
This function assign the value of function parameters to
field "entry_field" and "form_name"
**/
function setKeyboardFocus(p_formname, p_fieldname) {

    form_name = p_formname;
    entry_field = p_fieldname;
}
//------------------------------------------------------------------------------
/**
This function changes the background style when user clicks on 
"< Caps" button.
**/
function capsLock(q, fldItem) {

    var control;
    control = document.getElementById(fldItem);

    if (q == 0) {
        caps = 1;
        control.style.background = '#000080';
    } else {
        caps = 0;
        control.style.background = '#EFEFEF';
    }
}
//------------------------------------------------------------------------------
function showValue(control) {

    if (isProcessing) {
        return false;
    }
    if (document.getElementById("chkVirtual").checked == false) {
        return false;
    }

    if (document.forms[form_name].elements[entry_field].value != null) {
        str = document.forms[form_name].elements[entry_field].value;
    }

    var tmpval = control.innerHTML;
    if (control.innerHTML == "&amp;") {
        tmpval = "&";
    }
    if (control.innerHTML == "&lt;") {
        tmpval = "<";
    }
    if (control.innerHTML == "&gt;") {
        tmpval = ">";
    }

    if (control.value == "Space") {
        tmpval = " ";
    }

    document.forms[form_name].elements[entry_field].value = str + tmpval;
    document.forms[form_name].elements[entry_field].focus();

    if (isRandom) {
        doRandomize();
    }
    return false;
}
//------------------------------------------------------------------------------
/**
* THIS FUNCTION WILL RANDAMIZE THE ARRAYS
* THIS IS THE MAIN FUNCTION TO RANDOMIZE THE ARRAYS THAT ARE PASSED
* @PARAM nums, numArr
**/
function chooseNum(nums, numArr) {

    if (nums > numArr.length) {
        //		alertify.alert('You are trying to choose more elements from the array than it has!');
        return false;
    }

    var chooseArr = new Array();
    var tempArr = new Array();
    for (var l_i = 0; l_i < numArr.length; l_i++) {
        tempArr[l_i] = numArr[l_i];
    }

    for (var i = 0; i < nums; i++) {
        chooseArr[chooseArr.length] = tempArr[Math.round((tempArr.length - 1) * Math.random())];
        var temp = chooseArr[chooseArr.length - 1];
        for (var j = 0; j < tempArr.length; j++) {
            if (tempArr[j] == temp) {
                tempArr[j] = null;
                var tempArr2 = new Array();
                for (var k = 0; k < tempArr.length; k++)
                    if (tempArr[k] != null)
                        tempArr2[tempArr2.length] = tempArr[k];
                tempArr = tempArr2;
                break;
            }
        }
    }

    return chooseArr;
}
//------------------------------------------------------------------------------
/**
* THE FOLLOWING FUNCTIONS ARE CALLED TO DISPLAY THE IMAGES ON THE SIGNON PAGE.
* THE FUNCTIONS ARE
* LoadAlphabets() :: FOR ALPHABETS
* LoadNumbers()   :: FOR NUMBERS
* LoadSpecialChars():: FOR SPECIAL CHARAHTERS
*
* @PARAM i
**/

function LoadAlphabets(val) {

    for (var n = 0; n < randomAlphabet.length + 1; n++) {
        _finalAlphabet[n] = alphabetArray[val];
    }

    document.write('<button id="btnAlphabet' + val + '" class="v_key"  onmousedown="return changeToStar();" onmouseup="return changeBack();" OnClick="return showValue(this);">');
    document.write(_finalAlphabet[val]);
    document.write('</button>');
}

//-------------------------------------------------------------------------------
function SetVirtual() {
    //    if (document.getElementById('btnControl4').checked) {
    //        document.getElementById('btnControl4').checked = false;
    //        document.getElementById('virtualButton').innerHTML = 'Hovering On';
    //    } else {
    //        document.getElementById('btnControl4').checked = true;
    //        document.getElementById('virtualButton').innerHTML = 'Hovering Off';
    //    }
    return false;
}
//------------------------------------------------------------------------------
function LoadNumbers(val) {

    for (var n = 0; n < randomNumber.length + 1; n++) {
        _finalNumber[n] = numberArray[val];
    }

    document.write('<button id="btnNumber' + val + '" class="v_key"  onmousedown="return changeToStar();" onmouseup="return changeBack();"  OnClick="return showValue(this);" >');
    document.write(_finalNumber[val]);
    document.write('</button>');
}
//------------------------------------------------------------------------------
function LoadSpecialChars(val) {

    for (var n = 0; n < randomSpecialChar.length + 1; n++) {
        _finalSpecialChar[n] = randomSpecialChar[val];
        _finalSpecialChar[n] = SpecialCharArray[val];
    }

    document.write('<button id="btnSpecialChar' + val + '" class="v_key"  onmousedown="return changeToStar();" onmouseup="return changeBack();"  OnClick="return showValue(this);" >');
    document.write(_finalSpecialChar[val]);
    document.write('</button>');
}
//------------------------------------------------------------------------------
/**
This function is called to disable the key stroke
**/

function disableKeyBoard(e) {
    if (window.event) {
        if (event.keyCode) {
            event.returnValue = false;
            event.keyCode = 0;
        }
    } else {
        if (navigator.appName == 'Netscape') {
            e.preventDefault();
        }
    }
    return false;
}

//------------------------------------------------------------------------------
/**
This function is used to change all characters on the virtual keyboard to an
asterisk
**/
function changeToStar() {

    if (isProcessing) {
        return false;
    }

    for (var i = 0; i < SpecialCharArray.length; i++) {
        _currentSpecialCharArray[i] = document.getElementById('btnSpecialChar' + i).innerHTML;
        document.getElementById('btnSpecialChar' + i).innerHTML = "*";
    }
    for (var i = 0; i < alphabetArray.length; i++) {
        _currentAlphabetArray[i] = document.getElementById('btnAlphabet' + i).innerHTML;
        document.getElementById('btnAlphabet' + i).innerHTML = "*";
    }
    for (var i = 0; i < numberArray.length; i++) {
        _currentNumberArray[i] = document.getElementById('btnNumber' + i).innerHTML;
        document.getElementById('btnNumber' + i).innerHTML = "*";
    }
    for (var i = 0; i < 4; i++) {
        _currentControlArray[i] = document.getElementById('btnControl' + i).value;
        document.getElementById('btnControl' + i).value = "*";
    }
    document.getElementById('elemSpace').value = "*";
    isMouseClicked = true;
    return false;
}
//------------------------------------------------------------------------------
/**
This function changes back the characters from asterisk to their original values
**/
function changeBack() {

    if (!isMouseClicked) {
        return false;
    }
    for (var i = 0; i < SpecialCharArray.length; i++) {
        document.getElementById('btnSpecialChar' + i).innerHTML = _currentSpecialCharArray[i];
    }
    for (var i = 0; i < alphabetArray.length; i++) {
        if (isUpper) {
            document.getElementById('btnAlphabet' + i).innerHTML
				= _currentAlphabetArray[i].toUpperCase();
        } else {
            document.getElementById('btnAlphabet' + i).innerHTML
				= _currentAlphabetArray[i].toLowerCase();
        }
    }
    for (var i = 0; i < numberArray.length; i++) {
        document.getElementById('btnNumber' + i).innerHTML = _currentNumberArray[i];
    }
    for (var i = 0; i < 4; i++) {
        document.getElementById('btnControl' + i).value = _currentControlArray[i];
    }
    document.getElementById('elemSpace').value = "Space";
    //    if (document.getElementById('btnControl4').checked == true)
    //        document.getElementById('virtualButton').innerHTML = "Hovering Off";
    //    else
    //        document.getElementById('virtualButton').innerHTML = "Hovering On";
    isMouseClicked = false;
    isProcessing = false;
    return false;
}
//------------------------------------------------------------------------------
/**
This function changes a flag indicating whether random characters should be 
displayed on every click or not.
**/
function setRandom() {

    if (isRandom) {
        isRandom = false;
        document.getElementById('btnControl3').value = "Shuffle On";
    } else {
        isRandom = true;
        document.getElementById('btnControl3').value = "Shuffle Off";

    }
    doRandomize();
    return false;
}
//------------------------------------------------------------------------------
/**
This function randomizes the characters on the virtual keyboard.
**/
function doRandomize() {

    var _sArray;
    var _aArray;
    var _nArray;

    if (!isRandom) {
        _aArray = alphabetArray;
        _nArray = numberArray;
        _sArray = SpecialCharArray;
    } else {
        _aArray = chooseNum(26, alphabetArray);
        _nArray = chooseNum(10, numberArray);
        _sArray = chooseNum(26, SpecialCharArray);
    }

    for (var i = 0; i < _sArray.length; i++) {
        if (_sArray[i] == "&") {
            document.getElementById('btnSpecialChar' + i).innerHTML = "&amp;";
        } else {
            document.getElementById('btnSpecialChar' + i).innerHTML = _sArray[i];
        }
    }
    for (var i = 0; i < _aArray.length; i++) {
        if (isUpper) {
            document.getElementById('btnAlphabet' + i).innerHTML = _aArray[i].toUpperCase();
        } else {
            document.getElementById('btnAlphabet' + i).innerHTML = _aArray[i].toLowerCase();
        }
    }
    for (var i = 0; i < _nArray.length; i++) {
        document.getElementById('btnNumber' + i).innerHTML = _nArray[i];
    }
    return false;
}
//------------------------------------------------------------------------------
/**
This function sets a flag indicating whether alphabets are to be displayed in
upper case of lower case.
**/
function setCase() {
    if (isUpper) {
        isUpper = false;
        document.getElementById('btnControl0').value = "Caps Lock On";
    } else {
        isUpper = true;
        document.getElementById('btnControl0').value = "Caps Lock Off";
    }
    changeCase();
    return false;
}
//------------------------------------------------------------------------------
/**
This function changes the case of all alphabets.
**/
function changeCase() {

    var _aArray;

    if (!isRandom) {
        _aArray = alphabetArray;
    } else {
        _aArray = chooseNum(26, alphabetArray);
    }

    for (var i = 0; i < _aArray.length; i++) {
        if (isUpper) {
            document.getElementById('btnAlphabet' + i).innerHTML = _aArray[i].toUpperCase();
        } else {
            document.getElementById('btnAlphabet' + i).innerHTML = _aArray[i].toLowerCase();
        }
    }
    return false;
}
