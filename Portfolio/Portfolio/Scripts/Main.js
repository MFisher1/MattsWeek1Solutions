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
    /*Image 1 carousel */ 
    $(document).ready(function () {
        $(".workNext1").on("click", function () {
            //get active slide
            var activeSlide = $(".active.workImg1");
            //go to next slide
            var nextSlide = $(activeSlide).next();
            if (!nextSlide.hasClass("hide")) {
                nextSlide = $(".workImg1").first();
            }
            activeSlide.removeClass("active").addClass("hide");
            nextSlide.removeClass("hide").addClass("active");
        });
    });
    /*Image 1 carousel end*/
    /*Image 2 carousel */
    $(document).ready(function () {
        $(".workNext2").on("click", function () {
            //get active slide
            var activeSlide = $(".active.workImg2");
            //go to next slide
            var nextSlide = $(activeSlide).next();
            if (!nextSlide.hasClass("hide")) {
                nextSlide = $(".workImg2").first();
            }
            activeSlide.removeClass("active").addClass("hide");
            nextSlide.removeClass("hide").addClass("active");
        });
    });
    /*Image 2 carousel end*/
    /*Image 3 carousel */
    $(document).ready(function () {
        $(".workNext3").on("click", function () {
            //get active slide
            var activeSlide = $(".active.workImg3");
            //go to next slide
            var nextSlide = $(activeSlide).next();
            if (!nextSlide.hasClass("hide")) {
                nextSlide = $(".workImg3").first();
            }
            activeSlide.removeClass("active").addClass("hide");
            nextSlide.removeClass("hide").addClass("active");
        });
    });
    /*Image 3 carousel end*/
    /*Image 4 carousel*/
    $(document).ready(function () {
        $(".workNext4").on("click", function () {
            //get active slide
            var activeSlide = $(".active.workImg4");
            //go to next slide
            var nextSlide = $(activeSlide).next();
            if (!nextSlide.hasClass("hide")) {
                nextSlide = $(".workImg4").first();
            }
            activeSlide.removeClass("active").addClass("hide");
            nextSlide.removeClass("hide").addClass("active");
        });
    });
    /*Image 4 carousel end*/

//Ajax Post for Contact Form
    $(document).ready(function(){
        $("contactForm").on("submit", function (event) {
            //Prevent default behavior of form upon clicking on submit
            event.preventDefault();
            //see if form is valid
            if ($(this).valid()) {
                //ajax post
                var urlToPostTo = $(this).attr("action");
                //serialize converts form fields into string that we can pass into our $.post() function
                var dataToSend = $(this).serialize();
                alert(dataToSend);
                $.post(urlToPostTo, dataToSend, function (data) {
                    //update #container element with new html
                    $("#contianer").html(data);
                });
            }
        });
    });