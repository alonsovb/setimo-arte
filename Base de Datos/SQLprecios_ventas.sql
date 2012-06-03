/*Procedimiento para insertar los precios de las ventas*/
CREATE PROCEDURE [dbo].[insertar_precios_ventas]
	@STRtipo VARCHAR(50) = NULL,
	@INTprecio INT = NULL,
	@nStatus INT OUTPUT,                     
    @strMessage VARCHAR(250) OUTPUT

AS	
BEGIN
	
	SET @nStatus = 0		
	SET @strMessage = 'TRANSACCIÓN SATISFACTORIA'                             			
			
INSERT INTO [dbo].[precios_ventas]
		( [tipo],
          [precio])
           
     VALUES(	
			@STRtipo,
			@INTprecio
			)
					
SALIDA:
	SELECT @nStatus, @strMessage
	RETURN 
END
GO

/* Procedimiento para consultar los precios de ventas */
IF EXISTS (
	SELECT 'h' FROM DBO.SYSOBJECTS 
		WHERE id = OBJECT_ID(N'[dbo].[consultar_precios_ventas]')AND 
		OBJECTPROPERTY(id, N'IsProcedure') = 1)
	DROP PROCEDURE [dbo].[consultar_precios_ventas]
GO

CREATE PROCEDURE [dbo].[consultar_precios_ventas]
	@nStatus INT OUTPUT,                     
    @strMessage VARCHAR(250) OUTPUT 
AS	
BEGIN
	
	SET @nStatus = 0		
	SET @strMessage = 'TRANSACCIÓN SATISFACTORIA'                             			
	
			
	SELECT precio FROM precios_ventas
					
SALIDA:
	SELECT @nStatus, @strMessage
	RETURN
END
GO


/* Procedimiento para modificar la informacion de los precios de venta */

IF EXISTS (
	SELECT 'h' FROM DBO.SYSOBJECTS 
		WHERE id = OBJECT_ID(N'[dbo].[modificar_precios_ventas]')AND 
		OBJECTPROPERTY(id, N'IsProcedure') = 1)
	DROP PROCEDURE [dbo].[modificar_precios_ventas]
GO

CREATE PROCEDURE [dbo].[modificar_precios_ventas]
	@INTprecio_socio INT = NULL,
	@INTprecio_particular INT = NULL,
	@nStatus INT OUTPUT,                     
    @strMessage VARCHAR(250) OUTPUT 
AS	
BEGIN
	SET @nStatus = 0		
	SET @strMessage = 'TRANSACCIÓN SATISFACTORIA'                             			
			
			
	UPDATE [dbo].[precios_ventas]

	SET		
		   [precio] = ISNULL(@INTprecio_socio, [precio])
           
	FROM precios_ventas 
    WHERE [tipo] = 'socio'
	
	UPDATE [dbo].[precios_ventas]

	SET		
		   [precio] = ISNULL(@INTprecio_particular, [precio])
           
	FROM precios_ventas 
    WHERE [tipo] = 'particular'	
SALIDA:
	SELECT @nStatus, @strMessage
	RETURN
END
GO

select * from precios_ventas

exec insertar_precios_ventas 'socio',0,null,null;
exec insertar_precios_ventas 'particular',0,null,null;



