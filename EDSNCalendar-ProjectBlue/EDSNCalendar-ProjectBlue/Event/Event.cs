using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EDSNCalendar_ProjectBlue.Event
{
    /// <summary>
    /// Event class represents any particular Event that has 
    /// been submitted, verified, or removed from the Calendar.
    /// </summary>
    public class Event
    {
        /// <summary>
        /// Name of the event.
        /// </summary>
        private string title;

        /// <summary>
        /// The person who is hosting the event.
        /// </summary>
        private string hostName;

        /// <summary>
        /// Contact email of the host.
        /// </summary>
        private string hostEmail;

        /// <summary>
        /// Contact phone number of the host.
        /// </summary>
        private string hostPhoneNumber;

        /// <summary>
        /// Name of the facility where the event will be hosted.
        /// </summary>
        private string venueName;

        /// <summary>
        /// Address of the event.
        /// </summary>
        private string address;
        
        /// <summary>
        /// Description of the event.
        /// </summary>
        private string description;

        /// <summary>
        /// Registration URL.
        /// </summary>
        private string registrationURL;

        /// <summary>
        /// Name of the user submitting the event.
        /// </summary>
        private string submitterName;

        /// <summary>
        /// Email of the user submitting the event.
        /// </summary>
        private string submitterEmail;

        /// <summary>
        /// Official date of the event..
        /// </summary>
        private DateTime date;

        /// <summary>
        /// Time of when the event begins.
        /// </summary>
        private DateTime startTime;

        /// <summary>
        /// Time of when the event ends.
        /// <summary>
        private DateTime endTime;

        /// <summary>
        /// Flag indicated if the event lasts all day. 
        /// </summary>
        private bool allDay;

        /// <summary>
        /// The state of the event. Refers to whether the event has been submitted, approved, or deleted.
        /// </summary>
        private EventState state;

        /// <summary>
        /// Constructor that intializes an event and places it in submittion.
        /// </summary>
        public Event(string title, string hostName, string hostEmail, string hostPhoneNumber, string venueName,
                     string address, string description, string registrationURL, string submitterName,
                     string submitterEmail, DateTime date, DateTime startTime, DateTime endTime, bool allDay)
        {
            this.title = title;
            this.hostName = hostName;
            this.hostEmail = hostEmail;
            this.hostPhoneNumber = hostPhoneNumber;
            this.venueName = venueName;
            this.address = address;
            this.description = description;
            this.registrationURL = registrationURL;
            this.submitterName = submitterName;
            this.submitterEmail = submitterEmail;
            this.date = date;
            this.startTime = startTime;
            this.endTime = endTime;
            this.allDay = allDay;
            this.state = EventState.SUBMITTED;
        }

        public string Title
        {
            get
            {
                return title;
            }

            set
            {
                title = value;
            }
        }

        public string HostName
        {
            get
            {
                return hostName;
            }

            set
            {
                hostName = value;
            }
        }

        public string HostEmail
        {
            get
            {
                return hostEmail;
            }

            set
            {
                hostEmail = value;
            }
        }

        public string HostPhoneNumber
        {
            get
            {
                return hostPhoneNumber;
            }

            set
            {
                hostPhoneNumber = value;
            }
        }

        public string VenueName
        {
            get
            {
                return venueName;
            }

            set
            {
                venueName = value;
            }
        }

        public string Address
        {
            get
            {
                return address;
            }

            set
            {
                address = value;
            }
        }

        public string Description
        {
            get
            {
                return description;
            }

            set
            {
                description = value;
            }
        }

        public string RegistrationURL
        {
            get
            {
                return registrationURL;
            }

            set
            {
                registrationURL = value;
            }
        }

        public string SubmitterName
        {
            get
            {
                return submitterName;
            }

            set
            {
                submitterName = value;
            }
        }

        public string SubmitterEmail
        {
            get
            {
                return submitterEmail;
            }

            set
            {
                submitterEmail = value;
            }
        }

        public DateTime Date
        {
            get
            {
                return date;
            }

            set
            {
                date = value;
            }
        }

        public DateTime StartTime
        {
            get
            {
                return startTime;
            }

            set
            {
                startTime = value;
            }
        }

        public DateTime EndTime
        {
            get
            {
                return endTime;
            }

            set
            {
                endTime = value;
            }
        }

        public bool AllDay
        {
            get
            {
                return allDay;
            }

            set
            {
                allDay = value;
            }
        }

        public EventState State
        {
            get
            {
                return state;
            }

            set
            {
                state = value;
            }
        }

    }

    /// <summary>
    /// EventState is an enumeration of states that an event can possibly be in. 
    /// Events can only exist in one state at a time.
    /// </summary>
    public enum EventState
    {
        SUBMITTED,
        PUBLISHED,
        DELETED,
    }

}