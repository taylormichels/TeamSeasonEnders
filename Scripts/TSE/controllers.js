angular.module('controllers.team', [])
  .controller('RivalController', ['$scope', '$rootScope', 'dataFactory', 'colorService', '$location',
    function (scope, rootScope, data, color, location) {
      scope.teams = []; 
      if (rootScope.homeTeam == undefined)
          location.path('/chooser');
      scope.division = rootScope.homeTeam ? rootScope.homeTeam.Division : 'Eastern';
      scope.team = rootScope.homeTeam ? rootScope.homeTeam.Id : 0;
      scope.teamName = rootScope.homeTeam ? rootScope.homeTeam.Name : 'foo';
      scope.rival = '';
      scope.default = { 'Name': 'Select a Rival', 'Id': '0' };
      scope.results = [];
      scope.selectionMade = false;
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
          scope.selectionMade = true;
      };

      init();
  }])
.controller('TeamController', ['$scope', '$rootScope', 'dataFactory', 'colorService', '$location',
    function (scope, rootScope, data, color, location) {
      scope.teams = [];                        
      scope.division = rootScope.homeTeam ? rootScope.homeTeam.Division : 'Eastern';      
      scope.teamName =  rootScope.homeTeam ? rootScope.homeTeam.Name:'foo';
      scope.teamId = rootScope.homeTeam ? rootScope.homeTeam.Id : 0;
      scope.default = { 'Name': 'Select a Team', 'Id': '0' };      
      scope.results = [];
      scope.setTeam = function () {
          rootScope.homeTeam = { 'Name': scope.teamName, 'Id': scope.teamId, 'Division': scope.division };
          location.path('/');
      }
      var init = function () {          
          getTeamsByDivision(scope.division);                    

          // tab toggle logic
          $('a[data-toggle="pill"]').on('shown.bs.tab', function (e) {              
              scope.division = $(e.target).text() // activated tab              
              getTeamsByDivision(scope.division);              
          });          
      }

      var getTeamsByDivision = function(division) {
          data.getTeams(division).success(function (result) {
              scope.teams = result;
              scope.teams.unshift(scope.default);
              scope.team = scope.teams[0];              
          });
      }

      init();
}]);   