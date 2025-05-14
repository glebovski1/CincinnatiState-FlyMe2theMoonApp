/******************************************************************************************
  FlyMe2theMoon – FULL BUILD • SEED • STORED-PROC SCRIPT

  Gleb Usov 

******************************************************************************************/


/*=========  GLOBAL  ===============================================================*/
USE master;
IF DB_ID(N'dbFlyMe2theMoon') IS NULL
    CREATE DATABASE dbFlyMe2theMoon;
GO
USE dbFlyMe2theMoon;
GO
SET NOCOUNT ON; SET ANSI_NULLS ON; SET QUOTED_IDENTIFIER ON;

/*=========  PURGE  ================================================================*/
DECLARE @p SYSNAME;
DECLARE cur CURSOR FOR
    SELECT name FROM sys.objects WHERE type = 'P' AND name LIKE 'usp_%';
OPEN cur; FETCH NEXT FROM cur INTO @p;
WHILE @@FETCH_STATUS = 0
BEGIN EXEC ('DROP PROCEDURE dbo.[' + @p + ']');
      FETCH NEXT FROM cur INTO @p;
END
CLOSE cur; DEALLOCATE cur;

IF OBJECT_ID('dbo.TPilotFlights')                  IS NOT NULL DROP TABLE dbo.TPilotFlights;
IF OBJECT_ID('dbo.TAttendantFlights')              IS NOT NULL DROP TABLE dbo.TAttendantFlights;
IF OBJECT_ID('dbo.TMaintenanceMaintenanceWorkers') IS NOT NULL DROP TABLE dbo.TMaintenanceMaintenanceWorkers;
IF OBJECT_ID('dbo.TFlightPassengers')              IS NOT NULL DROP TABLE dbo.TFlightPassengers;

IF OBJECT_ID('dbo.TEmployees')          IS NOT NULL DROP TABLE dbo.TEmployees;
IF OBJECT_ID('dbo.TPassengers')         IS NOT NULL DROP TABLE dbo.TPassengers;
IF OBJECT_ID('dbo.TPilots')             IS NOT NULL DROP TABLE dbo.TPilots;
IF OBJECT_ID('dbo.TAttendants')         IS NOT NULL DROP TABLE dbo.TAttendants;
IF OBJECT_ID('dbo.TMaintenanceWorkers') IS NOT NULL DROP TABLE dbo.TMaintenanceWorkers;

IF OBJECT_ID('dbo.TFlights')      IS NOT NULL DROP TABLE dbo.TFlights;
IF OBJECT_ID('dbo.TMaintenances') IS NOT NULL DROP TABLE dbo.TMaintenances;
IF OBJECT_ID('dbo.TPlanes')       IS NOT NULL DROP TABLE dbo.TPlanes;
IF OBJECT_ID('dbo.TPlaneTypes')   IS NOT NULL DROP TABLE dbo.TPlaneTypes;
IF OBJECT_ID('dbo.TPilotRoles')   IS NOT NULL DROP TABLE dbo.TPilotRoles;
IF OBJECT_ID('dbo.TAirports')     IS NOT NULL DROP TABLE dbo.TAirports;
IF OBJECT_ID('dbo.TStates')       IS NOT NULL DROP TABLE dbo.TStates;

/*=========  TABLES  ===============================================================*/
CREATE TABLE dbo.TPassengers(
 intPassengerID INT IDENTITY(1,1) PRIMARY KEY,
 strLoginID      VARCHAR(255) NOT NULL,
 strPassword     VARCHAR(255) NOT NULL,
 strFirstName    VARCHAR(255) NOT NULL,
 strLastName     VARCHAR(255) NOT NULL,
 strAddress      VARCHAR(255) NOT NULL,
 strCity         VARCHAR(255) NOT NULL,
 intStateID      INT NOT NULL,
 strZip          VARCHAR(255) NOT NULL,
 strPhoneNumber  VARCHAR(255) NOT NULL,
 strEmail        VARCHAR(255) NOT NULL,
 dtDateOfBirth   DATE NOT NULL
);

CREATE TABLE dbo.TPilots(
 intPilotID INT IDENTITY(1,1) PRIMARY KEY,
 strFirstName        VARCHAR(255) NOT NULL,
 strLastName         VARCHAR(255) NOT NULL,
 strEmployeeID       VARCHAR(255) NOT NULL,   -- badge
 dtmDateOfHire       DATETIME NOT NULL,
 dtmDateOfTermination DATETIME NOT NULL,
 dtmDateOfLicense    DATETIME NOT NULL,
 intPilotRoleID      INT NOT NULL
);

CREATE TABLE dbo.TAttendants(
 intAttendantID INT IDENTITY(1,1) PRIMARY KEY,
 strFirstName        VARCHAR(255) NOT NULL,
 strLastName         VARCHAR(255) NOT NULL,
 strEmployeeID       VARCHAR(255) NOT NULL,
 dtmDateOfHire       DATETIME NOT NULL,
 dtmDateOfTermination DATETIME NOT NULL
);

CREATE TABLE dbo.TMaintenanceWorkers(
 intMaintenanceWorkerID INT IDENTITY(1,1) PRIMARY KEY,
 strFirstName            VARCHAR(255) NOT NULL,
 strLastName             VARCHAR(255) NOT NULL,
 strEmployeeID           VARCHAR(255) NOT NULL,
 dtmDateOfHire           DATETIME NOT NULL,
 dtmDateOfTermination    DATETIME NOT NULL,
 dtmDateOfCertification  DATETIME NOT NULL
);

CREATE TABLE dbo.TStates(
 intStateID INT IDENTITY(1,1) PRIMARY KEY,
 strState   VARCHAR(255) NOT NULL
);

CREATE TABLE dbo.TFlights(
 intFlightID INT IDENTITY(1,1) PRIMARY KEY,
 strFlightNumber   VARCHAR(255) NOT NULL,
 dtmFlightDate     DATETIME NOT NULL,
 dtmTimeofDeparture TIME NOT NULL,
 dtmTimeOfLanding   TIME NOT NULL,
 intFromAirportID  INT NOT NULL,
 intToAirportID    INT NOT NULL,
 intMilesFlown     INT NOT NULL,
 intPlaneID        INT NOT NULL
);

CREATE TABLE dbo.TMaintenances(
 intMaintenanceID INT IDENTITY(1,1) PRIMARY KEY,
 strWorkCompleted  VARCHAR(8000) NOT NULL,
 dtmMaintenanceDate DATETIME NOT NULL,
 intPlaneID        INT NOT NULL
);

CREATE TABLE dbo.TPlanes(
 intPlaneID INT IDENTITY(1,1) PRIMARY KEY,
 strPlaneNumber VARCHAR(255) NOT NULL,
 intPlaneTypeID INT NOT NULL
);

CREATE TABLE dbo.TPlaneTypes(
 intPlaneTypeID INT IDENTITY(1,1) PRIMARY KEY,
 strPlaneType   VARCHAR(255) NOT NULL
);

CREATE TABLE dbo.TPilotRoles(
 intPilotRoleID INT IDENTITY(1,1) PRIMARY KEY,
 strPilotRole   VARCHAR(255) NOT NULL
);

CREATE TABLE dbo.TAirports(
 intAirportID INT IDENTITY(1,1) PRIMARY KEY,
 strAirportCity VARCHAR(255) NOT NULL,
 strAirportCode VARCHAR(255) NOT NULL
);

CREATE TABLE dbo.TPilotFlights(
 intPilotFlightID INT IDENTITY(1,1) PRIMARY KEY,
 intPilotID INT NOT NULL,
 intFlightID INT NOT NULL
);

CREATE TABLE dbo.TAttendantFlights(
 intAttendantFlightID INT IDENTITY(1,1) PRIMARY KEY,
 intAttendantID INT NOT NULL,
 intFlightID    INT NOT NULL
);

CREATE TABLE dbo.TFlightPassengers(
 intFlightPassengerID INT IDENTITY(1,1) PRIMARY KEY,
 intFlightID    INT NOT NULL,
 intPassengerID INT NOT NULL,
 strSeat        VARCHAR(255) NOT NULL,
 decFlightCost  DECIMAL(8,2) NOT NULL
);

CREATE TABLE dbo.TMaintenanceMaintenanceWorkers(
 intMaintenanceMaintenanceWorkerID INT IDENTITY(1,1) PRIMARY KEY,
 intMaintenanceID INT NOT NULL,
 intMaintenanceWorkerID INT NOT NULL,
 intHours INT NOT NULL
);

CREATE TABLE dbo.TEmployees(
 intEmployeeAccountID INT IDENTITY(1,1) PRIMARY KEY,
 strEmployeeLoginID  VARCHAR(255) NOT NULL,
 strEmployeePassword VARCHAR(255) NOT NULL,
 strEmployeeRole     VARCHAR(10)  NOT NULL CHECK (strEmployeeRole IN ('Admin','Pilot','Attendant')),
 intEmployeeID       INT NULL,
 CONSTRAINT UQ_Login UNIQUE (strEmployeeLoginID),
 CONSTRAINT UQ_Pwd   UNIQUE (strEmployeePassword)
);

GO
/*=========  FK CONSTRAINTS  =========================================================*/

/*--- TPassengers -------------------------------------------------------------------*/
ALTER TABLE dbo.TPassengers
    ADD CONSTRAINT FK_TPassengers_State
        FOREIGN KEY (intStateID)
        REFERENCES dbo.TStates(intStateID)
        ON DELETE CASCADE;

/*--- TFlightPassengers --------------------------------------------------------------*/
ALTER TABLE dbo.TFlightPassengers
    ADD CONSTRAINT FK_TFlightPassengers_Passenger
        FOREIGN KEY (intPassengerID)
        REFERENCES dbo.TPassengers(intPassengerID)
        ON DELETE CASCADE;

ALTER TABLE dbo.TFlightPassengers
    ADD CONSTRAINT FK_TFlightPassengers_Flight
        FOREIGN KEY (intFlightID)
        REFERENCES dbo.TFlights(intFlightID)
        ON DELETE CASCADE;

/*--- TFlights -----------------------------------------------------------------------*/
ALTER TABLE dbo.TFlights
    ADD CONSTRAINT FK_TFlights_Plane
        FOREIGN KEY (intPlaneID)
        REFERENCES dbo.TPlanes(intPlaneID)
        ON DELETE CASCADE;

ALTER TABLE dbo.TFlights
    ADD CONSTRAINT FK_TFlights_FromAirport
        FOREIGN KEY (intFromAirportID)
        REFERENCES dbo.TAirports(intAirportID)
        ON DELETE CASCADE;

ALTER TABLE dbo.TFlights
    ADD CONSTRAINT FK_TFlights_ToAirport
        FOREIGN KEY (intToAirportID)
        REFERENCES dbo.TAirports(intAirportID)
        ON DELETE NO ACTION;

/*--- TPilotFlights ------------------------------------------------------------------*/
ALTER TABLE dbo.TPilotFlights
    ADD CONSTRAINT FK_TPilotFlights_Pilot
        FOREIGN KEY (intPilotID)
        REFERENCES dbo.TPilots(intPilotID)
        ON DELETE CASCADE;

ALTER TABLE dbo.TPilotFlights
    ADD CONSTRAINT FK_TPilotFlights_Flight
        FOREIGN KEY (intFlightID)
        REFERENCES dbo.TFlights(intFlightID)
        ON DELETE CASCADE;

/*--- TAttendantFlights --------------------------------------------------------------*/
ALTER TABLE dbo.TAttendantFlights
    ADD CONSTRAINT FK_TAttendantFlights_Attendant
        FOREIGN KEY (intAttendantID)
        REFERENCES dbo.TAttendants(intAttendantID)
        ON DELETE CASCADE;

ALTER TABLE dbo.TAttendantFlights
    ADD CONSTRAINT FK_TAttendantFlights_Flight
        FOREIGN KEY (intFlightID)
        REFERENCES dbo.TFlights(intFlightID)
        ON DELETE CASCADE;

/*--- TPilots ------------------------------------------------------------------------*/
ALTER TABLE dbo.TPilots
    ADD CONSTRAINT FK_TPilots_Role
        FOREIGN KEY (intPilotRoleID)
        REFERENCES dbo.TPilotRoles(intPilotRoleID)
        ON DELETE CASCADE;

/*--- TPlanes ------------------------------------------------------------------------*/
ALTER TABLE dbo.TPlanes
    ADD CONSTRAINT FK_TPlanes_Type
        FOREIGN KEY (intPlaneTypeID)
        REFERENCES dbo.TPlaneTypes(intPlaneTypeID)
        ON DELETE CASCADE;

/*--- TMaintenances ------------------------------------------------------------------*/
ALTER TABLE dbo.TMaintenances
    ADD CONSTRAINT FK_TMaintenances_Plane
        FOREIGN KEY (intPlaneID)
        REFERENCES dbo.TPlanes(intPlaneID)
        ON DELETE CASCADE;

/*--- TMaintenanceMaintenanceWorkers -------------------------------------------------*/
ALTER TABLE dbo.TMaintenanceMaintenanceWorkers
    ADD CONSTRAINT FK_TMMW_Maintenance
        FOREIGN KEY (intMaintenanceID)
        REFERENCES dbo.TMaintenances(intMaintenanceID)
        ON DELETE CASCADE;

ALTER TABLE dbo.TMaintenanceMaintenanceWorkers
    ADD CONSTRAINT FK_TMMW_Worker
        FOREIGN KEY (intMaintenanceWorkerID)
        REFERENCES dbo.TMaintenanceWorkers(intMaintenanceWorkerID)
        ON DELETE CASCADE;


/*=========  DATA SEED  ==============================================================*/
SET IDENTITY_INSERT dbo.TStates ON;
INSERT INTO dbo.TStates (intStateID,strState)
VALUES (1,'Ohio'),(2,'Kentucky'),(3,'Indiana');
SET IDENTITY_INSERT dbo.TStates OFF;

SET IDENTITY_INSERT dbo.TPilotRoles ON;
INSERT INTO dbo.TPilotRoles (intPilotRoleID,strPilotRole)
VALUES (1,'Co-Pilot'),(2,'Captain');
SET IDENTITY_INSERT dbo.TPilotRoles OFF;

SET IDENTITY_INSERT dbo.TPlaneTypes ON;
INSERT INTO dbo.TPlaneTypes (intPlaneTypeID,strPlaneType)
VALUES (1,'Airbus A350'),(2,'Boeing 747-8'),(3,'Boeing 767-300F');
SET IDENTITY_INSERT dbo.TPlaneTypes OFF;

SET IDENTITY_INSERT dbo.TPlanes ON;
INSERT INTO dbo.TPlanes (intPlaneID,strPlaneNumber,intPlaneTypeID)
VALUES (1,'4X887G',1),(2,'5HT78F',2),(3,'5TYY65',2),
       (4,'4UR522',1),(5,'6OP3PK',3),(6,'67TYHH',3);
SET IDENTITY_INSERT dbo.TPlanes OFF;

SET IDENTITY_INSERT dbo.TAirports ON;
INSERT INTO dbo.TAirports (intAirportID,strAirportCity,strAirportCode)
VALUES (1,'Cincinnati','CVG'),(2,'Miami','MIA'),(3,'Ft. Meyer','RSW'),
       (4,'Louisville','SDF'),(5,'Denver','DEN'),(6,'Orlando','MCO');
SET IDENTITY_INSERT dbo.TAirports OFF;

SET IDENTITY_INSERT dbo.TPassengers ON;
INSERT INTO dbo.TPassengers (intPassengerID,strLoginID,strPassword,strFirstName,strLastName,
 strAddress,strCity,intStateID,strZip,strPhoneNumber,strEmail,dtDateOfBirth) VALUES
 (1,'Knelly111','111','Knelly','Nervious','321 Elm St.','Cincinnati',1,'45201','5135553333','nnelly@gmail.com','1985-03-14'),
 (2,'Orville111','222','Orville','Waite','987 Oak St.','Cleveland',1,'45218','5135556333','owright@gmail.com','1990-07-22'),
 (3,'Eileen111','333','Eileen','Awnewe','1569 Windisch Rd.','Dayton',1,'45069','5135555333','eonewe1@yahoo.com','1978-11-05'),
 (4,'Bob111','444','Bob','Eninocean','44561 Oak Ave.','Florence',2,'45246','8596663333','bobenocean@gmail.com','1982-12-30'),
 (5,'Ware111','555','Ware','Hyjeked','44881 Pine Ave.','Aurora',3,'45546','2825553333','Hyjekedohmy@gmail.com','1995-06-17'),
 (6,'Kay111','666','Kay','Oss','4484 Bushfield Ave.','Lawrenceburg',3,'45546','2825553333','wehavekayoss@gmail.com','1976-09-09');
SET IDENTITY_INSERT dbo.TPassengers OFF;

SET IDENTITY_INSERT dbo.TPilots ON;
INSERT INTO dbo.TPilots (intPilotID,strFirstName,strLastName,strEmployeeID,dtmDateOfHire,
 dtmDateOfTermination,dtmDateOfLicense,intPilotRoleID) VALUES
 (1,'Tip','Seenow','12121','2015-01-01','2099-01-01','2014-12-01',1),
 (2,'Ima','Soring','13322','2016-01-01','2099-01-01','2015-12-01',1),
 (3,'Hugh','Encharge','16666','2017-01-01','2099-01-01','2016-12-01',2),
 (4,'Iwanna','Knapp','17676','2014-01-01','2015-01-01','2013-12-01',1),
 (5,'Rose','Ennair','19909','2012-01-01','2099-01-01','2011-12-01',2);
SET IDENTITY_INSERT dbo.TPilots OFF;

SET IDENTITY_INSERT dbo.TAttendants ON;
INSERT INTO dbo.TAttendants (intAttendantID,strFirstName,strLastName,strEmployeeID,
 dtmDateOfHire,dtmDateOfTermination) VALUES
 (1,'Miller','Tyme','22121','2015-01-01','2099-01-01'),
 (2,'Sherley','Ujest','23322','2016-01-01','2099-01-01'),
 (3,'Buhh','Biy','26666','2017-01-01','2099-01-01'),
 (4,'Myles','Amanie','27676','2014-01-01','2015-01-01'),
 (5,'Walker','Toexet','29909','2012-01-01','2099-01-01');
SET IDENTITY_INSERT dbo.TAttendants OFF;

SET IDENTITY_INSERT dbo.TMaintenanceWorkers ON;
INSERT INTO dbo.TMaintenanceWorkers (intMaintenanceWorkerID,strFirstName,strLastName,strEmployeeID,
 dtmDateOfHire,dtmDateOfTermination,dtmDateOfCertification) VALUES
 (1,'Gressy','Nuckles','32121','2015-01-01','2099-01-01','2014-12-01'),
 (2,'Bolt','Izamiss','33322','2016-01-01','2099-01-01','2015-12-01'),
 (3,'Sharon','Urphood','36666','2017-01-01','2099-01-01','2016-12-01'),
 (4,'Ides','Racrozed','37676','2014-01-01','2015-01-01','2013-12-01');
SET IDENTITY_INSERT dbo.TMaintenanceWorkers OFF;

SET IDENTITY_INSERT dbo.TMaintenances ON;
INSERT INTO dbo.TMaintenances (intMaintenanceID,strWorkCompleted,dtmMaintenanceDate,intPlaneID) VALUES
 (1,'Fixed Wing','2022-01-01',1),(2,'Repaired Flat Tire','2022-03-01',2),
 (3,'Added Wiper Fluid','2022-04-01',3),(4,'Tightened Engine to Wing','2022-05-01',2),
 (5,'100,000 mile checkup','2022-03-10',4),(6,'Replaced Loose Door','2022-04-10',6),
 (7,'Trapped Raccoon in Cargo Hold','2022-05-01',6);
SET IDENTITY_INSERT dbo.TMaintenances OFF;

SET IDENTITY_INSERT dbo.TFlights ON;
INSERT INTO dbo.TFlights (intFlightID,dtmFlightDate,strFlightNumber,dtmTimeofDeparture,dtmTimeOfLanding,
 intFromAirportID,intToAirportID,intMilesFlown,intPlaneID) VALUES
 (1,'2022-04-01','111','10:00','12:00',1,2,1200,2),
 (2,'2022-04-04','222','13:00','15:00',1,3,1000,2),
 (3,'2022-04-05','333','15:00','17:00',1,5,1200,3),
 (4,'2022-04-16','444','10:00','12:00',4,6,1100,3),
 (5,'2022-03-14','555','18:00','20:00',2,1,1200,3),
 (6,'2022-03-21','666','19:00','21:00',3,1,1000,1),
 (7,'2022-03-11','777','20:00','22:00',3,6,1400,4),
 (8,'2022-03-17','888','09:00','11:00',6,4,1100,5),
 (9,'2022-04-19','999','08:00','10:00',4,2,1000,6),
 (10,'2022-04-22','091','10:00','12:00',2,1,1200,6),
 (11,'2025-06-01','110','09:00','11:00',1,5,1350,1),
 (12,'2025-09-15','120','13:30','16:00',2,6,1420,2),
 (13,'2025-12-22','130','15:45','18:15',3,1,1230,3),
 (14,'2026-03-10','140','06:00','08:00',4,2,1150,4),
 (15,'2026-06-25','150','10:30','12:30',5,3,1380,5),
 (16,'2026-10-05','160','12:15','14:30',6,4,1300,6),
 (17,'2027-01-18','170','07:45','09:45',1,3,1250,2),
 (18,'2027-04-09','180','11:00','13:15',2,5,1450,3),
 (19,'2027-06-15','201','08:00','10:00',1,2,1100,2),
 (20,'2027-08-20','202','09:30','11:30',3,4,1300,3),
 (21,'2027-10-05','203','07:45','09:45',2,5,1250,1),
 (22,'2027-12-12','204','10:15','12:15',4,6,1400,4),
 (23,'2028-02-28','205','06:00','08:00',5,1,1200,5),
 (24,'2028-04-15','206','11:00','13:00',6,2,1150,6),
 (25,'2028-07-01','207','12:00','14:00',1,3,1350,1),
 (26,'2028-09-20','208','14:30','16:30',3,4,1250,2),
 (27,'2028-11-05','209','09:00','11:00',2,5,1300,3),
 (28,'2029-01-15','210','10:30','12:30',4,6,1400,4);
SET IDENTITY_INSERT dbo.TFlights OFF;

SET IDENTITY_INSERT dbo.TPilotFlights ON;
INSERT INTO dbo.TPilotFlights (intPilotFlightID,intPilotID,intFlightID) VALUES
 (1,1,2),(2,1,3),(3,3,3),(4,3,2),(5,5,1),(6,2,1),
 (7,3,4),(8,2,4),(9,2,5),(10,3,5),(11,5,6),(12,1,6),
 (13,1,11),(14,3,11),(15,2,12),(16,5,12),(17,3,13),(18,1,13),
 (19,2,14),(20,3,14),(21,5,15),(22,2,15),(23,1,16),(24,5,16),
 (25,2,17),(26,3,17),(27,1,18),(28,3,18),
 (29,1,19),(30,3,19),(31,2,20),(32,5,20),(33,4,21),(34,3,21),
 (35,1,22),(36,5,22),(37,2,23),(38,3,23),(39,4,24),(40,5,24),
 (41,1,25),(42,3,25),(43,2,26),(44,5,26),(45,4,27),(46,3,27),
 (47,1,28),(48,5,28);
SET IDENTITY_INSERT dbo.TPilotFlights OFF;

SET IDENTITY_INSERT dbo.TAttendantFlights ON;
INSERT INTO dbo.TAttendantFlights (intAttendantFlightID,intAttendantID,intFlightID) VALUES
 (1,1,2),(2,2,3),(3,3,3),(4,4,2),(5,5,1),(6,1,1),
 (7,2,4),(8,3,4),(9,4,5),(10,5,5),(11,5,6),(12,1,6),
 (13,1,11),(14,2,11),(15,3,12),(16,4,12),(17,5,13),(18,1,13),
 (19,2,14),(20,3,14),(21,4,15),(22,5,15),(23,1,16),(24,2,16),
 (25,3,17),(26,4,17),(27,5,18),(28,1,18),
 (29,1,19),(30,2,19),(31,3,20),(32,4,20),(33,5,21),(34,1,21),
 (35,2,22),(36,3,22),(37,4,23),(38,5,23),(39,1,24),(40,2,24),
 (41,3,25),(42,4,25),(43,5,26),(44,1,26),(45,2,27),(46,3,27),
 (47,4,28),(48,5,28);
SET IDENTITY_INSERT dbo.TAttendantFlights OFF;

SET IDENTITY_INSERT dbo.TFlightPassengers ON;
INSERT INTO dbo.TFlightPassengers (intFlightPassengerID,intFlightID,intPassengerID,strSeat,decFlightCost) VALUES
 (1,1,1,'1A',250),(2,1,2,'2A',250),(3,1,3,'1B',250),(4,1,4,'1C',250),(5,1,5,'1D',250),
 (6,2,5,'1A',250),(7,2,4,'2A',250),(8,2,3,'1B',250),(9,3,1,'1B',250),(10,3,2,'2A',250),
 (11,3,3,'1B',250),(12,3,4,'1C',250),(13,3,5,'1D',250),(14,4,2,'1A',250),(15,4,3,'1B',250),
 (16,4,4,'1C',250),(17,4,5,'1D',250),(18,5,1,'1A',250),(19,5,2,'2A',250),(20,5,3,'1B',250),
 (21,5,4,'2B',250),(22,6,1,'1A',250),(23,6,2,'2A',250),(24,6,3,'3A',250),
 (25,11,1,'1A',250),(26,11,2,'1B',250),(27,12,3,'2A',250),(28,12,4,'2B',250),
 (29,13,5,'3A',250),(30,13,6,'3B',250),(31,14,1,'4A',250),(32,14,2,'4B',250),
 (33,15,3,'5A',250),(34,15,4,'5B',250),(35,16,5,'6A',250),(36,16,6,'6B',250),
 (37,17,1,'7A',250),(38,17,2,'7B',250),(39,18,3,'8A',250),(40,18,4,'8B',250),
 (41,19,1,'1A',250),(42,19,2,'1B',250),(43,20,3,'2A',250),(44,20,4,'2B',250),
 (45,21,5,'3A',250),(46,21,6,'3B',250),(47,22,1,'1A',250),(48,22,2,'1B',250),
 (49,23,3,'2A',250),(50,23,4,'2B',250),(51,24,5,'3A',250),(52,24,6,'3B',250),
 (53,25,1,'1A',250),(54,25,2,'1B',250),(55,26,3,'2A',250),(56,26,4,'2B',250),
 (57,27,5,'3A',250),(58,27,6,'3B',250),(59,28,1,'1A',250),(60,28,2,'1B',250);
SET IDENTITY_INSERT dbo.TFlightPassengers OFF;

SET IDENTITY_INSERT dbo.TMaintenanceMaintenanceWorkers ON;
INSERT INTO dbo.TMaintenanceMaintenanceWorkers (intMaintenanceMaintenanceWorkerID,intMaintenanceID,
 intMaintenanceWorkerID,intHours) VALUES
 (1,2,1,2),(2,4,1,3),(3,2,3,4),(4,1,4,2),(5,3,4,2),
 (6,4,3,5),(7,5,1,7),(8,6,1,2),(9,7,3,4),(10,4,4,1),
 (11,3,3,4),(12,7,3,8);
SET IDENTITY_INSERT dbo.TMaintenanceMaintenanceWorkers OFF;

SET IDENTITY_INSERT dbo.TEmployees ON;
INSERT INTO dbo.TEmployees (intEmployeeAccountID,strEmployeeLoginID,strEmployeePassword,strEmployeeRole,intEmployeeID) VALUES
 (1,'admin','password','Admin',NULL),
 (2,'pilot1','pilot1pwd','Pilot',1),(3,'pilot2','pilot2pwd','Pilot',2),
 (4,'pilot3','pilot3pwd','Pilot',3),(5,'pilot4','pilot4pwd','Pilot',4),
 (6,'pilot5','pilot5pwd','Pilot',5),
 (7,'att1','att1pwd','Attendant',1),(8,'att2','att2pwd','Attendant',2),
 (9,'att3','att3pwd','Attendant',3),(10,'att4','att4pwd','Attendant',4),
 (11,'att5','att5pwd','Attendant',5);
SET IDENTITY_INSERT dbo.TEmployees OFF;

/*=========  STORED PROCEDURES  ======================================================*/
/*---- 1. Passenger insert -----------------------------------------------------------*/
GO
CREATE OR ALTER PROCEDURE dbo.usp_AddPassenger
 @strFirstName VARCHAR(255),
 @strLastName VARCHAR(255),
 @strAddress VARCHAR(255),
 @strCity VARCHAR(255),
 @intStateID INT,
 @strZip VARCHAR(255),
 @strPhoneNumber VARCHAR(255),
 @strEmail VARCHAR(255),
 @PassengerLoginID VARCHAR(255),
 @PassengerPassword VARCHAR(255),
 @PassengerDateOfBirth DATE
AS
BEGIN

 BEGIN TRY
  BEGIN TRAN;
  INSERT INTO dbo.TPassengers
      (strLoginID,strPassword,strFirstName,strLastName,strAddress,
       strCity,intStateID,strZip,strPhoneNumber,strEmail,dtDateOfBirth)
  VALUES
      (
	   @PassengerLoginID,
	   @PassengerPassword,
	   @strFirstName,
	   @strLastName,
	   @strAddress,
       @strCity,
	   @intStateID,
	   @strZip,
	   @strPhoneNumber,
	   @strEmail,
	   @PassengerDateOfBirth
	   );
  COMMIT;
 END TRY BEGIN CATCH IF @@TRANCOUNT>0 ROLLBACK; THROW; END CATCH
END;
GO

/*---- 2. ROLE-SAFE lookups ----------------------------------------------------------*/
CREATE OR ALTER PROCEDURE dbo.usp_GetAttendantByID @intAttendantID INT AS
BEGIN

 SELECT E.strEmployeeLoginID,E.strEmployeePassword,
        A.intAttendantID,A.strFirstName,A.strLastName,
        A.strEmployeeID,A.dtmDateOfHire,A.dtmDateOfTermination
 FROM dbo.TAttendants A
 JOIN dbo.TEmployees  E
       ON E.intEmployeeID   = A.intAttendantID
      AND E.strEmployeeRole = 'Attendant'
 WHERE A.intAttendantID = @intAttendantID;
END;
GO

CREATE OR ALTER PROCEDURE dbo.usp_GetPilotByID @intPilotID INT AS
BEGIN

 SELECT P.intPilotID,
		P.strFirstName,
		P.strLastName,
        E.strEmployeeLoginID,
		E.strEmployeePassword,
        P.strEmployeeID,
		P.dtmDateOfHire,
		P.dtmDateOfLicense,
        P.dtmDateOfTermination,
		P.intPilotRoleID
 FROM dbo.TPilots P
 JOIN dbo.TEmployees E
       ON E.intEmployeeID   = P.intPilotID
      AND E.strEmployeeRole = 'Pilot'
 WHERE P.intPilotID = @intPilotID;
END;
GO

/*---- 3. Pilot / Attendant name lists ----------------------------------------------*/
CREATE OR ALTER PROCEDURE dbo.usp_GetPilotFullNames
AS
BEGIN

 SELECT intPilotID,
        strFirstName + ' ' + strLastName AS FullName
 FROM dbo.TPilots
 ORDER BY strLastName, strFirstName;
END;
GO

CREATE OR ALTER PROCEDURE dbo.usp_GetAttendantFullNames
AS
BEGIN

 SELECT intAttendantID,
        strFirstName + ' ' + strLastName AS FullName
 FROM dbo.TAttendants
 ORDER BY strLastName, strFirstName;
END;
GO

/*---- 4. Flight insert (NEW) --------------------------------------------------------*/
CREATE OR ALTER PROCEDURE dbo.usp_InsertFlight
    @strFlightNumber     VARCHAR(255),
    @dtmFlightDate       DATETIME,
    @dtmTimeofDeparture  TIME,
    @dtmTimeOfLanding    TIME,
    @intFromAirportID    INT,
    @intToAirportID      INT,
    @intMilesFlown       INT,
    @intPlaneID          INT
AS
BEGIN

 BEGIN TRY
  BEGIN TRAN;
  INSERT INTO dbo.TFlights (strFlightNumber,dtmFlightDate,dtmTimeofDeparture,dtmTimeOfLanding,
                            intFromAirportID,intToAirportID,intMilesFlown,intPlaneID)
  VALUES (
		  @strFlightNumber,
		  @dtmFlightDate,
		  @dtmTimeofDeparture,
		  @dtmTimeOfLanding,
          @intFromAirportID,
		  @intToAirportID,
		  @intMilesFlown,
		  @intPlaneID);
  SELECT SCOPE_IDENTITY() AS NewFlightID;
  COMMIT;
 END TRY BEGIN CATCH IF @@TRANCOUNT>0 ROLLBACK; THROW; END CATCH
END;
GO

/*---- 5. Flight / mileage stats -----------------------------------------------------*/
CREATE OR ALTER PROCEDURE dbo.usp_GetAttendantFlightsAndMiles @AttendantID INT AS
BEGIN

 SELECT F.intFlightID,F.strFlightNumber,F.dtmFlightDate,
        A1.strAirportCity AS FromCity,A2.strAirportCity AS ToCity,
        P.strPlaneNumber,PT.strPlaneType,F.intMilesFlown
 FROM dbo.TFlights F
 JOIN dbo.TAirports A1 ON F.intFromAirportID=A1.intAirportID
 JOIN dbo.TAirports A2 ON F.intToAirportID=A2.intAirportID
 JOIN dbo.TPlanes   P  ON F.intPlaneID=P.intPlaneID
 JOIN dbo.TPlaneTypes PT ON P.intPlaneTypeID=PT.intPlaneTypeID
 JOIN dbo.TAttendantFlights AF ON AF.intFlightID=F.intFlightID
 WHERE F.dtmFlightDate<=CAST(GETDATE() AS DATE)
   AND AF.intAttendantID=@AttendantID
 ORDER BY F.dtmFlightDate;
END;
GO

CREATE OR ALTER PROCEDURE dbo.usp_GetAverageMilesFlownForPassengers AS
BEGIN

 SELECT AVG(TotalFlown) AS AverageMilesFlownForPassengers
 FROM (SELECT P.intPassengerID,SUM(ISNULL(F.intMilesFlown,0)) AS TotalFlown
       FROM dbo.TPassengers P
       LEFT JOIN dbo.TFlightPassengers FP ON FP.intPassengerID=P.intPassengerID
       LEFT JOIN dbo.TFlights F ON F.intFlightID=FP.intFlightID
       GROUP BY P.intPassengerID) x;
END;
GO

CREATE OR ALTER PROCEDURE dbo.usp_GetFutureAttendantFlights @AttendantID INT AS
BEGIN

 SELECT F.intFlightID,F.strFlightNumber,F.dtmFlightDate,
        A1.strAirportCity AS FromCity,A2.strAirportCity AS ToCity,
        P.strPlaneNumber,PT.strPlaneType,F.intMilesFlown
 FROM dbo.TFlights F
 JOIN dbo.TAirports A1 ON F.intFromAirportID=A1.intAirportID
 JOIN dbo.TAirports A2 ON F.intToAirportID=A2.intAirportID
 JOIN dbo.TPlanes   P  ON F.intPlaneID=P.intPlaneID
 JOIN dbo.TPlaneTypes PT ON P.intPlaneTypeID=PT.intPlaneTypeID
 JOIN dbo.TAttendantFlights AF ON AF.intFlightID=F.intFlightID
 WHERE F.dtmFlightDate>=CAST(GETDATE() AS DATE)
   AND AF.intAttendantID=@AttendantID
 ORDER BY F.dtmFlightDate;
END;
GO

CREATE OR ALTER PROCEDURE dbo.usp_GetFuturePassengerFlights @PassengerID INT AS
BEGIN

 SELECT F.intFlightID,
        F.strFlightNumber,
        F.dtmFlightDate,
        A1.strAirportCity AS FromCity,
		A2.strAirportCity AS ToCity,
        P.strPlaneNumber,
		PT.strPlaneType,
		F.intMilesFlown,
		FP.strSeat
 FROM dbo.TFlights F
 JOIN dbo.TAirports A1 ON F.intFromAirportID=A1.intAirportID
 JOIN dbo.TAirports A2 ON F.intToAirportID=A2.intAirportID
 JOIN dbo.TPlanes   P  ON F.intPlaneID=P.intPlaneID
 JOIN dbo.TPlaneTypes PT ON P.intPlaneTypeID=PT.intPlaneTypeID
 JOIN dbo.TFlightPassengers FP ON FP.intFlightID=F.intFlightID
 WHERE F.dtmFlightDate>=CAST(GETDATE() AS DATE)
   AND FP.intPassengerID=@PassengerID
 ORDER BY F.dtmFlightDate;
END;
GO

CREATE OR ALTER PROCEDURE dbo.usp_GetPastPassengerFlights @PassengerID INT AS
BEGIN
 SELECT F.intFlightID,F.strFlightNumber,F.dtmFlightDate,
        A1.strAirportCity AS FromCity,A2.strAirportCity AS ToCity,
        P.strPlaneNumber,PT.strPlaneType,F.intMilesFlown
 FROM dbo.TFlights F
 JOIN dbo.TAirports A1 ON F.intFromAirportID=A1.intAirportID
 JOIN dbo.TAirports A2 ON F.intToAirportID=A2.intAirportID
 JOIN dbo.TPlanes   P  ON F.intPlaneID=P.intPlaneID
 JOIN dbo.TPlaneTypes PT ON P.intPlaneTypeID=PT.intPlaneTypeID
 JOIN dbo.TFlightPassengers FP ON FP.intFlightID=F.intFlightID
 WHERE F.dtmFlightDate<=CAST(GETDATE() AS DATE)
   AND FP.intPassengerID=@PassengerID
 ORDER BY F.dtmFlightDate;
END;
GO

CREATE OR ALTER PROCEDURE dbo.usp_GetTakenSeatCountByFlight @intFlightID INT AS
BEGIN
 SELECT COUNT(*) AS TakenSeatCount
 FROM dbo.TFlightPassengers
 WHERE intFlightID=@intFlightID;
END;
GO

CREATE OR ALTER PROCEDURE dbo.usp_GetTakenSeatsByFlight @intFlightID INT AS
BEGIN
 SELECT strSeat
 FROM dbo.TFlightPassengers
 WHERE intFlightID=@intFlightID;
END;
GO

CREATE OR ALTER PROCEDURE dbo.usp_GetTotalFlightsOfCustomers AS
BEGIN
 SELECT COUNT(*) AS TotalFlightsOfPassengers
 FROM dbo.TFlightPassengers;
END;
GO

CREATE OR ALTER PROCEDURE dbo.usp_GetTotalNumberOfCustomers AS
BEGIN
 SELECT COUNT(intPassengerID) AS PassengersNumber
 FROM dbo.TPassengers;
END;
GO

/*---- 6. Insert / Update ) -------------------------------------*/
CREATE OR ALTER PROCEDURE dbo.usp_InsertAttendantWithEmployee
 @strEmployeeLoginID  VARCHAR(255),
 @strEmployeePassword VARCHAR(255),
 @strEmployeeRole     VARCHAR(50),
 @strEmployeeID       VARCHAR(255),
 @strFirstName        VARCHAR(255),
 @strLastName         VARCHAR(255),
 @dtmDateOfHire       DATETIME,
 @dtmDateOfTermination DATETIME
AS
BEGIN
 DECLARE @EmpID INT,@AttID INT;
 BEGIN TRY
  BEGIN TRAN;

  INSERT INTO dbo.TEmployees (strEmployeeLoginID,strEmployeePassword,strEmployeeRole)
  VALUES (@strEmployeeLoginID,@strEmployeePassword,@strEmployeeRole);
  SET @EmpID = SCOPE_IDENTITY();

  INSERT INTO dbo.TAttendants (strFirstName,strLastName,strEmployeeID,
                               dtmDateOfHire,dtmDateOfTermination)
  VALUES (@strFirstName,@strLastName,@strEmployeeID,@dtmDateOfHire,@dtmDateOfTermination);
  SET @AttID = SCOPE_IDENTITY();

  UPDATE dbo.TEmployees
     SET intEmployeeID = @AttID
   WHERE intEmployeeAccountID = @EmpID
     AND strEmployeeRole      = 'Attendant';

  COMMIT;
  SELECT @EmpID AS NewEmployeeAccountID,@AttID AS NewAttendantID;
 END TRY BEGIN CATCH IF @@TRANCOUNT>0 ROLLBACK; THROW; END CATCH
END;
GO

CREATE OR ALTER PROCEDURE dbo.usp_InsertPilotWithEmployee
 @strEmployeeLoginID  VARCHAR(255),
 @strEmployeePassword VARCHAR(255),
 @strEmployeeRole     VARCHAR(50),
 @strEmployeeID       VARCHAR(255),
 @strFirstName        VARCHAR(255),
 @strLastName         VARCHAR(255),
 @dtmDateOfHire       DATETIME,
 @dtmDateOfTermination DATETIME,
 @dtmDateOfLicense    DATETIME,
 @intPilotRoleID      INT
AS
BEGIN
 DECLARE @EmpID INT,@PilotID INT;
 BEGIN TRY
  BEGIN TRAN;

  INSERT INTO dbo.TEmployees (strEmployeeLoginID,strEmployeePassword,strEmployeeRole)
  VALUES (
  @strEmployeeLoginID,
  @strEmployeePassword,
  @strEmployeeRole);
  SET @EmpID = SCOPE_IDENTITY();

  INSERT INTO dbo.TPilots (strFirstName,strLastName,strEmployeeID,
                           dtmDateOfHire,dtmDateOfTermination,
                           dtmDateOfLicense,intPilotRoleID)
  VALUES (@strFirstName,@strLastName,@strEmployeeID,
          @dtmDateOfHire,@dtmDateOfTermination,@dtmDateOfLicense,@intPilotRoleID);
  SET @PilotID = SCOPE_IDENTITY();

  UPDATE dbo.TEmployees
     SET intEmployeeID = @PilotID
   WHERE intEmployeeAccountID = @EmpID
     AND strEmployeeRole      = 'Pilot';

  COMMIT;
  SELECT @EmpID AS NewEmployeeAccountID,@PilotID AS NewPilotID;
 END TRY BEGIN CATCH IF @@TRANCOUNT>0 ROLLBACK; THROW; END CATCH
END;
GO

CREATE OR ALTER PROCEDURE dbo.usp_UpdateAttendantWithEmployee
 @intAttendantID      INT,
 @strEmployeeLoginID  VARCHAR(255),
 @strEmployeePassword VARCHAR(255),
 @strEmployeeRole     VARCHAR(50) = 'Attendant',
 @strEmployeeID       VARCHAR(255),
 @strFirstName        VARCHAR(255),
 @strLastName         VARCHAR(255),
 @dtmDateOfHire       DATETIME,
 @dtmDateOfTermination DATETIME = NULL
AS
BEGIN
 BEGIN TRY
  BEGIN TRAN;

  UPDATE dbo.TEmployees
     SET strEmployeeLoginID  = @strEmployeeLoginID,
         strEmployeePassword = @strEmployeePassword,
         strEmployeeRole     = @strEmployeeRole
   WHERE intEmployeeID   = @intAttendantID
     AND strEmployeeRole = 'Attendant';

  UPDATE dbo.TAttendants
     SET strFirstName        = @strFirstName,
         strLastName         = @strLastName,
         strEmployeeID       = @strEmployeeID,
         dtmDateOfHire       = @dtmDateOfHire,
         dtmDateOfTermination= @dtmDateOfTermination
   WHERE intAttendantID = @intAttendantID;

  COMMIT;
 END TRY BEGIN CATCH IF @@TRANCOUNT>0 ROLLBACK; THROW; END CATCH
END;
GO

CREATE OR ALTER PROCEDURE dbo.usp_UpdatePilotWithEmployee
 @intPilotID          INT,
 @strEmployeeLoginID  VARCHAR(255),
 @strEmployeePassword VARCHAR(255),
 @strEmployeeRole     VARCHAR(50),
 @strEmployeeID       VARCHAR(255),
 @strFirstName        VARCHAR(255),
 @strLastName         VARCHAR(255),
 @dtmDateOfHire       DATETIME,
 @dtmDateOfTermination DATETIME,
 @dtmDateOfLicense    DATETIME,
 @intPilotRoleID      INT
AS
BEGIN
 BEGIN TRY
  BEGIN TRAN;

  UPDATE dbo.TEmployees
     SET strEmployeeLoginID  = @strEmployeeLoginID,
         strEmployeePassword = @strEmployeePassword,
         strEmployeeRole     = @strEmployeeRole
   WHERE intEmployeeID   = @intPilotID
     AND strEmployeeRole = 'Pilot';

  UPDATE dbo.TPilots
     SET strFirstName       = @strFirstName,
         strLastName        = @strLastName,
         strEmployeeID      = @strEmployeeID,
         dtmDateOfHire      = @dtmDateOfHire,
         dtmDateOfTermination = @dtmDateOfTermination,
         dtmDateOfLicense   = @dtmDateOfLicense,
         intPilotRoleID     = @intPilotRoleID
   WHERE intPilotID = @intPilotID;

  COMMIT;
 END TRY BEGIN CATCH IF @@TRANCOUNT>0 ROLLBACK; THROW; END CATCH
END;
GO


CREATE PROCEDURE dbo.usp_DeleteAttendant
  @intAttendantID INT
AS
BEGIN
  BEGIN TRY
    BEGIN TRANSACTION;
      DELETE FROM dbo.TAttendants
       WHERE intAttendantID = @intAttendantID;

      DELETE FROM dbo.TEmployees
       WHERE intEmployeeID = @intAttendantID
         AND strEmployeeRole = 'Attendant';
    COMMIT;
  END TRY
  BEGIN CATCH
    IF @@TRANCOUNT > 0 ROLLBACK;
    THROW;
  END CATCH
END;
GO

CREATE PROCEDURE dbo.usp_DeletePilot
    @intPilotID INT
AS
BEGIN

    BEGIN TRY
        BEGIN TRANSACTION;

        -- 1) Remove from TPilots
        DELETE FROM dbo.TPilots
         WHERE intPilotID = @intPilotID;

        -- 2) Remove from TEmployees, but only if this row really is a Pilot
        DELETE FROM dbo.TEmployees
         WHERE intEmployeeID = @intPilotID
           AND strEmployeeRole = 'Pilot';

        COMMIT;
    END TRY
    BEGIN CATCH
        IF @@TRANCOUNT > 0
            ROLLBACK;
        THROW;
    END CATCH
END;
GO

/*=========  FINISH  ================================================================*/
PRINT N'FlyMe2theMoon – tables, seeds, and 19 stored procedures compiled successfully.';
