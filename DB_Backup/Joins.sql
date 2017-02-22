SELECT *
FROM 
[dbo].[Users] INNER JOIN
[dbo].[Education] ON Users.ID = Education.UserID 
 
SELECT *
FROM 
[dbo].[Users] LEFT JOIN
[dbo].[Education] ON Users.ID = Education.UserID 
 
SELECT *
FROM 
[dbo].[Users] Right JOIN
[dbo].[Education] ON Users.ID = Education.UserID 

SELECT *
FROM 
[dbo].[Users] FULL JOIN
[dbo].[Education] ON Users.ID = Education.UserID 
 