/*Procedimiento para insertar los alquileres*/
CREATE PROCEDURE [dbo].[insertar_alquileres]
	@INTsocio INT = NULL,		
	@DTfecha DATETIME = NULL,
	@DTentrega DATETIME = NULL,
	@INTcosto INT = NULL,		
	@INTplazo INT = NULL,
	@CHARdevuelto CHAR = NULL,	
	@nStatus INT OUTPUT,                     
    @strMessage VARCHAR(250) OUTPUT,
    @INTid_alquiler INT OUTPUT

AS	
BEGIN
	
	SET @nStatus = 0		
	SET @strMessage = 'TRANSACCIÓN SATISFACTORIA'                             			
			
BEGIN TRAN actulizar_socio
BEGIN TRY			
INSERT INTO [dbo].[alquileres]
		( [socio],
          [fecha],
          [entrega],
          [costo],
          [plazo],
          [devuelto])
           
     VALUES(	
			@INTsocio,
			@DTfecha,
			@DTentrega,
			@INTcosto,
			@INTplazo,
			@CHARdevuelto
			)
			set @INTid_alquiler = SCOPE_IDENTITY()
				
UPDATE [dbo].[socios]

	SET		
		   [ultimo_alquiler] = ISNULL(@DTfecha, [ultimo_alquiler]),
		   [estado] = 1
           
	FROM socios
    WHERE numero_socios = @INTsocio 

COMMIT TRAN actualizar_socio
END TRY
BEGIN CATCH
	ROLLBACK TRAN actualizar_socio
END CATCH
				
SALIDA:
	SELECT @nStatus, @strMessage
	RETURN 
END
GO

/* Procedimiento para consultar los alquileres pendientes */
IF EXISTS (
	SELECT 'h' FROM DBO.SYSOBJECTS 
		WHERE id = OBJECT_ID(N'[dbo].[consultar_alquileres_pendientes]')AND 
		OBJECTPROPERTY(id, N'IsProcedure') = 1)
	DROP PROCEDURE [dbo].[consultar_alquileres_pendientes]
GO

CREATE PROCEDURE [dbo].[consultar_alquileres_pendientes]
	@nStatus INT OUTPUT,                     
    @strMessage VARCHAR(250) OUTPUT 
AS	
BEGIN
	
	SET @nStatus = 0		
	SET @strMessage = 'TRANSACCIÓN SATISFACTORIA'                             			
			
	SELECT
		id_alquileres,
		nombre,
		apellidos,
		entrega,
		costo
	FROM 
		alquileres a inner join socios s		
	ON
		a.socio=s.numero_socios and devuelto = 0 and entrega < GETDATE()		
SALIDA:
	SELECT @nStatus, @strMessage
	RETURN
END
GO

/* Procedimiento para consultar los alquileres aun activos */
IF EXISTS (
	SELECT 'h' FROM DBO.SYSOBJECTS 
		WHERE id = OBJECT_ID(N'[dbo].[consultar_alquileres_activos]')AND 
		OBJECTPROPERTY(id, N'IsProcedure') = 1)
	DROP PROCEDURE [dbo].[consultar_alquileres_activos]
GO

CREATE PROCEDURE [dbo].[consultar_alquileres_activos]
	@nStatus INT OUTPUT,                     
    @strMessage VARCHAR(250) OUTPUT 
AS	
BEGIN
	
	SET @nStatus = 0		
	SET @strMessage = 'TRANSACCIÓN SATISFACTORIA'                             			
			
	SELECT
		id_alquileres,
		nombre,
		apellidos,
		entrega,
		costo
	FROM 
		alquileres a inner join socios s		
	ON
		a.socio=s.numero_socios and devuelto = 0 and entrega >= GETDATE()		
SALIDA:
	SELECT @nStatus, @strMessage
	RETURN
END
GO

/* Procedimiento para consultar los alquileres por id */
IF EXISTS (
	SELECT 'h' FROM DBO.SYSOBJECTS 
		WHERE id = OBJECT_ID(N'[dbo].[consultar_alquileres_id]')AND 
		OBJECTPROPERTY(id, N'IsProcedure') = 1)
	DROP PROCEDURE [dbo].[consultar_alquileres_id]
GO

CREATE PROCEDURE [dbo].[consultar_alquileres_id]
	@INTid_alquiler INT = NULL,
	@nStatus INT OUTPUT,                     
    @strMessage VARCHAR(250) OUTPUT 
AS	
BEGIN
	
	SET @nStatus = 0		
	SET @strMessage = 'TRANSACCIÓN SATISFACTORIA'                             			
			
	SELECT
		id_alquileres,
		nombre,
		apellidos,
		entrega,
		costo
	FROM 
		alquileres a inner join socios s		
	ON
		a.socio=s.numero_socios and id_alquileres = @INTid_alquiler
SALIDA:
	SELECT @nStatus, @strMessage
	RETURN
END
GO

/* Procedimiento para consultar las peliculas asociadas a un alquiler */
IF EXISTS (
	SELECT 'h' FROM DBO.SYSOBJECTS 
		WHERE id = OBJECT_ID(N'[dbo].[consultar_alquileres_peliculas]')AND 
		OBJECTPROPERTY(id, N'IsProcedure') = 1)
	DROP PROCEDURE [dbo].[consultar_alquileres_peliculas]
GO

CREATE PROCEDURE [dbo].[consultar_alquileres_peliculas]
	@INTid_alquiler INT = NULL,
	@nStatus INT OUTPUT,                     
    @strMessage VARCHAR(250) OUTPUT 
AS	
BEGIN
	
	SET @nStatus = 0		
	SET @strMessage = 'TRANSACCIÓN SATISFACTORIA'                             			
	
	SELECT 
		p.nombre	
	FROM		
		(SELECT pelicula 
		FROM alquileres a inner join alquileres_peliculas ap 
		ON id_alquileres = @INTid_alquiler and alquiler=id_alquileres) as alq
	inner join
	peliculas p
	ON alq.pelicula = p.id_peliculas
	
	
SALIDA:
	SELECT @nStatus, @strMessage
	RETURN
END
GO



/* Procedimiento para consultar los alquileres por fecha */
IF EXISTS (
	SELECT 'h' FROM DBO.SYSOBJECTS 
		WHERE id = OBJECT_ID(N'[dbo].[consultar_alquileres_fecha]')AND 
		OBJECTPROPERTY(id, N'IsProcedure') = 1)
	DROP PROCEDURE [dbo].[consultar_alquileres_fecha]
GO

CREATE PROCEDURE [dbo].[consultar_alquileres_fecha]
	@DTfecha_ini DATETIME = NULL,
	@DTfecha_fin DATETIME = NULL,
	@INTsocio INT = NULL,
	@nStatus INT OUTPUT,                     
    @strMessage VARCHAR(250) OUTPUT 
AS	
BEGIN
	
	SET @nStatus = 0		
	SET @strMessage = 'TRANSACCIÓN SATISFACTORIA'                             			
			
	SELECT
		id_alquileres,
		nombre,
		apellidos,
		email,
		entrega,
		costo
	FROM 
		alquileres a inner join socios s		
	ON
		a.socio=s.numero_socios and devuelto = 0 and 
		numero_socios = ISNULL(@INTsocio, numero_socios) and
		entrega BETWEEN @DTfecha_ini and @DTfecha_fin
				
SALIDA:
	SELECT @nStatus, @strMessage
	RETURN
END
GO


/* Procedimiento para modificar la informacion de los alquileres */

IF EXISTS (
	SELECT 'h' FROM DBO.SYSOBJECTS 
		WHERE id = OBJECT_ID(N'[dbo].[modificar_alquileres]')AND 
		OBJECTPROPERTY(id, N'IsProcedure') = 1)
	DROP PROCEDURE [dbo].[modificar_alquileres]
GO

CREATE PROCEDURE [dbo].[modificar_alquileres]
	@INTid_alquiler INT = NULL,
	@CHARdevuelto CHAR = NULL,
	@nStatus INT OUTPUT,                     
    @strMessage VARCHAR(250) OUTPUT 
AS	
BEGIN
	SET @nStatus = 0		
	SET @strMessage = 'TRANSACCIÓN SATISFACTORIA'                             			
			
	BEGIN TRAN reducir_inventario
	BEGIN TRY
	UPDATE [dbo].[alquileres]
	SET		
		   [devuelto] = ISNULL(@CHARdevuelto, [devuelto])
    FROM alquileres
    WHERE [id_alquileres] = @INTid_alquiler
    
    UPDATE socios
    SET
		estado = 0
	FROM socios inner join alquileres
	ON numero_socios = socio and id_alquileres = @INTid_alquiler	
	
	exec dbo.actualizar_inventario_peliculas @INTid_alquiler,null,null;
	
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

/* Procedimiento para actualizar los datos de las peliculas */
IF EXISTS (
	SELECT 'h' FROM DBO.SYSOBJECTS 
		WHERE id = OBJECT_ID(N'[dbo].[actualizar_inventario_peliculas]')AND 
		OBJECTPROPERTY(id, N'IsProcedure') = 1)
	DROP PROCEDURE [dbo].[actualizar_inventario_peliculas]
GO

CREATE PROCEDURE [dbo].[actualizar_inventario_peliculas]
	@INTid_alquiler INT = NULL,
	@nStatus INT OUTPUT,                     
    @strMessage VARCHAR(250) OUTPUT 
AS	
BEGIN
	SET @nStatus = 0		
	SET @strMessage = 'TRANSACCIÓN SATISFACTORIA'                             			
			
	UPDATE [dbo].[peliculas]
	SET		
		   [inventario_dvd] = inventario_dvd +total_dvd,
		   [inventario_blueray] = inventario_blueray + total_blueray,
		   [inventario_hddvd] = inventario_hddvd + total_hddvd
           
	FROM 
		(SELECT ap.*
		FROM alquileres a inner join alquileres_peliculas ap 
		ON a.id_alquileres = @INTid_alquiler and id_alquileres = alquiler) as alq
	inner join
		peliculas p
    ON 
		alq.pelicula = id_peliculas
		
SALIDA:
	SELECT @nStatus, @strMessage
	RETURN
END
GO


/* Procedimiento para verificar la actividad de un socio
   luego de que se cumple la fecha de entrega se pasa a moroso*/
   
CREATE PROCEDURE [dbo].[actualizar_socios_morosos]
AS	
	DECLARE @INTsocio as INT
	DECLARE @DTfecha_entrega as DATETIME
	DECLARE @DTfecha_actual as DATETIME
	-- se crea la declaración de las variables
	DECLARE cursor_morosos cursor for
	select numero_socios,entrega 
	from socios s inner join alquileres a
	on s.numero_socios = a.socio
	-- se abre el cursor
	open cursor_morosos
	-- avanzamos al primer registro para cargar nuestras variables
	FETCH NEXT FROM cursor_morosos
	into @INTsocio, @DTfecha_entrega
	while @@FETCH_STATUS = 0
BEGIN
	SET @DTfecha_actual = GETDATE()
		
	IF @DTfecha_actual > @DTfecha_entrega
	BEGIN
		UPDATE dbo.socios
		SET estado =  2
		from socios
		where numero_socios = @INTsocio
	END
	FETCH NEXT FROM cursor_morosos
	into @INTsocio, @DTfecha_entrega
END
CLOSE cursor_morosos
deallocate cursor_morosos
GO

/* Procedimiento para verificar la actividad de un socio
   si esta moroso se le envia un correo*/
CREATE PROCEDURE [dbo].[enviar_correo_morosos]
AS	
	DECLARE @STRemail as VARCHAR(100)
	-- se crea la declaración de las variables
	DECLARE cursor_correo_morosos cursor for
	select email
	from socios 
	where estado=1
	-- se abre el cursor
	open cursor_correo_morosos
	-- avanzamos al primer registro para cargar nuestras variables
	FETCH NEXT FROM cursor_correo_morosos
	into @STRemail
	while @@FETCH_STATUS = 0
BEGIN
	EXEC  msdb.dbo.sp_send_dbmail @profile_name='Sétimo Arte',
	@recipients= @STRemail,
	@subject= 'Prueba de envio desde SQL Server con procedimiento',
	@body= 'Aqui va el contenido o cuerpo del e-mail'
	FETCH NEXT FROM cursor_correo_morosos
	into @STRemail
END
CLOSE cursor_correo_morosos
deallocate cursor_correo_morosos
GO



CREATE PROCEDURE [dbo].[enviar_correo]
	@STRcorreo VARCHAR(50) = NULL
AS
BEGIN
	EXEC  msdb.dbo.sp_send_dbmail @profile_name='Sétimo Arte',
	@recipients= @STRcorreo,
	@subject= 'Prueba de envio desde SQL Server con procedimiento',
	@body= 'Aqui va el contenido o cuerpo del e-mail'
END
GO


