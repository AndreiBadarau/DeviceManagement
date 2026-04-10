IF NOT EXISTS (SELECT * FROM sys.databases WHERE name = 'DeviceManagementDB')
BEGIN
    CREATE DATABASE DeviceManagementDB;
END
GO

USE DeviceManagementDB;
GO

-- Create Users table
IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'Users')
BEGIN
    CREATE TABLE Users (
        Id          INT IDENTITY(1,1) PRIMARY KEY,
        Name        NVARCHAR(100) NOT NULL,
        Role        NVARCHAR(100) NOT NULL,
        Location    NVARCHAR(100) NOT NULL
    );
END
GO

IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'Devices')
BEGIN
    CREATE TABLE Devices (
        Id               INT IDENTITY(1,1) PRIMARY KEY,
        Name             NVARCHAR(100) NOT NULL,
        Manufacturer     NVARCHAR(100) NOT NULL,
        Type             NVARCHAR(10)  NOT NULL,
        OperatingSystem  NVARCHAR(50)  NOT NULL,
        OsVersion        NVARCHAR(50)  NOT NULL,
        Processor        NVARCHAR(100) NOT NULL,
        RamAmount        INT           NOT NULL,
        Description      NVARCHAR(500) NOT NULL DEFAULT '',
        AssignedUserId   INT           NULL,
        CONSTRAINT FK_Devices_Users FOREIGN KEY (AssignedUserId)
            REFERENCES Users(Id) ON DELETE SET NULL
    );
END
GO