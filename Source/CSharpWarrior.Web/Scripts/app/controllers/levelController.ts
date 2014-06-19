interface csharpLevelScope extends ng.IScope {
    motivation:string;
    level:Level;
}

interface Level {
    tiles: Tile[];
}

interface Tile {
    heroIsHere?: boolean;
    isExit?: boolean;
}

csharpControllers.controller('LevelController', function LevelController($scope:csharpLevelScope, $routeParams) {

    $scope.motivation = "Level " + $routeParams.currentLevel;
    $scope.level = { tiles: [ { heroIsHere: true }, {}, { isExit: true } ] }
});
