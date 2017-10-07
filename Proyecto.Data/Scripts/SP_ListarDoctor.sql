USE [DB_CNCAPP]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE SP_ListarDoctor
    @codError varchar(3) = '' OUTPUT,
	@mensajeRetorno varchar(100) = '' OUTPUT
AS
BEGIN

    SET NOCOUNT ON

	BEGIN TRY
		SELECT [IdDoctor]
		  ,[Nombre]
		  ,[Especialidad]
		  ,[LugarTrabajo]
		  ,[IdProvincia]
		  ,[IdCiudad]
		  ,[DIreccion]
		  ,[Email]
		FROM [DB_CNCAPP].[dbo].[Doctor]
		
		SET @codError='000'
		SET @mensajeRetorno='Consulta Doctores Ok.'

    END TRY

    BEGIN CATCH
		SET @codError='999'
        SET @mensajeRetorno=ERROR_MESSAGE() 
    END CATCH

	SET NOCOUNT OFF
END