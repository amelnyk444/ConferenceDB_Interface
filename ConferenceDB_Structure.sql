-- Database
CREATE DATABASE Conference
ON
(NAME = Conference_DB,
	FILENAME = 'C:\Program Files\Microsoft SQL Server\MSSQL13.MSSQLSERVER\MSSQL\DATA\conferencedat.mdf',
	SIZE = 10,
	MAXSIZE = UNLIMITED,
	FILEGROWTH = 5)
	LOG ON
	(NAME = ConferenceDB_Log,
		FILENAME = 'D:\SQL_LOGS\conferencelog.ldf',
		SIZE = 5MB,
		MAXSIZE = UNLIMITED,
		FILEGROWTH = 2MB);
-- Table structure for tables
CREATE TABLE Conferences(
ID INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
incDate DATE, finDate DATE,
confName VARCHAR(50),
building VARCHAR(50));

CREATE TABLE Sections(
ID INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
sectName VARCHAR(20),
chairman VARCHAR(20),
room VARCHAR(20),
confID INT NOT NULL FOREIGN KEY REFERENCES Conferences(ID)
CONSTRAINT sectRoom UNIQUE (room));

CREATE TABLE Speeches(
ID INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
topic VARCHAR(20),
spDate DATE,
incTime TIME,finTime TIME,
sectID INT NOT NULL FOREIGN KEY REFERENCES Sections(ID));

CREATE TABLE Speakers(
ID INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
acDegree VARCHAR(20),
acStatus VARCHAR(20),
workplace VARCHAR(20),
position VARCHAR(20),
biography VARCHAR(100));

CREATE TABLE Equipment(
eqName VARCHAR(50) NOT NULL PRIMARY KEY);

CREATE TABLE EquipmentForSpeech(
equipmentName VARCHAR(50) NOT NULL FOREIGN KEY REFERENCES Equipment(eqName),
speechID INT NOT NULL FOREIGN KEY REFERENCES Speeches(ID));

CREATE TABLE SpeakersAtSpeech(
speakerID INT  NOT NULL FOREIGN KEY REFERENCES Speakers(ID),
speechID INT  NOT NULL FOREIGN KEY REFERENCES Speeches(ID));

ALTER TABLE Speakers
ADD spName VARCHAR(20);

ALTER TABLE Speakers
ADD spForname VARCHAR(20);

CREATE TABLE ConferenceParticipants(
participantID INT NOT NULL FOREIGN KEY REFERENCES Speakers(ID),
ConferenceID INT NOT NULL FOREIGN KEY REFERENCES Conferences(ID))
--Triggers
CREATE TRIGGER SpeakersInSections
ON SpeakersAtSpeech
INSTEAD OF INSERT, UPDATE
AS
--If speaker is already performing in another section today, he can`t perform in another sections
IF EXISTS (SELECT 1 FROM
					(SELECT * FROM 
					 SpeakersAtSpeech JOIN Speeches ON SpeakersAtSpeech.speechID = Speeches.ID) AS baseTable,
					(SELECT * FROM
					 inserted JOIN Speeches ON inserted.speechID = Speeches.ID) AS tempTable
					 WHERE baseTable.speakerID = tempTable.speakerID AND baseTable.spDate = tempTable.spDate AND
					 baseTable.sectID <> tempTable.sectID)
BEGIN
	RAISERROR('This speaker is already performing in another section today',10,1)
END
ELSE 
	INSERT INTO SpeakersAtSpeech
	VALUES((SELECT speakerID FROM inserted),(SELECT speechID FROM inserted))
GO

CREATE TRIGGER UniqueRooms
ON Speeches
INSTEAD OF INSERT, UPDATE
AS
-- You can`t use busy room
IF EXISTS(SELECT 1
FROM (SELECT Sections.ID AS sctID,Speeches.ID as spchID, spDate,incTime,finTime FROM Sections JOIN Speeches ON Sections.ID = Speeches.sectID) AS t1,
(SELECT Sections.ID AS sctID,inserted.ID as spchID, spDate,incTime,finTime FROM Sections JOIN inserted ON Sections.ID = inserted.sectID) AS t2
WHERE t1.sctID = t2.sctID AND t1.spDate=t2.spDate AND (t2.incTime BETWEEN t1.incTime AND t1.finTime OR t2.finTime BETWEEN t1.incTime AND t1.finTime)
)
BEGIN
	RAISERROR('The room is busy at this time',10,1)
END
ELSE
	INSERT INTO Speeches
		SELECT topic,spDate,incTime,finTime,sectID FROM inserted
GO
