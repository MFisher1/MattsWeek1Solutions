$(document).ready(function () {
    $(".homeNext").on("click", function () {
        //get active slide
        var activeSlide = $(".active");
        //go to next slide
        var nextSlide = $(activeSlide).next();
        if (!nextSlide.hasClass("hide")) {
            nextSlide = $(".homeImg").first();
        }
        activeSlide.removeClass("active").addClass("hide");
        nextSlide.removeClass("hide").addClass("active");
    });
});