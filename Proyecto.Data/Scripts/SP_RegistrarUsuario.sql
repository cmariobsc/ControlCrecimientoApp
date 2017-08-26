USE DB_CNCAPP
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE SP_RegistrarUsuario
    @Usuario varchar(20), 
    @Contrasenia varchar(20), 
    @Nombres varchar(100), 
    @Apellidos varchar(100),
	@Email varchar(50),
    @codError varchar(3) = '' OUTPUT,
	@mensajeRetorno varchar(100) = '' OUTPUT
AS
BEGIN
    SET NOCOUNT ON

    BEGIN TRY

        INSERT INTO Usuario(Usuario, Contrasenia, Nombres, Apellidos, Email, Habilitado, FechaCreacion)
        VALUES(@Usuario, HASHBYTES('SHA2_512', @Contrasenia), @Nombres, @Apellidos, @Email, 0, GETDATE())

        SET @codError='000'
		SET @mensajeRetorno='Se ha registrado correctamente, ingrese a su correo para activar su cuenta.'

    END TRY
    BEGIN CATCH
		SET @codError='999'
        SET @mensajeRetorno=ERROR_MESSAGE() 
    END CATCH

	SET NOCOUNT OFF
END