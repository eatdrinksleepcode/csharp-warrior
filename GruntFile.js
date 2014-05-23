module.exports = function (grunt) {
    grunt.loadNpmTasks('grunt-typescript');
    grunt.loadNpmTasks('grunt-contrib-watch');

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
        watch: {
            files: ['Source/**/*.ts'],
            tasks: ['typescript']
        },
    });
 
    grunt.registerTask('default', ['watch']);
 
}
