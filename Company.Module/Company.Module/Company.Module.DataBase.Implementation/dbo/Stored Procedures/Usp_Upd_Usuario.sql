CREATE PROCEDURE [dbo].[Usp_Upd_Usuario]
    @IdUsuario INT,
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
    
    UPDATE [dbo].[Usuario] SET
        [UserName] = @UserName,
        [Password] = @Password,
        [CreationUser] = @CreationUser,
        [CreationDate] = @CreationDate,
        [UpdateUser] = @UpdateUser,
        [UpdateDate] = @UpdateDate,
        [Active] = @Active
    WHERE
        [IdUsuario] = @IdUsuario 
    
    SET NOCOUNT OFF
END