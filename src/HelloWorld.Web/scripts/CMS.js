// version: beta
// created: 2005-08-30
// updated: 2005-08-31
// mredkj.com
function extractNumber(obj, decimalPlaces, allowNegative) {
    var temp = obj.value;

    // avoid changing things if already formatted correctly
    var reg0Str = '[0-9]*';
    if (decimalPlaces > 0) {
        reg0Str += '\\.?[0-9]{0,' + decimalPlaces + '}';
    } else if (decimalPlaces < 0) {
        reg0Str += '\\.?[0-9]*';
    }
    reg0Str = allowNegative ? '^-?' + reg0Str : '^' + reg0Str;
    reg0Str = reg0Str + '$';
    var reg0 = new RegExp(reg0Str);
    if (reg0.test(temp)) return true;

    // first replace all non numbers
    var reg1Str = '[^0-9' + (decimalPlaces != 0 ? '.' : '') + (allowNegative ? '-' : '') + ']';
    var reg1 = new RegExp(reg1Str, 'g');
    temp = temp.replace(reg1, '');

    if (allowNegative) {
        // replace extra negative
        var hasNegative = temp.length > 0 && temp.charAt(0) == '-';
        var reg2 = /-/g;
        temp = temp.replace(reg2, '');
        if (hasNegative) temp = '-' + temp;
    }

    if (decimalPlaces != 0) {
        var reg3 = /\./g;
        var reg3Array = reg3.exec(temp);
        if (reg3Array != null) {
            // keep only first occurrence of .
            //  and the number of places specified by decimalPlaces or the entire string if decimalPlaces < 0
            var reg3Right = temp.substring(reg3Array.index + reg3Array[0].length);
            reg3Right = reg3Right.replace(reg3, '');
            reg3Right = decimalPlaces > 0 ? reg3Right.substring(0, decimalPlaces) : reg3Right;
            temp = temp.substring(0, reg3Array.index) + '.' + reg3Right;
        }
    }

    obj.value = temp;
}

function blockNonNumbers(obj, e, allowDecimal, allowNegative) {
    var key;
    var isCtrl = false;
    var keychar;
    var reg;

    if (window.event) {
        key = e.keyCode;
        isCtrl = window.event.ctrlKey
    }
    else if (e.which) {
        key = e.which;
        isCtrl = e.ctrlKey;
    }

    // check if Not-a-Number
    if (isNaN(key)) {
        return true;
    }

    keychar = String.fromCharCode(key);

    // check for backspace or delete, or if Ctrl was pressed
    if (key == 8 || isCtrl) {
        return true;
    }

    reg = /\d/;
    var isFirstN = allowNegative ? keychar == '-' && obj.value.indexOf('-') == -1 : false;
    var isFirstD = allowDecimal ? keychar == '.' && obj.value.indexOf('.') == -1 : false;

    return isFirstN || isFirstD || reg.test(keychar);
}

function round_decimals(original_number, decimals) {
    var result1 = original_number * Math.pow(10, decimals)
    var result2 = Math.round(result1)
    var result3 = result2 / Math.pow(10, decimals)
    return pad_with_zeros(result3, decimals)
}

function pad_with_zeros(rounded_value, decimal_places) {
    // Convert the number to a string
    var value_string = rounded_value.toString()
    // Locate the decimal point
    var decimal_location = value_string.indexOf(".")
    // Is there a decimal point?
    if (decimal_location == -1) {
        // If no, then all decimal places will be padded with 0s
        decimal_part_length = 0
        // If decimal_places is greater than zero, tack on a decimal point
        value_string += decimal_places > 0 ? "." : ""
    }
    else {

        // If yes, then only the extra decimal places will be padded with 0s
        decimal_part_length = value_string.length - decimal_location - 1
    }
    // Calculate the number of decimal places that need to be padded with 0s
    var pad_total = decimal_places - decimal_part_length
    if (pad_total > 0) {
        // Pad the string with 0s
        for (var counter = 1; counter <= pad_total; counter++)
            value_string += "0"
    }
    return value_string
}

function covertToNegative(obj) {
    // replace extra negative
    var temp = obj.value;

    var reg2 = /-/g;
    temp = temp.replace(reg2, '');
    temp = '-' + temp;

    obj.value = temp;
}

function covertToNegative(obj) {
    // replace extra negative
    var temp = obj.value;

    var reg2 = /-/g;
    temp = temp.replace(reg2, '');
    temp = '-' + temp;

    obj.value = temp;
}

function navKey(obj, event) {
    var x = event.keyCode;

    //navigation keys
    if (x >= 37 && x <= 40) {
        var inputId = obj.id;
        var elementId = inputId.substring(0, inputId.indexOf("_") + 1);
        var idx = parseInt(inputId.substring(inputId.indexOf("_") + 1));

        //left arrow key
        if (x == 37) {
            switch (elementId) {
                case 'insuranceRating_':
                    elementId = "insuranceProvider_";
                    break;
                case 'insuranceStart_':
                    elementId = "insuranceRating_";
                    break;
                case 'insuranceEnd_':
                    elementId = "insuranceStart_";
                    break;
                case 'insuranceComments_':
                    elementId = "insuranceEnd_";
                    break;
                default:
                    return;
            }
        }

        //up arrow key
        if (x == 38 && idx >= 0) {
            idx = idx - 1;
        }

        //right arrow key
        if (x == 39) {
            switch (elementId) {
                case 'insuranceProvider_':
                    elementId = "insuranceRating_";
                    break;
                case 'insuranceRating_':
                    elementId = "insuranceStart_";
                    break;
                case 'insuranceStart_':
                    elementId = "insuranceEnd_";
                    break;
                case 'insuranceEnd_':
                    elementId = "insuranceComments_";
                    break;
                default:
                    return;
            }
        }

        //down arrow key
        if (x == 40) {
            idx = idx + 1;
        }

        elementId = elementId + idx;
        var moveToElement = document.getElementById(elementId);

        if (moveToElement != undefined) {
            moveToElement.focus();
            window.setTimeout(function () {
                moveToElement.setSelectionRange(0, moveToElement.value.length);
            }, 0);
        }
    }
}

//does not work with compatibility view settings on
//function alphanumericOnly(event) {
//    var key = event.which;
//    return ((key >= 48 && key <= 57) || (key >= 65 && key <= 90) || (key >= 95 && key <= 122));
//}

function alphanumericOnly(obj) {
    obj.value = obj.value.replace(/[^a-zA-Z0-9]/g, '')
}