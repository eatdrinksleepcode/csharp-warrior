// <reference path="../typings/jquery/jquery.ts"/>
// <reference path="../typings/angularjs/angular.d.ts"/>
// <reference path="../typings/angularjs/angular-route.d.ts"/>

var csharpwarrior = angular.module('csharpwarrior', ['ngRoute'])
        .config(function ($routeProvider:ng.route.IRouteProvider) {
                $routeProvider.when('/', {
                        controller: 'WelcomeController',
                        templateUrl: 'partials/welcome.html'
                });
});
