class LevelController {

    scope: any;
    http: ng.IHttpService;

    constructor($scope, $routeParams, $http: ng.IHttpService) {
        this.scope = $scope;
        this.http = $http;

        this.scope.ctrl = this;
        this.scope.currentLevel = 1;

        this.scope.motivation = "Level " + $routeParams.currentLevel;
    }

    public getLevel(levelId: number): void {
        this.http.get('/level/1')
            .success((data: any) => {
                this.scope.level = data;
            });
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
