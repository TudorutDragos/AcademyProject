CREATE DATABASE Football;

CREATE TABLE [League](
	[League_ID] uniqueidentifier NOT NULL,
CONSTRAINT [PK_League] PRIMARY KEY ([League_ID]));


CREATE TABLE [Team](
	[Team_ID] uniqueidentifier NOT NULL,
	[League] uniqueidentifier NOT NULL,
CONSTRAINT [PK_Team] PRIMARY KEY (Team_ID),
CONSTRAINT [FK_Team_League] FOREIGN KEY ([League])
		REFERENCES [League]([League_ID]));

CREATE TABLE [Footballer](
	[Footballer_ID] uniqueidentifier NOT NULL,
	[First_Name] nvarchar(50) NOT NULL,
	[Last_Name] nvarchar(50) NOT NULL,
	[Birth_Day] date NOT NULL,
	[Nationality] nvarchar(50) NOT NULL,
	[Team] uniqueidentifier NOT NULL,
CONSTRAINT [PK_Footballer] PRIMARY KEY ([Footballer_ID]),
CONSTRAINT [FK_Footballer_Team] FOREIGN KEY ([Team])
		REFERENCES [Team]([Team_ID]));

CREATE TABLE [Clasament](
	[Clasament_ID] uniqueidentifier NOT NULL,
	[League] uniqueidentifier NOT NULL,
	[Position] int NOT NULL,
	[Team] uniqueidentifier NOT NULL,
	[Team_Wins] int,
	[Team_Defeats] int,
	[Team_Draws] int,
	[Team_Points] int,
CONSTRAINT [PK_Clasament] PRIMARY KEY ([Clasament_ID]),
CONSTRAINT [FK_Clasament_League] FOREIGN KEY ([League])
		REFERENCES [League]([League_ID]),
CONSTRAINT [FK_Clasament_Team] FOREIGN KEY ([Team])
		REFERENCES [Team]([Team_ID]));


