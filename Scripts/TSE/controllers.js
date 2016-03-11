angular.module('controllers.team', [])
  .controller('TeamController', ['$scope', 'dataFactory', '$timeout', function (scope, data, $timeout) {
      scope.teams = [];
      //scope.divisions = ['Eastern', 'Western'];
      scope.division = 'Eastern'; // TODO get from favorite team
      scope.team = '14';
      scope.rival = '';
      scope.results = [];
      var init = function () {
          data.getTeams(scope.division).success(function (result) {
              scope.teams = result;
          });
      };

      scope.update = function () {
        data.getResults(scope.team, scope.rival).success(function (result) {
            scope.results = result;                  
        });                    
      };

      init();
  }]);