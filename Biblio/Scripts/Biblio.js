$("#Send").attr("disabled", true);

//$("#RawInput").jqte({ change: function () { window.setTimeout(function () { process(unescape($("#RawInput").val())); }, 500); } });

$("#RawInput").keyup(function ()
{
    //process($("#RawInput").val());
    window.setTimeout(function () { process(unescape($("#RawInput").val())); }, 500);
});

function isPalindrome(str)
{
    return str == str.split('').reverse().join('');
}

function vowelCount(str)
{
    return str.replace(/[^aeiou]/gi, "").length;
}

function consonantCount(str)
{
    return str.replace(/[^bcdfghjklmnpqrstvwxyz]/gi, "").length;
}

function specialCharacterCount(str)
{
    return str.replace(/[abcdefghijklmnopqrstuvwxyz1234567890\s, ]/gi, "").length;
}

function process(txt)
{

    // lots of assumptions here, obviously this could be refined :
    // a single letter can be a word and a palindrome
    // words can contain special characters
    // numbers are not special characters
    // words have spaces or commas between them, or start a newline

    try
    {
     
        var splitPattern = /[\s, ]+/;

        var splitTxt = [];

        var uniqueHash = {}, duplicateHash = {}, palindromeHash = {}, word, duplicateArray = [], palindromeArray = [];

        if (txt != "") {

            // if we have something to process

            splitTxt = txt.trim().split(splitPattern);

            // determine if we have a palindrome, unique or a duplicate word

            for (var i = 0; i < splitTxt.length; i++) {
                word = splitTxt[i];

                if (isPalindrome(word))
                    palindromeHash[word] = true;

                if (uniqueHash[word]) {
                    duplicateHash[word] = true;
                } else {
                    uniqueHash[word] = true;
                }
            }

            // turn hash's into arrays

            for (var key in duplicateHash) {
                duplicateArray.push(key);
            }

            for (var key in palindromeHash) {
                palindromeArray.push(key);
            }

            $("#Send").attr("disabled",false);
        }
        else
        {
            $("#Send").attr("disabled", true);
        }

        // display values within read only textareas / textboxes, ready to post over to mvc controller

        $("#WordCount").val(splitTxt.length);

        $("#VowelCount").val(vowelCount(txt));

        $("#ConsonantCount").val(consonantCount(txt));

        $("#SpecialCharacterCount").val(specialCharacterCount(txt));

        $("#Duplicate").val(duplicateArray.toString().replace(/,/g, "\n"));

        $("#Palindrome").val(palindromeArray.toString().replace(/,/g, "\n"));

    }
    catch (err)
    {
        showModal(err.message);
    } 

}

function showModal(err)
{
    var options =
    {
        "backdrop": "static"
    };

    $("#modalBody").html(err);
    $('#basicModal').modal(options);

}