USE [DB_CNCAPP]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE SP_ConsultarOMSTallaxEdadMasculino
    @codError varchar(3) = '' OUTPUT,
	@mensajeRetorno varchar(100) = '' OUTPUT
AS
BEGIN

    SET NOCOUNT ON

	BEGIN TRY
		SELECT [Meses]
		  ,[L]
		  ,[M]
		  ,[S]
		  ,[SD]
		  ,[SD3neg]
		  ,[SD2neg]
		  ,[SD1neg]
		  ,[SD0]
		  ,[SD1]
		  ,[SD2]
		  ,[SD3]
		FROM [dbo].[OMSAlturaxEdadMasculino]
		
		SET @codError='000'
		SET @mensajeRetorno='Consulta OMSAlturaxEdadMasculino Ok.'

    END TRY

    BEGIN CATCH
		SET @codError='999'
        SET @mensajeRetorno=ERROR_MESSAGE() 
    END CATCH

	SET NOCOUNT OFF
END