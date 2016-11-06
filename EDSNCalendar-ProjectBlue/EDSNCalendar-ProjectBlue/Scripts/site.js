$(document).ready(function () {
    console.log($('.calendar').attr('data-events'));
    $('.calendar').fullCalendar({
        header: {
            left: 'prev,next today',
            center: 'title',
            right: 'month,listMonth'
        },
        defaultDate: '2016-09-12',
        editable: true,
        events: [$('.calendar').attr('data-events')]
    });
});