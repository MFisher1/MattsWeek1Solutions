$(document).ready(function () {
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

    //ajax get for about tabs
    $(".aboutTab").on("click", function () {
        var urlRequest = $(this).data("url");
        //to user ajax get, specify jquery.get
        $.get(urlRequest, function (data) {
            //replace content html with html returned from ajax get request
            $("#tabcontent").html(data);
        });
    });

    //ajax get site
    $(".pageLink").on("click", function () {
        var urlRequest = $(this).data("url");
        //to user ajax get, specify jquery.get
        $.get(urlRequest, function (data) {
            //replace content html with html returned from ajax get request
            $("#siteContent").html(data);
        });
    });

});