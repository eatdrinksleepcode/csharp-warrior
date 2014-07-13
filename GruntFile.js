module.exports = function (grunt) {
    grunt.loadNpmTasks('grunt-typescript');
    grunt.loadNpmTasks('grunt-contrib-watch');
    grunt.loadNpmTasks('grunt-contrib-jasmine');
    grunt.loadNpmTasks('grunt-msbuild');
    grunt.loadNpmTasks('grunt-shell');

    grunt.initConfig({
        msbuild: {
            src: ['CSharpWarrior.sln'],
            options: {
                projectConfiguration: 'Debug',
                targets: ['Rebuild'],
                verbosity: 'quiet'
            }

        },
        shell: {
            nunit: {
                command: 'mono --debug packages/NUnit.Runners.2.6.3/tools/nunit-console.exe "Test/CSharpWarrior.Server.Test/bin/Debug/CSharpWarrior.Domain.Test.dll" -noresult'
            },
            nuget: {
                command: 'nuget restore'
            },
            npm: {
                command: 'npm install'
            }
        },
        // pkg: grunt.file.readJSON('package.json'),
        typescript: {
            base: {
                src: ['Source/**/*.ts'],
                options: {
                    module: 'amd',
                    target: 'es5',
                    sourceMap: true,
                }
            }
        },
		jasmine: {
            all: {
                src: [
                    'Source/CSharpWarrior.Web/Scripts/app/site.js',
                    'Source/CSharpWarrior.Web/Scripts/app/controllers/*.js',
                ],
                options: {
                    'vendor': ['Source/CSharpWarrior.Web/Scripts/jquery-2.1.1.js',
                   	           'Source/CSharpWarrior.Web/Scripts/angular.js',
                   	           'Source/CSharpWarrior.Web/Scripts/angular-route.js',
                   	           'Source/CSharpWarrior.Web/Scripts/angular-mocks.js'],
                    'specs': 'Source/CSharpWarrior.Web/Scripts/tests/**/*.js'
                }
            }
        },
        watch: {
        	ts: {
            	files: ['Source/**/*.ts'],
            	tasks: ['typescript']
           	},
			js: {
        		files: ['Source/CSharpWarrior.Web/Scripts/**/*.js'],
        		tasks: ['jasmine:all']
    		},
            cs: {
                files: ['Test/**/*.cs'],
                tasks: ['msbuild', 'shell:nunit']
            }
        }
    });
 
    grunt.registerTask('default', ['watch']);
    grunt.registerTask('unitTests', ['msbuild', 'shell:nunit']);
    grunt.registerTask('startDev', 
                        [ 'shell:npm', 'shell:nuget', 'msbuild', 'shell:nunit', 'watch'])
 
}
