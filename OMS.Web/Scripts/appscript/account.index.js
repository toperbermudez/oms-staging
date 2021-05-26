/// <reference path="../jquery-1.10.2.min.js" />
/// <reference path="../jquery.validate.js" />
/// <reference path="../jquery.datatables.js" />
/// <reference path="../common/common.js" />
$(function () {
    var element = {
        $loginForm: $('#loginForm')
    };

    var dom = {
        loginFormValidate: null
    }

    var methods = {
        init: function () {
            dom.loginFormValidate = element.$loginForm.data('validator');
        }
    };

    element.$loginForm
        .on('click', '#btnLogin', function (e) {
            if (element.$loginForm.valid()) {
                e.preventDefault();
                Loader.show('Logging In Please Wait');
                $.ajax({
                    type: 'POST',
                    url: element.$loginForm.attr('action'),
                    data: element.$loginForm.serialize(),
                    success: function (data) {
                        if (data.Success) {
                            window.location.reload();
                        } else {
                            Loader.hide();
                            common.displayAlert(element.$loginForm,'Error', data.ErrorMessage);
                        }
                    }
                });
            }
        })
        ;

    methods.init();
});