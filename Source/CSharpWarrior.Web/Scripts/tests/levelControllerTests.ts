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
                '$scope': scope
            });
        }));

        it('sets the name', function () {
            expect(scope.motivation).toBe('You can do it!');
        });
    });
});