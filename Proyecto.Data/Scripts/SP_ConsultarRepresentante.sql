USE [DB_CNCAPP]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE SP_ConsultarRepresentante
    @IdUsuario int, 
    @codError varchar(3) = '' OUTPUT,
	@mensajeRetorno varchar(100) = '' OUTPUT
AS
BEGIN

    SET NOCOUNT ON

	BEGIN TRY
		SELECT [IdRepresentante]
		  ,[Identificacion]
		  ,[Nombres]
		  ,[Apellidos]
		  ,[FechaNacimiento]
		  ,[Edad]
		  ,[Direccion]
		  ,[Email]
		  ,[Telefono1]
		  ,[Telefono2]
		  ,[Talla]
		  ,[Peso]
		  ,[NHijos]
		  ,[FechaCreacion]
		  ,[FechaModificacion]
		  ,[IdUsuario]
		  ,[IdParentesco]
		  ,[IdNacionalidad]
		  ,[IdProvincia]
		  ,[IdCiudad]
	  FROM [dbo].[Representante] 
	  WHERE [IdUsuario] = @IdUsuario
		
		SET @codError='000'
		SET @mensajeRetorno='Consulta Representante Ok.'

    END TRY

    BEGIN CATCH
		SET @codError='999'
        SET @mensajeRetorno=ERROR_MESSAGE() 
    END CATCH

	SET NOCOUNT OFF
END