proyectoApp.directive('validEmail', function () {
    return {
        require: 'ngModel',
        link: function (scope, element, attrs, control) {
            control.$parsers.push(function (viewValue) {
                var newEmail = control.$viewValue;
                control.$setValidity("invalidEmail", true);
                if (typeof newEmail === "object" || newEmail == "") return newEmail;
                if (!newEmail.match(/^(([a-zA-Z0-9_\-\.]+)@([a-zA-Z0-9_\-\.]+)\.([a-zA-Z]{2,5}){1,25})+([;,.](([a-zA-Z0-9_\-\.]+)@([a-zA-Z0-9_\-\.]+)\.([a-zA-Z]{2,5}){1,25})+)*$/))
                    control.$setValidity("invalidEmail", false);
                return viewValue;
            });
        }
    };
});