var stat = 0;
var objAuth = "";
var authCode = "";
var scope = "<dogscope/>\n";
var dogNotPresent = false;
//Callback function, if the dog has been removed the function will be called.


function removeDog() {
    $('.login_panel').hide();
    $('.stroke').fadeIn(200);
}

//Callback function, if the dog still exists the function will be called.
function insertDog() {
    $('.stroke').hide();
    $('.login_panel').fadeIn(200);
    $('.login_panel input').focus();
}

function checkDog() {
    var authCode = "";
    var scope = "<dogscope/>\n";

    //Get Auth Code
    authCode = getAuthCode();

    //Get object
    objAuth = getAuthObject();

    //Open
    stat = objAuth.Open(scope, authCode);
    document.getElementById("hiddenstatus").value = stat;
    if (0 != stat) {
        dogNotPresent = true;
        reportStatus(stat);
    }
    else {
        if (dogNotPresent == true) {
            dogNotPresent = false;
            window.location.href = "/account/login";
        }
    }

    //Execute the check again after 2 seconds
    setTimeout(checkDog, 2000);
}

//Load callback functions, insertDog() and removeDog()
function loadFunc() {
    var objAuth;

    //Get object
    objAuth = getAuthObject();

    if (navigator.userAgent.indexOf("Window") > 0) {
        if (window.ActiveXObject || "ActiveXObject" in window)  //IE
        {
            objAuth.SetCheckDogCallBack("insertDog", "removeDog");
        }
        else {
            try {
                objAuth.SetCheckDogCallBack("insertDog", "removeDog");
                objAuth.InsertFunc = insertDog;
                objAuth.RemoveFunc = removeDog;
            }
            catch (e) {
                objAuth.InsertFunc = insertDog;
                objAuth.RemoveFunc = removeDog;
            }
        }
    }
    else if (navigator.userAgent.indexOf("Mac") > 0) {
        setTimeout(checkDog, 1000);
    }
    else if (navigator.userAgent.indexOf("Linux") > 0) {
        setTimeout(checkDog, 1000);
    }
    else {
        ;
    }
}


function login() {
    var password = $("#password").val();
    $.post('/account/login', { UserName: objAuth.UserNameStr, Password: password }, function (e) {
        if (e.success) {
            $('#loginFlag').show();
            location.href = '/account/roles';
        }
        else {
            $('#loginFlag').hide();
            alert('您的密码有误，请重新输入。');
            $('#password')
                .removeAttr("disabled")
                .val('')
                .focus();
        }
    });
}
try {

    embedTag();
    //Get object
    objAuth = getAuthObject();
    //Get Auth Code
    authCode = getAuthCode();
    // Open the dog

    document.getElementById("hiddenstatus").value = stat;

    if (objAuth.Open(scope, authCode) == 0)
        insertDog();
    // Get username from the dog

    if (objAuth.GetUserName() == 0) {
        $("#adminName").text(objAuth.UserNameStr);
    }

    $('#password').keydown(function (e) {
        if (e.keyCode == 13) {
            $(this).attr("disabled", "disabled");
            login();
        }
    })

    objAuth.Close();
}
catch (e) {
    ;
}