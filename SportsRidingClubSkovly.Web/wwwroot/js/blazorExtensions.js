window.blazorExtensions = {
    SaveJwtToken: function (token) {
        sessionStorage.setItem('jwt_token', token);
    },
    GetJwtToken: function () {
        return sessionStorage.getItem('jwt_token');
    }
};
