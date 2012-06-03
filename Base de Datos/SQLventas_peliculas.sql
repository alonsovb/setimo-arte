/*Procedimiento para insertar en la relacion de las ventas con las peliculas*/
CREATE PROCEDURE [dbo].[insertar_ventas_peliculas]
	@INTventa INT = NULL,
	@INTpelicula INT = NULL,
	@nStatus INT OUTPUT,                     
    @strMessage VARCHAR(250) OUTPUT

AS	
BEGIN
	
	SET @nStatus = 0		
	SET @strMessage = 'TRANSACCIÓN SATISFACTORIA' 
	
	BEGIN TRAN red_inventario
	BEGIN TRY                          			
			
	INSERT INTO [dbo].[ventas_peliculas]
		( [venta],
		  [pelicula] 
		)
           
	VALUES(
			@INTventa,
			@INTpelicula
			)
	UPDATE [dbo].[peliculas]

	SET		
		   [inventario_dvd] = [inventario_dvd] - 1
           
	FROM peliculas
    WHERE id_peliculas = @INTpelicula
    
    COMMIT TRAN red_inventario
	END TRY
	BEGIN CATCH
		ROLLBACK TRAN red_inventario 
	END CATCH
					
SALIDA:
	SELECT @nStatus, @strMessage
	RETURN 
END
GO


/* Procedimiento para consultar las peliculas de una venta especifica */
IF EXISTS (
	SELECT 'h' FROM DBO.SYSOBJECTS 
		WHERE id = OBJECT_ID(N'[dbo].[consultar_ventas_peliculas]')AND 
		OBJECTPROPERTY(id, N'IsProcedure') = 1)
	DROP PROCEDURE [dbo].[consultar_ventas_peliculas]
GO

CREATE PROCEDURE [dbo].[consultar_ventas_peliculas]
	@INTid_venta INT = NULL, 
	@nStatus INT OUTPUT,                     
    @strMessage VARCHAR(250) OUTPUT 
AS	
BEGIN
	
	SET @nStatus = 0		
	SET @strMessage = 'TRANSACCIÓN SATISFACTORIA'                             			
	
	SELECT id_peliculas, nombre, descripcion 
	FROM
		(SELECT id_peliculas,nombre, genero		
		FROM peliculas p INNER JOIN ventas_peliculas		
		ON venta = @INTid_venta) as p
	INNER JOIN 
		generos
	ON genero = id_generos
					
SALIDA:
	SELECT @nStatus, @strMessage
	RETURN
END
GO