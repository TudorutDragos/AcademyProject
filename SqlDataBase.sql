CREATE DATABASE Football;

CREATE TABLE [League](
	[LeagueName] nvarchar(50) NOT NULL,
CONSTRAINT [PK_League] PRIMARY KEY ([LeagueName]));


CREATE TABLE [Team](
	[TeamName] nvarchar(50) NOT NULL,
	[InLeague] nvarchar(50) NOT NULL,
CONSTRAINT [PK_Team] PRIMARY KEY ([TeamName]),
CONSTRAINT [FK_Team_League] FOREIGN KEY ([InLeague])
		REFERENCES [League]([LeagueName]));

CREATE TABLE [Footballer](
	[FootballerID] uniqueidentifier NOT NULL,
	[FirstName] nvarchar(50) NOT NULL,
	[LastName] nvarchar(50) NOT NULL,
	[Age] int NOT NULL,
	[Nationality] nvarchar(50) NOT NULL,
	[InTeam] nvarchar(50) NOT NULL,
CONSTRAINT [PK_Footballer] PRIMARY KEY ([FootballerID]),
CONSTRAINT [FK_Footballer_Team] FOREIGN KEY ([InTeam])
		REFERENCES [Team]([TeamName]));

CREATE TABLE [Clasament](
	[ClasamentID] uniqueidentifier NOT NULL,
	[LeagueName] nvarchar(50) NOT NULL,
	[Position] int NOT NULL,
	[TeamName] nvarchar(50) NOT NULL,
	[TeamWins] int,
	[TeamDefeats] int,
	[TeamDraws] int,
	[TeamPoints] int,
CONSTRAINT [PK_Clasament] PRIMARY KEY ([ClasamentID]),
CONSTRAINT [FK_Clasament_League] FOREIGN KEY ([LeagueName])
		REFERENCES [League]([LeagueName]));


