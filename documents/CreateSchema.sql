-- CREATE SCHEMA TEST
-- BY : ADAM BURTON
-- CREATE SCHEMA IF NOT EXISTS edsncalendar;

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
    dEventDate VARCHAR(50),
    dEndDate VARCHAR(50),
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
    dtPostDate DATETIME DEFAULT NOW(),
    dtPublishDate DATETIME DEFAULT NULL,
    bPublished BIT DEFAULT 0,
    bActive BIT DEFAULT 1
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
VALUES('Categories'),('Tags'),('Region'),('Country'),('Programs');

INSERT INTO property(iPropertyTypeId,vProperty)
VALUES(1, 'Movies'),(1,'Religion'),(2,'#Fitness'),(2,'#Community'),(3, 'Hartford, Ct'),(4,'USA'),(4,'Canada'),(5,'Birthday');

INSERT INTO calendarevent(vEventTitle, dEventDate, dEndDate, vStartTime, vEndTime, bAllDay, vVenueName, vAddress, vDescription, vOrganizerName,
						   vOrganizerEmail, vOrganizerPhoneNumber, vOrganizerURL, vCost, vRegistrationURL, vSubmitterName, vSubmitterEmail, dtPublishDate ,bPublished, bActive)
VALUES('Submitted Event1(StartFinish)(Active)', '2016-11-8', '2016-11-8', '2016-11-8T13:00:00', '2016-11-8T15:00:00', 0, 'Nowhere!', 'Nowhere St, Nowhere, 06062', 'This is my description here. Wow. Much description!', 'Adam',
	   'FakeEmail@email.com', '999-999-9999', NULL, 'FREE', NULL, 'Person1', 'AdamEmail@email.com', NULL,0, 1),
	  ('Submitted Event2(AllDay)(Active)', '2016-11-27', '2016-11-27', NULL, NULL, 1, 'Nowhere!', 'Nowhere St, Nowhere, 06062', 'This is my description here. Wow. Much description!', 'Adam',
	   'FakeEmail@email.com', '999-999-9999', NULL, 'FREE', NULL, 'Person2', 'AdamEmail@email.com', NULL,0, 1),
	  ('Submitted Event3(StartFinish)(Inactive)', '2016-11-20', '2016-11-20', '2016-11-20T8:00:00', '2016-11-20T11:00:00', 0, 'Nowhere!', 'Nowhere St, Nowhere, 06062', 'This is my description here. Wow. Much description!', 'Adam',
	   'FakeEmail@email.com', '999-999-9999', NULL, 'FREE', NULL, 'Person3', 'AdamEmail@email.com', NULL,0, 0),
	  ('Submitted Event4(AllDay)(Inactive)', '2016-11-15', '2016-11-15', NULL, NULL, 1, 'Nowhere!', 'Nowhere St, Nowhere, 06062', 'This is my description here. Wow. Much description!', 'Adam',
	   'FakeEmail@email.com', '999-999-9999', NULL, 'FREE', NULL, 'Person4', 'AdamEmail@email.com', NULL,0, 0),
	  ('Published Event1(StartFinish)(Active)', '2016-11-4', '2016-11-4', '2016-11-4T12:00:00', '2016-11-4T16:00:00', 0, 'Nowhere!', 'Nowhere St, Nowhere, 06062', 'This is my description here. Wow. Much description!', 'Adam',
	   'FakeEmail@email.com', '999-999-9999', NULL, 'FREE', NULL, 'Person5', 'AdamEmail@email.com', '2016-11-30',1, 1),
	  ('Published Event2(AllDay)(Active)', '2016-11-24', '2016-11-24', NULL, NULL, 1, 'Nowhere!', 'Nowhere St, Nowhere, 06062', 'This is my description here. Wow. Much description!', 'Adam',
	   'FakeEmail@email.com', '999-999-9999', NULL, 'FREE', NULL, 'Person6', 'AdamEmail@email.com', '2016-11-30',1, 1),
	  ('Published Event3(StartFinish)(Inactive)', '2016-11-30', '2016-11-30', '2016-11-30T20:00:00', '2016-11-30T23:00:00', 0, 'Nowhere!', 'Nowhere St, Nowhere, 06062', 'This is my description here. Wow. Much description!', 'Adam',
	   'FakeEmail@email.com', '999-999-9999', NULL, 'FREE', NULL, 'Person7', 'AdamEmail@email.com', '2016-11-30',1, 0),
	  ('Published Event4(AllDay)(Inactive)', '2016-11-1', '2016-11-1', NULL, NULL, 1, 'Nowhere!', 'Nowhere St, Nowhere, 06062', 'This is my description here. Wow. Much description!', 'Adam',
	   'FakeEmail@email.com', '999-999-9999', NULL, 'FREE', NULL, 'Person8', 'AdamEmail@email.com', '2016-11-30',1, 0);
       

