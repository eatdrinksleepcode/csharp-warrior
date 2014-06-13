module.exports = function (grunt) {
    grunt.loadNpmTasks('grunt-typescript');
    grunt.loadNpmTasks('grunt-contrib-watch');
    grunt.loadNpmTasks('grunt-contrib-jasmine');

    grunt.initConfig({
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
    		}
        }
    });
 
    grunt.registerTask('default', ['watch']);
 
}
