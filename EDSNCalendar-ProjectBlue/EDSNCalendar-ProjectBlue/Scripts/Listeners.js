//Add Listeners for Event Details
$(document).ready(() => {
  Array.prototype.forEach.call($(".fc-content"), (element) => {
    console.log(element);
    element.addEventListener("click", () => {
      propogateDetails(element.lastChild);
      $("#DetailsPopUp")[0].style.display = 'block';
    })
  })

  Array.prototype.forEach.call($(".poster-event.col-xs-3"), (element) => {
    console.log(element.childNodes[1].textContent.trim().replace(/@.*/ig, ""));
    element.addEventListener("click", () => {
      propogateDetails(element.childNodes[1].textContent.trim().replace(/@.*/ig, ""));
      $("#DetailsPopUp")[0].style.display = 'block';
    })
  })

  Array.prototype.forEach.call($(".close-btn"), (element) => {
    element.addEventListener("click", () => {
      element.parentNode.parentNode.style.display = 'none';
    })
  })
})

//Propogate Details 
function propogateDetails(eventName) {
  'use strict';
  let data = JSON.parse($(".poster")[0].dataset.events);
  let eventData = data.reduce((finalData, element) => {
    if (new RegExp(String(eventName), "ig").test(element.title) || eventName === element.title) {
      finalData = element;
      return finalData;
    }
    else {
      return finalData;
    }
  }, {})
  $("#detailsHead")[0].innerHTML = `${eventData.title}
                    <br />
                    <small id="detailsTimePlace">${eventData.date}|${eventData.venueName}</small>`
  $("#detailsTime")[0].innerHTML = `${eventData.date}`;
  $("#detailsContact")[0].innerHTML = `<i class="fa fa-user" aria-hidden="true"></i> ${eventData.hostName}
  <br />
  <i class ="fa fa-phone" aria-hidden="true"></i> ${eventData.hostPhoneNumber}`;
  $("#detailsAddr")[0].innerHTML = `${eventData.venueName} - ${eventData.address}`
}