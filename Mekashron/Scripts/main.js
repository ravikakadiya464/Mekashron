$(document).ready(function () {
    $("#login-form").validate({
        onfocusout: function (element) {
            // "eager" validation
            this.element(element);
        },
        rules: {
            username: "required",
            password: "required"
        },
        // Specify validation error messages
        messages: {
            username: "Please enter your username",
            password: "Please enter your password."
        }
    });

    $("#register-form").validate({
        onfocusout: function (element) {
            // "eager" validation
            this.element(element);
        },
        rules: {
            firstname: "required",
            lastname: "required",
            email: {
                required: true,
                email: true
            },
            password: "required",
            mobile: "required"
        },
        // Specify validation error messages
        messages: {
            firstname: "Please enter your firstname.",
            lastname: "Please enter your lastname.",
            email: "Please enter your email.",
            password: "Please enter your password.",
            mobile: "Please enter your mobile."
            
        }
    });
});