--DROP DATABASE PictorialMVC;

USE MASTER
GO

/*IF NOT EXISTS (
	SELECT [name]
	FROM sys databases
	WHERE [name] = N'PictorialMVC'
)*/

CREATE DATABASE PictorialMVC
GO

USE PictorialMVC
GO

DROP TABLE IF EXISTS ArtistUser;
DROP TABLE IF EXISTS Piece;
DROP TABLE IF EXISTS UserPieces;

CREATE TABLE ArtistUser (
	Id INTEGER NOT NULL PRIMARY KEY IDENTITY(1,1),
	FirebaseId NVARCHAR(28) NOT NULL,
	[Name] VARCHAR(255) NOT NULL,
	[Image] VARCHAR(255) NOT NULL,

	CONSTRAINT UQ_FirebaseId UNIQUE(FirebaseId)
);

CREATE TABLE Piece (
	Id INTEGER NOT NULL PRIMARY KEY IDENTITY(1,1),
	[Name] VARCHAR(255) NOT NULL,
	[Image] VARCHAR(255) NOT NULL,
	[Date] VARCHAR(255) NOT NULL,
	ArtistUserId INTEGER NOT NULL,
);

CREATE TABLE UserPieces (
	Id INTEGER NOT NULL PRIMARY KEY IDENTITY(1,1),
	ArtistUserId INTEGER NOT NULL,
	PieceId INTEGER NOT NULL,
);

INSERT INTO ArtistUser (FirebaseId, [Name], [Image]) VALUES ('rRW2nhb0uVTBfrlfma1lpnNSXMi1', 'Nathan', 'https://pbs.twimg.com/profile_images/1058553261584723968/yk2DyqCt_400x400.jpg' );

INSERT INTO Piece ([Name], [Image], [Date], ArtistUserId) VALUES ('The Scream 2: Vengence', 'https://dthezntil550i.cloudfront.net/ca/latest/ca2105220833446690011733151/9a6d4d56-4d2d-4bd9-8d97-6d5ba4615e42.jpg', '5/23/2022', 1);

INSERT INTO	UserPieces (ArtistUserId, PieceId) VALUES (1, 1);