proyectoApp.directive('decimalsOnly', function () {
    return {
        require: 'ngModel',
        link: function (scope, element, attrs, control) {
            control.$parsers.push(function (viewValue) {
                var newDecimal = control.$viewValue;
                control.$setValidity("invalidDecimal", true);
                if (typeof newDecimal === "object" || newDecimal == "") return newDecimal;
                if (!newDecimal.match(/(.*)\.[0-9][0-9]/))
                    control.$setValidity("invalidDecimal", false);
                return viewValue;
            });
        }
    };
});