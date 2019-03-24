CREATE PROCEDURE [dbo].[Usp_Sel_Usuario_ById]
    @IdUsuario INT
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
    WHERE
        [IdUsuario] = @IdUsuario 
    
    SET NOCOUNT OFF
END