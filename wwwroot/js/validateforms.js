function validateLoginForm() {
    var uname = $("#email").val();
    var pwd = $("#pwd").val();

    if (uname == "" || pwd == "") {
        alert("Please fill in your username and/or password.");
        return false;
    } else {
        return true;
    }

}

function hasNumber(input) {
    return !isNaN(parseFloat(input) && isFinite(input));
}

function validatePwdRequirements(input) {
    var format = /^[!@#$%^&*()_+\-=\[\]{};':"\\|,.<>\/?]*$/;
    if (this.match(/[a-z]/) &&
        this.match(/[A-Z]/) &&
        hasNumber(input) &&
        string.match(format)) {
        return true;
    } else {
        return false;
    }
}