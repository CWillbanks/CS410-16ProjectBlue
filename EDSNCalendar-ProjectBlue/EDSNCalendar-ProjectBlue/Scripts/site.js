$(document).ready(function () {
    $('.calendar').fullCalendar({
        header: {
            left: 'prev,next today list',
            center: 'title',
            right: 'month,agendaWeek,agendaDay,listMonth'
        },
        defaultDate: '2016-09-12',
        editable: true,
        events: [
            {
                title: 'Sample',
                start: '2016-09-03T13:00:00',
                constraint: 'businessHours'
            }
        ]
    });
});