$(document).ready(function () {
    if ($('.calendar').length) {
        events = JSON.parse($('.calendar').attr('data-events'));
        $('.calendar').fullCalendar({
            header: {
                left: 'prev,next today',
                center: 'title',
                right: 'month,listMonth,posterView'
            },
            defaultDate: '2016-12-13',
            editable: true,
            events: events
        });
    }
    $(".poster")[0].style.display = 'none';
});

var events = [];