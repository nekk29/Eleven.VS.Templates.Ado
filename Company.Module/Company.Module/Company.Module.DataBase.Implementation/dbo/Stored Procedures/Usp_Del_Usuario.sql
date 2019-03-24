CREATE PROCEDURE [dbo].[Usp_Del_Usuario]
    @IdUsuario INT
AS
BEGIN
    SET NOCOUNT ON
    
    DELETE FROM [dbo].[Usuario]
    WHERE
        [IdUsuario] = @IdUsuario 
    
    SET NOCOUNT OFF
END