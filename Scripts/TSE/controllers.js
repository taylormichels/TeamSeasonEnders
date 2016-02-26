angular.module('controllers.team', [])
  .controller('TeamController', ['$scope', 'dataFactory', '$timeout', function (scope, data, $timeout) {
      scope.teams = [];
      scope.divisions = ['Eastern', 'Western'];
      scope.division = 'Eastern';
      var init = function () {
          data.getTeams(scope.division).success(function (result) {
              scope.teams = result;
          });
      };

      scope.update = function () {
        data.getTeams(scope.division).success(function (result) {
            scope.teams = result;                  
        });                    
      };

      init();
  }]);