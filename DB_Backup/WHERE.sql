SELECT


	Users.LastName AS FamilyName,
	Users.FirstName AS Firstname,
	Users.EmploymentDate
	

FROM
	Users --INNER JOIN Education Edu ON 
	--Users.ID = Edu.UserId

WHERE
--	Edu.School = 'WMSU' OR Edu.School = 'Ateneo'
	Users.EmploymentDate IS NOT NULL