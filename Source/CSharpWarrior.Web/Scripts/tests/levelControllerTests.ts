describe("Test", function() {
    var scope: csharpLevelScope;
    var controller: LevelController;

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

        describe('executes code', function() {
            var httpBackend;

            beforeEach(inject(function($httpBackend) {
                httpBackend = $httpBackend;
            }));

            it('displays successful result for good code', () => {
                httpBackend.when('POST', '/level/1', 'good code').respond({ Result: 'Success!' });

                scope.userCode = "good code";
                controller.executeCode();
                httpBackend.flush();

                expect(scope.results).toBe("Success!");
                expect(scope.isError).toBe(false);
            });

            it('displays failure results for bad code', () => {
                httpBackend.when('POST', '/level/1', 'bad code').respond(500, { Result: 'Failure!' });

                scope.userCode = "bad code";
                controller.executeCode();
                httpBackend.flush();

                expect(scope.results).toBe("Failure!");
                expect(scope.isError).toBe(true);
            });

            afterEach(function() {
                httpBackend.verifyNoOutstandingExpectation();
                httpBackend.verifyNoOutstandingRequest();
            });
       });
    });
});
