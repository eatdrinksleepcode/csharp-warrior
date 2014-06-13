interface csharpLevelScope extends ng.IScope {
    motivation:string;
}

csharpControllers.controller('LevelController', function LevelController($scope:csharpLevelScope) {

    $scope.motivation = "You can do it!"

});


