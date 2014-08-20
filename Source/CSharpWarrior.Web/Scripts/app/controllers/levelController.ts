interface csharpLevelScope extends ng.IScope {
    ctrl:LevelController;
    motivation:string;
    level:Level;
    userCode:string;

    results:string;
    isError:boolean;
    errors:string[];
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
    http: ng.IHttpService;

    constructor($scope:csharpLevelScope, $routeParams, $http: ng.IHttpService) {
        this.scope = $scope;
        this.http = $http;

        this.scope.ctrl = this;
        this.scope.motivation = "Level " + $routeParams.currentLevel;
        this.scope.level = {
            objective: "Get to the exit!",
            tiles: [ { heroIsHere: true }, {}, { isExit: true } ] 
        };
    }

    public executeCode = function() {
        this.http.post('/level/1',  JSON.stringify({ code: this.scope.userCode}))
            .success((data) => {
                this.scope.results = data.output;
                this.scope.isError = data.hasErrors;
                this.scope.errors = data.errors;
            })
            .error((data, status) => {
                if(status === 400) {
                    this.scope.results = data.result;
                } else {
                    this.scope.results = 'Here be dragons!?! Sorry, something went wrong; try again soon...when the dragons are napping.';
                }
                this.scope.isError = true;
            });
    };
}

csharpControllers.controller('LevelController', LevelController);
