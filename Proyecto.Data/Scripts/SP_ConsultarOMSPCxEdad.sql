USE [DB_CNCAPP]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE SP_ConsultarOMSPCxEdad
	@idSexo int,
    @codError varchar(3) = '' OUTPUT,
	@mensajeRetorno varchar(100) = '' OUTPUT
AS
BEGIN

    SET NOCOUNT ON

	BEGIN TRY
	IF @idSexo = 1
	BEGIN
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
		FROM [dbo].[OMSPCxEdadMasculino]
		
		SET @codError='000'
		SET @mensajeRetorno='Per�metro Cef�lico Para la Edad en Ni�os'
	END
	IF @idSexo = 2
	BEGIN
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
		FROM [dbo].[OMSPCxEdadFemenino]
		
		SET @codError='000'
		SET @mensajeRetorno='Per�metro Cef�lico Para la Edad en Ni�as'
	END

    END TRY

    BEGIN CATCH
		SET @codError='999'
        SET @mensajeRetorno=ERROR_MESSAGE() 
    END CATCH

	SET NOCOUNT OFF
END