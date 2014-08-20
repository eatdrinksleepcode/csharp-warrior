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
                httpBackend.when('POST', '/level/1',  JSON.stringify({ code: "good code"})).respond({ output: 'Success!!!', hasErrors: false });

                scope.userCode = "good code";
                controller.executeCode();
                httpBackend.flush();

                expect(scope.results).toBe("Success!!!");
                expect(scope.isError).toBe(false);
            });

            it('displays failure results for bad code', () => {
                var compileErrorMessage = 'Could not compile!!!';
                httpBackend.when('POST', '/level/1',  JSON.stringify({ code: "bad code" }))
                           .respond({ output: compileErrorMessage, hasErrors: true, errors: ["Error!!!"]});

                scope.userCode = "bad code";
                controller.executeCode();
                httpBackend.flush();

                expect(scope.results).toBe(compileErrorMessage);
                expect(scope.isError).toBe(true);
                expect(scope.errors.length).toBe(1);
            });

            it('displays failure results for unknown errors', () => {
                httpBackend.when('POST', '/level/1').respond(404);

                scope.userCode = "unknown error";
                controller.executeCode();
                httpBackend.flush();

                expect(scope.results).toBe("Here be dragons!?! Sorry, something went wrong; try again soon...when the dragons are napping.");
                expect(scope.isError).toBe(true);
            });

            afterEach(function() {
                httpBackend.verifyNoOutstandingExpectation();
                httpBackend.verifyNoOutstandingRequest();
            });
       });
    });
});
