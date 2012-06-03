/*Procedimiento para insertar los socios*/
CREATE PROCEDURE [dbo].[insertar_socios]
	@STRnombre VARCHAR(50) = NULL,
	@STRapellidos VARCHAR(100) = NULL,
	@IMAfotografia IMAGE = NULL,
	@INTtelefono INT = NULL,		
	@STRemail VARCHAR(70) = NULL, 	
	@STRdireccion VARCHAR(200) = NULL,
	@DTfecha_afiliacion DATETIME = NULL,
	@INTestado INT = NULL,	
	@nStatus INT OUTPUT,                     
    @strMessage VARCHAR(250) OUTPUT

AS	
BEGIN
	
	SET @nStatus = 0		
	SET @strMessage = 'TRANSACCIÓN SATISFACTORIA'                             			
			
INSERT INTO [dbo].[socios]
		( [nombre],
          [apellidos],
          [fotografia],
          [telefono],
          [email],
          [direccion],
          [fecha_afiliacion],
          [estado],
          [ultimo_alquiler])
           
     VALUES(	
			@STRnombre,
			@STRapellidos,
			@IMAfotografia,
			@INTtelefono,
			@STRemail,
			@STRdireccion,
			@DTfecha_afiliacion,
			@INTestado,
			@DTfecha_afiliacion
			)
					
SALIDA:
	SELECT @nStatus, @strMessage
	RETURN 
END
GO


/* Procedimiento para consultar los socios */
IF EXISTS (
	SELECT 'h' FROM DBO.SYSOBJECTS 
		WHERE id = OBJECT_ID(N'[dbo].[consultar_socios]')AND 
		OBJECTPROPERTY(id, N'IsProcedure') = 1)
	DROP PROCEDURE [dbo].[consultar_socios]
GO

CREATE PROCEDURE [dbo].[consultar_socios]
	@INTnumero_socios INT = NULL, 
	@STRnombre VARCHAR(30) = null,
	@STRapellidos VARCHAR(100) = null,	
	@nStatus INT OUTPUT,                     
    @strMessage VARCHAR(250) OUTPUT 
AS	
BEGIN
	
	SET @nStatus = 0		
	SET @strMessage = 'TRANSACCIÓN SATISFACTORIA'                             			
			
	SELECT
		numero_socios,
		nombre,
		apellidos,
		fotografia,
		telefono,
		fotografia,
		email,
		direccion,
		estado
	FROM 
		socios s		
	WHERE 
		s.numero_socios = ISNULL(@INTnumero_socios, s.numero_socios) AND
		s.nombre = ISNULL(@STRnombre, s.nombre) AND
		s.apellidos = ISNULL(@STRapellidos, s.apellidos)
					
SALIDA:
	SELECT @nStatus, @strMessage
	RETURN
END
GO


/* Procedimiento para verificar la actividad de un socio
   cada 90 dias pasa a ser inactivo */
   
CREATE PROCEDURE [dbo].[actualizar_socios_activos]
AS	
	DECLARE @INTsocio as INT
	DECLARE @DTultimo_alq as DATETIME
	DECLARE @DTfecha_actual as DATETIME
	DECLARE @INTdiferencia as INT
	-- se crea la declaración de las variables
	DECLARE cursor_activos cursor for
	select numero_socios, ultimo_alquiler from socios
	-- se abre el cursor
	open cursor_activos
	-- avanzamos al primer registro para cargar nuestras variables
	FETCH NEXT FROM cursor_activos
	into @INTsocio, @DTultimo_alq
	while @@FETCH_STATUS = 0
BEGIN
	SET @DTfecha_actual = GETDATE()
	SET @INTdiferencia = DATEDIFF(DAY,@DTultimo_alq, @DTfecha_actual)
	
	IF @INTdiferencia >= 90
	BEGIN
		UPDATE dbo.socios
		SET estado =  1
		from socios
		where numero_socios = @INTsocio
	END
	FETCH NEXT FROM cursor_activos
	into @INTsocio, @DTultimo_alq
END
CLOSE cursor_activos
deallocate cursor_activos
GO
