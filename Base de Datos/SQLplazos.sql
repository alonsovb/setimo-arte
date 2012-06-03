/*Procedimiento para insertar en los plazos*/
CREATE PROCEDURE [dbo].[insertar_plazos]
	@STRtipo VARCHAR(50) = NULL,
	@INTdias SMALLINT = NULL,		
	@nStatus INT OUTPUT,                     
    @strMessage VARCHAR(250) OUTPUT

AS	
BEGIN
	
	SET @nStatus = 0		
	SET @strMessage = 'TRANSACCIÓN SATISFACTORIA'                             			
			
INSERT INTO [dbo].[plazos]
		( [tipo],
          [dias])
           
     VALUES(	
			@STRtipo,
			@INTdias
			)
					
SALIDA:
	SELECT @nStatus, @strMessage
	RETURN 
END
GO


/* Procedimiento para consultar los plazos */
IF EXISTS (
	SELECT 'h' FROM DBO.SYSOBJECTS 
		WHERE id = OBJECT_ID(N'[dbo].[consultar_plazos]')AND 
		OBJECTPROPERTY(id, N'IsProcedure') = 1)
	DROP PROCEDURE [dbo].[consultar_generos]
GO

CREATE PROCEDURE [dbo].[consultar_plazos]
	@nStatus INT OUTPUT,                     
    @strMessage VARCHAR(250) OUTPUT 
AS	
BEGIN
	
	SET @nStatus = 0		
	SET @strMessage = 'TRANSACCIÓN SATISFACTORIA'                             			
			
	SELECT
		individual,
		doble_triple,
		multiple		
	FROM 
		(SELECT dias as individual FROM plazos WHERE tipo = 'individual') as ind,
		(SELECT dias as doble_triple FROM plazos WHERE tipo = 'doble_triple') as DT,
		(SELECT dias as multiple FROM plazos WHERE tipo = 'multiple') as multi
						
SALIDA:
	SELECT @nStatus, @strMessage
	RETURN
END
GO






-- Procedimiento para modificar el plazo de dias de los alquileres

IF EXISTS (
	SELECT 'h' FROM DBO.SYSOBJECTS 
		WHERE id = OBJECT_ID(N'[dbo].[editar_plazos]')AND 
		OBJECTPROPERTY(id, N'IsProcedure') = 1)
	DROP PROCEDURE [dbo].[editar_plazos]
GO


CREATE PROCEDURE [dbo].[editar_plazos]
	@INTindividual INT = NULL, 
	@INTdoble_triple INT = NULL,
	@INTmultiple INT = NULL,
	@nStatus INT OUTPUT,                     
    @strMessage VARCHAR(250) OUTPUT 
AS	
BEGIN
	
	SET @nStatus = 0		
	SET @strMessage = 'TRANSACCIÓN SATISFACTORIA'                             			
					
UPDATE [dbo].[plazos]

	SET	  [dias] = ISNULL(@INTindividual, [dias])
    WHERE [tipo] = 'individual'

UPDATE [dbo].[plazos]

	SET	  [dias] = ISNULL(@INTdoble_triple, [dias])
    WHERE [tipo] = 'doble_triple'

UPDATE [dbo].[plazos]

	SET	  [dias] = ISNULL(@INTmultiple, [dias])
    WHERE [tipo] = 'multiple'   

SALIDA:
	SELECT @nStatus, @strMessage
	RETURN
END
GO

exec insertar_plazos 'individual',0,null,null;
exec insertar_plazos 'doble_triple',0,null,null;
exec insertar_plazos 'multiple',0,null,null;

exec consultar_plazos null, null