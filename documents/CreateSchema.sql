-- CREATE SCHEMA TEST
-- BY : ADAM BURTON

CREATE SCHEMA IF NOT EXISTS edsncalendar;

DROP TABLE IF EXISTS eventproperties;
DROP TABLE IF EXISTS property;
DROP TABLE IF EXISTS propertytype;
DROP TABLE IF EXISTS calendarevent;

CREATE TABLE propertytype
(
	iPropertyTypeId INT NOT NULL PRIMARY KEY AUTO_INCREMENT,
    vPropertyType VARCHAR(100),
    bActive BIT DEFAULT 1
);

CREATE TABLE property
(
	iPropertyId INT NOT NULL PRIMARY KEY AUTO_INCREMENT,
    iPropertyTypeId INT NOT NULL,
    vProperty VARCHAR(100),
    bActive BIT DEFAULT 1,
    FOREIGN KEY (iPropertyTypeId)
		REFERENCES propertytype(iPropertyTypeId)
        ON DELETE CASCADE
);

CREATE TABLE calendarevent
(
	iEventId INT NOT NULL PRIMARY KEY AUTO_INCREMENT,
    vEventTitle VARCHAR(255),
    dEventDate DATE,
    vStartTime VARCHAR(50),
    vEndTime VARCHAR(50),
    bAllDay BIT,
    vVenueName VARCHAR(255) NOT NULL,
    vAddress VARCHAR(255) NOT NULL,
    vDescription VARCHAR(1000) NOT NULL,
    vOrganizerName VARCHAR(100) NOT NULL,
    vOrganizerEmail VARCHAR(50) NOT NULL,
    vOrganizerPhoneNumber VARCHAR(20) NOT NULL,
    vOrganizerURL VARCHAR(255),
    vCost VARCHAR(50),
    vRegistrationURL VARCHAR(255),
    vSubmitterName VARCHAR(100),
    vSubmitterEmail VARCHAR(50),
    bPublished BIT,
    bActive BIT DEFAULT 0
);

CREATE TABLE eventproperties
(
	iEventPropertyId INT NOT NULL PRIMARY KEY AUTO_INCREMENT,
    iEventId INT NOT NULL,
    iPropertyId INT NOT NULL,
    FOREIGN KEY (iEventId)
		REFERENCES calendarevent(iEventId)
        ON DELETE CASCADE,
	FOREIGN KEY (iPropertyId)
		REFERENCES property(iPropertyId)
        ON DELETE CASCADE
);

INSERT INTO propertytype(vPropertyType)
VALUES("Categories"),("Tags"),("Region"),("Country"),("Programs");

INSERT INTO property(iPropertyTypeId,vProperty)
VALUES(1, "Movies"),(1,"Religion"),(2,"#Fitness"),(2,"#Community"),(3, "Hartford, Ct"),(4,"USA"),(4,"Canada"),(5,"Birthday");

INSERT INTO calendarevent(vEventTitle, dEventDate, vStartTime, vEndTime, bAllDay, vVenueName, vAddress, vDescription, vOrganizerName,
						   vOrganizerEmail, vOrganizerPhoneNumber, vOrganizerURL, vCost, vRegistrationURL, vSubmitterName, vSubmitterEmail)
VALUES("Adam's Test Event", "2016-11-15", "", "", 1, "Nowhere!", "Nowhere St, Nowhere, 06062", "This is my description here. Wow. Much description!", "Adam",
	   "AdamEmail@email.com", "999-999-9999", NULL, "FREE", NULL, "Adam", "AdamEmail@email.com");
       
INSERT INTO calendarevent(vEventTitle, dEventDate, vStartTime, vEndTime, bAllDay, vVenueName, vAddress, vDescription, vOrganizerName, vOrganizerEmail, vOrganizerPhoneNumber,vOrganizerURL, vCost, vRegistrationURL, vSubmitterName, vSubmitterEmail)VALUES('TestTitle','11/5/2016','','',1,'VenueName','Address25463636 346356457','Deescription blah blah blah','NameHere','EmailHur','','URL','','','','')