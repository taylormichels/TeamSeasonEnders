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
        link: function (scope, element) {
            element.bind('change', function () {
                // this is used to set rootScope.homeTeam and grab logo
                scope.teamName =
                    element[0].options[element[0].selectedIndex].text;
                scope.teamId =
                    element[0].options[element[0].selectedIndex].value.replace('number:', '');
                scope.$apply();                
            });
        }
    };
}]);