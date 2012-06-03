/*Procedimiento para insertar a las ventas*/
CREATE PROCEDURE [dbo].[insertar_ventas]
	@INTcliente INT = NULL,		
	@DTfecha DATETIME = NULL, 	
	@INTcosto INT = NULL,
	@nStatus INT OUTPUT,                     
    @strMessage VARCHAR(250) OUTPUT,
    @INTid_venta INT OUTPUT
AS	
BEGIN
	
	SET @nStatus = 0		
	SET @strMessage = 'TRANSACCIÓN SATISFACTORIA'                             			
			
INSERT INTO [dbo].[ventas]	
		( [cliente],
          [fecha],
          [costo])
           
     VALUES(	
			@INTcliente,
			@DTfecha,
			@INTcosto
			)
	set @INTid_venta = SCOPE_IDENTITY()				
SALIDA:
	SELECT @nStatus, @strMessage
	RETURN 
END
GO

/* Procedimiento para consultar las ventas por fechas*/
IF EXISTS (
	SELECT 'h' FROM DBO.SYSOBJECTS 
		WHERE id = OBJECT_ID(N'[dbo].[consultar_ventas_fecha]')AND 
		OBJECTPROPERTY(id, N'IsProcedure') = 1)
	DROP PROCEDURE [dbo].[consultar_ventas_fecha]
GO

CREATE PROCEDURE [dbo].[consultar_ventas_fecha]
	@DTfecha_ini DATETIME = NULL, 
	@DTfecha_fin DATETIME = NULL,
	@INTsocio INT = NULL,
	@nStatus INT OUTPUT,                     
    @strMessage VARCHAR(250) OUTPUT 
AS	
BEGIN
	
	SET @nStatus = 0		
	SET @strMessage = 'TRANSACCIÓN SATISFACTORIA'                             			
			
	SELECT id_ventas, nombre, apellidos, costo, fecha 
		FROM 		
		 ventas inner join socios 
		 ON 
		 cliente=numero_socios AND
		 numero_socios = ISNULL(@INTsocio, numero_socios) AND
		 fecha BETWEEN @DTfecha_ini AND @DTfecha_fin	
SALIDA:
	SELECT @nStatus, @strMessage
	RETURN
END
GO

/* Procedimiento para consultar las ventas */
IF EXISTS (
	SELECT 'h' FROM DBO.SYSOBJECTS 
		WHERE id = OBJECT_ID(N'[dbo].[consultar_ventas]')AND 
		OBJECTPROPERTY(id, N'IsProcedure') = 1)
	DROP PROCEDURE [dbo].[consultar_ventas]
GO

CREATE PROCEDURE [dbo].[consultar_ventas]
	@nStatus INT OUTPUT,                     
    @strMessage VARCHAR(250) OUTPUT 
AS	
BEGIN
	
	SET @nStatus = 0		
	SET @strMessage = 'TRANSACCIÓN SATISFACTORIA'                             			
			
	SELECT id_ventas, nombre, apellidos, costo, fecha 
		FROM 		
		 ventas inner join socios 
		 ON 
		 cliente=numero_socios
									
SALIDA:
	SELECT @nStatus, @strMessage
	RETURN
END
GO

exec dbo.consultar_ventas_fecha '13/05/2012','20/05/2012',null,null,null

select GETDATE()