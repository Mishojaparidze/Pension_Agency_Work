/*
CREATE PROCEDURE SelectAllCustomers
AS
SELECT * FROM [dbo].[Users]
GO;

EXEC SelectAllCustomers;





CREATE PROCEDURE SelectAllWithRole @Role nvarchar(30)
AS
SELECT * FROM [dbo].[Users] us
join [dbo].[Roles] rol on us.RoleId=rol.Id
Where rol.Role=@Role
GO;

EXEC SelectAllWithRole @Role = 'User';





CREATE PROCEDURE  AddingNewUser
AS
INSERT INTO [dbo].[Users]
--VALUES      (6,
             'ramu',
             'kksingh',
             3456,
             'jk');
go;

EXEC AddingNewUser;



CREATE PROCEDURE  SetUserRole @Role
AS
Select * from [dbo].[Users] us
join [dbo].[Roles] rol on us.RoleId=rol.Id
INSERT INTO [dbo].[Roles].Role=@Role

Go;

EXEC SetUserRole;


Create Procedure UpdateUserInfo @UserId nvarchar(10)
As
INSERT INTO [Dbo].Users
                        (id,
                         Surname,
                         Username,
                         Password,
                         MonthlySalary,
						 Age,
						 Balance)
            VALUES     ( @id,
                         @first_name,
                         @last_name,
                         @salary,
                         @city)
        END
		go;

EXEC UpdateUserInfo;

*/
