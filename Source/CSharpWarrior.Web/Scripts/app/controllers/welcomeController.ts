interface csharpWelcomeScope extends ng.IScope {
    welcomeMessage:string;
}

csharpwarrior.controller('WelcomeController', function WelcomeController($scope:csharpWelcomeScope) {

    $scope.welcomeMessage = "Hello! Young Warrior!"

});
