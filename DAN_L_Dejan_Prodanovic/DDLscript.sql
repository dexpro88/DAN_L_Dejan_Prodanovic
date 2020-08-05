--we create database  
CREATE DATABASE AudioPlayerData;
GO

use AudioPlayerData;

GO

 --we delete tables in case they exist
DROP TABLE IF EXISTS tblSong;
DROP TABLE IF EXISTS tblUser;

CREATE TABLE tblUser (
    UserID int NOT NULL IDENTITY(1,1) PRIMARY KEY,
    UserName varchar(50),
	UserPassword varchar(50)
	
); 
 
CREATE TABLE tblSong (
    SongID int NOT NULL IDENTITY(1,1) PRIMARY KEY,
    SongName varchar(50),
	Author varchar(50),
    SongLength varchar(50),
     UserID int FOREIGN KEY REFERENCES tblUser(UserID) 

	
);




 
 