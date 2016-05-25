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
  }]).factory('colorService', function () {
      return {          
          setBackgroundColor: function () {
              // convert svg logo to canvas then to tempLogo for bgcolor plugin
              canvg(document.getElementById('canLogo'),
                document.getElementById('topLogo').src);
              var canvas = document.getElementById('canLogo');
              var image = document.getElementById('tempLogo');
              image.src = canvas.toDataURL("image/png");
              
              // this sets background color to prominent color in logo
              var defaults = { parent: 'body' };
              $.adaptiveBackground.run(defaults);
          }
      };      
  });