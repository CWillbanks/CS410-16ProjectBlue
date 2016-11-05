-- CREATE SCHEMA TEST
-- BY : ADAM BURTON

CREATE SCHEMA IF NOT EXISTS edsncalendar;

DROP TABLE IF EXISTS Tags;
CREATE TABLE Tags
(
	iTagId INT NOT NULL PRIMARY KEY AUTO_INCREMENT,
    vTag VARCHAR(100),
	bActive BIT DEFAULT 1
);

DROP TABLE IF EXISTS Categories;
CREATE TABLE Categories
(
	iCategoryId INT NOT NULL PRIMARY KEY AUTO_INCREMENT,
    vCategory VARCHAR(100),
	bActive BIT DEFAULT 1
);

INSERT INTO CATEGORIES(vCategory)
VALUES("Movie"),("Religion"),("Soca");