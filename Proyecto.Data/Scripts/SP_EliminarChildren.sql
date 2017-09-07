USE [DB_CNCAPP]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE SP_EliminarChildren
    @IdChildren int, 
    @codError varchar(3) = '' OUTPUT,
	@mensajeRetorno varchar(100) = '' OUTPUT
AS
BEGIN

    SET NOCOUNT ON

	BEGIN TRY

		DELETE
		  FROM [dbo].[HistorialChildren] 
		  WHERE [IdChildren] = @IdChildren

		DELETE
		  FROM [dbo].[Children] 
		  WHERE [IdChildren] = @IdChildren
		
		SET @codError='000'
		SET @mensajeRetorno= 'El registro del niño ha sido eliminado corectamente.'

    END TRY

    BEGIN CATCH
		SET @codError='999'
        SET @mensajeRetorno=ERROR_MESSAGE() 
    END CATCH

	SET NOCOUNT OFF
END