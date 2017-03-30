angular.module('formatters.logo', []).
 filter('logoFormatter', function () {               
     return function (teamName) {
         var result;

         switch (teamName) {
             case "Red Wings":
                 result = 'https://upload.wikimedia.org/wikipedia/en/e/e0/Detroit_Red_Wings_logo.svg';
                 break;
             case 'Rangers':
                 result = 'https://upload.wikimedia.org/wikipedia/commons/a/ae/New_York_Rangers.svg';                 
                 break;
             case 'Bruins':
                 result = 'https://upload.wikimedia.org/wikipedia/en/1/12/Boston_Bruins.svg';
                 break;
             case 'Canadiens':
                 result = 'https://upload.wikimedia.org/wikipedia/commons/6/69/Montreal_Canadiens.svg';
                 break;
             case 'Ducks':
                 result = 'https://upload.wikimedia.org/wikipedia/en/7/72/Anaheim_Ducks.svg';
                 break;
             case 'Sabres':
                 result = 'https://upload.wikimedia.org/wikipedia/en/6/6f/Buffalo_Sabres.svg';
                 break;
             case 'Panthers':
                 result = 'https://upload.wikimedia.org/wikipedia/en/7/7a/Carolina_Panthers_logo_2012.svg';
                 break;
             case 'Senators':
                 result = 'https://upload.wikimedia.org/wikipedia/en/d/db/Ottawa_Senators.svg';
                 break;
             case 'Lightning':
                 result = 'https://upload.wikimedia.org/wikipedia/en/2/2f/Tampa_Bay_Lightning_Logo_2011.svg';
                 break;
             case 'Maple Leafs':
                 result = 'https://upload.wikimedia.org/wikipedia/en/b/b6/Toronto_Maple_Leafs_2016_logo.svg';
                 break;
             case 'Hurricanes':
                 result = 'https://upload.wikimedia.org/wikipedia/en/3/32/Carolina_Hurricanes.svg';
                 break;
             case 'Blue Jackets':
                 result = 'https://upload.wikimedia.org/wikipedia/en/0/04/Columbus_BlueJackets.svg';
                 break;
             case 'Devils':
                 result = 'https://upload.wikimedia.org/wikipedia/en/9/9f/New_Jersey_Devils_logo.svg';
                 break;
             case 'Islanders':
                 result = 'https://upload.wikimedia.org/wikipedia/en/4/42/Logo_New_York_Islanders.svg';
                 break;
             case 'Flyers':
                 result = 'https://upload.wikimedia.org/wikipedia/en/d/dc/Philadelphia_Flyers.svg';
                 break;
             case 'Penguins':
                 result = 'https://upload.wikimedia.org/wikipedia/en/3/3a/Pittsburgh_Penguins_logo.svg';
                 break;
             case 'Capitals':
                 result = 'https://upload.wikimedia.org/wikipedia/en/2/2d/Washington_Capitals.svg';
                 break;
             default:
                 result = 'https://upload.wikimedia.org/wikipedia/commons/3/33/Image-missing.svg';
         }         
         return result;
     }
 }).filter('mobileBreak', ['$sce', function ($sce) {
     return function (text) {
         var result = text.replace(' ', ' <br class="mobile-break" />');
         return $sce.trustAsHtml('<span>' + result + '</span>');
     }
 }]);