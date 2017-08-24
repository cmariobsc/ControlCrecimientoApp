USE [DB_CNCAPP]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE SP_ConsultarUsuario
    @Usuario varchar(20), 
    @codError varchar(3) = '' OUTPUT,
	@mensajeRetorno varchar(100) = '' OUTPUT
AS
BEGIN

    SET NOCOUNT ON

	BEGIN TRY
		SELECT [IdUsuario]
		  ,[Usuario]
		  ,[Contrasenia]
		  ,[Nombres]
		  ,[Apellidos]
		  ,[Email]
		  ,[Habilitado]
		  ,[FechaCreacion]
		FROM [dbo].[Usuario]
		WHERE [Usuario] = @Usuario
		
		SET @codError='000'
		SET @mensajeRetorno='Consulta Usuario Ok.'

    END TRY

    BEGIN CATCH
		SET @codError='999'
        SET @mensajeRetorno=ERROR_MESSAGE() 
    END CATCH

	SET NOCOUNT OFF
END