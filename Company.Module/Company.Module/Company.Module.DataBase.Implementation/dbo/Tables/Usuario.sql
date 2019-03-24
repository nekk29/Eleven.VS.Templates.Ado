CREATE TABLE [dbo].[Usuario] (
    [IdUsuario] INT IDENTITY(1,1) NOT NULL,
    [UserName] NVARCHAR (64) ,
    [Password] NVARCHAR (256),
    [CreationUser] NVARCHAR (64) ,
    [CreationDate] DATETIME,
    [UpdateUser] NVARCHAR (64) ,
    [UpdateDate] DATETIME,
    [Active] BIT
);