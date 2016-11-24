module.exports = function (grunt) {
    grunt.loadNpmTasks('grunt-contrib-cssmin');
    grunt.loadNpmTasks('grunt-contrib-uglify');
    grunt.loadNpmTasks('grunt-contrib-jshint');
    grunt.loadNpmTasks('grunt-contrib-watch');
    grunt.loadNpmTasks('grunt-contrib-concat');
    grunt.loadNpmTasks('grunt-contrib-clean');
    grunt.initConfig({
        concat: {
            js: {
                files: {
                    'Scripts/Lib-js/angular-app.min.js': ['Scripts/Lib-js/angular.min.js', 'Scripts/Lib-js/angular-route.min.js', 'Scripts/Lib-js/angular-animate.min.js'],
                    'Scripts/app/app.min.js': ['Scripts/app/**/*.js', '!Scripts/app/app.min.js']
                }
            },
            dev: {
                files: {
                    'Scripts/app/app.min.js': ['Scripts/app/**/*.js', '!Scripts/app/app.min.js']
                }
            }
        },
        uglify: {
            bundle: {
                files: {
                    'Scripts/Lib-js/angular-app.min.js': 'Scripts/Lib-js/angular-app.min.js',
                    'Scripts/app/app.min.js': 'Scripts/app/app.min.js'
                }
            },
            dev: {
                files: {
                    'Scripts/app/app.min.js': 'Scripts/app/app.min.js'
                }
            }
        },
        jshint: {
            all: ['Gruntfile.js', 'Scripts/app/**/*.js', '!Scripts/app/**/*.min.js']
        },
        watch: {
            scripts: {
                files: ['Scripts/app/**/*.js', '!Scripts/app/**/*.min.js', '!Scripts/app/site.js'],
                tasks: ['jshint', 'clean', 'concat:dev', 'uglify:dev']
            }
        },
        clean: {
            js: ['Scripts/app/app.min.js']
        }
    });

    grunt.log.write('Grunt is running\n');
    grunt.registerTask('default', ['jshint', 'concat:js', 'uglify:bundle', 'watch']);
};