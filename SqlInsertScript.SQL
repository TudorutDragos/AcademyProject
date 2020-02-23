INSERT INTO League([League_ID],[Name]) VALUES (newID(),'Premier League');
INSERT INTO League([League_ID],[Name]) VALUES (newID(),'La Liga');
INSERT INTO League([League_ID],[Name]) VALUES (newID(),'Liga I');

INSERT INTO Team([Team_ID],[Name],[League]) VALUES (newID(),'Chelsea','33929CD4-4F80-4716-8416-466553AE5445');
INSERT INTO Team([Team_ID],[Name],[League]) VALUES (newID(),'Manchester City','33929CD4-4F80-4716-8416-466553AE5445');
INSERT INTO Team([Team_ID],[Name],[League]) VALUES (newID(),'Manchester United','33929CD4-4F80-4716-8416-466553AE5445');
INSERT INTO Team([Team_ID],[Name],[League]) VALUES (newID(),'Arsenal','33929CD4-4F80-4716-8416-466553AE5445');
INSERT INTO Team([Team_ID],[Name],[League]) VALUES (newID(),'Atletico Madrid','8D7F0ECD-B865-48BC-9638-AC78E9A20C96');
INSERT INTO Team([Team_ID],[Name],[League]) VALUES (newID(),'Barcelona','8D7F0ECD-B865-48BC-9638-AC78E9A20C96');
INSERT INTO Team([Team_ID],[Name],[League]) VALUES (newID(),'Steaua','E855A844-60E5-4A18-89FD-B3A45963A795');
INSERT INTO Team([Team_ID],[Name],[League]) VALUES (newID(),'Viitorul','E855A844-60E5-4A18-89FD-B3A45963A795');

INSERT INTO Footballer([Footballer_ID],[First_Name],[Last_Name],[Birth_Day],[Nationality],[Team]) VALUES(NewID(),'Mark','Newt','2001-05-10','British','D7E44595-1A80-4CC0-A0EF-D22A722ECE7E');
INSERT INTO Footballer([Footballer_ID],[First_Name],[Last_Name],[Birth_Day],[Nationality],[Team]) VALUES(NewID(),'Michal','Bing','1997-04-11','British','7050470E-3EDE-406D-8A64-B61CA10D5030');
INSERT INTO Footballer([Footballer_ID],[First_Name],[Last_Name],[Birth_Day],[Nationality],[Team]) VALUES(NewID(),'Julio','Ricardo','2000-01-01','Spanish','1062C183-61A6-4068-85D2-44FB7C5ECFE2');
INSERT INTO Footballer([Footballer_ID],[First_Name],[Last_Name],[Birth_Day],[Nationality],[Team]) VALUES(NewID(),'Henry','Clark','1995-10-11','British','0FA731F3-4792-43CF-8C11-79F988334E39');
INSERT INTO Footballer([Footballer_ID],[First_Name],[Last_Name],[Birth_Day],[Nationality],[Team]) VALUES(NewID(),'Mihai','Cilian','1998-02-12','Romanian','1B5FF27C-9B34-43FF-910F-86F57FEFCB82');
INSERT INTO Footballer([Footballer_ID],[First_Name],[Last_Name],[Birth_Day],[Nationality],[Team]) VALUES(NewID(),'John','Well','1996-03-03','British','D7E44595-1A80-4CC0-A0EF-D22A722ECE7E');
INSERT INTO Footballer([Footballer_ID],[First_Name],[Last_Name],[Birth_Day],[Nationality],[Team]) VALUES(NewID(),'Jake','Dean','1994-09-12','British','A0545D15-33E4-489D-B040-FCF62E8408DB');
INSERT INTO Footballer([Footballer_ID],[First_Name],[Last_Name],[Birth_Day],[Nationality],[Team]) VALUES(NewID(),'Andrei','Muntean','2002-10-02','Romanian','553D6899-F85D-47EC-B4F3-FC243171DF2B');
INSERT INTO Footballer([Footballer_ID],[First_Name],[Last_Name],[Birth_Day],[Nationality],[Team]) VALUES(NewID(),'Jonny','Young','2003-09-09','British','5810C08A-38D7-4153-AFE9-85B67F313FDB United');
INSERT INTO Footballer([Footballer_ID],[First_Name],[Last_Name],[Birth_Day],[Nationality],[Team]) VALUES(NewID(),'Aldeguer','Montoia','1990-01-09','Spanish','A0545D15-33E4-489D-B040-FCF62E8408DB');


SELECT *
FROM Footballer

SELECT t.Team_ID, f.First_Name, f.Last_Name, f.Birth_Day
FROM Footballer f INNER JOIN Team t ON f.Team = t.Team_ID
WHERE t.Name = 'Chelsea'

SELECT f.First_Name,f.Last_Name,f.Birth_Day,l.Name
FROM Footballer f INNER JOIN Team t ON f.Team = t.Team_ID
				  INNER JOIN League l ON t.League = l.League_ID
WHERE l.Name = 'Premier League'

SELECT f.First_Name,f.Last_Name,f.Birth_Day,l.Name
FROM Footballer f INNER JOIN Team t ON f.Team = t.Team_ID
				  INNER JOIN League l ON t.League = l.Name
WHERE l.Name = 'Premier League'
ORDER BY f.Birth_Day

SELECT t.Name, t.League
FROM Team t INNER JOIN League l ON t.League = l.League_ID
WHERE l.Name LIKE 'L%'

SELECT Nationality,COUNT(Footballer_ID)
FROM Footballer
GROUP BY Nationality

SELECT Nationality
FROM Footballer
GROUP BY Nationality
Having COUNT(Footballer_ID)>3