USE [master]
GO
/****** Object:  Database [DIPLOMA]    Script Date: 24/05/2021 1:09:47 ******/
CREATE DATABASE [DIPLOMA]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'DIPLOMA', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\DIPLOMA.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'DIPLOMA_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\DIPLOMA_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [DIPLOMA] SET COMPATIBILITY_LEVEL = 140
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
EXEC sys.sp_db_vardecimal_storage_format N'DIPLOMA', N'ON'
GO
ALTER DATABASE [DIPLOMA] SET QUERY_STORE = OFF
GO
USE [DIPLOMA]
GO
/****** Object:  UserDefinedFunction [dbo].[fn_FileExist]    Script Date: 24/05/2021 1:09:47 ******/
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
/****** Object:  UserDefinedFunction [dbo].[fn_FileExists]    Script Date: 24/05/2021 1:09:47 ******/
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
/****** Object:  Table [dbo].[Bitacora]    Script Date: 24/05/2021 1:09:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Bitacora](
	[IDBitacora] [int] IDENTITY(1,1) NOT NULL,
	[Accion] [nvarchar](100) NOT NULL,
	[Descripcion] [nvarchar](max) NOT NULL,
	[Fecha] [datetime] NOT NULL,
	[IDUsuario] [int] NOT NULL,
	[idCriticidad] [int] NOT NULL,
	[DVH] [int] NOT NULL,
 CONSTRAINT [PK_Bitacora] PRIMARY KEY CLUSTERED 
(
	[IDBitacora] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Criticidad]    Script Date: 24/05/2021 1:09:47 ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Idioma]    Script Date: 24/05/2021 1:09:47 ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[IdiomaControl]    Script Date: 24/05/2021 1:09:47 ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Usuario]    Script Date: 24/05/2021 1:09:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Usuario](
	[IDUsuario] [int] IDENTITY(1,1) NOT NULL,
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
 CONSTRAINT [PK_Usuario] PRIMARY KEY CLUSTERED 
(
	[IDUsuario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Bitacora] ON 

INSERT [dbo].[Bitacora] ([IDBitacora], [Accion], [Descripcion], [Fecha], [IDUsuario], [idCriticidad], [DVH]) VALUES (2, N'Inicio de sesión', N'3æ<|<œˆ™7ƒ6ÏWDÏÿR4«’›ŒZ–B‡]ÕÎé)XûÃlÚ%n£t', CAST(N'2021-05-24T00:26:58.437' AS DateTime), 1004, 2, 0)
INSERT [dbo].[Bitacora] ([IDBitacora], [Accion], [Descripcion], [Fecha], [IDUsuario], [idCriticidad], [DVH]) VALUES (3, N'Inicio de sesión', N'3æ<|<œˆ™7ƒ6ÏWDÏÿR4«’›ŒZ–B‡]ÕÎé)XûÃlÚ%n£t', CAST(N'2021-05-24T00:32:04.287' AS DateTime), 1004, 2, 0)
INSERT [dbo].[Bitacora] ([IDBitacora], [Accion], [Descripcion], [Fecha], [IDUsuario], [idCriticidad], [DVH]) VALUES (4, N'Inicio de sesión', N'3æ<|<œˆ™7ƒ6ÏWDÏÿR4«’›ŒZ–B‡]ÕÎé)XûÃlÚ%n£t', CAST(N'2021-05-24T00:33:26.407' AS DateTime), 1004, 2, 0)
INSERT [dbo].[Bitacora] ([IDBitacora], [Accion], [Descripcion], [Fecha], [IDUsuario], [idCriticidad], [DVH]) VALUES (5, N'Inicio de sesión', N'3æ<|<œˆ™7ƒ6ÏWDÏÿR4«’›ŒZ–B‡]ÕÎé)XûÃlÚ%n£t', CAST(N'2021-05-24T00:41:13.457' AS DateTime), 1004, 2, 0)
INSERT [dbo].[Bitacora] ([IDBitacora], [Accion], [Descripcion], [Fecha], [IDUsuario], [idCriticidad], [DVH]) VALUES (6, N'Inicio de sesión', N'3æ<|<œˆw16C+¨º''kö¿Š‘FµãØÌó7lp”p¨xdvóÍ1ŠÑÆºóB', CAST(N'2021-05-24T00:43:24.673' AS DateTime), 1004, 2, 0)
INSERT [dbo].[Bitacora] ([IDBitacora], [Accion], [Descripcion], [Fecha], [IDUsuario], [idCriticidad], [DVH]) VALUES (7, N'Inicio de sesión', N'3æ<|<œˆw16C+¨º''kö¿Š‘FµãØÌó7lp”p¨xdvóÍ1ŠÑÆºóB', CAST(N'2021-05-24T00:45:13.097' AS DateTime), 1004, 2, 0)
INSERT [dbo].[Bitacora] ([IDBitacora], [Accion], [Descripcion], [Fecha], [IDUsuario], [idCriticidad], [DVH]) VALUES (8, N'Inicio de sesión', N'3æ<|<œˆw16C+¨º''kö¿Š‘FµãØÌó7lp”p¨xdvóÍ1ŠÑÆºóB', CAST(N'2021-05-24T00:47:16.517' AS DateTime), 1004, 2, 0)
INSERT [dbo].[Bitacora] ([IDBitacora], [Accion], [Descripcion], [Fecha], [IDUsuario], [idCriticidad], [DVH]) VALUES (9, N'Inicio de sesión', N'3æ<|<œˆw16C+¨º''kö¿Š‘FµãØÌó7lp”p¨xdvóÍ1ŠÑÆºóB', CAST(N'2021-05-24T00:48:17.577' AS DateTime), 1004, 2, 0)
SET IDENTITY_INSERT [dbo].[Bitacora] OFF
GO
SET IDENTITY_INSERT [dbo].[Criticidad] ON 

INSERT [dbo].[Criticidad] ([IDCriticidad], [Descripcion]) VALUES (1, N'Alta')
INSERT [dbo].[Criticidad] ([IDCriticidad], [Descripcion]) VALUES (2, N'Media')
INSERT [dbo].[Criticidad] ([IDCriticidad], [Descripcion]) VALUES (3, N'Baja')
SET IDENTITY_INSERT [dbo].[Criticidad] OFF
GO
SET IDENTITY_INSERT [dbo].[Idioma] ON 

INSERT [dbo].[Idioma] ([ID_Idioma], [Idioma]) VALUES (1, N'Español')
INSERT [dbo].[Idioma] ([ID_Idioma], [Idioma]) VALUES (2, N'English')
SET IDENTITY_INSERT [dbo].[Idioma] OFF
GO
SET IDENTITY_INSERT [dbo].[IdiomaControl] ON 

INSERT [dbo].[IdiomaControl] ([ID_IdiomaControl], [ID_Idioma], [nombreControl], [Traduccion]) VALUES (1, 1, N'lblUsuarioLogin', N'Usuario')
INSERT [dbo].[IdiomaControl] ([ID_IdiomaControl], [ID_Idioma], [nombreControl], [Traduccion]) VALUES (2, 2, N'lblUsuarioLogin', N'Username')
INSERT [dbo].[IdiomaControl] ([ID_IdiomaControl], [ID_Idioma], [nombreControl], [Traduccion]) VALUES (3, 1, N'lblContraseñaLogin', N'Contraseña')
INSERT [dbo].[IdiomaControl] ([ID_IdiomaControl], [ID_Idioma], [nombreControl], [Traduccion]) VALUES (4, 2, N'lblContraseñaLogin', N'Password')
INSERT [dbo].[IdiomaControl] ([ID_IdiomaControl], [ID_Idioma], [nombreControl], [Traduccion]) VALUES (5, 1, N'btnIngresar', N'Ingresar')
INSERT [dbo].[IdiomaControl] ([ID_IdiomaControl], [ID_Idioma], [nombreControl], [Traduccion]) VALUES (6, 2, N'btnIngresar', N'Log In')
INSERT [dbo].[IdiomaControl] ([ID_IdiomaControl], [ID_Idioma], [nombreControl], [Traduccion]) VALUES (7, 1, N'btnCerrarSesion', N'Cerrar Sesion')
INSERT [dbo].[IdiomaControl] ([ID_IdiomaControl], [ID_Idioma], [nombreControl], [Traduccion]) VALUES (8, 2, N'btnCerrarSesion', N'Log Out')
INSERT [dbo].[IdiomaControl] ([ID_IdiomaControl], [ID_Idioma], [nombreControl], [Traduccion]) VALUES (9, 1, N'btnRegistrarUsuario', N'Registrar Usuario')
INSERT [dbo].[IdiomaControl] ([ID_IdiomaControl], [ID_Idioma], [nombreControl], [Traduccion]) VALUES (10, 2, N'btnRegistrarUsuario', N'Register User')
INSERT [dbo].[IdiomaControl] ([ID_IdiomaControl], [ID_Idioma], [nombreControl], [Traduccion]) VALUES (11, 1, N'baseDeDatosToolStripMenuItem', N'Base de datos')
INSERT [dbo].[IdiomaControl] ([ID_IdiomaControl], [ID_Idioma], [nombreControl], [Traduccion]) VALUES (12, 2, N'baseDeDatosToolStripMenuItem', N'DataBase')
INSERT [dbo].[IdiomaControl] ([ID_IdiomaControl], [ID_Idioma], [nombreControl], [Traduccion]) VALUES (13, 1, N'generarBackUpToolStripMenuItem', N'Generar Back Up')
INSERT [dbo].[IdiomaControl] ([ID_IdiomaControl], [ID_Idioma], [nombreControl], [Traduccion]) VALUES (14, 2, N'generarBackUpToolStripMenuItem', N'Generate Back Up')
INSERT [dbo].[IdiomaControl] ([ID_IdiomaControl], [ID_Idioma], [nombreControl], [Traduccion]) VALUES (15, 1, N'generarRestoreToolStripMenuItem', N'Generar Restore')
INSERT [dbo].[IdiomaControl] ([ID_IdiomaControl], [ID_Idioma], [nombreControl], [Traduccion]) VALUES (16, 2, N'generarRestoreToolStripMenuItem', N'Generate Restore')
INSERT [dbo].[IdiomaControl] ([ID_IdiomaControl], [ID_Idioma], [nombreControl], [Traduccion]) VALUES (17, 1, N'lblNombreRegistrarUsuario', N'Nombre')
INSERT [dbo].[IdiomaControl] ([ID_IdiomaControl], [ID_Idioma], [nombreControl], [Traduccion]) VALUES (18, 2, N'lblNombreRegistrarUsuario', N'Name')
INSERT [dbo].[IdiomaControl] ([ID_IdiomaControl], [ID_Idioma], [nombreControl], [Traduccion]) VALUES (19, 1, N'lblApellidoRegistrarUsuario', N'Apellido')
INSERT [dbo].[IdiomaControl] ([ID_IdiomaControl], [ID_Idioma], [nombreControl], [Traduccion]) VALUES (20, 2, N'lblApellidoRegistrarUsuario', N'Surname')
INSERT [dbo].[IdiomaControl] ([ID_IdiomaControl], [ID_Idioma], [nombreControl], [Traduccion]) VALUES (21, 1, N'lblFechaNacimientoRegistrarUsuario', N'Fecha de nacimiento')
INSERT [dbo].[IdiomaControl] ([ID_IdiomaControl], [ID_Idioma], [nombreControl], [Traduccion]) VALUES (25, 2, N'lblFechaNacimientoRegistrarUsuario', N'birthdate')
INSERT [dbo].[IdiomaControl] ([ID_IdiomaControl], [ID_Idioma], [nombreControl], [Traduccion]) VALUES (26, 1, N'lblDireccionRegistroUsuario', N'Domicilio')
INSERT [dbo].[IdiomaControl] ([ID_IdiomaControl], [ID_Idioma], [nombreControl], [Traduccion]) VALUES (27, 2, N'lblDireccionRegistroUsuario', N'Address')
INSERT [dbo].[IdiomaControl] ([ID_IdiomaControl], [ID_Idioma], [nombreControl], [Traduccion]) VALUES (28, 1, N'btnRegistrarUsuario', N'Registrar')
INSERT [dbo].[IdiomaControl] ([ID_IdiomaControl], [ID_Idioma], [nombreControl], [Traduccion]) VALUES (29, 2, N'btnRegistrarUsuario', N'Register')
INSERT [dbo].[IdiomaControl] ([ID_IdiomaControl], [ID_Idioma], [nombreControl], [Traduccion]) VALUES (30, 1, N'lblLenguajeLogin', N'Idioma')
INSERT [dbo].[IdiomaControl] ([ID_IdiomaControl], [ID_Idioma], [nombreControl], [Traduccion]) VALUES (31, 2, N'lblLenguajeLogin', N'Language')
INSERT [dbo].[IdiomaControl] ([ID_IdiomaControl], [ID_Idioma], [nombreControl], [Traduccion]) VALUES (1030, 1, N'msbContraseñaBlock', N'Contraseña incorrecta. Se ha bloqueado el usuario')
INSERT [dbo].[IdiomaControl] ([ID_IdiomaControl], [ID_Idioma], [nombreControl], [Traduccion]) VALUES (1032, 2, N'msbContraseñaBlock', N'Wrong Password. The user has been blocked')
INSERT [dbo].[IdiomaControl] ([ID_IdiomaControl], [ID_Idioma], [nombreControl], [Traduccion]) VALUES (1033, 1, N'msbContraseñaIncorrecta', N'Contraseña incorrecta. Intentos restantes: ')
INSERT [dbo].[IdiomaControl] ([ID_IdiomaControl], [ID_Idioma], [nombreControl], [Traduccion]) VALUES (1034, 2, N'msbContraseñaIncorrecta', N'Wrong password. Attemps left: ')
INSERT [dbo].[IdiomaControl] ([ID_IdiomaControl], [ID_Idioma], [nombreControl], [Traduccion]) VALUES (1037, 1, N'msbUsuarioInexistente', N'Usuario inexistente')
INSERT [dbo].[IdiomaControl] ([ID_IdiomaControl], [ID_Idioma], [nombreControl], [Traduccion]) VALUES (1038, 2, N'msbUsuarioInexistente', N'The user does not exist')
INSERT [dbo].[IdiomaControl] ([ID_IdiomaControl], [ID_Idioma], [nombreControl], [Traduccion]) VALUES (1039, 1, N'lblFechaDesdeBitacora', N'Fecha desde')
INSERT [dbo].[IdiomaControl] ([ID_IdiomaControl], [ID_Idioma], [nombreControl], [Traduccion]) VALUES (1040, 2, N'lblFechaDesdeBitacora', N'Date from')
INSERT [dbo].[IdiomaControl] ([ID_IdiomaControl], [ID_Idioma], [nombreControl], [Traduccion]) VALUES (1042, 1, N'lblFechaHastaBitacora', N'Fecha hasta')
INSERT [dbo].[IdiomaControl] ([ID_IdiomaControl], [ID_Idioma], [nombreControl], [Traduccion]) VALUES (1043, 2, N'lblFechaHastaBitacora', N'Date to')
INSERT [dbo].[IdiomaControl] ([ID_IdiomaControl], [ID_Idioma], [nombreControl], [Traduccion]) VALUES (1044, 1, N'btnListarBitacora', N'Listar')
INSERT [dbo].[IdiomaControl] ([ID_IdiomaControl], [ID_Idioma], [nombreControl], [Traduccion]) VALUES (1045, 2, N'btnListarBitacora', N'Get list')
INSERT [dbo].[IdiomaControl] ([ID_IdiomaControl], [ID_Idioma], [nombreControl], [Traduccion]) VALUES (1046, 1, N'lblUsernameBitacora', N'Usuario')
INSERT [dbo].[IdiomaControl] ([ID_IdiomaControl], [ID_Idioma], [nombreControl], [Traduccion]) VALUES (1047, 2, N'lblUsernameBitacora', N'Username')
INSERT [dbo].[IdiomaControl] ([ID_IdiomaControl], [ID_Idioma], [nombreControl], [Traduccion]) VALUES (1048, 1, N'lblCriticidadBitacora', N'Criticidad')
INSERT [dbo].[IdiomaControl] ([ID_IdiomaControl], [ID_Idioma], [nombreControl], [Traduccion]) VALUES (1049, 2, N'lblCriticidadBitacora', N'Criticity')
SET IDENTITY_INSERT [dbo].[IdiomaControl] OFF
GO
SET IDENTITY_INSERT [dbo].[Usuario] ON 

INSERT [dbo].[Usuario] ([IDUsuario], [Nombre], [Apellido], [DNI], [Username], [Contraseña], [Email], [FechaNacimiento], [IntentosIngreso], [Bloqueado], [Direccion]) VALUES (1004, N'Julian', N'Perez Demonty', N'42679056', N'?®Ññáõ´z5èß2¤', N'16ab235a97496c5d7b73959fe99d3b3e5c6fa262ee7c0f31c4e0f14f29f742c4', N'jperezdemonty@live.com.ar', CAST(N'2021-04-03' AS Date), 3, 0, N'|-Ì!3Xhþµ¯K:ýb˜©êÓ')
INSERT [dbo].[Usuario] ([IDUsuario], [Nombre], [Apellido], [DNI], [Username], [Contraseña], [Email], [FechaNacimiento], [IntentosIngreso], [Bloqueado], [Direccion]) VALUES (1005, N'tomi', N'loquita', N'34823426', N'cÇw‹u''xÍäÆr30ç', N'7c17e1e71b16e61e724ef8845e20ad3e5955d2b0cf7ed4a6b935cc1fae01511a', N'tjuarez.tm@gmail.com', CAST(N'2021-04-10' AS Date), 3, 0, N'w€C&‚I6ÜI‹ŸOe')
SET IDENTITY_INSERT [dbo].[Usuario] OFF
GO
/****** Object:  StoredProcedure [dbo].[BloquearUsuario]    Script Date: 24/05/2021 1:09:47 ******/
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
/****** Object:  StoredProcedure [dbo].[BuscarTexto]    Script Date: 24/05/2021 1:09:47 ******/
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
/****** Object:  StoredProcedure [dbo].[CrearUsuario]    Script Date: 24/05/2021 1:09:47 ******/
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
values(@Nombre,@Apellido,@Dni,@Username,@Contraseña,@Email,@FechaNacimiento,3,0,@Direccion)
end
GO
/****** Object:  StoredProcedure [dbo].[IniciarSesion]    Script Date: 24/05/2021 1:09:47 ******/
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
/****** Object:  StoredProcedure [dbo].[ListarBitacora]    Script Date: 24/05/2021 1:09:47 ******/
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
set @idUsuario = (select IDUsuario from Usuario where Username=@usuario)

select Accion,bitacora.Descripcion,Fecha,Criticidad.Descripcion as Criticidad , Usuario.Username 
from Bitacora
inner join Usuario on Bitacora.IDUsuario = Usuario.IDUsuario
inner join Criticidad on Bitacora.idCriticidad = Criticidad.IDCriticidad
where 
((CONVERT(date,Fecha,103) >= @fechaDesde ) or (@fechaDesde is null )) and
((CONVERT(date,Fecha,103) <= @fechaHasta ) or (@fechaHasta is null )) and
((Bitacora.idCriticidad=@idCriticidad) or (@criticidad is null)) and
((Bitacora.IDUsuario=@idUsuario) or (@idUsuario is null))
order by Fecha desc
end
GO
/****** Object:  StoredProcedure [dbo].[ListarIdiomas]    Script Date: 24/05/2021 1:09:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create   procedure [dbo].[ListarIdiomas]
as begin
select * from Idioma
end
GO
/****** Object:  StoredProcedure [dbo].[MostrarIntentoLog]    Script Date: 24/05/2021 1:09:47 ******/
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
/****** Object:  StoredProcedure [dbo].[ReestablecerInicioSesion]    Script Date: 24/05/2021 1:09:47 ******/
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
/****** Object:  StoredProcedure [dbo].[RegistrarBitacora]    Script Date: 24/05/2021 1:09:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE   PROCEDURE [dbo].[RegistrarBitacora]
@Accion nvarchar(100), @Descripcion nvarchar(max),
@Criticidad nvarchar(30), @usuario nvarchar(100)
as begin
declare @idusuario int, @idCriticidad int
set @idusuario=(select IDUsuario from Usuario where Username=@usuario)
set @idCriticidad = (select IDCriticidad from Criticidad where Descripcion = @Criticidad)

insert into Bitacora 
(Accion,
Descripcion,
Fecha,
IDUsuario,
idCriticidad,
DVH)

values (
@Accion,
@Descripcion,
GETDATE(),
@idusuario,
@idCriticidad,
0)

end
GO
/****** Object:  StoredProcedure [dbo].[SumarIntentoDeLog]    Script Date: 24/05/2021 1:09:47 ******/
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
/****** Object:  StoredProcedure [dbo].[VerificarUsuario]    Script Date: 24/05/2021 1:09:47 ******/
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
