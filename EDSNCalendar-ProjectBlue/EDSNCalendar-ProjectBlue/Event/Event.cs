using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

namespace EDSNCalendar_ProjectBlue.Event
{
    /// <summary>
    /// Event class represents any particular Event that has 
    /// been submitted, verified, or removed from the Calendar.
    /// </summary>
    public class Event
    {
        /// <summary>
        /// Int Primary Key ID of event.
        /// </summary>
        private int eventId;

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
        /// The state of the event. Refers to whether the event has been submitted or published.
        /// </summary>
        private bool isPublished;

        /// <summary>
        /// An active event will be shown to users/administartors, while an inactive event won't be.
        /// </summary>
        private bool isActive;

        /// <summary>
        /// Constructor that initializes an event and get an existing event's data
        /// </summary>
        /// <param name="iEventId"></param>
        public Event(int iEventId)
        {
            DataTable dtEvent = SQLData.SQLQueries.GetEvent(iEventId);
            this.eventId = (int)dtEvent.Rows[0]["iEventId"];
            this.title = dtEvent.Rows[0]["vEventTitle"].ToString();
            this.hostName = dtEvent.Rows[0]["vOrganizerName"].ToString();
            this.hostEmail = dtEvent.Rows[0]["vOrganizerEmail"].ToString();
            this.hostPhoneNumber = dtEvent.Rows[0]["vOrganizerPhoneNumber"].ToString();
            this.venueName = dtEvent.Rows[0]["vVenueName"].ToString();
            this.address = dtEvent.Rows[0]["vAddress"].ToString();
            this.description = dtEvent.Rows[0]["vDescription"].ToString();
            this.registrationURL = dtEvent.Rows[0]["vRegistrationURL"].ToString();
            this.submitterName = dtEvent.Rows[0]["vSubmitterName"].ToString();
            this.submitterEmail = dtEvent.Rows[0]["vSubmitterEmail"].ToString();
            this.date = DateTime.Parse(dtEvent.Rows[0]["dEventDate"].ToString());
            if(!String.IsNullOrWhiteSpace(dtEvent.Rows[0]["vStartTime"].ToString()))
            {
                this.startTime = DateTime.Parse(dtEvent.Rows[0]["vStartTime"].ToString());
            }
            if (!String.IsNullOrWhiteSpace(dtEvent.Rows[0]["vStartTime"].ToString()))
            {
                this.endTime = DateTime.Parse(dtEvent.Rows[0]["vEndTime"].ToString());
            }
            this.allDay = (bool)dtEvent.Rows[0]["bAllDay"];
            this.isPublished = (bool)dtEvent.Rows[0]["bPublished"];
            this.isActive = (bool)dtEvent.Rows[0]["bActive"];
        }

        /// <summary>
        /// Constructor that intializes a new event object
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
            this.isPublished = false;
            this.isActive = true;
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

        public bool IsPublished
        {
            get
            {
                return isPublished;
            }

            set
            {
                isPublished = value;
            }
        }

        public bool IsActive
        {
            get
            {
                return isActive;
            }

            set
            {
                isActive = value;
            }
        }

    }

}