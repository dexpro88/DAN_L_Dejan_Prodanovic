--we create database  
CREATE DATABASE IdCardsDbase;
GO

use IdCardsDbase;

GO

 --we delete tables in case they exist
DROP TABLE IF EXISTS tblRECORD_OF_APPLICATIONS;
DROP TABLE IF EXISTS tblUSER;
DROP TABLE IF EXISTS tblLOCATION;
DROP TABLE IF EXISTS tblID_CARD;
DROP TABLE IF EXISTS tblCRIMINAL_CHARGES;

--we create table tblLOCATION
 CREATE TABLE tblLOCATION (
    LocationID int NOT NULL IDENTITY(1,1) PRIMARY KEY,
    Adress varchar(50),
	Place varchar(50),
	Country varchar(50)   
);

 --we create table tblID_CARD
 --RegistrationNumber has to be 9 characters long
 --IssueDate has to be before current date
 --ExpiryDate has to be after IssueDate
 CREATE TABLE tblID_CARD (
    ID_CardID int NOT NULL IDENTITY(1,1) PRIMARY KEY,
    RegistrationNumber varchar(50) CHECK (LEN(RegistrationNumber)=9)UNIQUE,
	IssueDate date CHECK (IssueDate<GETDATE()),    
    ExpiryDate date,
	IssueDateToPresent varchar(50),
    ExpiryDateToPresent varchar(50),
	Publisher varchar(50),
	CONSTRAINT CK_CmsSponsoredContents_DatumIsteka CHECK (ExpiryDate > IssueDate)    
);

--ALTER TABLE tblID_CARD
--ADD UNIQUE (RegistrationNumber);




--we create table tblCRIMINAL_CHARGES
CREATE TABLE tblCRIMINAL_CHARGES (
    CriminalChargesID int NOT NULL IDENTITY(1,1) PRIMARY KEY,
    Name varchar(50),
	Verbally bit		    
);

--we create table tblUser
--JMBG has to be 13 characters long
--DateOfBirth has to be at least 16 years ago
--Gender can be M or F or X
CREATE TABLE tblUser (
    UserID int NOT NULL IDENTITY(1,1) PRIMARY KEY,
    FirstName varchar(50),
	LastName varchar(50),
	JMBG varchar(13) UNIQUE CHECK (LEN(JMBG)=13 and ISNUMERIC(JMBG) = 1),
	DateOfBirth date CHECK(DateOfBirth<=GETDATE()-16),
	Gender char(1) CHECK (UPPER(Gender) = 'M' or UPPER(Gender) = 'F' or UPPER(Gender) = 'X'),    
	LocationID int FOREIGN KEY REFERENCES tblLOCATION(LocationID),
	ID_CardID int FOREIGN KEY REFERENCES tblID_CARD(ID_CardID) ON DELETE CASCADE NOT NULL 
);

 

--we create table tblRECORD_OF_APPLICATIONS
CREATE TABLE tblRECORD_OF_APPLICATIONS (
    RecordID int NOT NULL IDENTITY(1,1) PRIMARY KEY,
    CriminalChargesID int FOREIGN KEY REFERENCES tblCRIMINAL_CHARGES(CriminalChargesID) ON DELETE CASCADE,
	UserID int FOREIGN KEY REFERENCES tblUSER(UserID) ON DELETE CASCADE     	    
);

 
GO
 
 
GO
CREATE VIEW vwUser
AS

SELECT   dbo.tblLOCATION.Adress + ', '+dbo.tblLOCATION.Place  + ', ' +dbo.tblLOCATION.Country AS Location,
         dbo.tblUser.UserID, dbo.tblLOCATION.LocationID, dbo.tblID_CARD.ID_CardID, dbo.tblID_CARD.RegistrationNumber,
         dbo.tblUser.FirstName, dbo.tblUser.LastName, dbo.tblID_CARD.ExpiryDate, dbo.tblID_CARD.IssueDate,
		 dbo.tblUser.JMBG, dbo.tblUser.Gender,dbo.tblUser.DateOfBirth,dbo.tblID_CARD.ExpiryDateToPresent,
		 dbo.tblID_CARD.IssueDateToPresent
FROM            dbo.tblID_CARD INNER JOIN
            dbo.tblUser ON dbo.tblID_CARD.ID_CardID = dbo.tblUser.ID_CardID INNER JOIN
            dbo.tblLOCATION ON dbo.tblUser.LocationID = dbo.tblLOCATION.LocationID
GO


CREATE VIEW vwLOCATION
AS

SELECT LocationID, Adress + ', '+ Place + ',' + Country AS Location
FROM dbo.tblLOCATION


GO
CREATE VIEW vwIDCard
AS
SELECT  dbo.tblUser.FirstName, dbo.tblUser.LastName, dbo.tblUser.JMBG, dbo.tblUser.Gender, 
        dbo.tblID_CARD.Publisher, dbo.tblID_CARD.RegistrationNumber,
        dbo.tblUser.LocationID, dbo.tblID_CARD.ID_CardID,dbo.tblUser.DateOfBirth
FROM    dbo.tblID_CARD INNER JOIN
            dbo.tblUser ON dbo.tblID_CARD.ID_CardID = dbo.tblUser.ID_CardID
GO


INSERT INTO tblLOCATION(Adress,Place,Country)VALUES('Kotorska 15','Novi Sad','Serbia');
INSERT INTO tblLOCATION(Adress,Place,Country)VALUES('Cara Dusana 45','Novi Sad','Serbia');
INSERT INTO tblLOCATION(Adress,Place,Country)VALUES('Futoska 54','Novi Sad','Serbia');


INSERT INTO tblID_CARD(RegistrationNumber,IssueDate,ExpiryDate,Publisher)
VALUES('123498548','2015-11-11','2025-11-11','SUP');
INSERT INTO tblID_CARD(RegistrationNumber,IssueDate,ExpiryDate,Publisher)
VALUES('313498025','2017-11-11','2027-11-11','SUP');
INSERT INTO tblID_CARD(RegistrationNumber,IssueDate,ExpiryDate,Publisher)
VALUES('908765678','2017-11-11','3000-1-1','SUP');

INSERT INTO tblUser(FirstName,LastName,JMBG,DateOfBirth,Gender,LocationID,ID_CardID)
VALUES('Milan','Milic','1111978123989','1978-11-11','m',1,1);
INSERT INTO tblUser(FirstName,LastName,JMBG,DateOfBirth,Gender,LocationID,ID_CardID)
VALUES('Pera','Peric','1111948123949','1948-11-11','m',2,2);
INSERT INTO tblUser(FirstName,LastName,JMBG,DateOfBirth,Gender,LocationID,ID_CardID)
VALUES('Jovan','Jovic','1111988123934','1988-11-11','m',3,3);
