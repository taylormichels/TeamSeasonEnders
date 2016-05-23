﻿angular.module('formatters.logo', []).
 filter('logoFormatter', function () {               
     return function (teamName) {
         var result;

         switch (teamName) {
             case 'Rangers':
                 result = 'https://upload.wikimedia.org/wikipedia/commons/a/ae/New_York_Rangers.svg';
                 //result = '/Images/RangersLogo.png';
                 break;
             case 'Bruins':
                 result = 'https://upload.wikimedia.org/wikipedia/en/1/12/Boston_Bruins.svg';
                 break;
         }         
         return result;
     }
 }).filter('mobileBreak', ['$sce', function ($sce) {
     return function (text) {
         var result = text.replace(' ', ' <br class="mobile-break" />');
         return $sce.trustAsHtml('<span>' + result + '</span>');
     }
 }]);