// gulpfile.js
var gulp = require('gulp');
var cssnano = require('gulp-cssnano');

gulp.task('minify-css', function () {
    return gulp.src('/wwwroot/Kashi_Seramic_Theme/assets/css/*.css') // مسیر فایل‌های CSS خود را مشخص کنید
        .pipe(cssnano())
        .pipe(gulp.dest('/wwwroot/Kashi_Seramic_Theme')); // مسیر ذخیره فایل‌های CSS فشرده شده
});