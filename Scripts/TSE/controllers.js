angular.module('controllers.team', [])
  .controller('RivalController', ['$scope', '$rootScope', 'dataFactory', 'colorService', '$location',
    function (scope, rootScope, data, color, location) {
      scope.teams = []; 
      if (rootScope.homeTeam == undefined)
          location.path('/chooser');
      scope.division = rootScope.homeTeam ? rootScope.homeTeam.Conference: 'Eastern';
      scope.team = rootScope.homeTeam ? rootScope.homeTeam.Id : 0;
      scope.teamName = rootScope.homeTeam ? rootScope.homeTeam.Name : 'foo';
      scope.rival = '';
      scope.default = { 'Name': 'Select a Rival', 'Id': '0' };
      scope.results = [];
      scope.selectionMade = false;
      var init = function () {
          data.getTeams(scope.division).success(function (result) {
              scope.teams = result.filter(r => r.Id != scope.team);
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
      scope.division = rootScope.homeTeam ? rootScope.homeTeam.Conference: 'Eastern';      
      scope.teamName =  rootScope.homeTeam ? rootScope.homeTeam.Name:'foo';
      scope.default = { 'Name': 'Select a Team', 'Id': '0' };
      scope.team = [{'Id':0,'Name':'','City':'','State':'','Division':'','Conference':''}];
      scope.results = [];
      scope.selectedId = 0;
      scope.setTeam = function () {
          rootScope.homeTeam = scope.team;
          location.path('/');
      }

      scope.selectTeam = function (id) {
          scope.selectedId = id;
          scope.team = scope.teams.filter(function (t) {
              return t.Id == scope.selectedId;
          })[0];
      }

      var init = function () {          
          getTeamsByDivision(scope.division).then(function (teams) {
              if (!rootScope.homeTeam)
                  scope.team = scope.teams[0];

              else
                  scope.team =
                      scope.teams.filter(function(t) {
                          return t.Id == rootScope.homeTeam.Id
                      })[0];

                  scope.selectedId = scope.team.Id;
          });

          // tab toggle logic
          $('a[data-toggle="pill"]').on('shown.bs.tab', function (e) {              
              scope.division = $(e.target).text() // activated tab              
              getTeamsByDivision(scope.division);              
          });          
      }

      // TODO rename to Conference
      var getTeamsByDivision = function(division) {
          return data.getTeams(division).then(function (result) {
              scope.teams = result.data;
              scope.teams.unshift(scope.default);              
              scope.selectedId = scope.default.Id;
              scope.team = scope.teams[0];
          });
      }

      init();      
}]);   