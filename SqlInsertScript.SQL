INSERT INTO League([LeagueName]) VALUES ('Premier League');
INSERT INTO League([LeagueName]) VALUES ('La Liga');
INSERT INTO League([LeagueName]) VALUES ('Liga I');

INSERT INTO Team([TeamName],[InLeague]) VALUES ('Chelsea','Premier League');
INSERT INTO Team([TeamName],[InLeague]) VALUES ('Manchester City','Premier League');
INSERT INTO Team([TeamName],[InLeague]) VALUES ('Manchester United','Premier League');
INSERT INTO Team([TeamName],[InLeague]) VALUES ('Arsenal','Premier League');
INSERT INTO Team([TeamName],[InLeague]) VALUES ('Atletico Madrid','La Liga');
INSERT INTO Team([TeamName],[InLeague]) VALUES ('Barcelona','La Liga');
INSERT INTO Team([TeamName],[InLeague]) VALUES ('Steaua','Liga I');
INSERT INTO Team([TeamName],[InLeague]) VALUES ('Viitorul','Liga I');


INSERT INTO Footballer([FootballerID],[FirstName],[LastName],[Age],[Nationality],[InTeam]) VALUES(NewID(),'Mark','Newt','19','British','Chelsea');
INSERT INTO Footballer([FootballerID],[FirstName],[LastName],[Age],[Nationality],[InTeam]) VALUES(NewID(),'Michal','Bing','23','British','Manchester City');
INSERT INTO Footballer([FootballerID],[FirstName],[LastName],[Age],[Nationality],[InTeam]) VALUES(NewID(),'Julio','Ricardo','20','Spanish','Atletico Madrid');
INSERT INTO Footballer([FootballerID],[FirstName],[LastName],[Age],[Nationality],[InTeam]) VALUES(NewID(),'Henry','Clark','25','British','Barcelona');
INSERT INTO Footballer([FootballerID],[FirstName],[LastName],[Age],[Nationality],[InTeam]) VALUES(NewID(),'Mihai','Cilian','22','Romanian','Steaua');
INSERT INTO Footballer([FootballerID],[FirstName],[LastName],[Age],[Nationality],[InTeam]) VALUES(NewID(),'John','Well','24','British','Chelsea');
INSERT INTO Footballer([FootballerID],[FirstName],[LastName],[Age],[Nationality],[InTeam]) VALUES(NewID(),'Jake','Dean','26','British','Arsenal');
INSERT INTO Footballer([FootballerID],[FirstName],[LastName],[Age],[Nationality],[InTeam]) VALUES(NewID(),'Andrei','Muntean','18','Romanian','Viitorul');
INSERT INTO Footballer([FootballerID],[FirstName],[LastName],[Age],[Nationality],[InTeam]) VALUES(NewID(),'Jonny','Young','17','British','Manchester United');
INSERT INTO Footballer([FootballerID],[FirstName],[LastName],[Age],[Nationality],[InTeam]) VALUES(NewID(),'Aldeguer','Montoia','30','Spanish','Arsenal');


SELECT *
FROM Footballer

SELECT t.TeamName, f.FirstName, f.LastName, f.Age
FROM Footballer f INNER JOIN Team t ON f.InTeam = t.TeamName
WHERE t.TeamName = 'Chelsea'

SELECT f.FirstName,f.LastName,f.Age,l.LeagueName
FROM Footballer f INNER JOIN Team t ON f.InTeam = t.TeamName
				  INNER JOIN League l ON t.InLeague = l.LeagueName
WHERE LeagueName = 'Premier League'

SELECT f.FirstName,f.LastName,f.Age,l.LeagueName
FROM Footballer f INNER JOIN Team t ON f.InTeam = t.TeamName
				  INNER JOIN League l ON t.InLeague = l.LeagueName
WHERE LeagueName = 'Premier League'
ORDER BY f.Age

SELECT t.TeamName, t.InLeague
FROM Team t INNER JOIN League l ON t.InLeague = l.LeagueName
WHERE l.LeagueName LIKE 'L%'

SELECT Nationality,COUNT(FootballerID)
FROM Footballer
GROUP BY Nationality

SELECT Nationality
FROM Footballer
GROUP BY Nationality
Having COUNT(FootballerID)>3