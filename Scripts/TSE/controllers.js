angular.module('controllers.team', [])
  .controller('RivalController', ['$scope', 'dataFactory', 'colorService', function (scope, data, color) {
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
              color.setBackgroundColor(); // remove this
          });
      };

      scope.update = function () {
          data.getResults(scope.team, scope.rival.Id).success(function (result) {
              scope.results = result;                  
          });                    
      };

      init();
  }]).controller('TeamController', ['$scope', '$rootScope', 'dataFactory', 'colorService', function (scope, rootScope, data, color) {
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
              color.setBackgroundColor();              
          });
      };

      scope.update = function() {
          rootScope.HomeTeam = scope.team;
      }
      init();
}]);   