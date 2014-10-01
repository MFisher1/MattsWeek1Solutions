//load dom into jQuery
$(document).ready(function () {
    //functions go in here
    //bind to li items
    /*
    $('li').on('click', function()
    {
        $(this).css('color', 'red').css('backgroud-color', 'purple')
    });
    */

    /*Tab function Start*/
    $(".tabSelection li").on("click", function () {
        //bind click event under each li
        var tabID = $(this).data("tab-id");
        //select active tab
        var activeTab = $("active")
        //select tab to activate
        var selectedTab = $("#" + tabID);
        //remove active class from active tab and add hide class to active tab
        activeTab.removeClass("active");
        activeTab.addClass("hide");
        //remove hide class from selected tab, add active class to selected tab
        selectedTab.removeClass("hide").addClass("active");

    });
    /*Tab function End*/

    //Carousel Functions Start
    $(".carousel-next").on("click", function () {
        //get active slide
        var activeSlide = $(".active");
        //go to next slide
        var nextSlide = $(activeSlide).next();
        if(!nextSlide.hasClass("hide")){
            nextSlide = $(".carousel").first();
        }
        activeSlide.removeClass("active").addClass("hide");
        nextSlide.removeClass("hide").addClass("active");
    });
    //Carousel Functions End
});