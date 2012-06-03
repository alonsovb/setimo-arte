/*Procedimiento para insertar los precios de los alquileres*/
CREATE PROCEDURE [dbo].[insertar_precios_alquileres]
	@STRtipo VARCHAR(50) = NULL,
	@INTprecio_dvd INT = NULL,
	@INTprecio_blueray INT = NULL,
	@INTprecio_hddvd INT = NULL,
	@nStatus INT OUTPUT,                     
    @strMessage VARCHAR(250) OUTPUT

AS	
BEGIN
	
	SET @nStatus = 0		
	SET @strMessage = 'TRANSACCIÓN SATISFACTORIA'                             			
			
INSERT INTO [dbo].[precios_alquileres]
		( [tipo],
          [precio_dvd],
          [precio_blueray],
          [precio_hddvd])
           
     VALUES(	
			@STRtipo,
			@INTprecio_dvd,
			@INTprecio_blueray,
			@INTprecio_hddvd
			)
					
SALIDA:
	SELECT @nStatus, @strMessage
	RETURN 
END
GO

/* Procedimiento para consultar los precios de alquiler */
IF EXISTS (
	SELECT 'h' FROM DBO.SYSOBJECTS 
		WHERE id = OBJECT_ID(N'[dbo].[consultar_precios_alquileres]')AND 
		OBJECTPROPERTY(id, N'IsProcedure') = 1)
	DROP PROCEDURE [dbo].[consultar_precios_alquileres]
GO

CREATE PROCEDURE [dbo].[consultar_precios_alquileres]
	@nStatus INT OUTPUT,                     
    @strMessage VARCHAR(250) OUTPUT 
AS	
BEGIN
	
	SET @nStatus = 0		
	SET @strMessage = 'TRANSACCIÓN SATISFACTORIA'                             			
	
			
	SELECT 
		precio_dvd as DVD,
		precio_blueray as BlueRay,
		precio_hddvd as HD
	FROM precios_alquileres
	
				
SALIDA:
	SELECT @nStatus, @strMessage
	RETURN
END
GO


/* Procedimiento para modificar la informacion de los precios de alquiler */

IF EXISTS (
	SELECT 'h' FROM DBO.SYSOBJECTS 
		WHERE id = OBJECT_ID(N'[dbo].[modificar_precios_alquileres]')AND 
		OBJECTPROPERTY(id, N'IsProcedure') = 1)
	DROP PROCEDURE [dbo].[modificar_precios_alquileres]
GO

CREATE PROCEDURE [dbo].[modificar_precios_alquileres]
	@STRtipo VARCHAR(50) = NULL,
	@INTprecio_dvd INT = NULL,
	@INTprecio_blueray INT = NULL,
	@INTprecio_hddvd INT = NULL,
	@nStatus INT OUTPUT,                     
    @strMessage VARCHAR(250) OUTPUT 
AS	
BEGIN
	SET @nStatus = 0		
	SET @strMessage = 'TRANSACCIÓN SATISFACTORIA'                             			
			
			
	UPDATE [dbo].[precios_alquileres]

	SET		
		   [precio_dvd] = ISNULL(@INTprecio_dvd, [precio_dvd]),
		   [precio_blueray] = ISNULL(@INTprecio_blueray, [precio_blueray]),
		   [precio_hddvd] = ISNULL(@INTprecio_hddvd, [precio_hddvd])
           
	FROM precios_alquileres
    WHERE [tipo] = @STRtipo
		
SALIDA:
	SELECT @nStatus, @strMessage
	RETURN
END
GO

exec insertar_precios_alquileres 'individual',0,0,0,null,null;
exec insertar_precios_alquileres 'multiple',0,0,0,null,null;
exec insertar_precios_alquileres 'adicional',0,0,0,null,null;


