$(document).ready(function () {
    //slide show
    setInterval(function () {
            //get active slide
            var activeSlide = $(".slideImg.active");
            //go to next slide
            var nextSlide = $(activeSlide).next();
            if (!nextSlide.hasClass("hide")) {
                nextSlide = $(".slideImg").first();
            }
            activeSlide.removeClass("active").addClass("hide");
            nextSlide.removeClass("hide").addClass("active");
    }, 3000);

    /*Image 1 carousel */ 
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
    /*Image 1 carousel end*/
    /*Image 2 carousel */
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
    /*Image 2 carousel end*/
    /*Image 3 carousel */
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
    /*Image 3 carousel end*/
    /*Image 4 carousel*/

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
    /*Image 4 carousel end*/

    //Prev button
    //workimg1
        $('.workPrev1').on('click', function () {

            var activeSlide = $('.workImg1.active');
            var prevSlide = $(activeSlide).prev();
            if (!prevSlide.hasClass("hide")) {
                prevSlide = $(".workImg1").last();
            }
            activeSlide.removeClass('active').addClass('hide');
            prevSlide.removeClass('hide').addClass('active');
        });


//Ajax Post for Contact Form
   
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