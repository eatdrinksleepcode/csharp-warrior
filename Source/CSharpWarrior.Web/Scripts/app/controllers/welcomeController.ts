interface csharpWelcomeScope extends ng.IScope {
    welcomeMessage:string;
}

csharpControllers.controller('WelcomeController', function WelcomeController($scope:csharpWelcomeScope) {

    $scope.welcomeMessage = "Hello! Young Warrior!"

});
