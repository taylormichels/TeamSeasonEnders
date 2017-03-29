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