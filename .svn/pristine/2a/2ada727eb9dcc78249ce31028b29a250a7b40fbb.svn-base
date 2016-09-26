
/**********************************************************************************************
Function: validateRegForm
Parameters: none
Return: true or false
Description: Validate the form for emptiness.
***********************************************************************************************/
function validateRegForm() {
    var regForm = window.document.forms["RegFrm"];
    var name = document.getElementById("txtUserName").value;
    var pwd = document.getElementById("UserPwd").value;
    var rPwd = document.getElementById("RepPwd").value;
    if (isEmpty(name)) {
        //alert("Please enter your Username!");
        reportStatus(901);
        return false;
    }
    else {
        if (name.length < 1 || name.length > 32) {
            //alert ("Username length should be between 1-32 characters");
            reportStatus(902);
            return false;
        }
        if (!isLegalCharacters(name)) {
            //alert ("Username is illegal");
            reportStatus(903);
            return false;
        }
    }
    if (isEmpty(pwd)) {
        //alert("Please enter your password!");
        reportStatus(904);
        return false;
    }
    else {
        if (pwd.length < 6 || pwd.length > 16) {
            //alert ("Password's length should be between 6-16 characters");
            reportStatus(905);
            return false;
        }
        if (!isLegalCharacters(pwd)) {
            //alert ("Password is illegal");
            reportStatus(906);
            return false;
        }

    }
    if (isEmpty(rPwd)) {
        //alert("Please enter your confirm password!");
        reportStatus(908);
        return false;
    }
    else {
        if (rPwd.length < 6 || rPwd.length > 16) {
            //alert ("Confirm password's length should be between 6-16 characters");
            reportStatus(909);
            return false;
        }
        if (!isLegalCharacters(rPwd)) {
            //alert ("Password is illegal");
            reportStatus(910);
            return false;
        }
    }
    if (pwd != rPwd) {
        //alert("Passwords do not match.");
        reportStatus(911);
        document.getElementById("UserPwd").value = "";
        regForm.RepPwd.focus();
        return false;
    }

    return true;
}

/**********************************************************************************************
Function: validateChangeForm
Parameters: none
Return: true or false
Description: Validate the form for emptiness.
***********************************************************************************************/
function validateChangeForm() {
    var cForm = window.document.forms['ChangePinForm'];
    var oP = cForm.oldPwd.value;
    var nP = cForm.newPwd.value;
    var rP = cForm.retypePwd.value;

    if (isEmpty(oP)) {
        //alert("Please enter your current password!");
        reportStatus(912);
        return false;
    }
    else {
        if (oP.length < 6 || oP.length > 16) {
            //alert ("Password's length should be between 6-16 characters");
            reportStatus(905);
            return false;
        }
        if (!isLegalCharacters(oP)) {
            //alert ("Password is illegal");
            reportStatus(906);
            return false;
        }
    }
    if (isEmpty(nP)) {
        //alert("Please enter your new password!");
        reportStatus(914);
        return false;
    }
    else {
        if (nP.length < 6 || nP.length > 16) {
            //alert ("Password's length should be between 6-16 characters");
            reportStatus(905);
            return false;
        }
        if (!isLegalCharacters(nP)) {
            //alert ("Password is illegal");
            reportStatus(906);
            return false;
        }
    }
    if (isEmpty(rP)) {
        //alert("Please enter your new password!");
        reportStatus(914);
        return false;
    }
    else {
        if (rP.length < 6 || rP.length > 16) {
            //alert ("Password's length should be between 6-16 characters");
            reportStatus(905);
            return false;
        }
        if (!isLegalCharacters(rP)) {
            //alert ("Password is illegal");
            reportStatus(906);
            return false;
        }
    }
    if (nP != rP) {
        //alert("Passwords do not match.");
        reportStatus(911);
        cForm.newPwd.value = "";
        cForm.retypePwd.value = "";
        cForm.newPwd.focus();
        return false;
    }

    return true;
}

/**********************************************************************************************
Function: isLegalCharacters
Parameters: string
Return: true or false
Description: Judge the string whether it is legal.
***********************************************************************************************/
function isLegalCharacters(s) {
    var str;
    str = new String(s);
    var len;
    len = str.length;
    var i;

    for (i = 0; i < len; ++i) {  //if(!((str.charAt(i) >= '0' && str.charAt(i) <= '9')))
        if (!((str.charAt(i) >= '!' && str.charAt(i) <= '~'))) {
            return false;
        }
    }
    return true;
}

function isEmpty(strValue) {
    var mySting = new String(strValue);
    var len = mySting.length;
    if ("" == mySting) {
        return true;
    }
    for (var i = 0; i < len; ++i) {
        if (mySting.charAt(i) != " ") {
            return false;
        }
    }
    return true;
}

/**********************************************************************************************
Function: getChallenge
Parameters: none
Return: challenge
Description: Send XMLHttpRequest get challenge.
***********************************************************************************************/
function getChallenge() {
    var challenge = sendRequest("/api/superdog/getChallenge");
    return "" + challenge + "";
}

/**********************************************************************************************
Function: getVendorID
Parameters: none
Return: VendorID
Description: Send XMLHttpRequest get VendorID.
***********************************************************************************************/
function getVendorID() {

    var vendorID = sendRequest("/api/superdog/getVendorID");
    return "" + vendorID + "";
}

/**********************************************************************************************
Function: getAuthCode
Parameters: none
Return: authCode
Description: Send XMLHttpRequest get authCode.
***********************************************************************************************/
function getAuthCode() {

    var authCode = sendRequest("/api/superdog/getAuthCode");
    return ("" + authCode + "").replace(/\"/ig, "");
}

/**********************************************************************************************
Function: getFactor
Parameters: none
Return: factor
Description: Send XMLHttpRequest get Factor.
***********************************************************************************************/
function getFactor() {

    var factor = sendRequest("/api/superdog/getFactor");
    return ("" + factor + "").replace(/\"/ig, "");
}

function loadXMLDoc(file) {
    var xmlDoc = null;
    try //Internet Explorer
    {
        xmlDoc = new ActiveXObject("Microsoft.XMLDOM");
        xmlDoc.async = false;
        xmlDoc.load(file);
    }
    catch (e) {
        try //Firefox, Mozilla, Opera, etc.
        {
            xmlDoc = document.implementation.createDocument("", "", null);
            xmlDoc.async = false;
            xmlDoc.load(file);
        }
        catch (e) {
            try //Google Chrome
            {
                var xmlhttp = new window.XMLHttpRequest();
                xmlhttp.open("GET", file, false);
                xmlhttp.send(null);
                xmlDoc = xmlhttp.responseXML.documentElement;
            }
            catch (e) {
                //error = e.message;
                xmlDoc = null;
            }
        }
    }
    return xmlDoc;
}

/**********************************************************************************************
Function: doAuth
Parameters: dogID, result
Return: factor
Description: Send XMLHttpRequest do authenticate.
***********************************************************************************************/
function doAuth(vendorID, dogid, challenge, digest, factor) {
    var ret = sendRequest("/api/superdog/Authentication/" + vendorID + "," + dogid + "," + challenge + "," + digest + "," + factor + "");
    return ret;
}

/**********************************************************************************************
Function: createRequest
Parameters: none
Return: challenge
Description: Send XMLHttpRequest get challenge.
***********************************************************************************************/
function sendRequest(url) {
    var httpRequest = false;

    if (window.XMLHttpRequest) {
        httpRequest = new XMLHttpRequest();
    }
    else {
        // IE
        try {
            httpRequest = new ActiveXObject("Msxm12.XMLHTTP");
        }
        catch (e) {
            try {
                httpRequest = new ActiveXObject("Microsoft.XMLHTTP");
            }
            catch (e) {
            }
        }
    }

    if (!httpRequest) {
        alert("Can't create XMLHttpRequest object");
        return false;
    }
    httpRequest.open('POST', url, false);
    httpRequest.send(null);
    return httpRequest.responseText;
    //var reg = /[^\[][^\]]*[^\]]/;
    //var newxmlText = reg.exec(xmlText); 
}

function getAuthObject() {
    var objAuth = "";
    if (window.ActiveXObject || "ActiveXObject" in window) //IE
    {
        objAuth = document.getElementById("AuthIE");
    }
    else {
        objAuth = document.getElementById("AuthNoIE");
    }
    return objAuth;
}

function embedTag() {
    if (window.ActiveXObject || "ActiveXObject" in window) //IE
    {
        ;
    }
    else {
        var temp = document.body.innerHTML;
        var tag = "<embed id=\"AuthNoIE\" type=\"application/x-dogauth\" width=0 height=0 hidden=\"true\"></embed>";
        document.body.innerHTML = tag + temp;
    }
}

/**********************************************************************************************
Function: clearInfo
Parameters: none
Return: none
Description: Clear the error info displayed in page.
***********************************************************************************************/
function clearInfo() {
    document.getElementById("errorinfo").innerHTML = "";
}

/**********************************************************************************************
Function: reportStatus
Parameters: status
Return: Description
Description: Report status's description.
***********************************************************************************************/
function reportStatus(status) {
    var text = "未知的状态码";
    switch (status) {
        case 0: text = "成功";
            break;
        case 1: text = "请求超过数据文件范围";
            break;
        case 3: text = "系统内存不足";
            break;
        case 4: text = "太多的开放的登录会话";
            break;
        case 5: text = "拒绝访问";
            break;
        case 7: text = "需要超级狗没有找到";
            break;
        case 8: text = "加密/解密数据长度太短了";
            break;
        case 9: text = "无效输入处理";
            break;
        case 10: text = "指定文件ID不认可API";
            break;
        case 15: text = "无效的XML格式";
            break;
        case 18: text = "超级狗没有找到更新";
            break;
        case 19: text = "无效的更新数据";
            break;
        case 20: text = "更新不支持超级狗";
            break;
        case 21: text = "更新计数器设置不正确";
            break;
        case 22: text = "无效的供应商代码";
            break;
        case 24: text = "通过时间价值不在支持范围值";
            break;
        case 26: text = "承认数据要求的更新,然而ack数据输入参数是NULL";
            break;
        case 27: text = "程序运行在终端服务器";
            break;
        case 29: text = "未知的算法用于V2C文件";
            break;
        case 30: text = "签名验证失败";
            break;
        case 31: text = "请求的功能不可用";
            break;
        case 33: text = "API和本地狗的许可证管理器之间的通信错误";
            break;
        case 34: text = "供应商代码没有被API识别";
            break;
        case 35: text = "无效的XML规范";
            break;
        case 36: text = "无效的XML范围";
            break;
        case 37: text = "太多的超级狗当前连接";
            break;
        case 39: text = "会话被打断";
            break;
        case 41: text = "功能已经过期";
            break;
        case 42: text = "超级狗许可证管理器版本太老";
            break;
        case 43: text = "超级狗的USB通信时发生错误";
            break;
        case 45: text = "系统时间被篡改";
            break;
        case 46: text = "通信错误发生在安全通道";
            break;
        case 50: text = "无法找到一个特性匹配的范围";
            break;
        case 54: text = "文件中更新计数器的值低于超级狗";
            break;
        case 55: text = "文件中的第一个值的更新计数器大于超级狗中的值";
            break;
        case 400: text = "无法定位动态库的API";
            break;
        case 401: text = "动态库API是无效的";
            break;
        case 500: text = "对象初始化错误";
            break;
        case 501: text = "无效的函数参数";
            break;
        case 502: text = "登录两次相同的对象";
            break;
        case 503: text = "日志记录了两次相同的对象";
            break;
        case 525: text = "不正确的使用系统或平台";
            break;
        case 698: text = "要求功能没有实现";
            break;
        case 699: text = "内部错误发生在API";
            break;
        case 700: text = "密码的长度应该是6-16字符之间";
            break;
        case 703: text = "验证密码失败";
            break;
        case 704: text = "用户的密码长度应6-16字符之间";
            break;
        case 705: text = "修改用户密码失败";
            break;
        case 802: text = "参数错误";
            break;
        case 803: text = "验证密码失败";
            break;
        case 804: text = "修改密码失败";
            break;
        case 810: text = "密码的长度是错误的";
            break;
        case 811: text = "名字的长度是错误的";
            break;
        case 812: text = "信息的长度是错误的";
            break;
        case 813: text = "名字的长度是错误的";
            break;
        case 814: text = "参数错误";
            break;
        case 820: text = "硬件内部错误!";
            break;
        case 821: text = "参数错误";
            break;
        case 822: text = "需要验证密码";
            break;
        case 823: text = "验证密码失败";
            break;
        case 824: text = "需要初始化";
            break;
        case 825: text = "密码被锁定";
            break;
        case 831: text = "验证密码失败,你还有14的机会";
            break;
        case 832: text = "验证密码失败,你还有13的机会";
            break;
        case 833: text = "验证密码失败,你还有12的机会";
            break;
        case 834: text = "验证密码失败,你还有11的机会";
            break;
        case 835: text = "验证密码失败,你还有10的机会";
            break;
        case 836: text = "验证密码失败,你还有9的机会";
            break;
        case 837: text = "验证密码失败,你还有8的机会";
            break;
        case 838: text = "验证密码失败,你还有7的机会";
            break;
        case 839: text = "验证密码失败,你还有6的机会";
            break;
        case 840: text = "验证密码失败,你还有5的机会";
            break;
        case 841: text = "验证密码失败,你还有4的机会";
            break;
        case 842: text = "验证密码失败,你还有3的机会";
            break;
        case 843: text = "验证密码失败,你还有2的机会";
            break;
        case 844: text = "验证密码失败,你还有1的机会";
            break;
        case 845: text = "密码被锁定";
            break;
        case 901: text = "请输入用户名!";
            break;
        case 902: text = "名称长度应在1-32字符";
            break;
        case 903: text = "名字是非法的";
            break;
        case 904: text = "请输入密码";
            break;
        case 905: text = "密码的长度应在6-16个字符";
            break;
        case 906: text = "密码是非法的";
            break;
        case 907: text = "这个密码不安全,请输入另一个";
            break;
        case 908: text = "请输入您的确认密码";
            break;
        case 909: text = "确认密码的长度应在6-16个字符";
            break;
        case 910: text = "密码是非法的";
            break;
        case 911: text = "密码不匹配";
            break;
        case 1001: text = "在java.library.path没有dog_auth_srv";
            break;
        case 1002: text = "无法获得challenge";
            break;
        case 1003: text = "无法获得challenge";
            break;
        case 1020: text = "超级狗已经注册!";
            break;
    }
    document.getElementById("errorinfo").innerHTML = text + " (" + status + ")\n";
}