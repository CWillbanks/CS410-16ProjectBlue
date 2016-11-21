$(document).ready(function () {
    if ($('.calendar').length) {
        events = JSON.parse($('.calendar').attr('data-events'));
        $('.calendar').fullCalendar({
            header: {
                left: 'prev,next today',
                center: 'title',
                right: 'month,listMonth'
            },
            defaultDate: '2016-11-05',
            editable: true,
            events: events
        });
    }
});

var events = [];