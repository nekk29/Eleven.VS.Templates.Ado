CREATE PROCEDURE [dbo].[Usp_Ins_Usuario]
    @IdUsuario INT OUTPUT,
    @UserName NVARCHAR (64) ,
    @Password NVARCHAR (256),
    @CreationUser NVARCHAR (64) ,
    @CreationDate DATETIME,
    @UpdateUser NVARCHAR (64) ,
    @UpdateDate DATETIME,
    @Active BIT
AS
BEGIN
    SET NOCOUNT ON
    
    INSERT INTO [dbo].[Usuario] (
        [UserName],
        [Password],
        [CreationUser],
        [CreationDate],
        [UpdateUser],
        [UpdateDate],
        [Active]
    )
    VALUES (
        @UserName,
        @Password,
        @CreationUser,
        @CreationDate,
        @UpdateUser,
        @UpdateDate,
        @Active
    )
    
    SET @IdUsuario = @@identity
    
    SET NOCOUNT OFF
END