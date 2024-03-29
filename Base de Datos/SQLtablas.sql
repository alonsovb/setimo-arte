USE [proyectoWeb2]
GO
/****** Object:  Table [dbo].[generos]    Script Date: 05/08/2012 17:56:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[generos](
	[id_generos] [int] IDENTITY(1,1) NOT NULL,
	[descripcion] [text] NULL,
 CONSTRAINT [PK_generos] PRIMARY KEY CLUSTERED 
(
	[id_generos] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[socios]    Script Date: 05/08/2012 17:56:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE TABLE [dbo].[socios](
	[numero_socios] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [nchar](50) NOT NULL,
	[apellidos] [nchar](100) NOT NULL,
	[fotografia] [image] NULL,
	[telefono] [int] NULL,
	[email] [nchar](70) NULL,
	[direccion] [nchar](200) NULL,
	[fecha_afiliacion] [timestamp] NULL,
	[estado] [int] NOT NULL,
 CONSTRAINT [PK_socios] PRIMARY KEY CLUSTERED 
(
	[numero_socios] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[precios_ventas]    Script Date: 05/08/2012 17:56:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[precios_ventas](
	[id_precios_ventas] [int] IDENTITY(1,1) NOT NULL,
	[tipo] [nchar](50) NULL,
	[precio] [int] NULL,
 CONSTRAINT [PK_precios_ventas] PRIMARY KEY CLUSTERED 
(
	[id_precios_ventas] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[precios_alquileres]    Script Date: 05/08/2012 17:56:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[precios_alquileres](
	[id_precios_alquileres] [int] IDENTITY(1,1) NOT NULL,
	[tipo] [nchar](50) NULL,
	[precio_dvd] [int] NULL,
	[precio_blueray] [int] NULL,
	[precio_hddvd] [int] NULL,
 CONSTRAINT [PK_precios_alquileres] PRIMARY KEY CLUSTERED 
(
	[id_precios_alquileres] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[plazos]    Script Date: 05/08/2012 17:56:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[plazos](
	[id_tipo] [int] IDENTITY(1,1) NOT NULL,
	[tipo] [nchar](50) NULL,
	[dias] [smallint] NULL,
 CONSTRAINT [PK_plazos] PRIMARY KEY CLUSTERED 
(
	[id_tipo] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[peliculas]    Script Date: 05/08/2012 17:56:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[peliculas](
	[id_peliculas] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [nchar](60) NULL,
	[genero] [int] NULL,
	[inventario_dvd] [int] NULL,
	[inventario_blueray] [int] NULL,
	[inventario_hddvd] [int] NULL,
 CONSTRAINT [PK_peliculas] PRIMARY KEY CLUSTERED 
(
	[id_peliculas] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[alquileres]    Script Date: 05/08/2012 17:56:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[alquileres](
	[id_alquileres] [int] IDENTITY(1,1) NOT NULL,
	[socio] [int] NULL,
	[fecha] [timestamp] NULL,
	[entrega] [date] NULL,
	[costo] [int] NULL,
	[plazo] [int] NULL,
	[devuelto] [char](1) NULL,
 CONSTRAINT [PK_alquileres] PRIMARY KEY CLUSTERED 
(
	[id_alquileres] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  StoredProcedure [dbo].[insertar_generos]    Script Date: 05/08/2012 17:56:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/*Procedimiento para insertar a las personas*/
CREATE PROCEDURE [dbo].[insertar_generos]
	@STRdescripcion TEXT = NULL,	
	@nStatus INT OUTPUT,                     
    @strMessage VARCHAR(250) OUTPUT

AS	
BEGIN
	
	SET @nStatus = 0		
	SET @strMessage = 'TRANSACCIÓN SATISFACTORIA'                             			
			
INSERT INTO [dbo].[generos]
		( [descripcion] )
           
     VALUES( @STRdescripcion )
					
SALIDA:
	SELECT @nStatus, @strMessage
	RETURN 
END
GO
/****** Object:  Table [dbo].[ventas]    Script Date: 05/08/2012 17:56:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ventas](
	[id_ventas] [int] IDENTITY(1,1) NOT NULL,
	[cliente] [int] NULL,
	[fecha] [timestamp] NULL,
	[costo] [int] NULL,
 CONSTRAINT [PK_ventas] PRIMARY KEY CLUSTERED 
(
	[id_ventas] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ventas_peliculas]    Script Date: 05/08/2012 17:56:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ventas_peliculas](
	[id_ventas_peliculas] [int] IDENTITY(1,1) NOT NULL,
	[venta] [int] NULL,
	[pelicula] [int] NULL,
 CONSTRAINT [PK_ventas_peliculas] PRIMARY KEY CLUSTERED 
(
	[id_ventas_peliculas] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  StoredProcedure [dbo].[insertar_peliculas]    Script Date: 05/08/2012 17:56:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
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
/****** Object:  Table [dbo].[alquileres_peliculas]    Script Date: 05/08/2012 17:56:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[alquileres_peliculas](
	[id_alquileres_peliculas] [int] IDENTITY(1,1) NOT NULL,
	[alquiler] [int] NULL,
	[pelicula] [int] NULL,
	[total_dvd] [int] NULL,
	[total_blueray] [int] NULL,
	[total_hddvd] [int] NULL,
 CONSTRAINT [PK_alquileres_peliculas] PRIMARY KEY CLUSTERED 
(
	[id_alquileres_peliculas] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  StoredProcedure [dbo].[insertar_ventas_peliculas]    Script Date: 05/08/2012 17:56:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/*Procedimiento para insertar a las personas*/
CREATE PROCEDURE [dbo].[insertar_ventas_peliculas]
	@INTventa INT = NULL,
	@INTpelicula INT = NULL,
	@nStatus INT OUTPUT,                     
    @strMessage VARCHAR(250) OUTPUT

AS	
BEGIN
	
	SET @nStatus = 0		
	SET @strMessage = 'TRANSACCIÓN SATISFACTORIA'                             			
			
INSERT INTO [dbo].[ventas_peliculas]
		( [venta],
		  [pelicula] 
		)
           
     VALUES(
			@INTventa,
			@INTpelicula
			)
					
SALIDA:
	SELECT @nStatus, @strMessage
	RETURN 
END
GO
/****** Object:  ForeignKey [FK_alquileres_plazos]    Script Date: 05/08/2012 17:56:17 ******/
ALTER TABLE [dbo].[alquileres]  WITH CHECK ADD  CONSTRAINT [FK_alquileres_plazos] FOREIGN KEY([plazo])
REFERENCES [dbo].[plazos] ([id_tipo])
GO
ALTER TABLE [dbo].[alquileres] CHECK CONSTRAINT [FK_alquileres_plazos]
GO
/****** Object:  ForeignKey [FK_alquileres_socios]    Script Date: 05/08/2012 17:56:17 ******/
ALTER TABLE [dbo].[alquileres]  WITH CHECK ADD  CONSTRAINT [FK_alquileres_socios] FOREIGN KEY([socio])
REFERENCES [dbo].[socios] ([numero_socios])
GO
ALTER TABLE [dbo].[alquileres] CHECK CONSTRAINT [FK_alquileres_socios]
GO
/****** Object:  ForeignKey [FK_alquileres_peliculas_alquileres]    Script Date: 05/08/2012 17:56:17 ******/
ALTER TABLE [dbo].[alquileres_peliculas]  WITH CHECK ADD  CONSTRAINT [FK_alquileres_peliculas_alquileres] FOREIGN KEY([alquiler])
REFERENCES [dbo].[alquileres] ([id_alquileres])
GO
ALTER TABLE [dbo].[alquileres_peliculas] CHECK CONSTRAINT [FK_alquileres_peliculas_alquileres]
GO
/****** Object:  ForeignKey [FK_alquileres_peliculas_peliculas]    Script Date: 05/08/2012 17:56:17 ******/
ALTER TABLE [dbo].[alquileres_peliculas]  WITH CHECK ADD  CONSTRAINT [FK_alquileres_peliculas_peliculas] FOREIGN KEY([pelicula])
REFERENCES [dbo].[peliculas] ([id_peliculas])
GO
ALTER TABLE [dbo].[alquileres_peliculas] CHECK CONSTRAINT [FK_alquileres_peliculas_peliculas]
GO
/****** Object:  ForeignKey [FK_peliculas_generos]    Script Date: 05/08/2012 17:56:17 ******/
ALTER TABLE [dbo].[peliculas]  WITH CHECK ADD  CONSTRAINT [FK_peliculas_generos] FOREIGN KEY([genero])
REFERENCES [dbo].[generos] ([id_generos])
GO
ALTER TABLE [dbo].[peliculas] CHECK CONSTRAINT [FK_peliculas_generos]
GO
/****** Object:  ForeignKey [FK_ventas_socios]    Script Date: 05/08/2012 17:56:17 ******/
ALTER TABLE [dbo].[ventas]  WITH CHECK ADD  CONSTRAINT [FK_ventas_socios] FOREIGN KEY([cliente])
REFERENCES [dbo].[socios] ([numero_socios])
GO
ALTER TABLE [dbo].[ventas] CHECK CONSTRAINT [FK_ventas_socios]
GO
/****** Object:  ForeignKey [FK_ventas_peliculas_peliculas]    Script Date: 05/08/2012 17:56:17 ******/
ALTER TABLE [dbo].[ventas_peliculas]  WITH CHECK ADD  CONSTRAINT [FK_ventas_peliculas_peliculas] FOREIGN KEY([pelicula])
REFERENCES [dbo].[peliculas] ([id_peliculas])
GO
ALTER TABLE [dbo].[ventas_peliculas] CHECK CONSTRAINT [FK_ventas_peliculas_peliculas]
GO
/****** Object:  ForeignKey [FK_ventas_peliculas_ventas]    Script Date: 05/08/2012 17:56:17 ******/
ALTER TABLE [dbo].[ventas_peliculas]  WITH CHECK ADD  CONSTRAINT [FK_ventas_peliculas_ventas] FOREIGN KEY([venta])
REFERENCES [dbo].[ventas] ([id_ventas])
GO
ALTER TABLE [dbo].[ventas_peliculas] CHECK CONSTRAINT [FK_ventas_peliculas_ventas]
GO
