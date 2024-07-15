
// אישור השליחה של טופס ההרשמה לסרבר
function ValidateRegister() {
    event.preventDefault();
    RgResetWarnings();

    ShowErrors();

    
    var value = (rgUsername.value.length >= 3 && rgPassword.value.length >= 5 && rgPassword.value == rgPasswordConfirm.value && rgFirstName.value.length >= 2 && rgLastName.value.length >= 2 && rgPhoneNum.value.length >= 9 && rgPhoneNum.value.length <= 10);

    return value;
}

// החבאת ההזהרות לפני בדיקתם בעמוד ההרשמה
function RgResetWarnings() {
    rgUsernameWarning.style.display = "none";
    rgPasswordWarning.style.display = "none";
    rgPasswordConfirmWarning.style.display = "none";
    rgFirstNameWarning.style.display = "none";
    rgLastNameWarning.style.display = "none";
    rgPhoneNumWarning.style.display = "none";
    
}

// הצגת ההזהרות במידה וצריך
function ShowErrors() {
    if (rgUsername.value.length < 3)
        rgUsernameWarning.style.display = "block";

    if (rgPassword.value.length < 5)
        rgPasswordWarning.style.display = "block";

    if (rgPassword.value != rgPasswordConfirm.value)
        rgPasswordConfirmWarning.style.display = "block";

    if (rgFirstName.value.length < 2)
        rgFirstNameWarning.style.display = "block";

    if (rgLastName.value.length < 2)
        rgLastNameWarning.style.display = "block";

    if (rgPhoneNum.value.length < 9 || rgPhoneNum.value.length > 10)
        rgPhoneNumWarning.style.display = "block";
}

//אישור השליחה של טופס ההרשמה לסרבר
function ValidateLogin() {
    // בדיקת מספר התווים בשם המשתמש וסיסמה
    if (lgUsername.value.length >= 3 && lgPassword.value.length >= 5) {
        return true;
        lgErrors.style.display = "none";
    }
    else
        lgErrors.style.display = "block";

    return false;

}

// החבאת ההזהרות לפני בדיקתם בעמוד ההרשמה
function LgResetWarnings() {
    lgErrors.style.display = "none";
}

function changeImage() {
    picUrl_html.value = prompt("Place a url for your new profile picture: ");
    location.href = location.href;
}

//שליחה של משתנים להרצה הבאה של הדף
//(alternative for onserverclick)

function sendApplication(animalId) {
    animalId_Html.value = animalId;
    form1.submit();
}

function sendAdopter(adopterId) {
    adopterId_Html.value = adopterId;
    form1.submit();
}

function sendAcception(animalId, adopterId) {
    animalId_Html.value = animalId;
    adopterId_Html.value = adopterId;
    form1.submit();
}
function sheltererAction(){
    sheltererAction_Html.value = "true";
    form1.submit();
}

function addSecurityQ() {
    securityQ2.style.display = block;
    securityA2.style.display = block;
}

function ShowUserInfo() {
    usersData.style.display = "block";
    animalsData.style.display = "none";
}

function ShowAnimalsInfo() {
    usersData.style.display = "none";
    animalsData.style.display = "block";
}

function hideDataInfo() {
    usersData.style.display = "none";
    animalsData.style.display = "none";
}

function ShowData() {
    var choise = mainSelect.value;

    if (choise == "UsersInfo")
        ShowUserInfo();
    else if (choise == "AnimalsInfo")
        ShowAnimalsInfo();
    else if (choise == "Nope")
        hideDataInfo();
}


