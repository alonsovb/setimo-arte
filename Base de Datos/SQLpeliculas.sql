/*Procedimiento para insertar a las peliculas*/
CREATE PROCEDURE [dbo].[insertar_peliculas]
	@STRnombre VARCHAR(60) = NULL,
	@INTgenero INT = NULL,		
	@INTinventario_dvd INT = NULL, 	
	@INTinventario_blueray INT = NULL,
	@INTinventario_hddvd INT = NULL,	
	@nStatus INT OUTPUT,                     
    @strMessage VARCHAR(250) OUTPUT

AS	
BEGIN
	
	SET @nStatus = 0		
	SET @strMessage = 'TRANSACCIÓN SATISFACTORIA'                             			
			
INSERT INTO [dbo].[peliculas]
		( [nombre],
          [genero],
          [inventario_dvd],
          [inventario_blueray],
          [inventario_hddvd])
           
     VALUES(	
			@STRnombre,
			@INTgenero,
			@INTinventario_dvd,
			@INTinventario_blueray,
			@INTinventario_hddvd
			)
					
SALIDA:
	SELECT @nStatus, @strMessage
	RETURN 
END
GO

/* Procedimiento para consultar las peliculas */
IF EXISTS (
	SELECT 'h' FROM DBO.SYSOBJECTS 
		WHERE id = OBJECT_ID(N'[dbo].[consultar_peliculas]')AND 
		OBJECTPROPERTY(id, N'IsProcedure') = 1)
	DROP PROCEDURE [dbo].[consultar_peliculas]
GO

CREATE PROCEDURE [dbo].[consultar_peliculas]
	@INTid_pelicula INT = NULL, 
	@STRnombre VARCHAR(30) = null,	
	@nStatus INT OUTPUT,                     
    @strMessage VARCHAR(250) OUTPUT 
AS	
BEGIN
	
	SET @nStatus = 0		
	SET @strMessage = 'TRANSACCIÓN SATISFACTORIA'                             			
			
	SELECT
		id_peliculas,
		p.nombre,
		g.nombre,
		inventario_dvd,
		inventario_blueray,
		inventario_hddvd
	FROM 
		peliculas p inner join generos g		
	ON 
		p.id_peliculas = ISNULL(@INTid_pelicula, p.id_peliculas) AND
		p.nombre = ISNULL(@STRnombre, p.nombre) AND
		p.genero = g.id_generos
					
SALIDA:
	SELECT @nStatus, @strMessage
	RETURN
END
GO


/* Procedimiento para consultar el inventario de las peliculas */
IF EXISTS (
	SELECT 'h' FROM DBO.SYSOBJECTS 
		WHERE id = OBJECT_ID(N'[dbo].[consultar_inventario_peliculas]')AND 
		OBJECTPROPERTY(id, N'IsProcedure') = 1)
	DROP PROCEDURE [dbo].[consultar_inventario_peliculas]
GO

CREATE PROCEDURE [dbo].[consultar_inventario_peliculas]
	@STRnombre VARCHAR(30) = null,
	@STRtipo VARCHAR(50) = null,	
	@nStatus INT OUTPUT,                     
    @strMessage VARCHAR(250) OUTPUT 
AS	
BEGIN
	
	SET @nStatus = 0		
	SET @strMessage = 'TRANSACCIÓN SATISFACTORIA'                             			
			
	SELECT
		*
	FROM 
		peliculas
	WHERE 
		nombre=@STRnombre and
		((@STRtipo = 'inventario_dvd' and inventario_dvd > 1) or
		 (@STRtipo = 'inventario_blueray' and inventario_blueray > 1) or
		 (@STRtipo = 'inventario_hddvd' and inventario_hddvd > 1 ))
		
SALIDA:
	SELECT @nStatus, @strMessage
	RETURN
END
GO


--exec consultar_inventario_peliculas 'madagascar','inventario_dvd',null,null