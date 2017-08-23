USE [DB_CNCAPP]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE SP_AutenticarUsuario
    @Usuario varchar(20), 
    @Contrasenia varchar(20),
    @codError varchar(3) = '' OUTPUT,
	@mensajeRetorno varchar(100) = '' OUTPUT
AS
BEGIN

    SET NOCOUNT ON

    DECLARE @IdUsuario INT

    IF EXISTS (SELECT TOP 1 IdUsuario FROM Usuario WHERE Usuario=@Usuario)
    BEGIN
        SET @IdUsuario=(SELECT IdUsuario FROM Usuario WHERE Usuario=@Usuario AND Contrasenia=HASHBYTES('SHA2_512', @Contrasenia))

       IF(@IdUsuario IS NULL) 
		   BEGIN
				SET @codError='001' 
				SET @mensajeRetorno='Contraseña incorrecta'
		   END
       ELSE
		   BEGIN
				SET @codError='000' 
				SET @mensajeRetorno='Acceso exitoso'
		   END
    END
    ELSE
		BEGIN
			SET @codError='999' 
			SET @mensajeRetorno='El usuario que ingresó no existe'
		END

	SET NOCOUNT OFF
END