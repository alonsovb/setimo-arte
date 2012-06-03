/*Procedimiento para insertar los generos de peliculas*/
CREATE  PROCEDURE [dbo].[insertar_generos]
	@STRnombre TEXT = NULL,	
	@nStatus INT OUTPUT,                     
    @strMessage VARCHAR(250) OUTPUT,
    @INTid_genero INT OUTPUT

AS	
BEGIN
	
	SET @nStatus = 0		
	SET @strMessage = 'TRANSACCIÓN SATISFACTORIA'                             			
			
INSERT INTO [dbo].[generos]
		( [nombre] )
           
     VALUES( @STRnombre )
     set @INTid_genero = SCOPE_IDENTITY()
					
SALIDA:
	SELECT @nStatus, @strMessage
	RETURN 
END
GO


/* Procedimiento para consultar los generos */
IF EXISTS (
	SELECT 'h' FROM DBO.SYSOBJECTS 
		WHERE id = OBJECT_ID(N'[dbo].[consultar_generos]')AND 
		OBJECTPROPERTY(id, N'IsProcedure') = 1)
	DROP PROCEDURE [dbo].[consultar_generos]
GO

CREATE PROCEDURE [dbo].[consultar_generos]
	@nStatus INT OUTPUT,                     
    @strMessage VARCHAR(250) OUTPUT 
AS	
BEGIN
	
	SET @nStatus = 0		
	SET @strMessage = 'TRANSACCIÓN SATISFACTORIA'                             			
			
	SELECT
		id_generos as ID,
		nombre as Nombre
	FROM 
		generos
						
SALIDA:
	SELECT @nStatus, @strMessage
	RETURN
END
GO

/* Procedimiento para consultar los generos */
IF EXISTS (
	SELECT 'h' FROM DBO.SYSOBJECTS 
		WHERE id = OBJECT_ID(N'[dbo].[consultar_generos_nombre]')AND 
		OBJECTPROPERTY(id, N'IsProcedure') = 1)
	DROP PROCEDURE [dbo].[consultar_generos_nombre]
GO

CREATE PROCEDURE [dbo].[consultar_generos_nombre]
	@STRnombre VARCHAR(70) = NULL,
	@nStatus INT OUTPUT,                     
    @strMessage VARCHAR(250) OUTPUT 
AS	
BEGIN
	
	SET @nStatus = 0		
	SET @strMessage = 'TRANSACCIÓN SATISFACTORIA'                             			
			
	SELECT
		id_generos
	FROM 
		generos
	WHERE
		nombre = @STRnombre
						
SALIDA:
	SELECT @nStatus, @strMessage
	RETURN
END
GO

