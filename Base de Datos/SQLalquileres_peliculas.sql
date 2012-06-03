/*Procedimiento para insertar a la relacion entre alquileres y peliculas*/
CREATE PROCEDURE [dbo].[insertar_alquileres_peliculas]
	@INTalquiler INT = NULL,
	@INTpelicula INT = NULL,		
	@INTtotal_dvd INT = NULL, 	
	@INTtotal_blueray INT = NULL,
	@INTtotal_hddvd INT = NULL,	
	@nStatus INT OUTPUT,                     
    @strMessage VARCHAR(250) OUTPUT

AS	
BEGIN
	
	SET @nStatus = 0		
	SET @strMessage = 'TRANSACCIÓN SATISFACTORIA'                             			
	
	BEGIN TRAN reducir_inventario
	BEGIN TRY
			
	INSERT INTO [dbo].[alquileres_peliculas]
		( [alquiler],
          [pelicula],
          [total_dvd],
          [total_blueray],
          [total_hddvd])
           
     VALUES(	
			@INTalquiler,
			@INTpelicula,
			@INTtotal_dvd,
			@INTtotal_blueray,
			@INTtotal_hddvd
			)
			
	UPDATE [dbo].[peliculas]

	SET		
		   [inventario_dvd] = [inventario_dvd] - @INTtotal_dvd,
		   [inventario_blueray] = [inventario_blueray] - @INTtotal_blueray,
		   [inventario_hddvd] = [inventario_hddvd] - @INTtotal_hddvd
           
	FROM peliculas
    WHERE id_peliculas = @INTpelicula
	
	COMMIT TRAN reducir_inventario
	END TRY
	BEGIN CATCH
		ROLLBACK TRAN reducir_inventario 
	END CATCH
	
					
SALIDA:
	SELECT @nStatus, @strMessage
	RETURN 
END
GO


/* Procedimiento para consultar las peliculas de un alquiler */
IF EXISTS (
	SELECT 'h' FROM DBO.SYSOBJECTS 
		WHERE id = OBJECT_ID(N'[dbo].[consultar_alquileres_peliculas]')AND 
		OBJECTPROPERTY(id, N'IsProcedure') = 1)
	DROP PROCEDURE [dbo].[consultar_alquileres_peliculas]
GO

CREATE PROCEDURE [dbo].[consultar_alquileres_peliculas]
	@INTalquiler INT = NULL, 	
	@nStatus INT OUTPUT,                     
    @strMessage VARCHAR(250) OUTPUT 
AS	
BEGIN
	
	SET @nStatus = 0		
	SET @strMessage = 'TRANSACCIÓN SATISFACTORIA'                             			
			
	SELECT
		id_peliculas
		nombre,
		descripcion
	FROM 
		peliculas p inner join generos		
	ON 
		p.id_peliculas = ISNULL(@INTalquiler, p.id_peliculas) AND
		p.genero = generos.id_generos
		
SALIDA:
	SELECT @nStatus, @strMessage
	RETURN
END
GO