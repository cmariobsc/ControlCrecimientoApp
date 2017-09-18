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
	@EdadAnios int,
	@EdadMeses int,
	@EdadTotalMeses int,
	@Talla decimal(6,2),
	@Peso decimal(6,2),
	@IMC decimal(6,2),
	@DetalleIMC varchar(100),
	@PerimCefalico decimal(6,2),
	@PerimMedioBrazo decimal(6,2),
	@Observaciones varchar(100),
	@FechaCreacion date,
	@IdNacionalidad int,
	@IdSexo int,
    @codError varchar(3) = '' OUTPUT,
	@mensajeRetorno varchar(100) = '' OUTPUT
AS
BEGIN
    SET NOCOUNT ON

    BEGIN TRY
		UPDATE Children SET Identificacion = @Identificacion, Nombres = @Nombres, Apellidos = @Apellidos, 
								FechaNacimiento = @FechaNacimiento, EdadAnios = @EdadAnios, EdadMeses = @EdadMeses, EdadTotalMeses = @EdadTotalMeses, Talla = @Talla, Peso = @Peso,
								IMC = @IMC, DetalleIMC = @DetalleIMC, PerimCefalico = @PerimCefalico, PerimMedioBrazo = @PerimMedioBrazo,
								Observaciones = @Observaciones, FechaModificacion = GETDATE(), IdNacionalidad = @IdNacionalidad, IdSexo = @IdSexo
				WHERE IdChildren = @IdChildren

		IF EXISTS (SELECT 1 FROM Children WHERE IdChildren = @IdChildren AND FechaCreacion = @FechaCreacion)
		BEGIN
			UPDATE HistorialChildren SET EdadAnios = @EdadAnios, EdadMeses = @EdadMeses, EdadTotalMeses = @EdadTotalMeses, Talla = @Talla, Peso = @Peso,
										IMC = @IMC, DetalleIMC = @DetalleIMC, PerimCefalico = @PerimCefalico, PerimMedioBrazo = @PerimMedioBrazo,
										Observaciones = @Observaciones,	FechaModificacion = GETDATE()
				WHERE IdChildren = @IdChildren AND FechaCreacion = @FechaCreacion
		END
		ELSE
		BEGIN
			INSERT INTO HistorialChildren(EdadAnios, EdadMeses, EdadTotalMeses, Talla, Peso, IMC, DetalleIMC, PerimCefalico, PerimMedioBrazo, Observaciones, FechaCreacion, FechaModificacion, IdChildren)
			VALUES (@EdadAnios, @EdadMeses, @EdadTotalMeses, @Talla, @Peso, @IMC, @DetalleIMC, @PerimCefalico, @PerimMedioBrazo, @Observaciones, @FechaCreacion, GETDATE(), @IdChildren)
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