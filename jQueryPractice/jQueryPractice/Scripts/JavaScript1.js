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
        var activeTab = $("active");
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

    //Ajax get
    /*
    $("#content .ajaxget").on("click", function () {
        //to user ajax get, specify jquery.get
        $.get("/ajaxget/cats", function (data) {
            //replace content html with html returned from ajax get request
            $("#content").html(data);
        });
    });
    */
    //Much better ajax code
    $("#content").on("click", ".ajaxget", function () {
        var urlRequest = $(this).data("url");
        //to user ajax get, specify jquery.get
        $.get(urlRequest, function (data) {
            //replace content html with html returned from ajax get request
            $("#content").html(data);
        });
    });

    //ajax get for tabs
    $("#tabs").on("click", ".tabsget", function () {
        var urlRequest = $(this).data("url");
        //to user ajax get, specify jquery.get
        $.get(urlRequest, function (data) {
            //replace content html with html returned from ajax get request
            $("#tabcontent").html(data);
        });
    });

    //Ajax Post for Contact Form
    $("contactForm").on("submit", function (event) {
        //Prevent default behavior of form upon clicking on submit
        event.preventDefault();
        //see if form is valid
        if ($(this).valid())
        {
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