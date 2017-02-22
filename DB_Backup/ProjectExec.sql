CREATE PROCEDURE upsCreateUser
@guid		UNIQUEIDENTIFIER,
@fname		VARCHAR(50),
@lname		VARCHAR(50),
@age		INT,
@empdate	DATE,
@school		VARCHAR(50),
@attended	VARCHAR(4),

AS

BEGIN

DECLARE @NewUserId INT

--insert into Users table

INSERT INTO Users
	(Guid, FirstName, LastName, Age, Gender, EmploymentDate)
VALUES
	(@guid, @fname, @lname, @age, @gender, @empdate)
	
--Get Id of newly inserted user

SET @NewUserId = IDENT_CURRENT ('Users')

--Insert Education table

INSERT INTO Education (UserId,School,YearAttended)
VALUES (@NewUserId, @school, @yrAttended)

SELECT @NewUserId

END
