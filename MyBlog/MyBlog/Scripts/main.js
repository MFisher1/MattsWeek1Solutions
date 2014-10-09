$(document).ready(function () {

    $('ShowComments').on('click', function () {
        var parent = $(this).parent();
        var commentsToShowOrHide = parent.find('.commentsdiv');
        commentsToShowOrHide.slideToggle();
    });



});