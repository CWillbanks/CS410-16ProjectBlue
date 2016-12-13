
//Create Dummy View
const FC = $.fullCalendar;
const View = FC.View;

var PosterView = View.extend({
  initialize() {
  },
  render() {
    this.intervalUnit = 'month';
    this.intervalDuration._days = 0;
    this.intervalDuration._months = 1;
  },
  setHeight(height, isAuto) {
  },
  renderEents(events) {
  },
  destroyEvents() {
  },
  renderSelection(range) {
  },
  destroySelection() {
  }
});

FC.views.poster = PosterView;

$(document).ready(function () {
  'use strict';
  let button = $(".fc-poster-button")[0];
  //Setup Listener
  if (button !== undefined) {
    button.addEventListener('click', function () {
      $(".poster")[0].style.display = 'block';
    });

    document.addEventListener('click', function () {
      if (!/fc-state-active/ig.test(button.className)) {
        $(".poster")[0].style.display = 'none';
      }
    })
  }

  //Extract Data From HTML Event and Render Data On Page In a Hidden Dev
  let data = events;
  data.forEach((event) => {
    $(".poster-events")[0].append(
    //console.log($(`<div class="col-xs-3"></div> `).text("Test")[0])
    $(
    `<div class="poster-event col-xs-3">
      <h3 class ="poster-event">
        ${event.title}@<span class ="poster-event">${event.venueName}</span>
      </h3>
      <br />
      <p>${event.date}</p>
      <image class="img-responsive"src="${(event.image !== null) ? 'data:image/png;base64,' + event.image : ''}"></img>
     </div>`)[0]
     )
  })
});