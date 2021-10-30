var LoginViewModel = function (headerToken) {
    var self = this;
    self.signinError = ko.observable(false);

    self.model = ko.observable({
        userName: ko.observable(""),
        password: ko.observable("")
    });

    self.signin = function () {
        debugger;
        if (!self.model().userName() || !self.model().password()) {
            return;
        }
        $.ajax({
            url: window.location.pathname,
            contentType: "application/json",
            cache: false,
            type: "POST",
            data: ko.toJSON(self.model()),
            processData: false,
            headers: {
                'RequestVerificationToken': headerToken
            },
            error: function (xhr, ajaxOptions, thrownError) {
                self.signinError(true);
            },
            success: function (data, textStatus, request) {
                if (data) {
                    if (data.IsLoggedIn) {
                        var result = self.saveTokenAndRedirect(data.AccessToken, self.model().userName(), data.RenewalTime);
                        if(!result)
                            self.signinError(true);

                    } 
                    else {
                        self.signinError(true);
                    }
                } else {
                    self.signinError(true);
                }
            }
        });
    };

    self.saveTokenAndRedirect = function(token, userName, renewalTime) {
        if (token) {
            window.sessionStorage.setItem("access_token", token);
            window.sessionStorage.setItem("userName", userName);
            window.sessionStorage.setItem("renewalTime", renewalTime);
        }

        if (window.sessionStorage.getItem("access_token")) {
            self.redirect();
            return true;
        } else
            return false;
    };

    self.redirect = function () {
        window.location.replace(window.location.protocol + "//" + window.location.host);
    };

}