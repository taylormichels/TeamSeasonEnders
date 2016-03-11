angular.module('factory.data', [])
  .factory('dataFactory', ['$http', function (http) {
      return {
          getTeams: function(data) {
              return http.get('/api/team/getteams', {
                  params: { division: data }
              });
          },
          getResults: function (team, rival) {
              return http.get('/api/team/getresults', {
                  params: { team: team, rival: rival }
              });
          }
      };
}]);