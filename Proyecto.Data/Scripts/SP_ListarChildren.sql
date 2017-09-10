USE [DB_CNCAPP]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE SP_ListarChildren
    @IdRepresentante int, 
    @codError varchar(3) = '' OUTPUT,
	@mensajeRetorno varchar(100) = '' OUTPUT
AS
BEGIN

    SET NOCOUNT ON

	BEGIN TRY
		DECLARE @contador int

		SELECT [IdChildren]
		  ,[Identificacion]
		  ,[Nombres]
		  ,[Apellidos]
		  ,[FechaNacimiento]
		  ,[EdadAnios]
		  ,[EdadMeses]
		  ,[Talla]
		  ,[Peso]
		  ,[IMC]
		  ,[DetalleIMC]
		  ,[PerimCefalico]
		  ,[PerimMedioBrazo]
		  ,[Observaciones]
		  ,[FechaCreacion]
		  ,[FechaModificacion]
		  ,[IdSexo]
		  ,[IdRepresentante]
		  ,[IdNacionalidad]
		  FROM [dbo].[Children] 
		  WHERE [IdRepresentante] = @IdRepresentante

		  SELECT @contador = COUNT(*)
		  FROM [dbo].[Children] 
		  WHERE [IdRepresentante] = @IdRepresentante
		
		SET @codError='000'
		SET @mensajeRetorno= CONVERT(varchar(2), @contador) + ' niños en total.'

    END TRY

    BEGIN CATCH
		SET @codError='999'
        SET @mensajeRetorno=ERROR_MESSAGE() 
    END CATCH

	SET NOCOUNT OFF
END