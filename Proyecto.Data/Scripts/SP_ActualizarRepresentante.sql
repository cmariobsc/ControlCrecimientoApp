USE DB_CNCAPP
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE SP_ActualizarRepresentante
	@IdRepresentante int,
    @Identificacion varchar(10), 
    @Nombres varchar(100), 
    @Apellidos varchar(100), 
    @FechaNacimiento date,
	@Edad int,
	@Direccion varchar(100),
	@Email varchar(50),
	@Telefono1 varchar(10),
	@Telefono2 varchar(10),
	@Talla decimal(6,2),
	@Peso int,
	@NHijos int,
	@IdParentesco int,
	@IdNacionalidad int,
	@IdProvincia int,
	@IdCiudad int,
    @codError varchar(3) = '' OUTPUT,
	@mensajeRetorno varchar(100) = '' OUTPUT
AS
BEGIN
    SET NOCOUNT ON

    BEGIN TRY
		UPDATE Representante SET Identificacion = @Identificacion, Nombres = @Nombres, Apellidos = @Apellidos, 
								FechaNacimiento = @FechaNacimiento, Edad = @Edad, Direccion = @Direccion, Email = @Email,
								Telefono1 = @Telefono1, Telefono2 = @Telefono2, Talla = @Talla, Peso = @Peso, 
								NHijos = @NHijos, FechaModificacion = GETDATE(), IdParentesco = @IdParentesco, 
								IdNacionalidad = @IdNacionalidad, IdProvincia = @IdProvincia, IdCiudad = @IdCiudad
				WHERE IdRepresentante = @IdRepresentante

		SET @codError='000'
		SET @mensajeRetorno='Sus datos se han actualizado correctamente.'
    END TRY
    BEGIN CATCH
		SET @codError='999'
        SET @mensajeRetorno=ERROR_MESSAGE() 
    END CATCH

	SET NOCOUNT OFF
END