USE [master]
GO
/****** Object:  Database [DIPLOMA]    Script Date: 5/9/2021 20:33:01 ******/
CREATE DATABASE [DIPLOMA]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'DIPLOMA', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\DIPLOMA.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'DIPLOMA_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\DIPLOMA_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [DIPLOMA] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [DIPLOMA].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [DIPLOMA] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [DIPLOMA] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [DIPLOMA] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [DIPLOMA] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [DIPLOMA] SET ARITHABORT OFF 
GO
ALTER DATABASE [DIPLOMA] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [DIPLOMA] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [DIPLOMA] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [DIPLOMA] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [DIPLOMA] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [DIPLOMA] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [DIPLOMA] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [DIPLOMA] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [DIPLOMA] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [DIPLOMA] SET  DISABLE_BROKER 
GO
ALTER DATABASE [DIPLOMA] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [DIPLOMA] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [DIPLOMA] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [DIPLOMA] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [DIPLOMA] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [DIPLOMA] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [DIPLOMA] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [DIPLOMA] SET RECOVERY FULL 
GO
ALTER DATABASE [DIPLOMA] SET  MULTI_USER 
GO
ALTER DATABASE [DIPLOMA] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [DIPLOMA] SET DB_CHAINING OFF 
GO
ALTER DATABASE [DIPLOMA] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [DIPLOMA] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [DIPLOMA] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [DIPLOMA] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'DIPLOMA', N'ON'
GO
ALTER DATABASE [DIPLOMA] SET QUERY_STORE = OFF
GO
USE [DIPLOMA]
GO
/****** Object:  UserDefinedFunction [dbo].[fn_FileExist]    Script Date: 5/9/2021 20:33:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create FUNCTION [dbo].[fn_FileExist](@path varchar(512))
RETURNS BIT
AS
BEGIN
     DECLARE @result INT
     EXEC master.dbo.xp_fileexist @path, @result OUTPUT
     RETURN CAST(@result as bit)
END
GO
/****** Object:  UserDefinedFunction [dbo].[fn_FileExists]    Script Date: 5/9/2021 20:33:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE FUNCTION [dbo].[fn_FileExists](@path varchar(512))
RETURNS BIT
AS
BEGIN
     DECLARE @result INT
     EXEC master.dbo.xp_fileexist @path, @result OUTPUT
     RETURN CAST(@result as bit)
END
GO
/****** Object:  Table [dbo].[Bitacora]    Script Date: 5/9/2021 20:33:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Bitacora](
	[ID_Bitacora] [int] IDENTITY(1,1) NOT NULL,
	[Accion] [nvarchar](100) NOT NULL,
	[Descripcion] [nvarchar](max) NOT NULL,
	[Fecha] [datetime] NOT NULL,
	[ID_Usuario] [int] NOT NULL,
	[idCriticidad] [int] NOT NULL,
	[DVH] [int] NOT NULL,
 CONSTRAINT [PK_Bitacora] PRIMARY KEY CLUSTERED 
(
	[ID_Bitacora] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Compuesto]    Script Date: 5/9/2021 20:33:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Compuesto](
	[ID_Compuesto] [int] IDENTITY(1,1) NOT NULL,
	[ID_Permiso] [int] NOT NULL,
	[ID_Familia] [int] NOT NULL,
	[DVH] [nvarchar](max) NULL,
 CONSTRAINT [PK_Compuesto] PRIMARY KEY CLUSTERED 
(
	[ID_Compuesto] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Criticidad]    Script Date: 5/9/2021 20:33:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Criticidad](
	[IDCriticidad] [int] IDENTITY(1,1) NOT NULL,
	[Descripcion] [nvarchar](30) NOT NULL,
 CONSTRAINT [PK_Criticidad] PRIMARY KEY CLUSTERED 
(
	[IDCriticidad] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DVV]    Script Date: 5/9/2021 20:33:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DVV](
	[ID_DVV] [int] IDENTITY(1,1) NOT NULL,
	[Tabla] [nvarchar](max) NULL,
	[DVV] [bigint] NULL,
 CONSTRAINT [PK_DVV] PRIMARY KEY CLUSTERED 
(
	[ID_DVV] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Idioma]    Script Date: 5/9/2021 20:33:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Idioma](
	[ID_Idioma] [int] IDENTITY(1,1) NOT NULL,
	[Idioma] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Idioma] PRIMARY KEY CLUSTERED 
(
	[ID_Idioma] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[IdiomaControl]    Script Date: 5/9/2021 20:33:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[IdiomaControl](
	[ID_IdiomaControl] [int] IDENTITY(1,1) NOT NULL,
	[ID_Idioma] [int] NOT NULL,
	[nombreControl] [nvarchar](150) NOT NULL,
	[Traduccion] [nvarchar](150) NOT NULL,
 CONSTRAINT [PK_IdiomaControl] PRIMARY KEY CLUSTERED 
(
	[ID_IdiomaControl] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Permiso]    Script Date: 5/9/2021 20:33:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Permiso](
	[ID_Permiso] [int] IDENTITY(1,1) NOT NULL,
	[Permiso] [nvarchar](200) NOT NULL,
	[IsFamilia] [bit] NOT NULL,
	[DVH] [nvarchar](max) NULL,
 CONSTRAINT [PK_Permiso] PRIMARY KEY CLUSTERED 
(
	[ID_Permiso] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Usuario]    Script Date: 5/9/2021 20:33:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Usuario](
	[ID_Usuario] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [nvarchar](50) NOT NULL,
	[Apellido] [nvarchar](50) NOT NULL,
	[DNI] [nvarchar](50) NOT NULL,
	[Username] [nvarchar](max) NOT NULL,
	[Contraseña] [nvarchar](max) NOT NULL,
	[Email] [nvarchar](100) NOT NULL,
	[FechaNacimiento] [date] NOT NULL,
	[IntentosIngreso] [int] NOT NULL,
	[Bloqueado] [bit] NOT NULL,
	[Direccion] [nvarchar](max) NOT NULL,
	[DVH] [nvarchar](max) NULL,
 CONSTRAINT [PK_Usuario] PRIMARY KEY CLUSTERED 
(
	[ID_Usuario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UsuarioPermiso]    Script Date: 5/9/2021 20:33:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UsuarioPermiso](
	[ID_UsuarioPermiso] [int] IDENTITY(1,1) NOT NULL,
	[ID_Usuario] [int] NOT NULL,
	[ID_Permiso] [int] NOT NULL,
	[DVH] [nvarchar](max) NULL,
 CONSTRAINT [PK_UsuarioPermiso] PRIMARY KEY CLUSTERED 
(
	[ID_UsuarioPermiso] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Bitacora] ON 

INSERT [dbo].[Bitacora] ([ID_Bitacora], [Accion], [Descripcion], [Fecha], [ID_Usuario], [idCriticidad], [DVH]) VALUES (2014, N'Inicio de sesión', N'33E63C7C813C9C883509F85670C7F20447104BA355AC2804765F2FC683CC2F6FC8E12B92196D239F', CAST(N'2021-09-05T19:51:53.603' AS DateTime), 1021, 3, 210552)
INSERT [dbo].[Bitacora] ([ID_Bitacora], [Accion], [Descripcion], [Fecha], [ID_Usuario], [idCriticidad], [DVH]) VALUES (2015, N'Inicio de sesión', N'33E63C7C813C9C883509F85670C7F20447104BA355AC2804765F2FC683CC2F6FC8E12B92196D239F', CAST(N'2021-09-05T19:51:59.837' AS DateTime), 1021, 3, 210658)
INSERT [dbo].[Bitacora] ([ID_Bitacora], [Accion], [Descripcion], [Fecha], [ID_Usuario], [idCriticidad], [DVH]) VALUES (2016, N'Inicio de sesión', N'33E63C7C813C9C883509F85670C7F20447104BA355AC2804765F2FC683CC2F6FC8E12B92196D239F', CAST(N'2021-09-05T19:53:22.373' AS DateTime), 1021, 3, 210523)
INSERT [dbo].[Bitacora] ([ID_Bitacora], [Accion], [Descripcion], [Fecha], [ID_Usuario], [idCriticidad], [DVH]) VALUES (2017, N'Inicio de sesión', N'33E63C7C813C9C883509F85670C7F20447104BA355AC2804765F2FC683CC2F6FC8E12B92196D239F', CAST(N'2021-09-05T19:54:12.970' AS DateTime), 1021, 3, 210525)
INSERT [dbo].[Bitacora] ([ID_Bitacora], [Accion], [Descripcion], [Fecha], [ID_Usuario], [idCriticidad], [DVH]) VALUES (2018, N'Inicio de sesión', N'33E63C7C813C9C883509F85670C7F20447104BA355AC2804765F2FC683CC2F6FC8E12B92196D239F', CAST(N'2021-09-05T19:55:09.063' AS DateTime), 1021, 3, 210646)
INSERT [dbo].[Bitacora] ([ID_Bitacora], [Accion], [Descripcion], [Fecha], [ID_Usuario], [idCriticidad], [DVH]) VALUES (2019, N'Inicio de sesión', N'33E63C7C813C9C883509F85670C7F20447104BA355AC2804765F2FC683CC2F6FC8E12B92196D239F', CAST(N'2021-09-05T20:01:53.720' AS DateTime), 1021, 3, 210418)
INSERT [dbo].[Bitacora] ([ID_Bitacora], [Accion], [Descripcion], [Fecha], [ID_Usuario], [idCriticidad], [DVH]) VALUES (2020, N'Registro de familia', N'258643BFE135AE253ACA72E58EFB55E4B243ACD95A355AD3D8F6DC442CD1DCB70263E47064D0AC6F', CAST(N'2021-09-05T20:02:02.423' AS DateTime), 1021, 2, 217330)
INSERT [dbo].[Bitacora] ([ID_Bitacora], [Accion], [Descripcion], [Fecha], [ID_Usuario], [idCriticidad], [DVH]) VALUES (2021, N'Inicio de sesión', N'33E63C7C813C9C883509F85670C7F20447104BA355AC2804765F2FC683CC2F6FC8E12B92196D239F', CAST(N'2021-09-05T20:08:59.507' AS DateTime), 1021, 3, 210589)
INSERT [dbo].[Bitacora] ([ID_Bitacora], [Accion], [Descripcion], [Fecha], [ID_Usuario], [idCriticidad], [DVH]) VALUES (2022, N'Registro de familia', N'258643BFE135AE253ACA72E58EFB55E4B243ACD95A355AD3E8961A2B909C91B5BE998A4C4F2AEB648C0A7A31D2414A887CE205EBD0F185EB', CAST(N'2021-09-05T20:09:15.077' AS DateTime), 1021, 2, 398254)
INSERT [dbo].[Bitacora] ([ID_Bitacora], [Accion], [Descripcion], [Fecha], [ID_Usuario], [idCriticidad], [DVH]) VALUES (2023, N'Inicio de sesión', N'33E63C7C813C9C883509F85670C7F20447104BA355AC2804765F2FC683CC2F6FC8E12B92196D239F', CAST(N'2021-09-05T20:10:57.827' AS DateTime), 1021, 3, 210464)
INSERT [dbo].[Bitacora] ([ID_Bitacora], [Accion], [Descripcion], [Fecha], [ID_Usuario], [idCriticidad], [DVH]) VALUES (2024, N'Registro de familia', N'258643BFE135AE253ACA72E58EFB55E4B243ACD95A355AD3E6923060EB5412A6', CAST(N'2021-09-05T20:13:41.140' AS DateTime), 1021, 2, 146534)
INSERT [dbo].[Bitacora] ([ID_Bitacora], [Accion], [Descripcion], [Fecha], [ID_Usuario], [idCriticidad], [DVH]) VALUES (2025, N'Inicio de sesión', N'33E63C7C813C9C883509F85670C7F20447104BA355AC2804765F2FC683CC2F6FC8E12B92196D239F', CAST(N'2021-09-05T20:16:27.520' AS DateTime), 1021, 3, 210508)
INSERT [dbo].[Bitacora] ([ID_Bitacora], [Accion], [Descripcion], [Fecha], [ID_Usuario], [idCriticidad], [DVH]) VALUES (2026, N'Registro de familia', N'258643BFE135AE253ACA72E58EFB55E4B243ACD95A355AD3D8F6DC442CD1DCB72156F0F52A0BEF77', CAST(N'2021-09-05T20:16:33.323' AS DateTime), 1021, 2, 218862)
INSERT [dbo].[Bitacora] ([ID_Bitacora], [Accion], [Descripcion], [Fecha], [ID_Usuario], [idCriticidad], [DVH]) VALUES (2027, N'Inicio de sesión', N'33E63C7C813C9C883509F85670C7F20447104BA355AC2804765F2FC683CC2F6FC8E12B92196D239F', CAST(N'2021-09-05T20:16:41.383' AS DateTime), 1021, 3, 210446)
INSERT [dbo].[Bitacora] ([ID_Bitacora], [Accion], [Descripcion], [Fecha], [ID_Usuario], [idCriticidad], [DVH]) VALUES (2028, N'Inicio de sesión', N'33E63C7C813C9C883509F85670C7F20447104BA355AC2804765F2FC683CC2F6FC8E12B92196D239F', CAST(N'2021-09-05T20:16:54.473' AS DateTime), 1021, 3, 210517)
INSERT [dbo].[Bitacora] ([ID_Bitacora], [Accion], [Descripcion], [Fecha], [ID_Usuario], [idCriticidad], [DVH]) VALUES (2029, N'Inicio de sesión', N'33E63C7C813C9C883509F85670C7F20447104BA355AC2804765F2FC683CC2F6FC8E12B92196D239F', CAST(N'2021-09-05T20:20:05.213' AS DateTime), 1021, 3, 210387)
INSERT [dbo].[Bitacora] ([ID_Bitacora], [Accion], [Descripcion], [Fecha], [ID_Usuario], [idCriticidad], [DVH]) VALUES (2030, N'Inicio de sesión', N'33E63C7C813C9C883509F85670C7F20447104BA355AC2804765F2FC683CC2F6FC8E12B92196D239F', CAST(N'2021-09-05T20:20:47.437' AS DateTime), 1021, 3, 210452)
INSERT [dbo].[Bitacora] ([ID_Bitacora], [Accion], [Descripcion], [Fecha], [ID_Usuario], [idCriticidad], [DVH]) VALUES (2031, N'Asignación de permiso', N'183187332B51371C12419391C577613FEAFCDFE9BBAC7776333A4D5147577E818529E211099DC3057755CB1F486C94B4D4D181CB92026D6B91E75859332404C6', CAST(N'2021-09-05T20:30:12.657' AS DateTime), 1021, 1, 499874)
INSERT [dbo].[Bitacora] ([ID_Bitacora], [Accion], [Descripcion], [Fecha], [ID_Usuario], [idCriticidad], [DVH]) VALUES (2032, N'Desasignación de permiso', N'183187332B51371C12419391C577613FEAFCDFE9BBAC777678480A0C768EF2FDBD69B5B34FD77061B98F62191ABE4402C7248823C84F7AEB000090A4406A5051', CAST(N'2021-09-05T20:30:17.327' AS DateTime), 1021, 1, 509911)
INSERT [dbo].[Bitacora] ([ID_Bitacora], [Accion], [Descripcion], [Fecha], [ID_Usuario], [idCriticidad], [DVH]) VALUES (2033, N'Inicio de sesión', N'33E63C7C813C9C883509F85670C7F20447104BA355AC2804765F2FC683CC2F6FC8E12B92196D239F', CAST(N'2021-09-05T20:30:39.680' AS DateTime), 1021, 3, 210495)
INSERT [dbo].[Bitacora] ([ID_Bitacora], [Accion], [Descripcion], [Fecha], [ID_Usuario], [idCriticidad], [DVH]) VALUES (2034, N'Asignación de permiso', N'183187332B51371C12419391C577613FEAFCDFE9BBAC7776333A4D5147577E818529E211099DC3057755CB1F486C94B4D4D181CB92026D6B91E75859332404C6', CAST(N'2021-09-05T20:30:49.730' AS DateTime), 1021, 1, 500053)
INSERT [dbo].[Bitacora] ([ID_Bitacora], [Accion], [Descripcion], [Fecha], [ID_Usuario], [idCriticidad], [DVH]) VALUES (2035, N'Desasignación de permiso', N'183187332B51371C12419391C577613FEAFCDFE9BBAC777678480A0C768EF2FDBD69B5B34FD77061B98F62191ABE4402C7248823C84F7AEB000090A4406A5051', CAST(N'2021-09-05T20:30:53.760' AS DateTime), 1021, 1, 509919)
SET IDENTITY_INSERT [dbo].[Bitacora] OFF
GO
SET IDENTITY_INSERT [dbo].[Criticidad] ON 

INSERT [dbo].[Criticidad] ([IDCriticidad], [Descripcion]) VALUES (1, N'Alta')
INSERT [dbo].[Criticidad] ([IDCriticidad], [Descripcion]) VALUES (2, N'Media')
INSERT [dbo].[Criticidad] ([IDCriticidad], [Descripcion]) VALUES (3, N'Baja')
SET IDENTITY_INSERT [dbo].[Criticidad] OFF
GO
SET IDENTITY_INSERT [dbo].[DVV] ON 

INSERT [dbo].[DVV] ([ID_DVV], [Tabla], [DVV]) VALUES (8, N'66948D9D1850B9DF', 220439)
INSERT [dbo].[DVV] ([ID_DVV], [Tabla], [DVV]) VALUES (9, N'5D0E1D6FC783A53B9CF8946D06083E8C', 5947917)
INSERT [dbo].[DVV] ([ID_DVV], [Tabla], [DVV]) VALUES (13, N'51D81CD833F3742A', 32929)
INSERT [dbo].[DVV] ([ID_DVV], [Tabla], [DVV]) VALUES (14, N'8171DFC3FD5A18E214C44D7BB898B882', 0)
SET IDENTITY_INSERT [dbo].[DVV] OFF
GO
SET IDENTITY_INSERT [dbo].[Idioma] ON 

INSERT [dbo].[Idioma] ([ID_Idioma], [Idioma]) VALUES (1, N'Español')
INSERT [dbo].[Idioma] ([ID_Idioma], [Idioma]) VALUES (2, N'English')
SET IDENTITY_INSERT [dbo].[Idioma] OFF
GO
SET IDENTITY_INSERT [dbo].[IdiomaControl] ON 

INSERT [dbo].[IdiomaControl] ([ID_IdiomaControl], [ID_Idioma], [nombreControl], [Traduccion]) VALUES (2037, 1, N'	administrarFamiliasToolStripMenuItem', N'Administrar Familias')
INSERT [dbo].[IdiomaControl] ([ID_IdiomaControl], [ID_Idioma], [nombreControl], [Traduccion]) VALUES (2038, 1, N'asignarPermisosToolStripMenuItem', N'Asignar Permisos')
INSERT [dbo].[IdiomaControl] ([ID_IdiomaControl], [ID_Idioma], [nombreControl], [Traduccion]) VALUES (2039, 1, N'baseDeDatosToolStripMenuItem', N'Base de datos')
INSERT [dbo].[IdiomaControl] ([ID_IdiomaControl], [ID_Idioma], [nombreControl], [Traduccion]) VALUES (2040, 1, N'btnCerrarSesion', N'Cerrar Sesion')
INSERT [dbo].[IdiomaControl] ([ID_IdiomaControl], [ID_Idioma], [nombreControl], [Traduccion]) VALUES (2041, 1, N'btnCrearFamilia', N'Crear Familia')
INSERT [dbo].[IdiomaControl] ([ID_IdiomaControl], [ID_Idioma], [nombreControl], [Traduccion]) VALUES (2042, 1, N'btnEliminarFamilia', N'eliminar familia')
INSERT [dbo].[IdiomaControl] ([ID_IdiomaControl], [ID_Idioma], [nombreControl], [Traduccion]) VALUES (2043, 1, N'btnIngresar', N'Ingresar')
INSERT [dbo].[IdiomaControl] ([ID_IdiomaControl], [ID_Idioma], [nombreControl], [Traduccion]) VALUES (2044, 1, N'btnListarBitacora', N'Listar')
INSERT [dbo].[IdiomaControl] ([ID_IdiomaControl], [ID_Idioma], [nombreControl], [Traduccion]) VALUES (2045, 1, N'btnListBitacora', N'Listar bitacora')
INSERT [dbo].[IdiomaControl] ([ID_IdiomaControl], [ID_Idioma], [nombreControl], [Traduccion]) VALUES (2046, 1, N'btnRegistrarUsuario', N'Registrar')
INSERT [dbo].[IdiomaControl] ([ID_IdiomaControl], [ID_Idioma], [nombreControl], [Traduccion]) VALUES (2047, 1, N'btnRegistrarUsuario', N'Registrar Usuario')
INSERT [dbo].[IdiomaControl] ([ID_IdiomaControl], [ID_Idioma], [nombreControl], [Traduccion]) VALUES (2048, 1, N'crearFamiliaToolStripMenuItem', N'Crear Familia')
INSERT [dbo].[IdiomaControl] ([ID_IdiomaControl], [ID_Idioma], [nombreControl], [Traduccion]) VALUES (2049, 1, N'generarBackUpToolStripMenuItem', N'Generar Back Up')
INSERT [dbo].[IdiomaControl] ([ID_IdiomaControl], [ID_Idioma], [nombreControl], [Traduccion]) VALUES (2050, 1, N'generarRestoreToolStripMenuItem', N'Generar Restore')
INSERT [dbo].[IdiomaControl] ([ID_IdiomaControl], [ID_Idioma], [nombreControl], [Traduccion]) VALUES (2051, 1, N'lblApellidoRegistrarUsuario', N'Apellido')
INSERT [dbo].[IdiomaControl] ([ID_IdiomaControl], [ID_Idioma], [nombreControl], [Traduccion]) VALUES (2052, 1, N'lblContraseñaLogin', N'Contraseña')
INSERT [dbo].[IdiomaControl] ([ID_IdiomaControl], [ID_Idioma], [nombreControl], [Traduccion]) VALUES (2053, 1, N'lblCriticidadBitacora', N'Criticidad')
INSERT [dbo].[IdiomaControl] ([ID_IdiomaControl], [ID_Idioma], [nombreControl], [Traduccion]) VALUES (2054, 1, N'lblDireccionRegistroUsuario', N'Domicilio')
INSERT [dbo].[IdiomaControl] ([ID_IdiomaControl], [ID_Idioma], [nombreControl], [Traduccion]) VALUES (2055, 1, N'lblFamiliaListar', N'familia')
INSERT [dbo].[IdiomaControl] ([ID_IdiomaControl], [ID_Idioma], [nombreControl], [Traduccion]) VALUES (2056, 1, N'lblFamiliasAsignadas', N'Familias asignadas')
INSERT [dbo].[IdiomaControl] ([ID_IdiomaControl], [ID_Idioma], [nombreControl], [Traduccion]) VALUES (2057, 1, N'lblFamiliasNoAsignadas', N'Familias no asignadas')
INSERT [dbo].[IdiomaControl] ([ID_IdiomaControl], [ID_Idioma], [nombreControl], [Traduccion]) VALUES (2058, 1, N'lblFechaDesdeBitacora', N'Fecha desde')
INSERT [dbo].[IdiomaControl] ([ID_IdiomaControl], [ID_Idioma], [nombreControl], [Traduccion]) VALUES (2059, 1, N'lblFechaHastaBitacora', N'Fecha hasta')
INSERT [dbo].[IdiomaControl] ([ID_IdiomaControl], [ID_Idioma], [nombreControl], [Traduccion]) VALUES (2060, 1, N'lblFechaNacimientoRegistrarUsuario', N'Fecha de nacimiento')
INSERT [dbo].[IdiomaControl] ([ID_IdiomaControl], [ID_Idioma], [nombreControl], [Traduccion]) VALUES (2061, 1, N'lblLenguajeLogin', N'Idioma')
INSERT [dbo].[IdiomaControl] ([ID_IdiomaControl], [ID_Idioma], [nombreControl], [Traduccion]) VALUES (2062, 1, N'lblNombreFamiliaCrear', N'Nombre familia')
INSERT [dbo].[IdiomaControl] ([ID_IdiomaControl], [ID_Idioma], [nombreControl], [Traduccion]) VALUES (2063, 1, N'lblNombreRegistrarUsuario', N'Nombre')
INSERT [dbo].[IdiomaControl] ([ID_IdiomaControl], [ID_Idioma], [nombreControl], [Traduccion]) VALUES (2064, 1, N'lblPermisosAsignados', N'Permisos asignados')
INSERT [dbo].[IdiomaControl] ([ID_IdiomaControl], [ID_Idioma], [nombreControl], [Traduccion]) VALUES (2065, 1, N'lblPermisosNoAsignados', N'Permisos no asignados')
INSERT [dbo].[IdiomaControl] ([ID_IdiomaControl], [ID_Idioma], [nombreControl], [Traduccion]) VALUES (2066, 1, N'lblRutaBackUp', N'Ruta backup')
INSERT [dbo].[IdiomaControl] ([ID_IdiomaControl], [ID_Idioma], [nombreControl], [Traduccion]) VALUES (2067, 1, N'lblRutaRestore', N'Ruta restore')
INSERT [dbo].[IdiomaControl] ([ID_IdiomaControl], [ID_Idioma], [nombreControl], [Traduccion]) VALUES (2068, 1, N'lblUsernameBitacora', N'Usuario')
INSERT [dbo].[IdiomaControl] ([ID_IdiomaControl], [ID_Idioma], [nombreControl], [Traduccion]) VALUES (2069, 1, N'lblUsuarioAsignar', N'Usuario')
INSERT [dbo].[IdiomaControl] ([ID_IdiomaControl], [ID_Idioma], [nombreControl], [Traduccion]) VALUES (2070, 1, N'lblUsuarioLogin', N'Usuario')
INSERT [dbo].[IdiomaControl] ([ID_IdiomaControl], [ID_Idioma], [nombreControl], [Traduccion]) VALUES (2071, 1, N'mensajeBackupExitoso', N'Back Up realizado con exito')
INSERT [dbo].[IdiomaControl] ([ID_IdiomaControl], [ID_Idioma], [nombreControl], [Traduccion]) VALUES (2072, 1, N'mensajeDebeSeleccionarUsuarioOFamilia', N'Debe seleccionar un usuario y una familia')
INSERT [dbo].[IdiomaControl] ([ID_IdiomaControl], [ID_Idioma], [nombreControl], [Traduccion]) VALUES (2073, 1, N'mensajeEstaSeleccionadaPatente', N'Está seleccionada una patente')
INSERT [dbo].[IdiomaControl] ([ID_IdiomaControl], [ID_Idioma], [nombreControl], [Traduccion]) VALUES (2074, 1, N'mensajeNoSePuedeDesasignar', N'No se puede desasignar')
INSERT [dbo].[IdiomaControl] ([ID_IdiomaControl], [ID_Idioma], [nombreControl], [Traduccion]) VALUES (2075, 1, N'msbBaseCorrompida', N'Base de datos dañada')
INSERT [dbo].[IdiomaControl] ([ID_IdiomaControl], [ID_Idioma], [nombreControl], [Traduccion]) VALUES (2076, 1, N'msbContraseñaBlock', N'Contraseña incorrecta. Se ha bloqueado el usuario')
INSERT [dbo].[IdiomaControl] ([ID_IdiomaControl], [ID_Idioma], [nombreControl], [Traduccion]) VALUES (2077, 1, N'msbContraseñaIncorrecta', N'Contraseña incorrecta. Intentos restantes:')
INSERT [dbo].[IdiomaControl] ([ID_IdiomaControl], [ID_Idioma], [nombreControl], [Traduccion]) VALUES (2078, 1, N'msbFamiliaAgregada', N'Familia agregada correctamente')
INSERT [dbo].[IdiomaControl] ([ID_IdiomaControl], [ID_Idioma], [nombreControl], [Traduccion]) VALUES (2079, 1, N'msbNombreFamiliaInvalido', N'Nombre de familia invalido')
INSERT [dbo].[IdiomaControl] ([ID_IdiomaControl], [ID_Idioma], [nombreControl], [Traduccion]) VALUES (2080, 1, N'msbUsuarioCreado', N'Usuario creado con exito')
INSERT [dbo].[IdiomaControl] ([ID_IdiomaControl], [ID_Idioma], [nombreControl], [Traduccion]) VALUES (2081, 1, N'msbUsuarioInexistente', N'Usuario inexistente')
INSERT [dbo].[IdiomaControl] ([ID_IdiomaControl], [ID_Idioma], [nombreControl], [Traduccion]) VALUES (2082, 2, N'administrarFamiliasToolStripMenuItem', N'Manage Family')
INSERT [dbo].[IdiomaControl] ([ID_IdiomaControl], [ID_Idioma], [nombreControl], [Traduccion]) VALUES (2083, 2, N'asignarPermisosToolStripMenuItem', N'Assign Permissions')
INSERT [dbo].[IdiomaControl] ([ID_IdiomaControl], [ID_Idioma], [nombreControl], [Traduccion]) VALUES (2084, 2, N'baseDeDatosToolStripMenuItem', N'DataBase')
INSERT [dbo].[IdiomaControl] ([ID_IdiomaControl], [ID_Idioma], [nombreControl], [Traduccion]) VALUES (2085, 2, N'btnCerrarSesion', N'Log Out')
INSERT [dbo].[IdiomaControl] ([ID_IdiomaControl], [ID_Idioma], [nombreControl], [Traduccion]) VALUES (2086, 2, N'btnCrearFamilia', N'Create family')
INSERT [dbo].[IdiomaControl] ([ID_IdiomaControl], [ID_Idioma], [nombreControl], [Traduccion]) VALUES (2087, 2, N'btnEliminarFamilia', N'delete family')
INSERT [dbo].[IdiomaControl] ([ID_IdiomaControl], [ID_Idioma], [nombreControl], [Traduccion]) VALUES (2088, 2, N'btnIngresar', N'Log In')
INSERT [dbo].[IdiomaControl] ([ID_IdiomaControl], [ID_Idioma], [nombreControl], [Traduccion]) VALUES (2089, 2, N'btnListarBitacora', N'Get list')
INSERT [dbo].[IdiomaControl] ([ID_IdiomaControl], [ID_Idioma], [nombreControl], [Traduccion]) VALUES (2090, 2, N'btnListBitacora', N'get log')
INSERT [dbo].[IdiomaControl] ([ID_IdiomaControl], [ID_Idioma], [nombreControl], [Traduccion]) VALUES (2091, 2, N'btnRegistrarUsuario', N'Register')
INSERT [dbo].[IdiomaControl] ([ID_IdiomaControl], [ID_Idioma], [nombreControl], [Traduccion]) VALUES (2092, 2, N'btnRegistrarUsuario', N'Register User')
INSERT [dbo].[IdiomaControl] ([ID_IdiomaControl], [ID_Idioma], [nombreControl], [Traduccion]) VALUES (2093, 2, N'crearFamiliaToolStripMenuItem', N'Create Family')
INSERT [dbo].[IdiomaControl] ([ID_IdiomaControl], [ID_Idioma], [nombreControl], [Traduccion]) VALUES (2094, 2, N'generarBackUpToolStripMenuItem', N'Generate Back Up')
INSERT [dbo].[IdiomaControl] ([ID_IdiomaControl], [ID_Idioma], [nombreControl], [Traduccion]) VALUES (2095, 2, N'generarRestoreToolStripMenuItem', N'Generate Restore')
INSERT [dbo].[IdiomaControl] ([ID_IdiomaControl], [ID_Idioma], [nombreControl], [Traduccion]) VALUES (2096, 2, N'lblApellidoRegistrarUsuario', N'lastname')
INSERT [dbo].[IdiomaControl] ([ID_IdiomaControl], [ID_Idioma], [nombreControl], [Traduccion]) VALUES (2097, 2, N'lblContraseñaLogin', N'Password')
INSERT [dbo].[IdiomaControl] ([ID_IdiomaControl], [ID_Idioma], [nombreControl], [Traduccion]) VALUES (2098, 2, N'lblCriticidadBitacora', N'Criticity')
INSERT [dbo].[IdiomaControl] ([ID_IdiomaControl], [ID_Idioma], [nombreControl], [Traduccion]) VALUES (2099, 2, N'lblDireccionRegistroUsuario', N'Address')
INSERT [dbo].[IdiomaControl] ([ID_IdiomaControl], [ID_Idioma], [nombreControl], [Traduccion]) VALUES (2100, 2, N'lblFamiliaListar', N'Family')
INSERT [dbo].[IdiomaControl] ([ID_IdiomaControl], [ID_Idioma], [nombreControl], [Traduccion]) VALUES (2101, 2, N'lblFamiliasAsignadas', N'assigned families')
INSERT [dbo].[IdiomaControl] ([ID_IdiomaControl], [ID_Idioma], [nombreControl], [Traduccion]) VALUES (2102, 2, N'lblFamiliasNoAsignadas', N'Unassigned families')
INSERT [dbo].[IdiomaControl] ([ID_IdiomaControl], [ID_Idioma], [nombreControl], [Traduccion]) VALUES (2103, 2, N'lblFechaDesdeBitacora', N'Date from')
INSERT [dbo].[IdiomaControl] ([ID_IdiomaControl], [ID_Idioma], [nombreControl], [Traduccion]) VALUES (2104, 2, N'lblFechaHastaBitacora', N'Date to')
INSERT [dbo].[IdiomaControl] ([ID_IdiomaControl], [ID_Idioma], [nombreControl], [Traduccion]) VALUES (2105, 2, N'lblFechaNacimientoRegistrarUsuario', N'birthdate')
INSERT [dbo].[IdiomaControl] ([ID_IdiomaControl], [ID_Idioma], [nombreControl], [Traduccion]) VALUES (2106, 2, N'lblLenguajeLogin', N'Language')
INSERT [dbo].[IdiomaControl] ([ID_IdiomaControl], [ID_Idioma], [nombreControl], [Traduccion]) VALUES (2107, 2, N'lblNombreFamiliaCrear', N'Family name')
INSERT [dbo].[IdiomaControl] ([ID_IdiomaControl], [ID_Idioma], [nombreControl], [Traduccion]) VALUES (2108, 2, N'lblNombreRegistrarUsuario', N'firstname')
INSERT [dbo].[IdiomaControl] ([ID_IdiomaControl], [ID_Idioma], [nombreControl], [Traduccion]) VALUES (2109, 2, N'lblPermisosAsignados', N'assigned permissions')
INSERT [dbo].[IdiomaControl] ([ID_IdiomaControl], [ID_Idioma], [nombreControl], [Traduccion]) VALUES (2110, 2, N'lblPermisosNoAsignados', N'unassigned permissions')
INSERT [dbo].[IdiomaControl] ([ID_IdiomaControl], [ID_Idioma], [nombreControl], [Traduccion]) VALUES (2111, 2, N'lblRutaBackUp', N'Backup path')
INSERT [dbo].[IdiomaControl] ([ID_IdiomaControl], [ID_Idioma], [nombreControl], [Traduccion]) VALUES (2112, 2, N'lblRutaRestore', N'Restore path')
INSERT [dbo].[IdiomaControl] ([ID_IdiomaControl], [ID_Idioma], [nombreControl], [Traduccion]) VALUES (2113, 2, N'lblUsernameBitacora', N'Username')
INSERT [dbo].[IdiomaControl] ([ID_IdiomaControl], [ID_Idioma], [nombreControl], [Traduccion]) VALUES (2114, 2, N'lblUsuarioAsignar', N'User')
INSERT [dbo].[IdiomaControl] ([ID_IdiomaControl], [ID_Idioma], [nombreControl], [Traduccion]) VALUES (2115, 2, N'lblUsuarioLogin', N'Username')
INSERT [dbo].[IdiomaControl] ([ID_IdiomaControl], [ID_Idioma], [nombreControl], [Traduccion]) VALUES (2116, 2, N'mensajeBackupExitoso', N'Successful backup')
INSERT [dbo].[IdiomaControl] ([ID_IdiomaControl], [ID_Idioma], [nombreControl], [Traduccion]) VALUES (2117, 2, N'mensajeDebeSeleccionarUsuarioOFamilia', N'You must select an user and a family')
INSERT [dbo].[IdiomaControl] ([ID_IdiomaControl], [ID_Idioma], [nombreControl], [Traduccion]) VALUES (2118, 2, N'mensajeEstaSeleccionadaPatente', N'A patent is selected')
INSERT [dbo].[IdiomaControl] ([ID_IdiomaControl], [ID_Idioma], [nombreControl], [Traduccion]) VALUES (2119, 2, N'mensajeNoSePuedeDesasignar', N'It cannot be unassigned')
INSERT [dbo].[IdiomaControl] ([ID_IdiomaControl], [ID_Idioma], [nombreControl], [Traduccion]) VALUES (2120, 2, N'msbBaseCorrompida', N'Corrupted Database')
INSERT [dbo].[IdiomaControl] ([ID_IdiomaControl], [ID_Idioma], [nombreControl], [Traduccion]) VALUES (2121, 2, N'msbContraseñaBlock', N'Wrong Password. The user has been blocked')
INSERT [dbo].[IdiomaControl] ([ID_IdiomaControl], [ID_Idioma], [nombreControl], [Traduccion]) VALUES (2122, 2, N'msbContraseñaIncorrecta', N'Wrong password. Attemps left:')
INSERT [dbo].[IdiomaControl] ([ID_IdiomaControl], [ID_Idioma], [nombreControl], [Traduccion]) VALUES (2123, 2, N'msbFamiliaAgregada', N'Family created successfully')
INSERT [dbo].[IdiomaControl] ([ID_IdiomaControl], [ID_Idioma], [nombreControl], [Traduccion]) VALUES (2124, 2, N'msbNombreFamiliaInvalido', N'Invalid family name')
INSERT [dbo].[IdiomaControl] ([ID_IdiomaControl], [ID_Idioma], [nombreControl], [Traduccion]) VALUES (2125, 2, N'msbUsuarioCreado', N'User created successfully')
INSERT [dbo].[IdiomaControl] ([ID_IdiomaControl], [ID_Idioma], [nombreControl], [Traduccion]) VALUES (2126, 2, N'msbUsuarioInexistente', N'The user does not exist')
SET IDENTITY_INSERT [dbo].[IdiomaControl] OFF
GO
SET IDENTITY_INSERT [dbo].[Permiso] ON 

INSERT [dbo].[Permiso] ([ID_Permiso], [Permiso], [IsFamilia], [DVH]) VALUES (5, N'440DA03C2E7CBB9CA6799BB9D4A68C5A', 1, N'32929')
SET IDENTITY_INSERT [dbo].[Permiso] OFF
GO
SET IDENTITY_INSERT [dbo].[Usuario] ON 

INSERT [dbo].[Usuario] ([ID_Usuario], [Nombre], [Apellido], [DNI], [Username], [Contraseña], [Email], [FechaNacimiento], [IntentosIngreso], [Bloqueado], [Direccion], [DVH]) VALUES (1021, N'julian', N'perez', N'42679056', N'8F95C6D1DFA80209', N'2228fd0cb1d1142cad99e5cfe0d871dd47b913b9cf5ebc7d73f94d0ebf92a62b', N'jperezdemonty@live.com.ar', CAST(N'2021-09-05' AS Date), 3, 0, N'755F115A5E8FC990', N'220439')
SET IDENTITY_INSERT [dbo].[Usuario] OFF
GO
ALTER TABLE [dbo].[Compuesto]  WITH CHECK ADD  CONSTRAINT [FK_Compuesto_Compuesto] FOREIGN KEY([ID_Compuesto])
REFERENCES [dbo].[Compuesto] ([ID_Compuesto])
GO
ALTER TABLE [dbo].[Compuesto] CHECK CONSTRAINT [FK_Compuesto_Compuesto]
GO
ALTER TABLE [dbo].[Compuesto]  WITH CHECK ADD  CONSTRAINT [FK_Compuesto_Compuesto1] FOREIGN KEY([ID_Familia])
REFERENCES [dbo].[Permiso] ([ID_Permiso])
GO
ALTER TABLE [dbo].[Compuesto] CHECK CONSTRAINT [FK_Compuesto_Compuesto1]
GO
ALTER TABLE [dbo].[Compuesto]  WITH CHECK ADD  CONSTRAINT [FK_Compuesto_Permiso] FOREIGN KEY([ID_Permiso])
REFERENCES [dbo].[Permiso] ([ID_Permiso])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Compuesto] CHECK CONSTRAINT [FK_Compuesto_Permiso]
GO
/****** Object:  StoredProcedure [dbo].[AGREGAR_FAMILIA]    Script Date: 5/9/2021 20:33:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE   Procedure [dbo].[AGREGAR_FAMILIA]
@familia nvarchar(max)

as
begin

INSERT INTO Permiso values(@familia,1,0)

return @@IDENTITY

end
GO
/****** Object:  StoredProcedure [dbo].[ASIGNAR_PERMISO_A_USUARIO]    Script Date: 5/9/2021 20:33:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE   Procedure [dbo].[ASIGNAR_PERMISO_A_USUARIO]
@nombrePermiso nvarchar(max), @username nvarchar(max), @isFamilia bit

as
begin


Declare @id_permiso int set @id_permiso = (Select p.ID_Permiso from Permiso p where p.Permiso = @nombrePermiso and p.IsFamilia = @isFamilia)

Declare @id_usuario int set @id_usuario = (Select us.ID_Usuario from Usuario us where us.Username = @username)

INSERT INTO UsuarioPermiso values (@id_usuario,@id_permiso,0)

return @@IDENTITY

end
GO
/****** Object:  StoredProcedure [dbo].[BloquearUsuario]    Script Date: 5/9/2021 20:33:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE   procedure [dbo].[BloquearUsuario]
@Username nvarchar(max)
as begin
update Usuario set Bloqueado=1 where Username=@Username
end
GO
/****** Object:  StoredProcedure [dbo].[BuscarTexto]    Script Date: 5/9/2021 20:33:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create   procedure [dbo].[BuscarTexto]
@nombreControl nvarchar(150), @idioma nvarchar(50)
as begin
select Traduccion from IdiomaControl
INNER JOIN Idioma ON IdiomaControl.ID_Idioma = Idioma.ID_Idioma
WHERE Idioma.Idioma=@idioma and IdiomaControl.nombreControl=@nombreControl
end
GO
/****** Object:  StoredProcedure [dbo].[COMPROBAR_FAMILIA_A_QUITAR_USUARIO]    Script Date: 5/9/2021 20:33:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE   Procedure [dbo].[COMPROBAR_FAMILIA_A_QUITAR_USUARIO]
@familia nvarchar(max), @user nvarchar(max)
--
as
begin

--LOTE DE PRUEBA 28,33
--recibimos el user. 
--obtenemos las patentes de la familia recibida por parametro. aplicar distinct-->  #patentesFamilia
--obtenemos TODAS las patentes del user,filtrando por las que se encuentran en #patentesFamilia .. distinguiendo por la familia recibida (compuesto.familia != familiaparametro). aplicar distinct
--contar todas las patentes que tiene familia recibida por parametro
--contar todas las patentes del user (sin contar las de familia por parametro)


declare @user_id int set @user_id = (select  u.ID_Usuario from Usuario u where u.Username = @user)


Declare @id_familia int set @id_familia = (Select p.ID_Permiso from Permiso p where p.Permiso = @familia and p.IsFamilia = 1)


select distinct p.Permiso into #patentesFamilia from Compuesto c 
inner join Permiso p on p.ID_Permiso = c.ID_Permiso 
where c.ID_Familia = @id_familia and p.IsFamilia = 0

SELECT distinct p.permiso into #patentesUsuarioParam
	FROM Permiso p 
	inner join UsuarioPermiso up on p.ID_Permiso = up.ID_Permiso 
	where  /*up.id_usuario = @user_id and*/ p.IsFamilia = 0 and p.Permiso in (select pf.Permiso from #patentesFamilia pf)

SELECT distinct p.ID_Permiso
INTO #familiasDistintoUsuarioParam
FROM Permiso p 
inner join Compuesto c on p.ID_Permiso= c.ID_Familia 
inner join UsuarioPermiso up on up.ID_Permiso = p.ID_Permiso  
where p.IsFamilia = 1 and up.ID_Usuario != @user_id



SELECT DISTINCT patentesTotalesUsuarioParam.permiso into #patentesTotalesUsuarioParam FROM
(  
	select * from #patentesUsuarioParam
	--
    UNION ALL
	--
    select p.Permiso
	from Permiso p 
	inner join Compuesto c on p.ID_Permiso = c.ID_Permiso 
	inner join #familiasDistintoUsuarioParam t on t.ID_Permiso = c.ID_Familia
	where  p.Permiso in (select pf.Permiso from #patentesFamilia pf)
) patentesTotalesUsuarioParam

Declare @cantidadPatentesUser int set @cantidadPatentesUser = (select COUNT(p.Permiso) as cantidad from #patentesTotalesUsuarioParam p) --Obtiene cantidad 

Declare @cantidadPatentesFamilia int set @cantidadPatentesFamilia = (select COUNT(p.Permiso) as cantidad from #patentesFamilia p) --Obtiene cantidad 

if @cantidadPatentesFamilia = @cantidadPatentesUser
	begin
		select 1 as Contador
	end
	else
	begin
		select 0 as Contador
	end

end
GO
/****** Object:  StoredProcedure [dbo].[COMPROBAR_PATENTE_A_QUITAR_USUARIO]    Script Date: 5/9/2021 20:33:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE   Procedure [dbo].[COMPROBAR_PATENTE_A_QUITAR_USUARIO]
@username nvarchar(max), @patente nvarchar(max)
--COMPRUEBA QUE UNA PATENTE PUEDA QUITARSE A UN USUARIO VERIFICANDO QUE HAYA OTRO U OTROS USUARIOS QUE POSEAN ESA PATENTE YA SEA SUELTA O HEREDADA DE FAMILIA
as
begin

--LOTE DE PRUEBAS 20,24,26,35,39

Declare @id_usuario int set @id_usuario = (Select us.ID_Usuario from Usuario us where us.Username = @username)

Declare @id_patente int set @id_patente = (Select p.ID_Permiso from Permiso p where p.Permiso = @patente)

SELECT distinct p.ID_Permiso,up.ID_Usuario INTO #tablaFamilias
FROM Permiso  p 
inner join Compuesto c on p.ID_Permiso= c.ID_Familia 
inner join UsuarioPermiso up on up.ID_Permiso = p.ID_Permiso 
where p.IsFamilia = 1 --Trae familias de usuarios

SELECT T.ID_Usuario, COUNT(T.permiso) cantidad into #usuariosConPatente FROM
(   SELECT p.permiso, up.ID_Usuario 
	FROM Permiso p 
	inner join UsuarioPermiso up on p.ID_Permiso = up.ID_Permiso and p.IsFamilia = 0 
	where p.ID_Permiso = @id_patente and up.ID_Usuario != @id_usuario --Trae patentes unicas por cada usuario distinto al que recibe y que no sea familia
    UNION ALL
    select p.Permiso, t.ID_Usuario
	from Permiso p 
	inner join Compuesto c on p.ID_Permiso = c.ID_Permiso 
	inner join #tablaFamilias t on t.ID_Permiso = c.ID_Familia
	where p.ID_Permiso = @id_patente  --Trae patentes a partir de las familias de los usuarios distinto a lo que recibe (en este caso una patente)
) T group by T.Permiso, T.ID_Usuario

Select COUNT(1) as Contador from #usuariosConPatente

end
GO
/****** Object:  StoredProcedure [dbo].[CrearUsuario]    Script Date: 5/9/2021 20:33:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE   procedure [dbo].[CrearUsuario]
@Nombre nvarchar(50),
@Apellido nvarchar(50),
@Dni nvarchar(50),
@Username nvarchar(max),
@Contraseña nvarchar(max),
@Email nvarchar(50),
@FechaNacimiento date,
@Direccion nvarchar(max)
as begin
insert into Usuario
values(@Nombre,@Apellido,@Dni,@Username,@Contraseña,@Email,@FechaNacimiento,3,0,@Direccion,0)

return @@IDENTITY
end
GO
/****** Object:  StoredProcedure [dbo].[DESASIGNAR_PERMISO_A_USUARIO]    Script Date: 5/9/2021 20:33:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE   Procedure [dbo].[DESASIGNAR_PERMISO_A_USUARIO]
@nombrePermiso nvarchar(max), @username nvarchar(max), @isFamilia bit

as
begin

Declare @id_permiso int set @id_permiso = (Select p.ID_Permiso from Permiso p where p.Permiso = @nombrePermiso and p.IsFamilia = @isFamilia)

Declare @id_usuario int set @id_usuario = (Select us.ID_Usuario from Usuario us where us.Username = @username)

Declare @id_usuario_permiso int set @id_usuario_permiso = (Select up.ID_UsuarioPermiso from UsuarioPermiso up where up.ID_Permiso = @id_permiso and up.ID_Usuario = @id_usuario)

Delete from UsuarioPermiso where ID_UsuarioPermiso = @id_usuario_permiso

end
GO
/****** Object:  StoredProcedure [dbo].[DVH_GUARDAR]    Script Date: 5/9/2021 20:33:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create   Procedure [dbo].[DVH_GUARDAR]
@nombre_tabla nvarchar(250), @nombre_id nvarchar(250),@id int, @dvh nvarchar(max)

as
begin

Declare @SQL nvarchar(max)

SET @SQL = 'UPDATE'+QUOTENAME(@nombre_tabla)+'SET DVH ='+@dvh+'WHERE'+QUOTENAME(@nombre_id)+'='+Cast(@id as varchar(max))
EXEC sp_executesql @SQL

end
GO
/****** Object:  StoredProcedure [dbo].[DVH_OBTENER_SUMA_TABLA]    Script Date: 5/9/2021 20:33:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create   Procedure [dbo].[DVH_OBTENER_SUMA_TABLA]
@nombreTabla nvarchar(max)
as
begin

Declare @SQL nvarchar(max)

SET @SQL = 'SELECT sum(CAST(DVH as bigint)) as DVH FROM '+QUOTENAME(@nombreTabla)
EXEC sp_executesql @SQL

end
GO
/****** Object:  StoredProcedure [dbo].[DVH_REGISTRO_COMPLETO]    Script Date: 5/9/2021 20:33:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create   Procedure [dbo].[DVH_REGISTRO_COMPLETO]
@nombre_tabla nvarchar(250), @nombre_id nvarchar(250), @id int

as
begin

Declare @SQL nvarchar(max)

SET @SQL = 'SELECT * FROM ' + QUOTENAME(@nombre_tabla) + 'where'+QUOTENAME(@nombre_id)+'=' + CAST(@id as varchar(max))
EXEC sp_executesql @SQL

end
GO
/****** Object:  StoredProcedure [dbo].[DVH_TRAER_DVH_REGISTRO]    Script Date: 5/9/2021 20:33:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create   Procedure [dbo].[DVH_TRAER_DVH_REGISTRO]
@nombreTabla nvarchar(max), @id int, @nombreId nvarchar(max)
as
begin

Declare @SQL nvarchar(max)

SET @SQL = 'SELECT ISNULL(DVH,0) AS DVH FROM ' + QUOTENAME(@nombreTabla) + 'where'+QUOTENAME(@nombreId)+'=' + CAST(@id as varchar(max))
EXEC sp_executesql @SQL

end
GO
/****** Object:  StoredProcedure [dbo].[DVH_TRAER_TABLA_COMPLETA]    Script Date: 5/9/2021 20:33:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create   Procedure [dbo].[DVH_TRAER_TABLA_COMPLETA]
@nombreTabla nvarchar(max)
as
begin

Declare @SQL nvarchar(max)

SET @SQL = 'SELECT * FROM ' + QUOTENAME(@nombreTabla)
EXEC sp_executesql @SQL

end
GO
/****** Object:  StoredProcedure [dbo].[DVV_GUARDAR]    Script Date: 5/9/2021 20:33:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create   Procedure [dbo].[DVV_GUARDAR]
@nombreTabla nvarchar(max), @dvv nvarchar(max)
as
begin

IF EXISTS(Select Tabla from DVV where Tabla = @nombreTabla)
	BEGIN
		UPDATE DVV SET DVV = @dvv where Tabla = @nombreTabla
	END
ELSE
	BEGIN
		INSERT INTO DVV values (@nombreTabla,@dvv)
	END

end
GO
/****** Object:  StoredProcedure [dbo].[DVV_OBTENER_TABLA_PARTICULAR]    Script Date: 5/9/2021 20:33:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create   Procedure [dbo].[DVV_OBTENER_TABLA_PARTICULAR]
@nombreTabla nvarchar(max)
as
begin

Select ID_DVV,Tabla,DVV from DVV where Tabla = @nombreTabla

end
GO
/****** Object:  StoredProcedure [dbo].[DVV_TABLA_COMPLETA]    Script Date: 5/9/2021 20:33:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create   Procedure [dbo].[DVV_TABLA_COMPLETA]
as
begin

Select ID_DVV,
	   Tabla,
	   DVV
from DVV

end
GO
/****** Object:  StoredProcedure [dbo].[IniciarSesion]    Script Date: 5/9/2021 20:33:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE   procedure [dbo].[IniciarSesion]
@username nvarchar(MAX), @password varchar(MAX)
as begin
select * from Usuario where Username=@username and Contraseña=@password and Bloqueado=0
end
GO
/****** Object:  StoredProcedure [dbo].[ListarBitacora]    Script Date: 5/9/2021 20:33:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE   PROCEDURE [dbo].[ListarBitacora]
@fechaDesde date=null, @fechaHasta date=null, 
@criticidad nvarchar(30)=null, @usuario nvarchar(max)=null
as begin
declare @idCriticidad int, @idUsuario int
set @idCriticidad = (select IDCriticidad from Criticidad where Descripcion=@criticidad)
set @idUsuario = 0

if @usuario is not null
begin
set @idUsuario = (select ID_Usuario from Usuario where Username=@usuario)
end


select Accion,bitacora.Descripcion,Fecha,Criticidad.Descripcion as Criticidad , Usuario.Username 
from Bitacora
inner join Usuario on Bitacora.ID_Usuario = Usuario.ID_Usuario
inner join Criticidad on Bitacora.idCriticidad = Criticidad.IDCriticidad
where 
((CONVERT(date,Fecha,103) >= @fechaDesde ) or (@fechaDesde is null )) and
((CONVERT(date,Fecha,103) <= @fechaHasta ) or (@fechaHasta is null )) and
((Bitacora.idCriticidad=@idCriticidad) or (@criticidad is null)) and
((Bitacora.ID_Usuario=@idUsuario) or (@idUsuario = 0 ))
order by Fecha desc
end
GO
/****** Object:  StoredProcedure [dbo].[ListarIdiomas]    Script Date: 5/9/2021 20:33:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create   procedure [dbo].[ListarIdiomas]
as begin
select * from Idioma
end
GO
/****** Object:  StoredProcedure [dbo].[MostrarIntentoLog]    Script Date: 5/9/2021 20:33:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create   procedure [dbo].[MostrarIntentoLog]
@Username nvarchar(max)
as begin
select IntentosIngreso from Usuario where Username=@Username
end
GO
/****** Object:  StoredProcedure [dbo].[OBTENER_PATENTE_X_FAMILIA]    Script Date: 5/9/2021 20:33:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE   Procedure [dbo].[OBTENER_PATENTE_X_FAMILIA]
@familia nvarchar(max)

as
begin

Declare @id_familia as int set @id_familia = (Select p.ID_Permiso from Permiso p where p.Permiso = @familia and p.IsFamilia = 1)

Select p.ID_Permiso as ID_Permiso,
		p.Permiso,
		p.IsFamilia as IsFamilia,
		ISNULL(p.DVH,0) as DVH
from Permiso p 
inner join Compuesto c on c.ID_Familia = @id_familia
where p.ID_Permiso = c.ID_Permiso

end
GO
/****** Object:  StoredProcedure [dbo].[OBTENER_PATENTSE_QUITANDO_PATENTES_FAMILIA]    Script Date: 5/9/2021 20:33:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE   Procedure [dbo].[OBTENER_PATENTSE_QUITANDO_PATENTES_FAMILIA]
@familia nvarchar(max)

as
begin

Declare @id_familia as int set @id_familia = (Select p.ID_Permiso from Permiso p where p.Permiso = @familia and p.IsFamilia = 1)

Select p.ID_Permiso as ID_Permiso,
		p.Permiso as Permiso,
		p.IsFamilia as IsFamilia,
		ISNULL(p.DVH,0) as DVH
into #patentes
from Permiso p 
where p.IsFamilia = 0 --Todas las patentes

Select p.ID_Permiso as ID_Permiso
into #patentesFamilia
from #patentes p
inner join Compuesto c on c.ID_Permiso = p.ID_Permiso
where p.IsFamilia = 0 and c.ID_Familia = @id_familia--Patentes de la familia

Delete from #patentes where ID_Permiso in (select ID_Permiso from #patentesFamilia)

Select p.ID_Permiso,
		p.Permiso,
		p.IsFamilia,
		p.DVH
from #patentes p

end
GO
/****** Object:  StoredProcedure [dbo].[OBTENER_PERMISOS]    Script Date: 5/9/2021 20:33:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE   Procedure [dbo].[OBTENER_PERMISOS]
@isFamilia bit

as
begin

Select p.ID_Permiso as ID_Permiso,
		p.Permiso as Permiso,
		p.IsFamilia as IsFamilia,
		ISNULL(p.DVH,0) as DVH
from Permiso p where p.IsFamilia = @isFamilia

end
GO
/****** Object:  StoredProcedure [dbo].[OBTENER_PERMISOS_EXLUYENTES_AL_USUARIO]    Script Date: 5/9/2021 20:33:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE   Procedure [dbo].[OBTENER_PERMISOS_EXLUYENTES_AL_USUARIO]
@username nvarchar(max),@isFamilia bit

as
begin

Declare @id_usuario int set @id_usuario = (Select us.ID_Usuario from Usuario us where us.Username = @username)

Select p.ID_Permiso as ID_Permiso,
		p.Permiso as Permiso,
		p.IsFamilia as IsFamilia,
		ISNULL(p.DVH,0) as DVH
into #permisos
from Permiso p 
where p.IsFamilia = @isFamilia

Select p.ID_Permiso as ID_Permiso
		into #permisosUsuario
from #permisos p
inner join UsuarioPermiso up on up.ID_Permiso = p.ID_Permiso
where up.ID_Usuario = @id_usuario 

Delete from #permisos where ID_Permiso in (select ID_Permiso from #permisosUsuario)

Select p.ID_Permiso,
		p.Permiso,
		p.IsFamilia,
		p.DVH
from #permisos p

end
GO
/****** Object:  StoredProcedure [dbo].[OBTENER_PERMISOS_GENERAL]    Script Date: 5/9/2021 20:33:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE   Procedure [dbo].[OBTENER_PERMISOS_GENERAL]
@isFamilia bit

as
begin

Select p.ID_Permiso as ID_Permiso,
		p.Permiso as Permiso,
		p.IsFamilia as IsFamilia,
		ISNULL(p.DVH,0) as DVH
from Permiso p where p.IsFamilia = @isFamilia

end
GO
/****** Object:  StoredProcedure [dbo].[OBTENER_PERMISOS_X_USUARIO]    Script Date: 5/9/2021 20:33:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [dbo].[OBTENER_PERMISOS_X_USUARIO]
@isFamilia bit, @user nvarchar(max)

as
begin

Declare @id_user int set @id_user = (Select u.ID_Usuario from Usuario u where u.Username = @user)


Select p.ID_Permiso as ID_Permiso,
		p.Permiso as Permiso,
		p.IsFamilia as IsFamilia,
		ISNULL(p.DVH,0) as DVH
from UsuarioPermiso up
inner join Permiso p on p.ID_Permiso = up.ID_Permiso
where up.ID_Usuario = @id_user and p.IsFamilia = @isFamilia

end
GO
/****** Object:  StoredProcedure [dbo].[OBTENER_USUARIOS]    Script Date: 5/9/2021 20:33:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE   PROCEDURE [dbo].[OBTENER_USUARIOS]

AS BEGIN
select * from Usuario
END
GO
/****** Object:  StoredProcedure [dbo].[ObtenerUsuarioLogin]    Script Date: 5/9/2021 20:33:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create   procedure [dbo].[ObtenerUsuarioLogin]
@username nvarchar(max)

as begin

select * from Usuario where Username=@username

end
GO
/****** Object:  StoredProcedure [dbo].[ReestablecerInicioSesion]    Script Date: 5/9/2021 20:33:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE   procedure [dbo].[ReestablecerInicioSesion]
@Username nvarchar(max)
as begin
update Usuario set IntentosIngreso=3 where Username=@Username
end
GO
/****** Object:  StoredProcedure [dbo].[RegistrarBitacora]    Script Date: 5/9/2021 20:33:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE   PROCEDURE [dbo].[RegistrarBitacora]
@Accion nvarchar(100), @Descripcion nvarchar(max),
@Criticidad nvarchar(30), @usuario nvarchar(100)
as begin
declare @idusuario int, @idCriticidad int
declare @lastID int
set @idusuario=(select ID_Usuario from Usuario where Username=@usuario)
set @idCriticidad = (select IDCriticidad from Criticidad where Descripcion = @Criticidad)

insert into Bitacora 
(Accion,
Descripcion,
Fecha,
ID_Usuario,
idCriticidad,
DVH)

values (
@Accion,
@Descripcion,
GETDATE(),
@idusuario,
@idCriticidad,
0)

set  @lastID = (select @@IDENTITY)

return @lastID
end
GO
/****** Object:  StoredProcedure [dbo].[SumarIntentoDeLog]    Script Date: 5/9/2021 20:33:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE   procedure [dbo].[SumarIntentoDeLog]
@Username nvarchar(max)
as begin
update Usuario
Set IntentosIngreso = IntentosIngreso - 1 where Username=@Username
end
GO
/****** Object:  StoredProcedure [dbo].[VerificarUsuario]    Script Date: 5/9/2021 20:33:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE   PROCEDURE [dbo].[VerificarUsuario]
@USERNAME NVARCHAR(MAX)
AS BEGIN
SELECT * FROM Usuario WHERE Username=@USERNAME and Bloqueado=0
END
GO
USE [master]
GO
ALTER DATABASE [DIPLOMA] SET  READ_WRITE 
GO
