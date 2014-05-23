module.exports = function (grunt) {
    grunt.loadNpmTasks('grunt-typescript');
    grunt.loadNpmTasks('grunt-contrib-watch');

    grunt.initConfig({
        // pkg: grunt.file.readJSON('package.json'),
        typescript: {
            base: {
                src: ['lib/**/*.ts'],
                dest: 'js/PixelVisionJSDemos.js',
                options: {
                    module: 'amd',
                    target: 'es5'
                }
            }
        },
        watch: {
            files: ['Source/**/*.ts', 'Test/**/*.ts'],
            tasks: ['typescript']
        },
    });
 
    grunt.registerTask('default', ['watch']);
 
}
