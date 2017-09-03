USE DB_CNCAPP
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE SP_GuardarChildren
    @Identificacion varchar(10), 
    @Nombres varchar(100), 
    @Apellidos varchar(100), 
    @FechaNacimiento date,
	@Edad int,
	@Talla decimal(6,2),
	@Peso int,
	@IdRepresentante int,
	@IdNacionalidad int,
    @codError varchar(3) = '' OUTPUT,
	@mensajeRetorno varchar(100) = '' OUTPUT
AS
BEGIN
    SET NOCOUNT ON

    BEGIN TRY
		INSERT INTO Children(Identificacion, Nombres, Apellidos, FechaNacimiento, Edad, Talla, Peso, FechaCreacion, FechaModificacion, IdRepresentante, IdNacionalidad)
			VALUES (@Identificacion, @Nombres, @Apellidos, @FechaNacimiento, @Edad, @Talla, @Peso, GETDATE(), GETDATE(), @IdRepresentante, @IdNacionalidad)

		SET @codError='000'
		SET @mensajeRetorno='Se ha registrado al niño correctamente.'
    END TRY
    BEGIN CATCH
		SET @codError='999'
        SET @mensajeRetorno=ERROR_MESSAGE() 
    END CATCH

	SET NOCOUNT OFF
END