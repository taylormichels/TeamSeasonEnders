angular.module('controllers.team', [])
  .controller('TeamController', ['$scope', 'dataFactory', '$timeout', function (scope, data, $timeout) {
      scope.teams = [];
      //scope.divisions = ['Eastern', 'Western'];
      scope.division = 'Eastern'; // TODO get from favorite team
      scope.team = '14';
      scope.rival = '';
      scope.default = { 'Name': 'Select a Rival', 'Id': '0' };
      scope.results = [];
      var init = function () {
          data.getTeams(scope.division).success(function (result) {
              scope.teams = result;
              scope.teams.unshift(scope.default);
              scope.rival = scope.teams[0];
          });
      };

      scope.update = function () {
        data.getResults(scope.team, scope.rival.Id).success(function (result) {
            scope.results = result;                  
        });                    
      };

      init();
  }]);