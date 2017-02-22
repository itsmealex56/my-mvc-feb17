CREATE PROCEDURE uspGetUserById
(
@id INT
)AS
BEGIN

SELECT * FROM Users
WHERE Id = @id
END