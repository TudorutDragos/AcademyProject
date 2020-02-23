CREATE PROCEDURE dbo.Footballer_ReadById 
(
	@Footballer_ID uniqueidentifier
)
AS
BEGIN
	SELECT  f.Footballer_ID,
			f.Last_Name,
			f.First_Name,
		    f.Team
	FROM Footballer f
	WHERE f.Footballer_ID = @Footballer_ID
	END
GO

CREATE PROCEDURE dbo.Team_ReadById 
(
	@Team_ID uniqueidentifier
)
AS
BEGIN
	SELECT  t.Team_ID,
			t.Name
	FROM Team t
	WHERE t.Team_ID = @Team_ID
	END
GO

CREATE PROCEDURE dbo.League_ReadById 
(
	@League_ID uniqueidentifier
)
AS
BEGIN
	SELECT  l.League_ID,
			l.Name
	FROM League l
	WHERE l.League_ID = @League_ID
	END
GO

CREATE PROCEDURE dbo.Clasament_ReadById 
(
	@Clasament_ID uniqueidentifier
)
AS
BEGIN
	SELECT  Clasament_ID,
			League,
			Team
	FROM Clasament
	WHERE Clasament_ID = @Clasament_ID
	END
GO

CREATE PROCEDURE dbo.Footballer_UpdateById
(
	@ID uniqueidentifier,
	@First_name nvarchar(50),
	@Last_name nvarchar(50),
	@Team uniqueidentifier
)
AS
BEGIN
	UPDATE Footballer
	SET	First_Name = @First_name,
		Last_Name = @Last_name,
		Team = @Team
	WHERE Footballer_ID = @ID
	END
GO

CREATE PROCEDURE dbo.Team_UpdateById
(
	@ID uniqueidentifier,
	@Name nvarchar(50)
)
AS
BEGIN
	UPDATE Team
	SET	Name = @Name
	WHERE Team_ID = @ID
	END
GO

CREATE PROCEDURE dbo.League_UpdateById
(
	@ID uniqueidentifier,
	@Name nvarchar(50)
)
AS
BEGIN
	UPDATE League
	SET	Name = @Name
	WHERE League_ID = @ID
	END
GO

CREATE PROCEDURE dbo.Clasament_UpdateById
(
	@ID uniqueidentifier,
	@Team_Wins int,
	@Team_Defeats int,
	@Team_Draws int,
	@Team_Points int
)
AS
BEGIN
	UPDATE Clasament
	SET	Team_Wins = @Team_Wins,
		Team_Defeats = @Team_Defeats,
		Team_Draws = @Team_Draws,
		Team_Points = @Team_Points
	WHERE Clasament_ID = @ID
	END
GO

CREATE PROCEDURE dbo.Footballer_DeleteById
(
	@ID uniqueidentifier
)
AS
BEGIN
	DELETE FROM Footballer
	WHERE Footballer_ID = @ID
END
GO

CREATE PROCEDURE dbo.Team_DeleteById
(
	@ID uniqueidentifier
)
AS
BEGIN
	DELETE FROM Team
	WHERE Team_ID = @ID
END
GO

CREATE PROCEDURE dbo.League_DeleteById
(
	@ID uniqueidentifier
)
AS
BEGIN
	DELETE FROM League
	WHERE League_ID = @ID
END
GO

CREATE PROCEDURE dbo.Clasament_DeleteById
(
	@ID uniqueidentifier
)
AS
BEGIN
	DELETE FROM Clasament
	WHERE Clasament_ID = @ID
END
GO