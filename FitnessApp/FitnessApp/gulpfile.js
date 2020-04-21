/// <binding AfterBuild='default' />
var gulp = require('gulp');
var uglify = require("gulp-uglify");
var concat = require("gulp-concat");

function minify() {
    return gulp.src("wwwroot/js/**/*.js")
        .pipe(uglify())
        .pipe(concat("finessApp.min.js"))
        .pipe(gulp.dest("wwwroot/dist"))
};


exports.minify = minify;
exports.default = gulp.series(minify);
