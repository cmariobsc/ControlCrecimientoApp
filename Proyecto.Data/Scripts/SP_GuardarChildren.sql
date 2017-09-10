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
	@EdadAnios int,
	@EdadMeses int,
	@Talla decimal(6,2),
	@Peso decimal(6,2),
	@IMC decimal(6,2),
	@DetalleIMC varchar(100),
	@PerimCefalico decimal(6,2),
	@PerimMedioBrazo decimal(6,2),
	@Observaciones varchar(100),
	@FechaCreacion date,
	@IdSexo int,
	@IdRepresentante int,
	@IdNacionalidad int,
    @codError varchar(3) = '' OUTPUT,
	@mensajeRetorno varchar(100) = '' OUTPUT
AS
BEGIN
    SET NOCOUNT ON

    BEGIN TRY
		DECLARE @contador int

		SELECT @contador = COUNT(*)
		  FROM [dbo].[Children] 
		  WHERE [IdRepresentante] = @IdRepresentante

		IF @contador >= (SELECT NHijos FROM Representante WHERE IdRepresentante = @IdRepresentante)
		BEGIN
			SET @codError='001'
			SET @mensajeRetorno='Sólo puede ingresar la cantidad de hijos que especificó en los Datos del Representante.'
		END
		ELSE
		BEGIN
			DECLARE @IdChildren int

			SELECT @IdChildren = COUNT(*) FROM Children
			SET @IdChildren = @IdChildren + 1

			INSERT INTO Children(IdChildren, Identificacion, Nombres, Apellidos, FechaNacimiento, EdadAnios, EdadMeses, Talla, Peso, IMC, DetalleIMC, PerimCefalico, PerimMedioBrazo, Observaciones, FechaCreacion, FechaModificacion, IdSexo, IdRepresentante, IdNacionalidad)
			VALUES (@IdChildren, @Identificacion, @Nombres, @Apellidos, @FechaNacimiento, @EdadAnios, @EdadMeses, @Talla, @Peso, @IMC, @DetalleIMC, @PerimCefalico, @PerimMedioBrazo, @Observaciones, @FechaCreacion, GETDATE(), @IdSexo, @IdRepresentante, @IdNacionalidad)

			INSERT INTO HistorialChildren(EdadAnios, EdadMeses, Talla, Peso, IMC, DetalleIMC, PerimCefalico, PerimMedioBrazo, Observaciones, FechaCreacion, FechaModificacion, IdChildren)
			VALUES (@EdadAnios, @EdadMeses, @Talla, @Peso, @IMC, @DetalleIMC, @PerimCefalico, @PerimMedioBrazo, @Observaciones, @FechaCreacion, GETDATE(), @IdChildren)

			SET @codError='000'
			SET @mensajeRetorno='Se ha registrado al niño correctamente.'
		END
    END TRY
    BEGIN CATCH
		SET @codError='999'
        SET @mensajeRetorno=ERROR_MESSAGE() 
    END CATCH

	SET NOCOUNT OFF
END