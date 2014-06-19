interface csharpLevelScope extends ng.IScope {
    ctrl:LevelController;
    motivation:string;
    level:Level;
    results:string;
    userCode:string;
}

interface Level {
    tiles: Tile[];
    objective: string;
}

interface Tile {
    heroIsHere?: boolean;
    isExit?: boolean;
}

class LevelController {

    scope: csharpLevelScope;

    constructor($scope:csharpLevelScope, $routeParams) {
        this.scope = $scope;
        this.scope.ctrl = this;
        this.scope.motivation = "Level " + $routeParams.currentLevel;
        this.scope.level = {
            objective: "Get to the exit!",
            tiles: [ { heroIsHere: true }, {}, { isExit: true } ] 
        };
    }

    private executeCode = function() {
        this.scope.results = this.scope.userCode;
    };
}

csharpControllers.controller('LevelController', LevelController);
