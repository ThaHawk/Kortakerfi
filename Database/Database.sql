-- =========== CREATE DATABASE ===========
DROP DATABASE IF EXISTS 2905962709_kortakerfi;
CREATE DATABASE 2905962709_kortakerfi;
USE 2905962709_kortakerfi;

-- =========== CREATE TABLES ===========
CREATE TABLE Personal
(
	SocialSecurityID VARCHAR(20) NOT NULL,
	Name VARCHAR(100) NOT NULL,
	Phone VARCHAR(20),
	Email VARCHAR(100),
	Comment VARCHAR(255),
	CONSTRAINT Personal_PK PRIMARY KEY(SocialSecurityID)
)ENGINE=InnoDB;

CREATE TABLE Membership
(
	MembershipID INT(11) NOT NULL AUTO_INCREMENT,
	SocialSecurityID VARCHAR(20) NOT NULL,
	MembershipType VARCHAR(100) NOT NULL,
	PassesRemaining INT(11),
	DueDate DATE,
 	LastPaidDate DATE NOT NULL,
 	SignUpDate DATE,
	CONSTRAINT Membership_PK PRIMARY KEY(MembershipID),
	CONSTRAINT Membership_Personal_FK FOREIGN KEY(SocialSecurityID) REFERENCES Personal(SocialSecurityID)
)ENGINE=InnoDB;

CREATE TABLE Visits
(
	ID INT(11) NOT NULL AUTO_INCREMENT,
	MembershipID INT(11) NOT NULL,
	CheckInDate TIMESTAMP,
	CONSTRAINT Visits_PK PRIMARY KEY(ID),
	CONSTRAINT Visits_Membership_FK FOREIGN KEY(MembershipID) REFERENCES Membership(MembershipID)
)ENGINE=InnoDB;