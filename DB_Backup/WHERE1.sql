SELECT
	Users.LastName AS FamilyName,
	Users.FirstName AS Firstname,
	--Users.EmploymentDate,
	Edu.YearAttended
	

FROM
	Users INNER JOIN Education Edu ON 
	Users.ID = Edu.UserId

WHERE
 --Edu.School = 'WMSU' OR Edu.School = 'Ateneo'
	Edu.YearAttended = '2000'