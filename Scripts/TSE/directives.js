angular.module('directives.imageonload', ['factory.data'])
    .directive('imageonload', ['colorService', function (color) {
    return {
        restrict: 'A',
        link: function (scope, element, attrs) {
            element.bind('load', function () {                
                color.setBackgroundColor();
            });
            element.bind('error', function () {
                alert('image could not be loaded');
            });
        }
    };
}]).directive('myChange', [ function () {
    return {
        restrict: 'A',
        scope: {
            teamName: '='
        },
        link: function (scope, element) {
            element.bind('change', function () {
                // TODO not really supposed to call $parent here??
                scope.$parent.teamName =
                    element[0].options[element[0].selectedIndex].text;
                scope.$parent.$apply();
                //alert('change on ' + element);
            });
        }
    };
}]);