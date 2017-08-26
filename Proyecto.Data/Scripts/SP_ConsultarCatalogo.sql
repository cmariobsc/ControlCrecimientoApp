USE [DB_CNCAPP]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE SP_ConsultarCatalogo
    @codError varchar(3) = '' OUTPUT,
	@mensajeRetorno varchar(100) = '' OUTPUT
AS
BEGIN

    SET NOCOUNT ON

	BEGIN TRY
		SELECT [IdCatalogo],[Detalle]
		FROM [dbo].[Catalogo] Ca, [dbo].[Parentesco] Pa, [dbo].[Nacionalidad] Na, [dbo].[Provincia] Pr, [dbo].[Ciudad] Ci
		
		SET @codError='000'
		SET @mensajeRetorno='Consulta Parentesco Ok.'

    END TRY

    BEGIN CATCH
		SET @codError='999'
        SET @mensajeRetorno=ERROR_MESSAGE() 
    END CATCH

	SET NOCOUNT OFF
END