describe("Test", function() {
    var scope,
    controller;

    beforeEach(function () {
        module('csharpwarrior');
    });

    describe('LevelController', function () {
        beforeEach(inject(function ($rootScope, $controller) {
            scope = $rootScope.$new();
            controller = $controller('LevelController', {
                '$scope': scope,
                '$routeParams': { currentLevel: 1 }
            });
        }));

        it('sets the level', function () {
            expect(scope.motivation).toBe('Level 1');
        });
    });
});