CREATE PROCEDURE [dbo].[Usp_Sel_Usuario]
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
    
    SELECT
        [IdUsuario],
        [UserName],
        [Password],
        [CreationUser],
        [CreationDate],
        [UpdateUser],
        [UpdateDate],
        [Active]
    FROM [dbo].[Usuario]
    -- Put your filters here... --
    /*
    WHERE
        [IdUsuario] = @IdUsuario AND
        [UserName] = @UserName AND
        [Password] = @Password AND
        [CreationUser] = @CreationUser AND
        [CreationDate] = @CreationDate AND
        [UpdateUser] = @UpdateUser AND
        [UpdateDate] = @UpdateDate AND
        [Active] = @Active 
    */
    
    SET NOCOUNT OFF
END