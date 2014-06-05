interface csharpWelcomeScope extends ng.IScope {
    welcomeMessage:string;
}

var csharpControllers = angular.module('csharpControllers', []);

csharpControllers.controller('WelcomeController', function WelcomeController($scope:csharpWelcomeScope) {

    $scope.welcomeMessage = "Hello! Young Warrior!"

});
