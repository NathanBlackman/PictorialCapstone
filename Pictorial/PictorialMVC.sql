USE MASTER
GO

IF NOT EXISTS (
	SELECT [name]
	FROM sys databases
	WHERE [name] = N'PictorialMVC'
)

CREATE DATABASE PictorialMVC
GO

USE PictorialMVC
GO

DROP TABLE IF EXISTS ArtistUser;
DROP TABLE IF EXISTS Piece;
DROP TABLE IF EXISTS Artist;
DROP TABLE IF EXISTS ArtistPieces;

CREATE TABLE ArtistUser (
	UserId INTEGER NOT NULL PRIMARY KEY IDENTITY,
	FirebaseId NVARCHAR(28) NOT NULL,
	[Name] VARCHAR(255) NOT NULL,
	[Image] VARCHAR(255) NOT NULL,

	CONSTRAINT UQ_FirebaseId UNIQUE(FirebaseId)
);

CREATE TABLE Piece (
	Id INTEGER NOT NULL PRIMARY KEY IDENTITY,
	[Name] VARCHAR(255) NOT NULL,
	[Image] VARCHAR(255) NOT NULL,
	[Date] VARCHAR(255) NOT NULL,
	ArtistName VARCHAR(255) NOT NULL,
	ArtistId INTEGER NOT NULL,
);

CREATE TABLE Artist (
	Id INTEGER NOT NULL PRIMARY KEY IDENTITY,
	UserId INTEGER NOT NULL,
);

CREATE TABLE ArtistPieces (
	Id INTEGER NOT NULL PRIMARY KEY IDENTITY,
	ArtistId INTEGER NOT NULL,
	PieceId INTEGER NOT NULL,
);

INSERT INTO ArtistUser (UserId, FirebaseId, [Name], [Image]) VALUES (1, 'rRW2nhb0uVTBfrlfma1lpnNSXMi1', 'Nathan', 'https://pbs.twimg.com/profile_images/1058553261584723968/yk2DyqCt_400x400.jpg' );

INSERT INTO Piece (Id, [Name], [Image], [Date], ArtistName, ArtistId) VALUES (6, 'The Scream 2: Vengence', 'https://dthezntil550i.cloudfront.net/ca/latest/ca2105220833446690011733151/9a6d4d56-4d2d-4bd9-8d97-6d5ba4615e42.jpg', '5/23/2022', 'Nathan', 8);

INSERT INTO Artist (Id, UserId) VALUES (8, 1);

INSERT INTO	ArtistPieces (Id, ArtistId, PieceId) VALUES (12, 8, 6);