
--****************************************************************************************************
CREATE DATABASE [MySchool]
GO

USE [MySchool]

--****************************************************************************************************

CREATE TABLE [Role]
(
	[Id] INT NOT NULL IDENTITY(1,1) CONSTRAINT pk_Role_Id PRIMARY KEY,
	[Name] VARCHAR(50) NOT NULL CONSTRAINT uk_Role_Name UNIQUE,
    [Description] VARCHAR(100) NOT NULL,
    [IsActive] BIT NOT NULL,
    [AddedDate] DATETIME NOT NULL,
    [AddedById] INT,
    [ModifiedDate] DATETIME,
    [ModifiedById] INT,
)

INSERT INTO [Role] (Name,Description,IsActive,AddedDate,AddedById,ModifiedDate,ModifiedById) 
VALUES('Admin','...',1,GETDATE(),1,NULL,NULL);

INSERT INTO [Role] (Name,Description,IsActive,AddedDate,AddedById,ModifiedDate,ModifiedById) 
VALUES('Staff','...',1,GETDATE(),1,NULL,NULL);

-- ****************************************************************************************************
CREATE TABLE [User]
(
	[Id] INT NOT NULL IDENTITY(1,1) CONSTRAINT pk_User_Id PRIMARY KEY,
	[FirstName] VARCHAR(20) NOT NULL,
    [LastName] VARCHAR(20) NOT NULL,
    [Username] VARCHAR(20) NOT NULL CONSTRAINT uk_User_Username UNIQUE,
    [Password] VARCHAR(32) NOT NULL,
    [MobileNo] VARCHAR(12),
    [Email] VARCHAR(50),
    [RoleId] INT CONSTRAINT fk_User_RoleId FOREIGN KEY REFERENCES Role(Id),
    [SysAdmin] BIT,
    [IsActive] BIT NOT NULL,
    [AddedDate] DATETIME NOT NULL,
    [AddedById] INT CONSTRAINT fk_User_AddedById FOREIGN KEY REFERENCES [User](Id),
    [ModifiedDate] DATETIME,
    [ModifiedById] INT CONSTRAINT fk_User_ModifiedById FOREIGN KEY REFERENCES [User](Id)
)

INSERT INTO [User] (FirstName,LastName,Username,Password,MobileNo,Email,RoleId,SysAdmin,IsActive,AddedDate,AddedById,ModifiedDate,ModifiedById) 
VALUES('Ramesh','Sir','ramesh','sir','9999999999','rameshsir@gmail.com',1,1,1,GETDATE(),1,NULL,NULL);

-- ****************************************************************************************************
