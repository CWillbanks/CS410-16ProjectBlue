$(document).ready(function () {
    console.log($('.calendar').attr('data-events'));
    $('.calendar').fullCalendar({
        header: {
            left: 'prev,next today',
            center: 'title',
            right: 'month,listMonth'
        },
        defaultDate: '2016-11-05',
        editable: true,
        events: [
            {
                title: 'Conference',
                start: '2016-11-05T13:00:00',
                end: '2016-11-05T16:00:00'
            },
        ]
    });
});