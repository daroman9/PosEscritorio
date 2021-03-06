USE [master]
GO
/****** Object:  Database [dbventas]    Script Date: 14/01/2021 16:22:19 ******/
CREATE DATABASE [dbventas]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'dbventas', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.SQLEXPRESS\MSSQL\DATA\dbventas.mdf' , SIZE = 12288KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'dbventas_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.SQLEXPRESS\MSSQL\DATA\dbventas_log.ldf' , SIZE = 12352KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [dbventas] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [dbventas].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [dbventas] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [dbventas] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [dbventas] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [dbventas] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [dbventas] SET ARITHABORT OFF 
GO
ALTER DATABASE [dbventas] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [dbventas] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [dbventas] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [dbventas] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [dbventas] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [dbventas] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [dbventas] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [dbventas] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [dbventas] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [dbventas] SET  DISABLE_BROKER 
GO
ALTER DATABASE [dbventas] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [dbventas] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [dbventas] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [dbventas] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [dbventas] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [dbventas] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [dbventas] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [dbventas] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [dbventas] SET  MULTI_USER 
GO
ALTER DATABASE [dbventas] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [dbventas] SET DB_CHAINING OFF 
GO
ALTER DATABASE [dbventas] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [dbventas] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [dbventas] SET DELAYED_DURABILITY = DISABLED 
GO
USE [dbventas]
GO
/****** Object:  Table [dbo].[articulo]    Script Date: 14/01/2021 16:22:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[articulo](
	[idarticulo] [int] IDENTITY(1,1) NOT NULL,
	[codigo] [varchar](50) NOT NULL,
	[marca] [varchar](50) NOT NULL,
	[descripcion] [varchar](50) NOT NULL,
	[imagen] [image] NULL,
	[idcategoria] [int] NOT NULL,
	[idpresentacion] [int] NULL,
	[contenido] [varchar](50) NULL,
	[descuento] [int] NULL,
 CONSTRAINT [PK_articulo] PRIMARY KEY CLUSTERED 
(
	[idarticulo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[categoria]    Script Date: 14/01/2021 16:22:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[categoria](
	[idcategoria] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](50) NOT NULL,
	[descripcion] [varchar](256) NULL,
 CONSTRAINT [PK_categoria] PRIMARY KEY CLUSTERED 
(
	[idcategoria] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[cliente]    Script Date: 14/01/2021 16:22:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[cliente](
	[idcliente] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](50) NULL,
	[apellidos] [varchar](50) NULL,
	[sexo] [varchar](20) NULL,
	[fecha_nacimiento] [date] NULL,
	[tipo_documento] [varchar](20) NULL,
	[num_documento] [varchar](20) NULL,
	[direccion] [varchar](50) NULL,
	[telefono] [varchar](20) NULL,
	[email] [varchar](50) NULL,
 CONSTRAINT [PK_cliente] PRIMARY KEY CLUSTERED 
(
	[idcliente] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[detalle_ingreso]    Script Date: 14/01/2021 16:22:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[detalle_ingreso](
	[iddetalle_ingreso] [int] IDENTITY(1,1) NOT NULL,
	[idingreso] [int] NOT NULL,
	[idarticulo] [int] NOT NULL,
	[precio_compra] [decimal](18, 0) NOT NULL,
	[precio_venta] [decimal](18, 0) NOT NULL,
	[stock_inicial] [int] NOT NULL,
	[stock_actual] [int] NOT NULL,
	[fecha_produccion] [date] NOT NULL,
	[fecha_vencimiento] [date] NOT NULL,
 CONSTRAINT [PK_detalle_ingreso] PRIMARY KEY CLUSTERED 
(
	[iddetalle_ingreso] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[detalle_venta]    Script Date: 14/01/2021 16:22:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[detalle_venta](
	[iddetalle_venta] [int] IDENTITY(1,1) NOT NULL,
	[idventa] [int] NOT NULL,
	[iddetalle_ingreso] [int] NOT NULL,
	[cantidad] [int] NOT NULL,
	[precio_venta] [decimal](18, 0) NOT NULL,
	[descuento] [decimal](18, 0) NOT NULL,
	[total] [decimal](18, 0) NOT NULL,
 CONSTRAINT [PK_detalle_venta] PRIMARY KEY CLUSTERED 
(
	[iddetalle_venta] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ingreso]    Script Date: 14/01/2021 16:22:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[ingreso](
	[idingreso] [int] IDENTITY(1,1) NOT NULL,
	[idtrabajador] [int] NOT NULL,
	[idproveedor] [int] NOT NULL,
	[fecha] [date] NOT NULL,
	[serie] [varchar](10) NOT NULL,
	[igv] [decimal](4, 2) NOT NULL,
	[estado] [varchar](7) NOT NULL,
 CONSTRAINT [PK_ingreso] PRIMARY KEY CLUSTERED 
(
	[idingreso] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[presentacion]    Script Date: 14/01/2021 16:22:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[presentacion](
	[idpresentacion] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](50) NOT NULL,
	[descripcion] [varchar](256) NOT NULL,
 CONSTRAINT [PK_presentacion] PRIMARY KEY CLUSTERED 
(
	[idpresentacion] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[proveedor]    Script Date: 14/01/2021 16:22:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[proveedor](
	[idproveedor] [int] IDENTITY(1,1) NOT NULL,
	[razon_social] [varchar](150) NOT NULL,
	[sector_comercial] [varchar](50) NOT NULL,
	[tipo_documento] [varchar](50) NOT NULL,
	[num_documento] [varchar](50) NOT NULL,
	[direccion] [varchar](256) NULL,
	[telefono] [varchar](50) NULL,
	[email] [varchar](50) NULL,
	[url] [varchar](150) NULL,
 CONSTRAINT [PK_proveedor] PRIMARY KEY CLUSTERED 
(
	[idproveedor] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[trabajador]    Script Date: 14/01/2021 16:22:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[trabajador](
	[idtrabajador] [int] IDENTITY(1,1) NOT NULL,
	[nombres] [varchar](50) NOT NULL,
	[apellidos] [varchar](50) NOT NULL,
	[sexo] [varchar](20) NOT NULL,
	[fecha_nacimiento] [date] NOT NULL,
	[num_documento] [varchar](20) NOT NULL,
	[direccion] [varchar](100) NULL,
	[telefono] [varchar](100) NULL,
	[email] [varchar](50) NULL,
	[acceso] [varchar](20) NOT NULL,
	[usuario] [varchar](20) NOT NULL,
	[password] [varchar](20) NOT NULL,
 CONSTRAINT [PK_trabajador] PRIMARY KEY CLUSTERED 
(
	[idtrabajador] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[venta]    Script Date: 14/01/2021 16:22:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[venta](
	[idventa] [int] IDENTITY(1,1) NOT NULL,
	[idcliente] [int] NULL,
	[idtrabajador] [int] NOT NULL,
	[fecha] [date] NOT NULL,
	[serie] [varchar](10) NOT NULL,
	[igv] [decimal](4, 2) NOT NULL,
	[totalpagado] [decimal](18, 0) NOT NULL,
 CONSTRAINT [PK_venta] PRIMARY KEY CLUSTERED 
(
	[idventa] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
ALTER TABLE [dbo].[articulo]  WITH CHECK ADD  CONSTRAINT [FK_articulo_categoria] FOREIGN KEY([idcategoria])
REFERENCES [dbo].[categoria] ([idcategoria])
GO
ALTER TABLE [dbo].[articulo] CHECK CONSTRAINT [FK_articulo_categoria]
GO
ALTER TABLE [dbo].[articulo]  WITH CHECK ADD  CONSTRAINT [FK_articulo_presentacion] FOREIGN KEY([idpresentacion])
REFERENCES [dbo].[presentacion] ([idpresentacion])
GO
ALTER TABLE [dbo].[articulo] CHECK CONSTRAINT [FK_articulo_presentacion]
GO
ALTER TABLE [dbo].[detalle_ingreso]  WITH CHECK ADD  CONSTRAINT [FK_detalle_ingreso_ingreso] FOREIGN KEY([idingreso])
REFERENCES [dbo].[ingreso] ([idingreso])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[detalle_ingreso] CHECK CONSTRAINT [FK_detalle_ingreso_ingreso]
GO
ALTER TABLE [dbo].[detalle_venta]  WITH CHECK ADD  CONSTRAINT [FK_detalle_venta_detalle_ingreso] FOREIGN KEY([iddetalle_ingreso])
REFERENCES [dbo].[detalle_ingreso] ([iddetalle_ingreso])
GO
ALTER TABLE [dbo].[detalle_venta] CHECK CONSTRAINT [FK_detalle_venta_detalle_ingreso]
GO
ALTER TABLE [dbo].[detalle_venta]  WITH CHECK ADD  CONSTRAINT [FK_detalle_venta_venta] FOREIGN KEY([idventa])
REFERENCES [dbo].[venta] ([idventa])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[detalle_venta] CHECK CONSTRAINT [FK_detalle_venta_venta]
GO
ALTER TABLE [dbo].[ingreso]  WITH CHECK ADD  CONSTRAINT [FK_ingreso_proveedor] FOREIGN KEY([idproveedor])
REFERENCES [dbo].[proveedor] ([idproveedor])
GO
ALTER TABLE [dbo].[ingreso] CHECK CONSTRAINT [FK_ingreso_proveedor]
GO
ALTER TABLE [dbo].[ingreso]  WITH CHECK ADD  CONSTRAINT [FK_ingreso_trabajador] FOREIGN KEY([idtrabajador])
REFERENCES [dbo].[trabajador] ([idtrabajador])
GO
ALTER TABLE [dbo].[ingreso] CHECK CONSTRAINT [FK_ingreso_trabajador]
GO
ALTER TABLE [dbo].[venta]  WITH CHECK ADD  CONSTRAINT [FK_venta_cliente] FOREIGN KEY([idcliente])
REFERENCES [dbo].[cliente] ([idcliente])
GO
ALTER TABLE [dbo].[venta] CHECK CONSTRAINT [FK_venta_cliente]
GO
ALTER TABLE [dbo].[venta]  WITH CHECK ADD  CONSTRAINT [FK_venta_trabajador] FOREIGN KEY([idtrabajador])
REFERENCES [dbo].[trabajador] ([idtrabajador])
GO
ALTER TABLE [dbo].[venta] CHECK CONSTRAINT [FK_venta_trabajador]
GO
/****** Object:  StoredProcedure [dbo].[sbuscar_articulo]    Script Date: 14/01/2021 16:22:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--Procedimiento buscar articulo -nombre
CREATE proc [dbo].[sbuscar_articulo]
@textobuscar varchar(50)
as
SELECT dbo.articulo.idarticulo, dbo.articulo.codigo, dbo.articulo.marca AS Marca,
dbo.articulo.descripcion, dbo.articulo.imagen, dbo.articulo.idcategoria,
dbo.categoria.nombre AS Categoria, dbo.articulo.idpresentacion, 
dbo.articulo.contenido AS Contenido,
dbo.presentacion.nombre AS Presentacion
FROM dbo.articulo INNER JOIN dbo.categoria 
ON dbo.articulo.idcategoria = dbo.categoria.idcategoria 
INNER JOIN dbo.presentacion 
ON dbo.articulo.idpresentacion = dbo.presentacion.idpresentacion
where dbo.articulo.marca like @textobuscar + '%'
order by dbo.articulo.idarticulo desc


GO
/****** Object:  StoredProcedure [dbo].[spanular_ingreso]    Script Date: 14/01/2021 16:22:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[spanular_ingreso]
@idingreso int
as
update ingreso set estado='ANULADO'
where idingreso=@idingreso


GO
/****** Object:  StoredProcedure [dbo].[spbuscar_categoria]    Script Date: 14/01/2021 16:22:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--Procedimiento buscar Nombre
CREATE proc [dbo].[spbuscar_categoria]
@textobuscar varchar(50)
as
select idcategoria, nombre AS Nombre, descripcion AS Descripción from categoria where nombre like @textobuscar + '%' 

GO
/****** Object:  StoredProcedure [dbo].[spbuscar_cliente_apellidos]    Script Date: 14/01/2021 16:22:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[spbuscar_cliente_apellidos]
@textobuscar varchar(50)
as
select * from cliente
where apellidos like @textobuscar + '%'


GO
/****** Object:  StoredProcedure [dbo].[spbuscar_cliente_num_documento]    Script Date: 14/01/2021 16:22:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[spbuscar_cliente_num_documento]
@textobuscar varchar(50)
as
select * from cliente
where num_documento like @textobuscar + '%'


GO
/****** Object:  StoredProcedure [dbo].[spbuscar_ingreso_fecha]    Script Date: 14/01/2021 16:22:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[spbuscar_ingreso_fecha]
@textobuscar varchar(20),
@textobuscar2 varchar (20)
as
select i.idingreso, (t.apellidos + ' ' +t.nombres) as Trabajador,
p.razon_social as Proveedor, i.fecha ,i.estado, sum(d.precio_compra * d.stock_inicial) as Total
from detalle_ingreso d inner join ingreso i on d.idingreso=i.idingreso
inner join proveedor p on i.idproveedor = p.idproveedor inner join trabajador t on i.idtrabajador = t.idtrabajador
group by 
i.idingreso, t.apellidos + ' ' +t.nombres,p.razon_social, i.fecha, i.estado
having i.fecha >= @textobuscar and i.fecha <=@textobuscar2

GO
/****** Object:  StoredProcedure [dbo].[spbuscar_presentacion]    Script Date: 14/01/2021 16:22:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--Procedimiento Buscar Presentaciones -Nombre
create proc [dbo].[spbuscar_presentacion]
@textobuscar varchar(50)
as
select * from presentacion 
where nombre like @textobuscar + '%' 

GO
/****** Object:  StoredProcedure [dbo].[spbuscar_proveedor_num_documento]    Script Date: 14/01/2021 16:22:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[spbuscar_proveedor_num_documento]
@textobuscar varchar (50)
as
select * from proveedor where num_documento like @textobuscar + '%'


GO
/****** Object:  StoredProcedure [dbo].[spbuscar_proveedor_razon_social]    Script Date: 14/01/2021 16:22:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[spbuscar_proveedor_razon_social]
@textobuscar varchar (50)
as
select * from proveedor where razon_social like @textobuscar + '%'


GO
/****** Object:  StoredProcedure [dbo].[spbuscar_trabajador_apellidos]    Script Date: 14/01/2021 16:22:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[spbuscar_trabajador_apellidos]
@textobuscar varchar(50)
as
select * from trabajador
where apellidos like @textobuscar + '%'


GO
/****** Object:  StoredProcedure [dbo].[spbuscar_trabajador_num_documento]    Script Date: 14/01/2021 16:22:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[spbuscar_trabajador_num_documento]
@textobuscar varchar(50)
as
select * from trabajador
where num_documento like @textobuscar + '%'


GO
/****** Object:  StoredProcedure [dbo].[spbuscar_venta_fecha]    Script Date: 14/01/2021 16:22:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[spbuscar_venta_fecha]
@textobuscar as varchar (50),
@textbobuscar2 as varchar (50)
as
select  v.idventa, (t.apellidos + '' + t.nombres) as Trabajador, (c.apellidos + ' ' + c.nombre) as Cliente , v.fecha,
v.serie, sum ((d.cantidad *d.precio_venta) - d.descuento) as Total
from detalle_venta d inner join venta v on  d.idventa = v.idventa inner join cliente c on v.idcliente = c.idcliente
inner join trabajador t on v.idtrabajador = t.idtrabajador
group by v.idventa, (t.apellidos + '' + t.nombres), (c.apellidos + ' ' + c.nombre) , v.fecha,
v.serie
having v.fecha >= @textobuscar and v.fecha <=@textbobuscar2

GO
/****** Object:  StoredProcedure [dbo].[spbuscararticulo_venta_codigo]    Script Date: 14/01/2021 16:22:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[spbuscararticulo_venta_codigo]
@textobuscar varchar(50)
as
select d.iddetalle_ingreso As Detalle_Ingreso, a.codigo AS Codigo, a.descripcion AS Descripción, a.marca As Marca, c.nombre as Categoria, p.nombre as Presentacion,
d.stock_actual AS Stock, d.precio_compra AS Precio_Compra, d.precio_venta AS Precio_Venta, a.descuento AS Descuento, d.fecha_vencimiento AS Fecha_Vencimiento
from articulo a inner join categoria c on a.idcategoria=c.idcategoria 
inner join presentacion p on a.idpresentacion= p.idpresentacion inner join detalle_ingreso d on a.idarticulo=d.idarticulo
inner join ingreso i on d.idingreso= i.idingreso
where a.codigo = @textobuscar and d.stock_actual > 0 and i.estado<>'ANULADO'


GO
/****** Object:  StoredProcedure [dbo].[spbuscararticulo_venta_nombre]    Script Date: 14/01/2021 16:22:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[spbuscararticulo_venta_nombre]
@textobuscar varchar(50)
as
select d.iddetalle_ingreso As Detalle_Ingreso, a.codigo AS Codigo, a.descripcion AS Descripción, a.marca As Marca, c.nombre as Categoria, p.nombre as Presentacion,
d.stock_actual AS Stock, d.precio_compra AS Precio_Compra, d.precio_venta AS Precio_Venta, a.descuento AS Descuento, d.fecha_vencimiento AS Fecha_Vencimiento
from articulo a inner join categoria c on a.idcategoria=c.idcategoria 
inner join presentacion p on a.idpresentacion= p.idpresentacion inner join detalle_ingreso d on a.idarticulo=d.idarticulo
inner join ingreso i on d.idingreso= i.idingreso
where a.descripcion like @textobuscar + '%' and d.stock_actual > 0 and i.estado<>'ANULADO'

GO
/****** Object:  StoredProcedure [dbo].[spdisminuir_stock]    Script Date: 14/01/2021 16:22:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[spdisminuir_stock]
@iddetalle_ingreso int,
@cantidad int
as
update detalle_ingreso set stock_actual = stock_actual - @cantidad
where iddetalle_ingreso=@iddetalle_ingreso


GO
/****** Object:  StoredProcedure [dbo].[speditar_articulo]    Script Date: 14/01/2021 16:22:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[speditar_articulo]
@idarticulo int,
@codigo varchar(50),
@marca varchar(50),
@descripcion varchar(1024),
@imagen image,
@idcategoria int,
@idpresentacion int,
@contenido varchar(50),
@descuento int
as
update articulo set codigo=@codigo,marca=@marca,descripcion=@descripcion,
imagen=@imagen,idcategoria=@idcategoria,idpresentacion=@idpresentacion, contenido=@contenido, descuento=@descuento
where idarticulo=@idarticulo

GO
/****** Object:  StoredProcedure [dbo].[speditar_categoria]    Script Date: 14/01/2021 16:22:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--Procedimiento editar
create proc [dbo].[speditar_categoria]
@idcategoria int,
@nombre varchar(50),
@descripcion varchar(256)
as
update categoria set nombre = @nombre, descripcion = @descripcion
where idcategoria = @idcategoria


GO
/****** Object:  StoredProcedure [dbo].[speditar_cliente]    Script Date: 14/01/2021 16:22:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[speditar_cliente]
@idcliente int,
@nombre varchar(50),
@apellidos varchar (50),
@sexo varchar (10),
@fecha_nacimiento date,
@tipo_documento varchar(20),
@num_documento varchar (20),
@direccion varchar (200),
@telefono varchar (50),
@email varchar (50)
as
update cliente set nombre=@nombre, apellidos=@apellidos, sexo=@sexo, fecha_nacimiento=@fecha_nacimiento, tipo_documento=@tipo_documento,
num_documento=@num_documento, direccion=@direccion, telefono=@telefono, email=@email
where idcliente=@idcliente


GO
/****** Object:  StoredProcedure [dbo].[speditar_presentacion]    Script Date: 14/01/2021 16:22:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[speditar_presentacion]
@idpresentacion int output,
@nombre varchar(50),
@descripcion varchar(256)
as
update presentacion set nombre=@nombre, descripcion=@descripcion
where idpresentacion=@idpresentacion


GO
/****** Object:  StoredProcedure [dbo].[speditar_proveedor]    Script Date: 14/01/2021 16:22:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[speditar_proveedor]
@idproveedor int,
@razon_social varchar(150),
@sector_comercial varchar(50),
@tipo_documento varchar(20),
@num_documento varchar(20),
@direccion varchar(100),
@telefono varchar(50),
@email varchar(100),
@url varchar(100)
as
update proveedor set razon_social=@razon_social, sector_comercial=@sector_comercial, tipo_documento=@tipo_documento, num_documento=@num_documento,
direccion=@direccion, telefono=@telefono, email=@email, url=@url
where idproveedor=@idproveedor


GO
/****** Object:  StoredProcedure [dbo].[speditar_trabajador]    Script Date: 14/01/2021 16:22:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[speditar_trabajador]
@idtrabajador int,
@nombres varchar(50),
@apellidos varchar (50),
@sexo varchar (10),
@fecha_nacimiento datetime,
@num_documento varchar (20),
@direccion varchar (100),
@telefono varchar (50),
@email varchar (50),
@acceso varchar (20),
@usuario varchar(20),
@password varchar(20)
as
update trabajador set nombres=@nombres, apellidos=@apellidos, sexo=@sexo, fecha_nacimiento=@fecha_nacimiento,
num_documento=@num_documento, direccion=@direccion, telefono=@telefono, email=@email, acceso=@acceso, usuario=@usuario, password=@password
where idtrabajador=@idtrabajador


GO
/****** Object:  StoredProcedure [dbo].[speliminar_articulo]    Script Date: 14/01/2021 16:22:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--Procedimiento eliminar articulo
create proc [dbo].[speliminar_articulo]
@idarticulo int
as
delete from articulo where idarticulo=@idarticulo

GO
/****** Object:  StoredProcedure [dbo].[speliminar_categoria]    Script Date: 14/01/2021 16:22:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--Procedimiento eliminar
create proc [dbo].[speliminar_categoria]
@idcategoria int
as 
delete from categoria where idcategoria = @idcategoria


GO
/****** Object:  StoredProcedure [dbo].[speliminar_cliente]    Script Date: 14/01/2021 16:22:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[speliminar_cliente]
@idcliente int
as
delete from cliente where idcliente=@idcliente


GO
/****** Object:  StoredProcedure [dbo].[speliminar_presentacion]    Script Date: 14/01/2021 16:22:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--Procedimiento Eliminar Presentaciones
create proc [dbo].[speliminar_presentacion]
@idpresentacion int
as
delete from presentacion where idpresentacion = @idpresentacion

GO
/****** Object:  StoredProcedure [dbo].[speliminar_proveedor]    Script Date: 14/01/2021 16:22:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[speliminar_proveedor]
@idproveedor int
as
delete from proveedor where idproveedor=@idproveedor


GO
/****** Object:  StoredProcedure [dbo].[speliminar_trabajador]    Script Date: 14/01/2021 16:22:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[speliminar_trabajador]
@idtrabajador int
as
delete from trabajador where idtrabajador=@idtrabajador

GO
/****** Object:  StoredProcedure [dbo].[speliminar_venta]    Script Date: 14/01/2021 16:22:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[speliminar_venta]
@idventa int
as
delete from venta where idventa=@idventa


GO
/****** Object:  StoredProcedure [dbo].[spinsertar_articulo]    Script Date: 14/01/2021 16:22:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[spinsertar_articulo]
@idarticulo int output,
@codigo varchar(50),
@marca varchar(50),
@descripcion varchar(50),
@contenido varchar (50),
@imagen image,
@idcategoria int,
@idpresentacion int,
@descuento int
as
insert into articulo (codigo,marca,descripcion,imagen,idcategoria,idpresentacion, contenido, descuento)
values (@codigo,@marca,@descripcion,@imagen,@idcategoria,@idpresentacion, @contenido, @descuento)


GO
/****** Object:  StoredProcedure [dbo].[spinsertar_categoria]    Script Date: 14/01/2021 16:22:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--Procedimiento Insertar
create proc [dbo].[spinsertar_categoria]
@idcategoria int output,
@nombre varchar(50),
@descripcion varchar (256)
as
insert into categoria (nombre, descripcion) values (@nombre, @descripcion)


GO
/****** Object:  StoredProcedure [dbo].[spinsertar_cliente]    Script Date: 14/01/2021 16:22:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[spinsertar_cliente]
@idcliente int output,
@nombre varchar(50),
@apellidos varchar (50),
@sexo varchar (10),
@fecha_nacimiento date,
@tipo_documento varchar(20),
@num_documento varchar (20),
@direccion varchar (100),
@telefono varchar (50),
@email varchar (50)
as
insert into cliente (nombre, apellidos, sexo, fecha_nacimiento, tipo_documento, num_documento, direccion, telefono, email)
values (@nombre, @apellidos, @sexo, @fecha_nacimiento, @tipo_documento, @num_documento, @direccion, @telefono, @email)


GO
/****** Object:  StoredProcedure [dbo].[spinsertar_detalle_ingreso]    Script Date: 14/01/2021 16:22:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[spinsertar_detalle_ingreso]
@iddetalle_ingreso int output,
@idingreso int,
@idarticulo int,
@precio_compra decimal,
@precio_venta decimal,
@stock_inicial int,
@stock_actual int,
@fecha_produccion date,
@fecha_vencimiento date
as
insert into detalle_ingreso (idingreso, idarticulo, precio_compra, precio_venta, stock_inicial, stock_actual, fecha_produccion, fecha_vencimiento)
values (@idingreso, @idarticulo, @precio_compra, @precio_venta, @stock_inicial, @stock_actual, @fecha_produccion, @fecha_vencimiento)


GO
/****** Object:  StoredProcedure [dbo].[spinsertar_detalle_venta]    Script Date: 14/01/2021 16:22:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[spinsertar_detalle_venta]
@iddetalle_venta int output,
@idventa int,
@iddetalle_ingreso int,
@cantidad int,
@precio_venta decimal,
@total decimal,
@descuento decimal
as
insert into detalle_venta (idventa, iddetalle_ingreso, cantidad, precio_venta, total, descuento)
values (@idventa, @iddetalle_ingreso, @cantidad, @precio_venta, @total, @descuento)

GO
/****** Object:  StoredProcedure [dbo].[spinsertar_ingreso]    Script Date: 14/01/2021 16:22:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[spinsertar_ingreso]
@idingreso int=null output,
@idtrabajador int,
@idproveedor int,
@fecha date,
@serie varchar (4),
@igv decimal(4,2),
@estado varchar(7)
as
insert into ingreso (idtrabajador, idproveedor, fecha, serie, igv, estado)
values (@idtrabajador, @idproveedor, @fecha, @serie, @igv, @estado)
--obtener codigo autogenerado
set @idingreso =@@IDENTITY

GO
/****** Object:  StoredProcedure [dbo].[spinsertar_presentacion]    Script Date: 14/01/2021 16:22:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--Procedimiento Insertar Presentaciones
create proc [dbo].[spinsertar_presentacion]
@idpresentacion int output,
@nombre varchar(50),
@descripcion varchar(256)
as
insert into presentacion (nombre, descripcion) values (@nombre, @descripcion)


GO
/****** Object:  StoredProcedure [dbo].[spinsertar_proveedor]    Script Date: 14/01/2021 16:22:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[spinsertar_proveedor]
@idproveedor int output,
@razon_social varchar(150),
@sector_comercial varchar(50),
@tipo_documento varchar(20),
@num_documento varchar(20),
@direccion varchar(100),
@telefono varchar(50),
@email varchar(100),
@url varchar(100)
as
insert into proveedor (razon_social, sector_comercial, tipo_documento, num_documento, direccion,telefono,email,url)
values (@razon_social, @sector_comercial, @tipo_documento, @num_documento, @direccion, @telefono, @email, @url)


GO
/****** Object:  StoredProcedure [dbo].[spinsertar_trabajador]    Script Date: 14/01/2021 16:22:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[spinsertar_trabajador]
@idtrabajador int output,
@nombres varchar(50),
@apellidos varchar (50),
@sexo varchar (10),
@fecha_nacimiento datetime,
@num_documento varchar (20),
@direccion varchar (100),
@telefono varchar (50),
@email varchar (50),
@acceso varchar (20),
@usuario varchar(20),
@password varchar(20)

as
insert into trabajador (nombres, apellidos, sexo, fecha_nacimiento, num_documento, direccion, telefono, email, acceso, usuario, password)
values (@nombres, @apellidos, @sexo, @fecha_nacimiento, @num_documento, @direccion, @telefono, @email, @acceso, @usuario, @password)


GO
/****** Object:  StoredProcedure [dbo].[spinsertar_venta]    Script Date: 14/01/2021 16:22:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[spinsertar_venta]
@idventa int=null output,
@idcliente int,
@idtrabajador int,
@fecha date,
@serie varchar(10),
@igv decimal (4,2),
@totalpagado decimal
as
insert into venta (idcliente, idtrabajador, fecha, serie, igv, totalpagado)
values (@idcliente, @idtrabajador, @fecha, @serie, @igv, @totalpagado)
--obtener codigo autogenerado
set @idventa=@@IDENTITY


GO
/****** Object:  StoredProcedure [dbo].[splogin]    Script Date: 14/01/2021 16:22:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[splogin]
@usuario varchar(20),
@password varchar (20)
as
select idtrabajador, apellidos, nombres, acceso from trabajador
where usuario=@usuario and password=@password 


GO
/****** Object:  StoredProcedure [dbo].[spmostrar_articulo]    Script Date: 14/01/2021 16:22:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--Procedimiento mostrar articulo
CREATE proc [dbo].[spmostrar_articulo]
as
SELECT top 1000 dbo.articulo.idarticulo, dbo.articulo.codigo AS Codigo, dbo.articulo.marca AS Marca,
dbo.articulo.descripcion AS Descripcion,dbo.presentacion.nombre AS Presentacion, dbo.articulo.contenido AS Contenido , dbo.articulo.idcategoria,
dbo.categoria.nombre AS Categoria, dbo.articulo.idpresentacion, dbo.articulo.descuento AS Descuento, dbo.articulo.imagen  AS Imagen
FROM dbo.articulo INNER JOIN dbo.categoria 
ON dbo.articulo.idcategoria = dbo.categoria.idcategoria 
INNER JOIN dbo.presentacion 
ON dbo.articulo.idpresentacion = dbo.presentacion.idpresentacion
order by dbo.articulo.idarticulo desc

GO
/****** Object:  StoredProcedure [dbo].[spmostrar_categoria]    Script Date: 14/01/2021 16:22:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--Procedimiento mostrar
CREATE proc [dbo].[spmostrar_categoria]
as
select idcategoria, nombre as Nombre, descripcion as Descripción from categoria
order by idcategoria desc

GO
/****** Object:  StoredProcedure [dbo].[spmostrar_cliente]    Script Date: 14/01/2021 16:22:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[spmostrar_cliente]
as
select top 100 * from cliente
order by apellidos asc

GO
/****** Object:  StoredProcedure [dbo].[spmostrar_detalle_ingreso]    Script Date: 14/01/2021 16:22:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--Mostrar detalle de ingreso
CREATE proc [dbo].[spmostrar_detalle_ingreso]
@textobuscar int
as
select d.idarticulo, a.marca as Articulo, d.precio_compra, d.precio_venta, d.stock_inicial, d.fecha_produccion, d.fecha_vencimiento, (d.stock_inicial * d.precio_compra) as Subtotal
from detalle_ingreso d inner join articulo a on d.idarticulo = a.idarticulo
where d.idingreso = @textobuscar


GO
/****** Object:  StoredProcedure [dbo].[spmostrar_detalle_venta]    Script Date: 14/01/2021 16:22:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[spmostrar_detalle_venta]
@textobuscar int
as
select d.iddetalle_ingreso, a.marca as Articulo, d.cantidad , d.precio_venta, d.descuento,
((d.precio_venta * d.cantidad)-d.descuento) as Subtotal
from detalle_venta d inner join detalle_ingreso di on d.iddetalle_ingreso = di.iddetalle_ingreso
inner join articulo a on di.idarticulo = a.idarticulo
where d.idventa=@textobuscar


GO
/****** Object:  StoredProcedure [dbo].[spmostrar_ingreso]    Script Date: 14/01/2021 16:22:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--Mostrar ingresos
CREATE proc [dbo].[spmostrar_ingreso]
as
select top 100 i.idingreso, (t.apellidos + ' ' +t.nombres) as Trabajador,
p.razon_social as Proveedor, i.fecha, i.serie, i.estado, sum(d.precio_compra * d.stock_inicial) as Total
from detalle_ingreso d inner join ingreso i on d.idingreso=i.idingreso
inner join proveedor p on i.idproveedor = p.idproveedor inner join trabajador t on i.idtrabajador = t.idtrabajador
group by 
i.idingreso, t.apellidos + ' ' +t.nombres,p.razon_social, i.fecha, i.serie, i.estado
order by i.idingreso desc


GO
/****** Object:  StoredProcedure [dbo].[spmostrar_presentacion]    Script Date: 14/01/2021 16:22:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--Procedimiento Mostrar Presentaciones
CREATE proc [dbo].[spmostrar_presentacion]
as
select idpresentacion, nombre AS Nombre, descripcion AS Descripción from presentacion
order by idpresentacion asc

GO
/****** Object:  StoredProcedure [dbo].[spmostrar_proveedor]    Script Date: 14/01/2021 16:22:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--Mostrar
CREATE proc [dbo].[spmostrar_proveedor]
as
select top 100 * from proveedor
order by razon_social asc

GO
/****** Object:  StoredProcedure [dbo].[spmostrar_trabajador]    Script Date: 14/01/2021 16:22:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[spmostrar_trabajador]
as
select top 100 * from trabajador
order by apellidos asc


GO
/****** Object:  StoredProcedure [dbo].[spmostrar_venta]    Script Date: 14/01/2021 16:22:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[spmostrar_venta]
as
select top 100 v.idventa, (t.apellidos + '' + t.nombres) as Trabajador, (c.apellidos + ' ' + c.nombre) as Cliente , v.fecha as Fecha,
v.serie AS Serie, sum ((d.cantidad *d.precio_venta) - d.descuento) as Total
from detalle_venta d inner join venta v on  d.idventa = v.idventa inner join cliente c on v.idcliente = c.idcliente
inner join trabajador t on v.idtrabajador = t.idtrabajador
group by v.idventa, (t.apellidos + '' + t.nombres), (c.apellidos + ' ' + c.nombre) , v.fecha,
v.serie
order by v.idventa desc 

GO
/****** Object:  StoredProcedure [dbo].[spmostrar_ventas_trabajador]    Script Date: 14/01/2021 16:22:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[spmostrar_ventas_trabajador]
@idtrabajador int,
@fecha date
as
select v.idventa, (t.apellidos + '' + t.nombres) as Trabajador, (c.apellidos + ' ' + c.nombre) as Cliente , v.fecha as Fecha,
v.serie AS Serie, sum ((d.cantidad *d.precio_venta) - d.descuento) as Total
from detalle_venta d inner join venta v on  d.idventa = v.idventa inner join cliente c on v.idcliente = c.idcliente
inner join trabajador t on v.idtrabajador = t.idtrabajador
where t.idtrabajador = @idtrabajador AND v.fecha = @fecha
group by v.idventa, (t.apellidos + '' + t.nombres), (c.apellidos + ' ' + c.nombre) , v.fecha,
v.serie
order by v.idventa desc


GO
/****** Object:  StoredProcedure [dbo].[spmostrarcodigo_articulo]    Script Date: 14/01/2021 16:22:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[spmostrarcodigo_articulo]
@textobuscar varchar(50)
as
SELECT dbo.articulo.idarticulo, dbo.articulo.codigo, dbo.articulo.marca, 
dbo.articulo.descripcion, dbo.articulo.imagen, dbo.articulo.idcategoria,
 dbo.categoria.nombre AS Categoria, dbo.articulo.idpresentacion, 
 dbo.presentacion.nombre AS Presentacion, dbo.articulo.contenido AS Contenido
FROM  dbo.articulo INNER JOIN
dbo.categoria ON dbo.articulo.idcategoria = dbo.categoria.idcategoria INNER JOIN
dbo.presentacion ON dbo.articulo.idpresentacion = dbo.presentacion.idpresentacion
where dbo.articulo.codigo = @textobuscar 

GO
/****** Object:  StoredProcedure [dbo].[spreporte_factura]    Script Date: 14/01/2021 16:22:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[spreporte_factura]
@idventa int
as
select 
v.idventa, (t.apellidos + ' ' + t.nombres) as Trabajador,
(c.apellidos + ' ' + c.nombre) as Cliente,
c.direccion, c.telefono, c.num_documento,
v.fecha, v.serie,
v.igv, a.marca, dv.precio_venta, dv.cantidad, dv.descuento,
(dv.cantidad * dv.precio_venta - dv.descuento) as Total_Parcial
 from detalle_venta dv inner join detalle_ingreso di on dv.iddetalle_ingreso = di.iddetalle_ingreso
inner join articulo a on a.idarticulo = di.idarticulo
inner join venta v on v.idventa = dv.idventa
inner join cliente c on v.idcliente = c.idcliente
inner join trabajador t on t.idtrabajador = v.idtrabajador
where v.idventa = @idventa


GO
/****** Object:  StoredProcedure [dbo].[spstock_articulos]    Script Date: 14/01/2021 16:22:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[spstock_articulos]
as
SELECT dbo.articulo.codigo, dbo.articulo.marca, dbo.articulo.descripcion,
dbo.categoria.nombre AS Categoria,
sum(dbo.detalle_ingreso.stock_inicial) as Cantidad_Ingreso,
sum(dbo.detalle_ingreso.stock_actual) as Cantidad_Stock,
(sum(dbo.detalle_ingreso.stock_inicial)-
sum(dbo.detalle_ingreso.stock_actual)) as Cantidad_Venta
FROM dbo.articulo INNER JOIN dbo.categoria 
ON dbo.articulo.idcategoria = dbo.categoria.idcategoria 
INNER JOIN dbo.detalle_ingreso 
ON dbo.articulo.idarticulo = dbo.detalle_ingreso.idarticulo 
INNER JOIN dbo.ingreso 
ON dbo.detalle_ingreso.idingreso = dbo.ingreso.idingreso
where ingreso.estado<>'ANULADO'
group by dbo.articulo.codigo, dbo.articulo.marca, dbo.articulo.descripcion,
dbo.categoria.nombre

GO
USE [master]
GO
ALTER DATABASE [dbventas] SET  READ_WRITE 
GO
