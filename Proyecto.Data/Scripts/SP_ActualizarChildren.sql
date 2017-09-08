USE DB_CNCAPP
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE SP_ActualizarChildren
	@IdChildren int,
    @Identificacion varchar(10), 
    @Nombres varchar(100), 
    @Apellidos varchar(100), 
    @FechaNacimiento date,
	@EdadAnos int,
	@EdadMeses int,
	@Talla decimal(6,2),
	@Peso int,
	@Observaciones varchar(100),
	@FechaCreacion date,
	@IdNacionalidad int,
    @codError varchar(3) = '' OUTPUT,
	@mensajeRetorno varchar(100) = '' OUTPUT
AS
BEGIN
    SET NOCOUNT ON

    BEGIN TRY
		UPDATE Children SET Identificacion = @Identificacion, Nombres = @Nombres, Apellidos = @Apellidos, 
								FechaNacimiento = @FechaNacimiento, EdadAnos = @EdadAnos, EdadMeses = @EdadMeses, Talla = @Talla, Peso = @Peso,
								Observaciones = @Observaciones, FechaModificacion = GETDATE(), IdNacionalidad = @IdNacionalidad
				WHERE IdChildren = @IdChildren

		IF @FechaCreacion =  CONVERT(date, GETDATE(), 111)
		BEGIN
			UPDATE HistorialChildren SET EdadAnos = @EdadAnos, EdadMeses = @EdadMeses, Talla = @Talla, Peso = @Peso, 
										Observaciones = @Observaciones,	FechaModificacion = GETDATE()
				WHERE IdChildren = @IdChildren AND FechaCreacion = @FechaCreacion
		END
		ELSE
		BEGIN
			INSERT INTO HistorialChildren(EdadAnos, EdadMeses, Talla, Peso, Observaciones, FechaCreacion, FechaModificacion, IdChildren)
			VALUES (@EdadAnos, EdadMeses, @Talla, @Peso, @Observaciones, GETDATE(), GETDATE(), @IdChildren)
		END

		SET @codError='000'
		SET @mensajeRetorno='Los datos se han actualizado correctamente.'
    END TRY
    BEGIN CATCH
		SET @codError='999'
        SET @mensajeRetorno=ERROR_MESSAGE() 
    END CATCH

	SET NOCOUNT OFF
END