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

		IF EXISTS (SELECT 1 FROM Usuario WHERE Usuario = @Usuario) 
		BEGIN
			SET @codError='001'
			SET @mensajeRetorno='El usuario que ingresò ya existe, debe elegir otro.'
		END
		ELSE
		BEGIN
			DECLARE @idUsuario int
			DECLARE @idRepresentante int
			
			SELECT @idUsuario = COUNT(*) FROM Usuario
			SET @idUsuario = @idUsuario + 1

			SELECT @idRepresentante = COUNT(*) FROM Representante
			SET @idRepresentante = @idRepresentante + 1

			INSERT INTO Usuario(IdUsuario, Usuario, Contrasenia, Nombres, Apellidos, Email, Habilitado, FechaCreacion)
			VALUES(@idUsuario, @Usuario, HASHBYTES('SHA2_512', @Contrasenia), @Nombres, @Apellidos, @Email, 0, GETDATE())

			INSERT INTO Representante (IdRepresentante, Nombres, Apellidos, Email, FechaCreacion, FechaModificacion, IdUsuario)
			VALUES (@idRepresentante, @Nombres, @Apellidos, @Email, GETDATE(), GETDATE(), @idUsuario)

			SET @codError='000'
			SET @mensajeRetorno='Se ha registrado correctamente, ingrese a su correo para activar su cuenta.'
		END

    END TRY
    BEGIN CATCH
		SET @codError='999'
        SET @mensajeRetorno=ERROR_MESSAGE() 
    END CATCH

	SET NOCOUNT OFF
END