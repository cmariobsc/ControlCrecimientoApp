USE [DB_CNCAPP]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE SP_ListarHistorialChildren
    @IdChildren int, 
    @codError varchar(3) = '' OUTPUT,
	@mensajeRetorno varchar(100) = '' OUTPUT
AS
BEGIN

    SET NOCOUNT ON

	BEGIN TRY
		DECLARE @contador int

		SELECT [IdHistorialChildren]
		  ,C.[Nombres] + ' ' + C.[Apellidos] AS NombreCompleto
		  ,C.[IdSexo]
		  ,HC.[EdadAnios]
		  ,HC.[EdadMeses]
		  ,HC.[Talla]
		  ,HC.[Peso]
		  ,HC.[IMC]
		  ,HC.[DetalleIMC]
		  ,HC.[PerimCefalico]
		  ,HC.[PerimMedioBrazo]
		  ,HC.[Observaciones]
		  ,HC.[FechaCreacion]
		  ,HC.[FechaModificacion]
		  ,HC.[IdChildren]
		  FROM [dbo].[HistorialChildren] HC
		  INNER JOIN [dbo].[Children] C
		  ON HC.[IdChildren] = @IdChildren
		  AND C.[IdChildren] = @IdChildren

		  SELECT @contador = COUNT(*)
		  FROM [dbo].[HistorialChildren] 
		  WHERE [IdChildren] = @IdChildren
		
		SET @codError='000'
		SET @mensajeRetorno= CONVERT(varchar(100), @contador) + ' registros en total.'

    END TRY

    BEGIN CATCH
		SET @codError='999'
        SET @mensajeRetorno=ERROR_MESSAGE() 
    END CATCH

	SET NOCOUNT OFF
END