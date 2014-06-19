interface csharpLevelScope extends ng.IScope {
    motivation:string;
    level:Level;
}

interface Level {
    tiles: Tile[];
    objective: string;
}

interface Tile {
    heroIsHere?: boolean;
    isExit?: boolean;
}

csharpControllers.controller('LevelController', function LevelController($scope:csharpLevelScope, $routeParams) {

    $scope.motivation = "Level " + $routeParams.currentLevel;
    $scope.level = {
        objective: "Get to the exit!",
        tiles: [ { heroIsHere: true }, {}, { isExit: true } ] 
    };
});
