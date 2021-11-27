USE [master]
GO
/****** Object:  Database [DIPLOMA]    Script Date: 27/11/2021 19:36:38 ******/
CREATE DATABASE [DIPLOMA]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'DIPLOMA', FILENAME = N'C:\Users\Juli\AppData\Roaming\DIPLOMA\DIPLOMA.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'DIPLOMA_log', FILENAME = N'C:\Users\Juli\AppData\Roaming\DIPLOMA\DIPLOMA_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [DIPLOMA] SET COMPATIBILITY_LEVEL = 130
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
ALTER DATABASE [DIPLOMA] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [DIPLOMA] SET AUTO_SHRINK ON 
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
ALTER DATABASE [DIPLOMA] SET RECOVERY SIMPLE 
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
ALTER DATABASE [DIPLOMA] SET QUERY_STORE = OFF
GO
USE [DIPLOMA]
GO
ALTER DATABASE SCOPED CONFIGURATION SET LEGACY_CARDINALITY_ESTIMATION = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION SET MAXDOP = 0;
GO
ALTER DATABASE SCOPED CONFIGURATION SET PARAMETER_SNIFFING = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION SET QUERY_OPTIMIZER_HOTFIXES = OFF;
GO
USE [DIPLOMA]
GO
/****** Object:  Table [dbo].[Alumno]    Script Date: 27/11/2021 19:36:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Alumno](
	[ID_Alumno] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [nvarchar](50) NOT NULL,
	[Apellido] [nvarchar](50) NOT NULL,
	[Email] [nvarchar](50) NOT NULL,
	[DNI] [nvarchar](50) NOT NULL,
	[Activo] [bit] NOT NULL,
 CONSTRAINT [PK_Alumno] PRIMARY KEY CLUSTERED 
(
	[ID_Alumno] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Bitacora]    Script Date: 27/11/2021 19:36:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Bitacora](
	[ID_Bitacora] [int] IDENTITY(1,1) NOT NULL,
	[Accion] [nvarchar](100) NOT NULL,
	[Descripcion] [nvarchar](max) NOT NULL,
	[Fecha] [datetime] NOT NULL,
	[Username] [nvarchar](max) NOT NULL,
	[idCriticidad] [int] NOT NULL,
	[DVH] [int] NOT NULL,
 CONSTRAINT [PK_Bitacora] PRIMARY KEY CLUSTERED 
(
	[ID_Bitacora] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Compuesto]    Script Date: 27/11/2021 19:36:38 ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Criticidad]    Script Date: 27/11/2021 19:36:38 ******/
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
/****** Object:  Table [dbo].[Curso]    Script Date: 27/11/2021 19:36:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Curso](
	[ID_Curso] [int] IDENTITY(1,1) NOT NULL,
	[AñoFecha] [int] NOT NULL,
	[AñoSecundaria] [int] NOT NULL,
	[Cupo] [int] NOT NULL,
	[Turno] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Curso] PRIMARY KEY CLUSTERED 
(
	[ID_Curso] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CursoAlumno]    Script Date: 27/11/2021 19:36:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CursoAlumno](
	[ID_CursoAlumno] [int] IDENTITY(1,1) NOT NULL,
	[ID_Alumno] [int] NOT NULL,
	[ID_Curso] [int] NOT NULL,
 CONSTRAINT [PK_CursoAlumno] PRIMARY KEY CLUSTERED 
(
	[ID_CursoAlumno] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CursoMateria]    Script Date: 27/11/2021 19:36:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CursoMateria](
	[ID_CursoMateria] [int] IDENTITY(1,1) NOT NULL,
	[ID_Curso] [int] NOT NULL,
	[ID_Materia] [int] NOT NULL,
 CONSTRAINT [PK_CursoMateria] PRIMARY KEY CLUSTERED 
(
	[ID_CursoMateria] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DVV]    Script Date: 27/11/2021 19:36:38 ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Idioma]    Script Date: 27/11/2021 19:36:38 ******/
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
/****** Object:  Table [dbo].[IdiomaControl]    Script Date: 27/11/2021 19:36:38 ******/
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
/****** Object:  Table [dbo].[Materia]    Script Date: 27/11/2021 19:36:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Materia](
	[ID_Materia] [int] IDENTITY(1,1) NOT NULL,
	[Año] [int] NOT NULL,
	[Descripcion] [nvarchar](50) NOT NULL,
	[Dia] [nvarchar](50) NOT NULL,
	[HoraInicio] [int] NOT NULL,
	[HoraFin] [int] NOT NULL,
	[ID_Profesor] [int] NULL,
 CONSTRAINT [PK_Materia] PRIMARY KEY CLUSTERED 
(
	[ID_Materia] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Nota]    Script Date: 27/11/2021 19:36:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Nota](
	[ID_Nota] [int] IDENTITY(1,1) NOT NULL,
	[ID_Materia] [int] NOT NULL,
	[ID_Alumno] [int] NOT NULL,
	[Nota] [decimal](5, 2) NOT NULL,
	[Previa] [bit] NOT NULL,
	[Trimestre] [int] NULL,
 CONSTRAINT [PK_Nota] PRIMARY KEY CLUSTERED 
(
	[ID_Nota] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Permiso]    Script Date: 27/11/2021 19:36:38 ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Profesor]    Script Date: 27/11/2021 19:36:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Profesor](
	[ID_Profesor] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [nvarchar](50) NOT NULL,
	[Apellido] [nvarchar](50) NOT NULL,
	[Email] [nvarchar](50) NOT NULL,
	[DNI] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Profesor] PRIMARY KEY CLUSTERED 
(
	[ID_Profesor] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Promedios]    Script Date: 27/11/2021 19:36:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Promedios](
	[ID_PromedioMAteria] [int] IDENTITY(1,1) NOT NULL,
	[ID_Materia] [int] NOT NULL,
	[ID_Alumno] [int] NOT NULL,
	[Promedio] [decimal](5, 2) NOT NULL,
 CONSTRAINT [PK_Promedios] PRIMARY KEY CLUSTERED 
(
	[ID_PromedioMAteria] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Usuario]    Script Date: 27/11/2021 19:36:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Usuario](
	[ID_Usuario] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [nvarchar](100) NOT NULL,
	[Apellido] [nvarchar](100) NOT NULL,
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UsuarioCambios]    Script Date: 27/11/2021 19:36:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UsuarioCambios](
	[ID_UsuarioCambios] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [nvarchar](50) NOT NULL,
	[Apellido] [nvarchar](50) NOT NULL,
	[DNI] [nvarchar](50) NOT NULL,
	[Email] [nvarchar](50) NOT NULL,
	[FechaNacimiento] [date] NOT NULL,
	[Direccion] [nvarchar](max) NOT NULL,
	[ID_Modificador] [int] NOT NULL,
	[Fecha] [datetime] NOT NULL,
	[ID_Usuario] [int] NOT NULL,
 CONSTRAINT [PK_UsuarioCambios] PRIMARY KEY CLUSTERED 
(
	[ID_UsuarioCambios] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UsuarioPermiso]    Script Date: 27/11/2021 19:36:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UsuarioPermiso](
	[ID_UsuarioPermiso] [int] IDENTITY(1,1) NOT NULL,
	[ID_Usuario] [int] NOT NULL,
	[ID_Permiso] [int] NOT NULL,
	[DVH] [bigint] NULL,
 CONSTRAINT [PK_UsuarioPermiso] PRIMARY KEY CLUSTERED 
(
	[ID_UsuarioPermiso] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Alumno] ON 

INSERT [dbo].[Alumno] ([ID_Alumno], [Nombre], [Apellido], [Email], [DNI], [Activo]) VALUES (9, N'matias', N'perez', N'fsdfasdfasdfa', N'3423423', 1)
SET IDENTITY_INSERT [dbo].[Alumno] OFF
GO
SET IDENTITY_INSERT [dbo].[Bitacora] ON 

INSERT [dbo].[Bitacora] ([ID_Bitacora], [Accion], [Descripcion], [Fecha], [Username], [idCriticidad], [DVH]) VALUES (1, N'Inicio de sesión', N'33E63C7C813C9C883509F85670C7F20447104BA355AC2804765F2FC683CC2F6FC8E12B92196D239F', CAST(N'2021-11-26T14:57:36.190' AS DateTime), N'8F95C6D1DFA80209', 3, 219252)
INSERT [dbo].[Bitacora] ([ID_Bitacora], [Accion], [Descripcion], [Fecha], [Username], [idCriticidad], [DVH]) VALUES (2, N'Inicio de sesión', N'33E63C7C813C9C883509F85670C7F20447104BA355AC2804765F2FC683CC2F6FC8E12B92196D239F', CAST(N'2021-11-26T15:19:06.720' AS DateTime), N'8F95C6D1DFA80209', 3, 219184)
INSERT [dbo].[Bitacora] ([ID_Bitacora], [Accion], [Descripcion], [Fecha], [Username], [idCriticidad], [DVH]) VALUES (3, N'Inicio de sesión', N'33E63C7C813C9C883509F85670C7F20447104BA355AC2804765F2FC683CC2F6FC8E12B92196D239F', CAST(N'2021-11-26T15:19:12.700' AS DateTime), N'8F95C6D1DFA80209', 3, 219127)
INSERT [dbo].[Bitacora] ([ID_Bitacora], [Accion], [Descripcion], [Fecha], [Username], [idCriticidad], [DVH]) VALUES (4, N'Eliminacion de usuario', N'D46629C5A62BC92B2B2892ADC930431F69004F74700B74F8E1C1EBEF7AB25779', CAST(N'2021-11-26T15:19:16.317' AS DateTime), N'8F95C6D1DFA80209', 1, 163270)
INSERT [dbo].[Bitacora] ([ID_Bitacora], [Accion], [Descripcion], [Fecha], [Username], [idCriticidad], [DVH]) VALUES (5, N'Restore', N'258643BFE135AE2516F33A07A230CF234C790C837E6013E80747221478AC1ADFDEB4D5DE5E198A1A6A9802CC23557857', CAST(N'2021-11-26T22:24:19.370' AS DateTime), N'26EEBE8E4E9196F2', 1, 288049)
INSERT [dbo].[Bitacora] ([ID_Bitacora], [Accion], [Descripcion], [Fecha], [Username], [idCriticidad], [DVH]) VALUES (6, N'Inicio de sesión', N'33E63C7C813C9C883509F85670C7F20447104BA355AC2804765F2FC683CC2F6FC8E12B92196D239F', CAST(N'2021-11-26T22:24:34.993' AS DateTime), N'8F95C6D1DFA80209', 3, 219112)
INSERT [dbo].[Bitacora] ([ID_Bitacora], [Accion], [Descripcion], [Fecha], [Username], [idCriticidad], [DVH]) VALUES (7, N'Inicio de sesión', N'33E63C7C813C9C883509F85670C7F20447104BA355AC2804765F2FC683CC2F6FC8E12B92196D239F', CAST(N'2021-11-26T22:26:42.817' AS DateTime), N'8F95C6D1DFA80209', 3, 219125)
INSERT [dbo].[Bitacora] ([ID_Bitacora], [Accion], [Descripcion], [Fecha], [Username], [idCriticidad], [DVH]) VALUES (8, N'Restore', N'258643BFE135AE2516F33A07A230CF234C790C837E6013E80747221478AC1ADFDEB4D5DE5E198A1A6A9802CC23557857', CAST(N'2021-11-26T22:29:12.250' AS DateTime), N'26EEBE8E4E9196F2', 1, 287999)
INSERT [dbo].[Bitacora] ([ID_Bitacora], [Accion], [Descripcion], [Fecha], [Username], [idCriticidad], [DVH]) VALUES (9, N'Inicio de sesión', N'33E63C7C813C9C883509F85670C7F20447104BA355AC2804765F2FC683CC2F6FC8E12B92196D239F', CAST(N'2021-11-26T22:29:38.110' AS DateTime), N'8F95C6D1DFA80209', 3, 219271)
INSERT [dbo].[Bitacora] ([ID_Bitacora], [Accion], [Descripcion], [Fecha], [Username], [idCriticidad], [DVH]) VALUES (10, N'Inicio de sesión', N'33E63C7C813C9C883509F85670C7F20447104BA355AC2804765F2FC683CC2F6FC8E12B92196D239F', CAST(N'2021-11-26T22:38:04.227' AS DateTime), N'8F95C6D1DFA80209', 3, 219228)
INSERT [dbo].[Bitacora] ([ID_Bitacora], [Accion], [Descripcion], [Fecha], [Username], [idCriticidad], [DVH]) VALUES (11, N'Inicio de sesión', N'33E63C7C813C9C883509F85670C7F20447104BA355AC2804765F2FC683CC2F6FC8E12B92196D239F', CAST(N'2021-11-26T22:38:10.107' AS DateTime), N'8F95C6D1DFA80209', 3, 219172)
INSERT [dbo].[Bitacora] ([ID_Bitacora], [Accion], [Descripcion], [Fecha], [Username], [idCriticidad], [DVH]) VALUES (12, N'Inicio de sesión', N'33E63C7C813C9C883509F85670C7F20447104BA355AC2804765F2FC683CC2F6FC8E12B92196D239F', CAST(N'2021-11-26T22:39:37.920' AS DateTime), N'8F95C6D1DFA80209', 3, 219359)
INSERT [dbo].[Bitacora] ([ID_Bitacora], [Accion], [Descripcion], [Fecha], [Username], [idCriticidad], [DVH]) VALUES (13, N'Nueva traduccion', N'3294206958FAA230016F21DA0309DB455FD148531D53E5151AED67EA3410BAB50C2688B30623474335FC59408C42635E0A40FAE0ED7A1F6E', CAST(N'2021-11-26T22:39:58.090' AS DateTime), N'8F95C6D1DFA80209', 2, 393974)
INSERT [dbo].[Bitacora] ([ID_Bitacora], [Accion], [Descripcion], [Fecha], [Username], [idCriticidad], [DVH]) VALUES (14, N'Inicio de sesión', N'33E63C7C813C9C883509F85670C7F20447104BA355AC2804765F2FC683CC2F6FC8E12B92196D239F', CAST(N'2021-11-26T22:41:38.937' AS DateTime), N'8F95C6D1DFA80209', 3, 219269)
INSERT [dbo].[Bitacora] ([ID_Bitacora], [Accion], [Descripcion], [Fecha], [Username], [idCriticidad], [DVH]) VALUES (15, N'Inicio de sesión', N'33E63C7C813C9C883509F85670C7F20447104BA355AC2804765F2FC683CC2F6FC8E12B92196D239F', CAST(N'2021-11-26T22:41:47.697' AS DateTime), N'8F95C6D1DFA80209', 3, 219270)
INSERT [dbo].[Bitacora] ([ID_Bitacora], [Accion], [Descripcion], [Fecha], [Username], [idCriticidad], [DVH]) VALUES (16, N'Nueva traduccion', N'3294206958FAA230016F21DA0309DB455FD148531D53E515B36E69FE1F88ED7DC80D94E4273C82FC37F3C395969817D288A3DC07A842D71D488DD7DA9162D419', CAST(N'2021-11-26T22:42:00.877' AS DateTime), N'8F95C6D1DFA80209', 2, 508629)
INSERT [dbo].[Bitacora] ([ID_Bitacora], [Accion], [Descripcion], [Fecha], [Username], [idCriticidad], [DVH]) VALUES (17, N'Nueva traduccion', N'3294206958FAA230016F21DA0309DB455FD148531D53E5156A2BE04298595FD0A3884D7914A625E11DC1801975FCB2E8E789B38CE5F89BF651ABBD2C74477C83', CAST(N'2021-11-26T22:42:20.157' AS DateTime), N'8F95C6D1DFA80209', 2, 509928)
INSERT [dbo].[Bitacora] ([ID_Bitacora], [Accion], [Descripcion], [Fecha], [Username], [idCriticidad], [DVH]) VALUES (18, N'Nueva traduccion', N'3294206958FAA230016F21DA0309DB455FD148531D53E5150493D68AD1F486459467DEB79D25D29C908AE4B9387A429B', CAST(N'2021-11-26T22:42:44.403' AS DateTime), N'8F95C6D1DFA80209', 2, 298812)
INSERT [dbo].[Bitacora] ([ID_Bitacora], [Accion], [Descripcion], [Fecha], [Username], [idCriticidad], [DVH]) VALUES (19, N'Inicio de sesión', N'33E63C7C813C9C883509F85670C7F20447104BA355AC2804765F2FC683CC2F6FC8E12B92196D239F', CAST(N'2021-11-27T16:48:38.103' AS DateTime), N'8F95C6D1DFA80209', 3, 219433)
SET IDENTITY_INSERT [dbo].[Bitacora] OFF
GO
SET IDENTITY_INSERT [dbo].[Compuesto] ON 

INSERT [dbo].[Compuesto] ([ID_Compuesto], [ID_Permiso], [ID_Familia], [DVH]) VALUES (2, 20, 5, N'249')
INSERT [dbo].[Compuesto] ([ID_Compuesto], [ID_Permiso], [ID_Familia], [DVH]) VALUES (3, 21, 5, N'252')
INSERT [dbo].[Compuesto] ([ID_Compuesto], [ID_Permiso], [ID_Familia], [DVH]) VALUES (4, 19, 5, N'268')
INSERT [dbo].[Compuesto] ([ID_Compuesto], [ID_Permiso], [ID_Familia], [DVH]) VALUES (5, 18, 5, N'267')
INSERT [dbo].[Compuesto] ([ID_Compuesto], [ID_Permiso], [ID_Familia], [DVH]) VALUES (6, 22, 5, N'257')
INSERT [dbo].[Compuesto] ([ID_Compuesto], [ID_Permiso], [ID_Familia], [DVH]) VALUES (7, 23, 5, N'260')
INSERT [dbo].[Compuesto] ([ID_Compuesto], [ID_Permiso], [ID_Familia], [DVH]) VALUES (8, 24, 5, N'263')
INSERT [dbo].[Compuesto] ([ID_Compuesto], [ID_Permiso], [ID_Familia], [DVH]) VALUES (9, 25, 5, N'266')
INSERT [dbo].[Compuesto] ([ID_Compuesto], [ID_Permiso], [ID_Familia], [DVH]) VALUES (10, 27, 5, N'358')
INSERT [dbo].[Compuesto] ([ID_Compuesto], [ID_Permiso], [ID_Familia], [DVH]) VALUES (11, 26, 5, N'358')
INSERT [dbo].[Compuesto] ([ID_Compuesto], [ID_Permiso], [ID_Familia], [DVH]) VALUES (12, 28, 5, N'364')
SET IDENTITY_INSERT [dbo].[Compuesto] OFF
GO
SET IDENTITY_INSERT [dbo].[Criticidad] ON 

INSERT [dbo].[Criticidad] ([IDCriticidad], [Descripcion]) VALUES (1, N'Alta')
INSERT [dbo].[Criticidad] ([IDCriticidad], [Descripcion]) VALUES (2, N'Media')
INSERT [dbo].[Criticidad] ([IDCriticidad], [Descripcion]) VALUES (3, N'Baja')
SET IDENTITY_INSERT [dbo].[Criticidad] OFF
GO
SET IDENTITY_INSERT [dbo].[Curso] ON 

INSERT [dbo].[Curso] ([ID_Curso], [AñoFecha], [AñoSecundaria], [Cupo], [Turno]) VALUES (1, 2021, 1, 30, N'Mañana')
INSERT [dbo].[Curso] ([ID_Curso], [AñoFecha], [AñoSecundaria], [Cupo], [Turno]) VALUES (2, 2021, 1, 30, N'Tarde')
INSERT [dbo].[Curso] ([ID_Curso], [AñoFecha], [AñoSecundaria], [Cupo], [Turno]) VALUES (3, 2021, 2, 39, N'Mañana')
INSERT [dbo].[Curso] ([ID_Curso], [AñoFecha], [AñoSecundaria], [Cupo], [Turno]) VALUES (4, 2021, 2, 30, N'Tarde')
INSERT [dbo].[Curso] ([ID_Curso], [AñoFecha], [AñoSecundaria], [Cupo], [Turno]) VALUES (5, 2021, 3, 35, N'Mañana')
INSERT [dbo].[Curso] ([ID_Curso], [AñoFecha], [AñoSecundaria], [Cupo], [Turno]) VALUES (6, 2021, 3, 35, N'Tarde')
INSERT [dbo].[Curso] ([ID_Curso], [AñoFecha], [AñoSecundaria], [Cupo], [Turno]) VALUES (7, 2021, 4, 25, N'Mañana')
INSERT [dbo].[Curso] ([ID_Curso], [AñoFecha], [AñoSecundaria], [Cupo], [Turno]) VALUES (8, 2021, 4, 25, N'Tarde')
INSERT [dbo].[Curso] ([ID_Curso], [AñoFecha], [AñoSecundaria], [Cupo], [Turno]) VALUES (9, 2021, 5, 20, N'Mañana')
INSERT [dbo].[Curso] ([ID_Curso], [AñoFecha], [AñoSecundaria], [Cupo], [Turno]) VALUES (10, 2021, 5, 20, N'Tarde')
INSERT [dbo].[Curso] ([ID_Curso], [AñoFecha], [AñoSecundaria], [Cupo], [Turno]) VALUES (11, 2021, 6, 20, N'Mañana')
INSERT [dbo].[Curso] ([ID_Curso], [AñoFecha], [AñoSecundaria], [Cupo], [Turno]) VALUES (12, 2021, 6, 20, N'Tarde')
SET IDENTITY_INSERT [dbo].[Curso] OFF
GO
SET IDENTITY_INSERT [dbo].[CursoAlumno] ON 

INSERT [dbo].[CursoAlumno] ([ID_CursoAlumno], [ID_Alumno], [ID_Curso]) VALUES (6, 9, 3)
SET IDENTITY_INSERT [dbo].[CursoAlumno] OFF
GO
SET IDENTITY_INSERT [dbo].[CursoMateria] ON 

INSERT [dbo].[CursoMateria] ([ID_CursoMateria], [ID_Curso], [ID_Materia]) VALUES (1, 1, 1)
INSERT [dbo].[CursoMateria] ([ID_CursoMateria], [ID_Curso], [ID_Materia]) VALUES (2, 1, 2)
INSERT [dbo].[CursoMateria] ([ID_CursoMateria], [ID_Curso], [ID_Materia]) VALUES (3, 1, 3)
INSERT [dbo].[CursoMateria] ([ID_CursoMateria], [ID_Curso], [ID_Materia]) VALUES (4, 1, 4)
INSERT [dbo].[CursoMateria] ([ID_CursoMateria], [ID_Curso], [ID_Materia]) VALUES (5, 2, 1)
INSERT [dbo].[CursoMateria] ([ID_CursoMateria], [ID_Curso], [ID_Materia]) VALUES (6, 1, 1004)
INSERT [dbo].[CursoMateria] ([ID_CursoMateria], [ID_Curso], [ID_Materia]) VALUES (7, 3, 3)
INSERT [dbo].[CursoMateria] ([ID_CursoMateria], [ID_Curso], [ID_Materia]) VALUES (1002, 3, 2004)
INSERT [dbo].[CursoMateria] ([ID_CursoMateria], [ID_Curso], [ID_Materia]) VALUES (1003, 3, 2005)
SET IDENTITY_INSERT [dbo].[CursoMateria] OFF
GO
SET IDENTITY_INSERT [dbo].[DVV] ON 

INSERT [dbo].[DVV] ([ID_DVV], [Tabla], [DVV]) VALUES (8, N'66948D9D1850B9DF', 518604)
INSERT [dbo].[DVV] ([ID_DVV], [Tabla], [DVV]) VALUES (9, N'5D0E1D6FC783A53B9CF8946D06083E8C', 5081463)
INSERT [dbo].[DVV] ([ID_DVV], [Tabla], [DVV]) VALUES (13, N'51D81CD833F3742A', 955783)
INSERT [dbo].[DVV] ([ID_DVV], [Tabla], [DVV]) VALUES (15, N'8171DFC3FD5A18E214C44D7BB898B882', 10494)
INSERT [dbo].[DVV] ([ID_DVV], [Tabla], [DVV]) VALUES (16, N'5ADE549CA8F2E4087FD2C3315EAEFF64', 3162)
SET IDENTITY_INSERT [dbo].[DVV] OFF
GO
SET IDENTITY_INSERT [dbo].[Idioma] ON 

INSERT [dbo].[Idioma] ([ID_Idioma], [Idioma]) VALUES (1, N'Español')
INSERT [dbo].[Idioma] ([ID_Idioma], [Idioma]) VALUES (2, N'English')
INSERT [dbo].[Idioma] ([ID_Idioma], [Idioma]) VALUES (1001, N'French')
INSERT [dbo].[Idioma] ([ID_Idioma], [Idioma]) VALUES (1003, N'Latin')
SET IDENTITY_INSERT [dbo].[Idioma] OFF
GO
SET IDENTITY_INSERT [dbo].[IdiomaControl] ON 

INSERT [dbo].[IdiomaControl] ([ID_IdiomaControl], [ID_Idioma], [nombreControl], [Traduccion]) VALUES (2038, 1, N'asignarPermisosToolStripMenuItem', N'Asignar Permisos')
INSERT [dbo].[IdiomaControl] ([ID_IdiomaControl], [ID_Idioma], [nombreControl], [Traduccion]) VALUES (2039, 1, N'baseDeDatosToolStripMenuItem', N'Base de datos')
INSERT [dbo].[IdiomaControl] ([ID_IdiomaControl], [ID_Idioma], [nombreControl], [Traduccion]) VALUES (2040, 1, N'btnCerrarSesion', N'Cerrar Sesion')
INSERT [dbo].[IdiomaControl] ([ID_IdiomaControl], [ID_Idioma], [nombreControl], [Traduccion]) VALUES (2041, 1, N'btnCrearFamilia', N'Crear Familia')
INSERT [dbo].[IdiomaControl] ([ID_IdiomaControl], [ID_Idioma], [nombreControl], [Traduccion]) VALUES (2042, 1, N'btnEliminarFamilia', N'eliminar familia')
INSERT [dbo].[IdiomaControl] ([ID_IdiomaControl], [ID_Idioma], [nombreControl], [Traduccion]) VALUES (2043, 1, N'btnIngresar', N'Ingresar')
INSERT [dbo].[IdiomaControl] ([ID_IdiomaControl], [ID_Idioma], [nombreControl], [Traduccion]) VALUES (2044, 1, N'btnListarBitacora', N'Listar')
INSERT [dbo].[IdiomaControl] ([ID_IdiomaControl], [ID_Idioma], [nombreControl], [Traduccion]) VALUES (2045, 1, N'btnListBitacora', N'Listar bitacora')
INSERT [dbo].[IdiomaControl] ([ID_IdiomaControl], [ID_Idioma], [nombreControl], [Traduccion]) VALUES (2047, 1, N'btnGuardarUsuario', N'Guardar usuario')
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
INSERT [dbo].[IdiomaControl] ([ID_IdiomaControl], [ID_Idioma], [nombreControl], [Traduccion]) VALUES (2083, 2, N'asignarPermisosToolStripMenuItem', N'Assign Permissions')
INSERT [dbo].[IdiomaControl] ([ID_IdiomaControl], [ID_Idioma], [nombreControl], [Traduccion]) VALUES (2084, 2, N'baseDeDatosToolStripMenuItem', N'DataBase')
INSERT [dbo].[IdiomaControl] ([ID_IdiomaControl], [ID_Idioma], [nombreControl], [Traduccion]) VALUES (2085, 2, N'btnCerrarSesion', N'Log Out')
INSERT [dbo].[IdiomaControl] ([ID_IdiomaControl], [ID_Idioma], [nombreControl], [Traduccion]) VALUES (2086, 2, N'btnCrearFamilia', N'Create family')
INSERT [dbo].[IdiomaControl] ([ID_IdiomaControl], [ID_Idioma], [nombreControl], [Traduccion]) VALUES (2087, 2, N'btnEliminarFamilia', N'delete family')
INSERT [dbo].[IdiomaControl] ([ID_IdiomaControl], [ID_Idioma], [nombreControl], [Traduccion]) VALUES (2088, 2, N'btnIngresar', N'Log In')
INSERT [dbo].[IdiomaControl] ([ID_IdiomaControl], [ID_Idioma], [nombreControl], [Traduccion]) VALUES (2089, 2, N'btnListarBitacora', N'Get list')
INSERT [dbo].[IdiomaControl] ([ID_IdiomaControl], [ID_Idioma], [nombreControl], [Traduccion]) VALUES (2090, 2, N'btnListBitacora', N'get log')
INSERT [dbo].[IdiomaControl] ([ID_IdiomaControl], [ID_Idioma], [nombreControl], [Traduccion]) VALUES (2092, 2, N'btnGuardarUsuario', N'Save user')
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
INSERT [dbo].[IdiomaControl] ([ID_IdiomaControl], [ID_Idioma], [nombreControl], [Traduccion]) VALUES (2127, 1, N'mensajeRestoreExitoso', N'Restore exitoso')
INSERT [dbo].[IdiomaControl] ([ID_IdiomaControl], [ID_Idioma], [nombreControl], [Traduccion]) VALUES (2128, 2, N'mensajeRestoreExitoso', N'Restore successful')
INSERT [dbo].[IdiomaControl] ([ID_IdiomaControl], [ID_Idioma], [nombreControl], [Traduccion]) VALUES (2129, 1, N'lblSaludoUsername', N'Hola')
INSERT [dbo].[IdiomaControl] ([ID_IdiomaControl], [ID_Idioma], [nombreControl], [Traduccion]) VALUES (2130, 2, N'lblSaludoUsername', N'Hello')
INSERT [dbo].[IdiomaControl] ([ID_IdiomaControl], [ID_Idioma], [nombreControl], [Traduccion]) VALUES (2131, 1, N'editarPerfilToolStripMenuItem', N'Editar perfil')
INSERT [dbo].[IdiomaControl] ([ID_IdiomaControl], [ID_Idioma], [nombreControl], [Traduccion]) VALUES (2132, 2, N'editarPerfilToolStripMenuItem', N'Edit profile')
INSERT [dbo].[IdiomaControl] ([ID_IdiomaControl], [ID_Idioma], [nombreControl], [Traduccion]) VALUES (2133, 1, N'btnRegistrarUsuario', N'Registrar usuario')
INSERT [dbo].[IdiomaControl] ([ID_IdiomaControl], [ID_Idioma], [nombreControl], [Traduccion]) VALUES (2134, 2, N'btnRegistrarUsuario', N'Register user')
INSERT [dbo].[IdiomaControl] ([ID_IdiomaControl], [ID_Idioma], [nombreControl], [Traduccion]) VALUES (2135, 1, N'msbUsuarioModificado', N'Usuario modificado con exito')
INSERT [dbo].[IdiomaControl] ([ID_IdiomaControl], [ID_Idioma], [nombreControl], [Traduccion]) VALUES (2136, 2, N'msbUsuarioModificado', N'User modificated successfully')
INSERT [dbo].[IdiomaControl] ([ID_IdiomaControl], [ID_Idioma], [nombreControl], [Traduccion]) VALUES (2137, 1, N'restaurarInformacionToolStripMenuItem', N'Restaurar perfil')
INSERT [dbo].[IdiomaControl] ([ID_IdiomaControl], [ID_Idioma], [nombreControl], [Traduccion]) VALUES (2138, 2, N'restaurarInformacionToolStripMenuItem', N'Restore profile')
INSERT [dbo].[IdiomaControl] ([ID_IdiomaControl], [ID_Idioma], [nombreControl], [Traduccion]) VALUES (2139, 1, N'btnRestaurarInfoUsuario', N'Restaurar informacion')
GO
INSERT [dbo].[IdiomaControl] ([ID_IdiomaControl], [ID_Idioma], [nombreControl], [Traduccion]) VALUES (2140, 2, N'btnRestaurarInfoUsuario', N'Restore information')
INSERT [dbo].[IdiomaControl] ([ID_IdiomaControl], [ID_Idioma], [nombreControl], [Traduccion]) VALUES (2141, 1, N'msbReestaurarInfoUsuario', N'Usuario restaurado exitosamente')
INSERT [dbo].[IdiomaControl] ([ID_IdiomaControl], [ID_Idioma], [nombreControl], [Traduccion]) VALUES (2142, 2, N'msbReestaurarInfoUsuario', N'User restored successfully')
INSERT [dbo].[IdiomaControl] ([ID_IdiomaControl], [ID_Idioma], [nombreControl], [Traduccion]) VALUES (2143, 1, N'msbReestaurarInfoUsuarioSeleccionar', N'Debe seleccionar un elemento')
INSERT [dbo].[IdiomaControl] ([ID_IdiomaControl], [ID_Idioma], [nombreControl], [Traduccion]) VALUES (2144, 2, N'msbReestaurarInfoUsuarioSeleccionar', N'You have to select an element')
INSERT [dbo].[IdiomaControl] ([ID_IdiomaControl], [ID_Idioma], [nombreControl], [Traduccion]) VALUES (2145, 1, N'mensajeEstaSeleccionadaFamilia', N'Está seleccionada una familia')
INSERT [dbo].[IdiomaControl] ([ID_IdiomaControl], [ID_Idioma], [nombreControl], [Traduccion]) VALUES (2146, 2, N'mensajeEstaSeleccionadaFamilia', N'A family is selected')
INSERT [dbo].[IdiomaControl] ([ID_IdiomaControl], [ID_Idioma], [nombreControl], [Traduccion]) VALUES (2147, 1, N'mensajeDebeSeleccionarUsuarioOPatente', N'Debe seleccionar un usuario o una patente')
INSERT [dbo].[IdiomaControl] ([ID_IdiomaControl], [ID_Idioma], [nombreControl], [Traduccion]) VALUES (2148, 2, N'mensajeDebeSeleccionarUsuarioOPatente', N'You must select an user or a patent')
INSERT [dbo].[IdiomaControl] ([ID_IdiomaControl], [ID_Idioma], [nombreControl], [Traduccion]) VALUES (2152, 1, N'lblPatentesDeLaFamilia', N'Patentes de la familia')
INSERT [dbo].[IdiomaControl] ([ID_IdiomaControl], [ID_Idioma], [nombreControl], [Traduccion]) VALUES (2153, 2, N'lblPatentesDeLaFamilia', N'Patentes de la familia')
INSERT [dbo].[IdiomaControl] ([ID_IdiomaControl], [ID_Idioma], [nombreControl], [Traduccion]) VALUES (2154, 1, N'lblPatentesSinOtorgar', N'Patentes sin otorgar')
INSERT [dbo].[IdiomaControl] ([ID_IdiomaControl], [ID_Idioma], [nombreControl], [Traduccion]) VALUES (2155, 2, N'lblPatentesSinOtorgar', N'Permissions w/o assignment')
INSERT [dbo].[IdiomaControl] ([ID_IdiomaControl], [ID_Idioma], [nombreControl], [Traduccion]) VALUES (2156, 1, N'mensajeSeleccionarFamiliaOPatente', N'Debe seleccionar una familia o patente')
INSERT [dbo].[IdiomaControl] ([ID_IdiomaControl], [ID_Idioma], [nombreControl], [Traduccion]) VALUES (2157, 2, N'mensajeSeleccionarFamiliaOPatente', N'You must select a family or a patent')
INSERT [dbo].[IdiomaControl] ([ID_IdiomaControl], [ID_Idioma], [nombreControl], [Traduccion]) VALUES (2158, 1, N'mensajeFamiliaYaExiste', N'La familia ingresada ya existe')
INSERT [dbo].[IdiomaControl] ([ID_IdiomaControl], [ID_Idioma], [nombreControl], [Traduccion]) VALUES (2159, 2, N'mensajeFamiliaYaExiste', N'The family already exists')
INSERT [dbo].[IdiomaControl] ([ID_IdiomaControl], [ID_Idioma], [nombreControl], [Traduccion]) VALUES (2160, 1, N'mensajePermisoInsuficiente', N'No posee el permiso suficiente')
INSERT [dbo].[IdiomaControl] ([ID_IdiomaControl], [ID_Idioma], [nombreControl], [Traduccion]) VALUES (2161, 2, N'mensajePermisoInsuficiente', N'You do not possess enough permissions')
INSERT [dbo].[IdiomaControl] ([ID_IdiomaControl], [ID_Idioma], [nombreControl], [Traduccion]) VALUES (2162, 1, N'mensajeFamiliaEliminada', N'Familia eliminada')
INSERT [dbo].[IdiomaControl] ([ID_IdiomaControl], [ID_Idioma], [nombreControl], [Traduccion]) VALUES (2163, 2, N'mensajeFamiliaEliminada', N'The family has been deleted')
INSERT [dbo].[IdiomaControl] ([ID_IdiomaControl], [ID_Idioma], [nombreControl], [Traduccion]) VALUES (2164, 1, N'mensajeNoSePuedeEliminarFamilia', N'No se puede eliminar la familia')
INSERT [dbo].[IdiomaControl] ([ID_IdiomaControl], [ID_Idioma], [nombreControl], [Traduccion]) VALUES (2165, 2, N'mensajeNoSePuedeEliminarFamilia', N'The family cannot be deleted')
INSERT [dbo].[IdiomaControl] ([ID_IdiomaControl], [ID_Idioma], [nombreControl], [Traduccion]) VALUES (2168, 1, N'mensajeNoExisteFamilia', N'No existe la familia ingresada')
INSERT [dbo].[IdiomaControl] ([ID_IdiomaControl], [ID_Idioma], [nombreControl], [Traduccion]) VALUES (2169, 2, N'mensajeNoExisteFamilia', N'The family does not exist')
INSERT [dbo].[IdiomaControl] ([ID_IdiomaControl], [ID_Idioma], [nombreControl], [Traduccion]) VALUES (2170, 1, N'mensajeFamiliaCreada', N'Familia creada exitosamente')
INSERT [dbo].[IdiomaControl] ([ID_IdiomaControl], [ID_Idioma], [nombreControl], [Traduccion]) VALUES (2171, 2, N'mensajeFamiliaCreada', N'Family created successfully')
INSERT [dbo].[IdiomaControl] ([ID_IdiomaControl], [ID_Idioma], [nombreControl], [Traduccion]) VALUES (2172, 1, N'msbMenorDeEdad', N'No se permite menor de edad')
INSERT [dbo].[IdiomaControl] ([ID_IdiomaControl], [ID_Idioma], [nombreControl], [Traduccion]) VALUES (2173, 2, N'msbMenorDeEdad', N'Minors are not allowed')
INSERT [dbo].[IdiomaControl] ([ID_IdiomaControl], [ID_Idioma], [nombreControl], [Traduccion]) VALUES (2174, 1, N'msbDireccionVacio', N'Formato de direccion incorrecto')
INSERT [dbo].[IdiomaControl] ([ID_IdiomaControl], [ID_Idioma], [nombreControl], [Traduccion]) VALUES (2175, 2, N'msbDireccionVacio', N'Wrong address format')
INSERT [dbo].[IdiomaControl] ([ID_IdiomaControl], [ID_Idioma], [nombreControl], [Traduccion]) VALUES (2176, 1, N'msbEmailVacio', N'Formato de Email incorrecto')
INSERT [dbo].[IdiomaControl] ([ID_IdiomaControl], [ID_Idioma], [nombreControl], [Traduccion]) VALUES (2177, 2, N'msbEmailVacio', N'Wrong Email format')
INSERT [dbo].[IdiomaControl] ([ID_IdiomaControl], [ID_Idioma], [nombreControl], [Traduccion]) VALUES (2178, 1, N'msbDNIVacio', N'Formato de DNI incorrecto')
INSERT [dbo].[IdiomaControl] ([ID_IdiomaControl], [ID_Idioma], [nombreControl], [Traduccion]) VALUES (2179, 2, N'msbDNIVacio', N'Wrong DNI format')
INSERT [dbo].[IdiomaControl] ([ID_IdiomaControl], [ID_Idioma], [nombreControl], [Traduccion]) VALUES (2180, 1, N'msbApellidoVacio', N'Formato de apellido incorrecto')
INSERT [dbo].[IdiomaControl] ([ID_IdiomaControl], [ID_Idioma], [nombreControl], [Traduccion]) VALUES (2181, 2, N'msbApellidoVacio', N'Wrong lastname format')
INSERT [dbo].[IdiomaControl] ([ID_IdiomaControl], [ID_Idioma], [nombreControl], [Traduccion]) VALUES (2182, 1, N'msbNombreVacio', N'Formato de nombre incorrecto')
INSERT [dbo].[IdiomaControl] ([ID_IdiomaControl], [ID_Idioma], [nombreControl], [Traduccion]) VALUES (2183, 2, N'msbNombreVacio', N'Wrong name format')
INSERT [dbo].[IdiomaControl] ([ID_IdiomaControl], [ID_Idioma], [nombreControl], [Traduccion]) VALUES (2186, 1, N'lblNombreRegistrarProfesor', N'Nombre')
INSERT [dbo].[IdiomaControl] ([ID_IdiomaControl], [ID_Idioma], [nombreControl], [Traduccion]) VALUES (2187, 2, N'lblNombreRegistrarProfesor', N'Firstname')
INSERT [dbo].[IdiomaControl] ([ID_IdiomaControl], [ID_Idioma], [nombreControl], [Traduccion]) VALUES (2188, 1, N'lblApellidoRegistrarProfesor', N'Apellido')
INSERT [dbo].[IdiomaControl] ([ID_IdiomaControl], [ID_Idioma], [nombreControl], [Traduccion]) VALUES (2189, 2, N'lblApellidoRegistrarProfesor', N'Lastname')
INSERT [dbo].[IdiomaControl] ([ID_IdiomaControl], [ID_Idioma], [nombreControl], [Traduccion]) VALUES (2191, 1, N'lblSueldoProfesor', N'Sueldo por materia')
INSERT [dbo].[IdiomaControl] ([ID_IdiomaControl], [ID_Idioma], [nombreControl], [Traduccion]) VALUES (2192, 2, N'lblSueldoProfesor', N'salary per subject')
INSERT [dbo].[IdiomaControl] ([ID_IdiomaControl], [ID_Idioma], [nombreControl], [Traduccion]) VALUES (2193, 1, N'msbSueldoVacio', N'Formato de apellido incorrecto')
INSERT [dbo].[IdiomaControl] ([ID_IdiomaControl], [ID_Idioma], [nombreControl], [Traduccion]) VALUES (2194, 2, N'msbSueldoVacio', N'Wrong salary format')
INSERT [dbo].[IdiomaControl] ([ID_IdiomaControl], [ID_Idioma], [nombreControl], [Traduccion]) VALUES (2195, 1, N'btnGuardarProfesor', N'Guardar Profesor')
INSERT [dbo].[IdiomaControl] ([ID_IdiomaControl], [ID_Idioma], [nombreControl], [Traduccion]) VALUES (2196, 2, N'btnGuardarProfesor', N'Save teacher')
INSERT [dbo].[IdiomaControl] ([ID_IdiomaControl], [ID_Idioma], [nombreControl], [Traduccion]) VALUES (2197, 1, N'btnRegistrarProfesor', N'Registrar profesor')
INSERT [dbo].[IdiomaControl] ([ID_IdiomaControl], [ID_Idioma], [nombreControl], [Traduccion]) VALUES (2198, 2, N'btnRegistrarProfesor', N'Register teacher')
INSERT [dbo].[IdiomaControl] ([ID_IdiomaControl], [ID_Idioma], [nombreControl], [Traduccion]) VALUES (2199, 1, N'lblMateriasSinAsignar', N'Materias sin asignar')
INSERT [dbo].[IdiomaControl] ([ID_IdiomaControl], [ID_Idioma], [nombreControl], [Traduccion]) VALUES (2200, 2, N'lblMateriasSinAsignar', N'Not assigned subjetcs')
INSERT [dbo].[IdiomaControl] ([ID_IdiomaControl], [ID_Idioma], [nombreControl], [Traduccion]) VALUES (2201, 1, N'lblMateriasAsignadas', N'materias asignadas')
INSERT [dbo].[IdiomaControl] ([ID_IdiomaControl], [ID_Idioma], [nombreControl], [Traduccion]) VALUES (2202, 2, N'lblMateriasAsignadas', N'assgned subjects')
INSERT [dbo].[IdiomaControl] ([ID_IdiomaControl], [ID_Idioma], [nombreControl], [Traduccion]) VALUES (2203, 1, N'msbHorarioProfesorOcupado', N'Tiene otra materia que ocupa ese horario')
INSERT [dbo].[IdiomaControl] ([ID_IdiomaControl], [ID_Idioma], [nombreControl], [Traduccion]) VALUES (2204, 2, N'msbHorarioProfesorOcupado', N'Has another subject that occupies that schedule')
INSERT [dbo].[IdiomaControl] ([ID_IdiomaControl], [ID_Idioma], [nombreControl], [Traduccion]) VALUES (2205, 1, N'msbMateriasNoAsignadas', N'No hay materias asignadas')
INSERT [dbo].[IdiomaControl] ([ID_IdiomaControl], [ID_Idioma], [nombreControl], [Traduccion]) VALUES (2206, 2, N'msbMateriasNoAsignadas', N'Not subjects assigned')
INSERT [dbo].[IdiomaControl] ([ID_IdiomaControl], [ID_Idioma], [nombreControl], [Traduccion]) VALUES (2207, 1, N'btnConfirmarProfesor', N'Confirmar')
INSERT [dbo].[IdiomaControl] ([ID_IdiomaControl], [ID_Idioma], [nombreControl], [Traduccion]) VALUES (2208, 2, N'btnConfirmarProfesor', N'Confirm')
INSERT [dbo].[IdiomaControl] ([ID_IdiomaControl], [ID_Idioma], [nombreControl], [Traduccion]) VALUES (2209, 1, N'msbProfesorAgregado', N'Profesor registrado correctamente')
INSERT [dbo].[IdiomaControl] ([ID_IdiomaControl], [ID_Idioma], [nombreControl], [Traduccion]) VALUES (2210, 2, N'msbProfesorAgregado', N'Teacher added successfully')
INSERT [dbo].[IdiomaControl] ([ID_IdiomaControl], [ID_Idioma], [nombreControl], [Traduccion]) VALUES (3205, 1, N'msbMaximoMateriasProfesor', N'El profesor alcanzo el maximo de materias')
INSERT [dbo].[IdiomaControl] ([ID_IdiomaControl], [ID_Idioma], [nombreControl], [Traduccion]) VALUES (3207, 2, N'msbMaximoMateriasProfesor', N'The teacher reached the maximum number of subjects')
INSERT [dbo].[IdiomaControl] ([ID_IdiomaControl], [ID_Idioma], [nombreControl], [Traduccion]) VALUES (3208, 1, N'msbCrearCursoExito', N'Cursos creado exitosamente')
INSERT [dbo].[IdiomaControl] ([ID_IdiomaControl], [ID_Idioma], [nombreControl], [Traduccion]) VALUES (3209, 2, N'msbCrearCursoExito', N'Courses created successfully')
INSERT [dbo].[IdiomaControl] ([ID_IdiomaControl], [ID_Idioma], [nombreControl], [Traduccion]) VALUES (3210, 1, N'msbCrearCursoPronto', N'Aun no pueden crearse cursos nuevos ya que los cursos actuales siguen vigentes')
INSERT [dbo].[IdiomaControl] ([ID_IdiomaControl], [ID_Idioma], [nombreControl], [Traduccion]) VALUES (3211, 2, N'msbCrearCursoPronto', N'New courses cannot yet be created as current courses are still valid')
INSERT [dbo].[IdiomaControl] ([ID_IdiomaControl], [ID_Idioma], [nombreControl], [Traduccion]) VALUES (3212, 1, N'btnCrearCursoPorAño', N'Crear cursos por año')
INSERT [dbo].[IdiomaControl] ([ID_IdiomaControl], [ID_Idioma], [nombreControl], [Traduccion]) VALUES (3213, 2, N'btnCrearCursoPorAño', N'Create courses per year')
INSERT [dbo].[IdiomaControl] ([ID_IdiomaControl], [ID_Idioma], [nombreControl], [Traduccion]) VALUES (4205, 1, N'lblNombreMateria', N'Nombre materia')
INSERT [dbo].[IdiomaControl] ([ID_IdiomaControl], [ID_Idioma], [nombreControl], [Traduccion]) VALUES (4206, 2, N'lblNombreMateria', N'Subject name')
INSERT [dbo].[IdiomaControl] ([ID_IdiomaControl], [ID_Idioma], [nombreControl], [Traduccion]) VALUES (4209, 1, N'lblDiaMateria', N'Dia materia')
INSERT [dbo].[IdiomaControl] ([ID_IdiomaControl], [ID_Idioma], [nombreControl], [Traduccion]) VALUES (4210, 2, N'lblDiaMateria', N'Subject day')
INSERT [dbo].[IdiomaControl] ([ID_IdiomaControl], [ID_Idioma], [nombreControl], [Traduccion]) VALUES (4211, 1, N'lblHoraInicioMateria', N'Hora de inicio')
INSERT [dbo].[IdiomaControl] ([ID_IdiomaControl], [ID_Idioma], [nombreControl], [Traduccion]) VALUES (4212, 2, N'lblHoraInicioMateria', N'Start hour')
INSERT [dbo].[IdiomaControl] ([ID_IdiomaControl], [ID_Idioma], [nombreControl], [Traduccion]) VALUES (4215, 1, N'btnSaveMateria', N'Guardar materia')
INSERT [dbo].[IdiomaControl] ([ID_IdiomaControl], [ID_Idioma], [nombreControl], [Traduccion]) VALUES (4216, 2, N'btnSaveMateria', N'Save Subject')
INSERT [dbo].[IdiomaControl] ([ID_IdiomaControl], [ID_Idioma], [nombreControl], [Traduccion]) VALUES (4217, 1, N'btnRegistrarMaterias', N'Registrar materias')
INSERT [dbo].[IdiomaControl] ([ID_IdiomaControl], [ID_Idioma], [nombreControl], [Traduccion]) VALUES (4218, 2, N'btnRegistrarMaterias', N'Register subjects')
INSERT [dbo].[IdiomaControl] ([ID_IdiomaControl], [ID_Idioma], [nombreControl], [Traduccion]) VALUES (4219, 1, N'msbNombreMateriaError', N'Formato de nombre incorrecto')
INSERT [dbo].[IdiomaControl] ([ID_IdiomaControl], [ID_Idioma], [nombreControl], [Traduccion]) VALUES (4220, 2, N'msbNombreMateriaError', N'Wrong name format')
INSERT [dbo].[IdiomaControl] ([ID_IdiomaControl], [ID_Idioma], [nombreControl], [Traduccion]) VALUES (4221, 1, N'msbHoraInicioIncorrecta', N'Formato de hora incorrecto')
INSERT [dbo].[IdiomaControl] ([ID_IdiomaControl], [ID_Idioma], [nombreControl], [Traduccion]) VALUES (4222, 2, N'msbHoraInicioIncorrecta', N'Wrong hour format')
INSERT [dbo].[IdiomaControl] ([ID_IdiomaControl], [ID_Idioma], [nombreControl], [Traduccion]) VALUES (4223, 1, N'msbHoraFueraDeTurno', N'El horario seleccionado esta fuera del turno')
INSERT [dbo].[IdiomaControl] ([ID_IdiomaControl], [ID_Idioma], [nombreControl], [Traduccion]) VALUES (4224, 2, N'msbHoraFueraDeTurno', N'The selected schedule is out of shift')
INSERT [dbo].[IdiomaControl] ([ID_IdiomaControl], [ID_Idioma], [nombreControl], [Traduccion]) VALUES (4225, 1, N'msbMateriaCreada', N'Materia creada correctamente')
INSERT [dbo].[IdiomaControl] ([ID_IdiomaControl], [ID_Idioma], [nombreControl], [Traduccion]) VALUES (4226, 2, N'msbMateriaCreada', N'Subject created successfully')
INSERT [dbo].[IdiomaControl] ([ID_IdiomaControl], [ID_Idioma], [nombreControl], [Traduccion]) VALUES (4227, 1, N'msbMateriaHorarioOcupado', N'No puede crearse la materia porque ocupa el horario de otra')
INSERT [dbo].[IdiomaControl] ([ID_IdiomaControl], [ID_Idioma], [nombreControl], [Traduccion]) VALUES (4229, 2, N'msbMateriaHorarioOcupado', N'The subject cannot be created because it occupies the schedule of another')
INSERT [dbo].[IdiomaControl] ([ID_IdiomaControl], [ID_Idioma], [nombreControl], [Traduccion]) VALUES (4230, 1, N'btnGuardarAlumno', N'Guardar Alumno')
INSERT [dbo].[IdiomaControl] ([ID_IdiomaControl], [ID_Idioma], [nombreControl], [Traduccion]) VALUES (4231, 2, N'btnGuardarAlumno', N'Save student')
INSERT [dbo].[IdiomaControl] ([ID_IdiomaControl], [ID_Idioma], [nombreControl], [Traduccion]) VALUES (4232, 1, N'btnRegistrarAlumno', N'Registrar Alumno')
INSERT [dbo].[IdiomaControl] ([ID_IdiomaControl], [ID_Idioma], [nombreControl], [Traduccion]) VALUES (4233, 2, N'btnRegistrarAlumno', N'Register student')
INSERT [dbo].[IdiomaControl] ([ID_IdiomaControl], [ID_Idioma], [nombreControl], [Traduccion]) VALUES (4234, 1, N'lblAñoCursoNuevoAlumno', N'Indique el año')
INSERT [dbo].[IdiomaControl] ([ID_IdiomaControl], [ID_Idioma], [nombreControl], [Traduccion]) VALUES (4235, 2, N'lblAñoCursoNuevoAlumno', N'Select the grade')
INSERT [dbo].[IdiomaControl] ([ID_IdiomaControl], [ID_Idioma], [nombreControl], [Traduccion]) VALUES (4236, 1, N'msbCuposVacios', N'No contamos con cupos para los años seleccionados')
INSERT [dbo].[IdiomaControl] ([ID_IdiomaControl], [ID_Idioma], [nombreControl], [Traduccion]) VALUES (4237, 2, N'msbCuposVacios', N'We do not have quotas for the selected grades')
INSERT [dbo].[IdiomaControl] ([ID_IdiomaControl], [ID_Idioma], [nombreControl], [Traduccion]) VALUES (4238, 1, N'lblSubject', N'Materias')
GO
INSERT [dbo].[IdiomaControl] ([ID_IdiomaControl], [ID_Idioma], [nombreControl], [Traduccion]) VALUES (4239, 2, N'lblSubject', N'Subjects')
INSERT [dbo].[IdiomaControl] ([ID_IdiomaControl], [ID_Idioma], [nombreControl], [Traduccion]) VALUES (4240, 1, N'lblNotaNumerica', N'Nota')
INSERT [dbo].[IdiomaControl] ([ID_IdiomaControl], [ID_Idioma], [nombreControl], [Traduccion]) VALUES (4241, 2, N'lblNotaNumerica', N'Score')
INSERT [dbo].[IdiomaControl] ([ID_IdiomaControl], [ID_Idioma], [nombreControl], [Traduccion]) VALUES (4242, 1, N'btnSaveNota', N'Guardar')
INSERT [dbo].[IdiomaControl] ([ID_IdiomaControl], [ID_Idioma], [nombreControl], [Traduccion]) VALUES (4243, 2, N'btnSaveNota', N'Save')
INSERT [dbo].[IdiomaControl] ([ID_IdiomaControl], [ID_Idioma], [nombreControl], [Traduccion]) VALUES (4244, 1, N'lblNotasAsignadas', N'Notas asignadas')
INSERT [dbo].[IdiomaControl] ([ID_IdiomaControl], [ID_Idioma], [nombreControl], [Traduccion]) VALUES (4245, 2, N'lblNotasAsignadas', N'Assigned scores')
INSERT [dbo].[IdiomaControl] ([ID_IdiomaControl], [ID_Idioma], [nombreControl], [Traduccion]) VALUES (4246, 1, N'msbFormatoNotaInvalido', N'Nota invalida')
INSERT [dbo].[IdiomaControl] ([ID_IdiomaControl], [ID_Idioma], [nombreControl], [Traduccion]) VALUES (4247, 2, N'msbFormatoNotaInvalido', N'Invalid score')
INSERT [dbo].[IdiomaControl] ([ID_IdiomaControl], [ID_Idioma], [nombreControl], [Traduccion]) VALUES (4248, 1, N'msbDemasiadasPrevias', N'No se puede registrar un alumno con mas de 2 materias previas')
INSERT [dbo].[IdiomaControl] ([ID_IdiomaControl], [ID_Idioma], [nombreControl], [Traduccion]) VALUES (4249, 2, N'msbDemasiadasPrevias', N'You cannot register a student with more than 2 previous subjects')
INSERT [dbo].[IdiomaControl] ([ID_IdiomaControl], [ID_Idioma], [nombreControl], [Traduccion]) VALUES (4250, 1, N'btnFinalizarRegistroAlumno', N'Finalizar')
INSERT [dbo].[IdiomaControl] ([ID_IdiomaControl], [ID_Idioma], [nombreControl], [Traduccion]) VALUES (4251, 2, N'btnFinalizarRegistroAlumno', N'Finish')
INSERT [dbo].[IdiomaControl] ([ID_IdiomaControl], [ID_Idioma], [nombreControl], [Traduccion]) VALUES (4252, 1, N'msbFaltanCalificarMaterias', N'Hay materias pendientes sin calificar')
INSERT [dbo].[IdiomaControl] ([ID_IdiomaControl], [ID_Idioma], [nombreControl], [Traduccion]) VALUES (4253, 2, N'msbFaltanCalificarMaterias', N'There are pending subjects without grading')
INSERT [dbo].[IdiomaControl] ([ID_IdiomaControl], [ID_Idioma], [nombreControl], [Traduccion]) VALUES (4254, 1, N'msbAlumnoRegistrado', N'Alumno registrado correctamente')
INSERT [dbo].[IdiomaControl] ([ID_IdiomaControl], [ID_Idioma], [nombreControl], [Traduccion]) VALUES (4255, 2, N'msbAlumnoRegistrado', N'Student registered successfully')
INSERT [dbo].[IdiomaControl] ([ID_IdiomaControl], [ID_Idioma], [nombreControl], [Traduccion]) VALUES (4256, 1, N'msbAlumnoReactivado', N'El alumno ha sido reactivado y actualizado sus notas y cursos')
INSERT [dbo].[IdiomaControl] ([ID_IdiomaControl], [ID_Idioma], [nombreControl], [Traduccion]) VALUES (4257, 2, N'msbAlumnoReactivado', N'The student has been reactivated and his grades and courses have been updated')
INSERT [dbo].[IdiomaControl] ([ID_IdiomaControl], [ID_Idioma], [nombreControl], [Traduccion]) VALUES (4258, 1, N'msbUsuarioActivo', N'Ya existe un alumno activo con los datos indicados')
INSERT [dbo].[IdiomaControl] ([ID_IdiomaControl], [ID_Idioma], [nombreControl], [Traduccion]) VALUES (4259, 2, N'msbUsuarioActivo', N'There is already an active student with the indicated data')
INSERT [dbo].[IdiomaControl] ([ID_IdiomaControl], [ID_Idioma], [nombreControl], [Traduccion]) VALUES (5205, 1, N'lblTraduccion', N'Traduccion')
INSERT [dbo].[IdiomaControl] ([ID_IdiomaControl], [ID_Idioma], [nombreControl], [Traduccion]) VALUES (5206, 1, N'btnGuardarTraduccion', N'Guardar')
INSERT [dbo].[IdiomaControl] ([ID_IdiomaControl], [ID_Idioma], [nombreControl], [Traduccion]) VALUES (5207, 1, N'msbTraduccionVacia', N'Debe ingresar una traduccion')
INSERT [dbo].[IdiomaControl] ([ID_IdiomaControl], [ID_Idioma], [nombreControl], [Traduccion]) VALUES (5208, 1, N'msbTraduccionExitosa', N'Traduccion guardada exitosamente')
INSERT [dbo].[IdiomaControl] ([ID_IdiomaControl], [ID_Idioma], [nombreControl], [Traduccion]) VALUES (5209, 1, N'msbIdiomaControlVacio', N'Debe seleccionar un elemento')
INSERT [dbo].[IdiomaControl] ([ID_IdiomaControl], [ID_Idioma], [nombreControl], [Traduccion]) VALUES (5211, 2, N'btnGuardarTraduccion', N'Save')
INSERT [dbo].[IdiomaControl] ([ID_IdiomaControl], [ID_Idioma], [nombreControl], [Traduccion]) VALUES (5213, 2, N'lblTraduccion', N'Traduction')
INSERT [dbo].[IdiomaControl] ([ID_IdiomaControl], [ID_Idioma], [nombreControl], [Traduccion]) VALUES (5214, 1, N'btnGuardarNuevoIdioma', N'Guardar')
INSERT [dbo].[IdiomaControl] ([ID_IdiomaControl], [ID_Idioma], [nombreControl], [Traduccion]) VALUES (5215, 1, N'msbNuevoIdiomaVacio', N'Debe indicar el nuevo idioma')
INSERT [dbo].[IdiomaControl] ([ID_IdiomaControl], [ID_Idioma], [nombreControl], [Traduccion]) VALUES (5216, 1, N'msbNuevoIdiomaExitoso', N'Se ha guardado el nuevo idioma')
INSERT [dbo].[IdiomaControl] ([ID_IdiomaControl], [ID_Idioma], [nombreControl], [Traduccion]) VALUES (5217, 1, N'msbNuevoIdiomaOcupado', N'Ya contamos con el idioma indicado')
INSERT [dbo].[IdiomaControl] ([ID_IdiomaControl], [ID_Idioma], [nombreControl], [Traduccion]) VALUES (5218, 1, N'lblNuevoIdioma', N'Nuevo idioma')
INSERT [dbo].[IdiomaControl] ([ID_IdiomaControl], [ID_Idioma], [nombreControl], [Traduccion]) VALUES (5219, 1, N'idiomaToolStripMenuItem', N'Idioma')
INSERT [dbo].[IdiomaControl] ([ID_IdiomaControl], [ID_Idioma], [nombreControl], [Traduccion]) VALUES (5220, 1, N'nuevoIdiomaToolStripMenuItem', N'Nuevo idioma')
INSERT [dbo].[IdiomaControl] ([ID_IdiomaControl], [ID_Idioma], [nombreControl], [Traduccion]) VALUES (5221, 1, N'completarIdiomaToolStripMenuItem', N'Completar idioma')
INSERT [dbo].[IdiomaControl] ([ID_IdiomaControl], [ID_Idioma], [nombreControl], [Traduccion]) VALUES (5222, 2, N'idiomaToolStripMenuItem', N'Language')
INSERT [dbo].[IdiomaControl] ([ID_IdiomaControl], [ID_Idioma], [nombreControl], [Traduccion]) VALUES (5223, 2, N'completarIdiomaToolStripMenuItem', N'Complete language')
INSERT [dbo].[IdiomaControl] ([ID_IdiomaControl], [ID_Idioma], [nombreControl], [Traduccion]) VALUES (5224, 2, N'btnGuardarNuevoIdioma', N'Save')
INSERT [dbo].[IdiomaControl] ([ID_IdiomaControl], [ID_Idioma], [nombreControl], [Traduccion]) VALUES (5225, 1001, N'btnCerrarSesion', N'serdfsdfa')
INSERT [dbo].[IdiomaControl] ([ID_IdiomaControl], [ID_Idioma], [nombreControl], [Traduccion]) VALUES (5226, 1001, N'btnCerrarSesion', N'serdfsdfa')
INSERT [dbo].[IdiomaControl] ([ID_IdiomaControl], [ID_Idioma], [nombreControl], [Traduccion]) VALUES (5227, 1, N'msbExportacionExito', N'Exportado correctamente')
INSERT [dbo].[IdiomaControl] ([ID_IdiomaControl], [ID_Idioma], [nombreControl], [Traduccion]) VALUES (5228, 1, N'btnBajaAlumno', N'Baja Alumno')
INSERT [dbo].[IdiomaControl] ([ID_IdiomaControl], [ID_Idioma], [nombreControl], [Traduccion]) VALUES (5229, 1, N'btnBuscarAlumnos', N'Buscar alumnos')
INSERT [dbo].[IdiomaControl] ([ID_IdiomaControl], [ID_Idioma], [nombreControl], [Traduccion]) VALUES (5230, 1, N'msbAlumnoEliminado', N'Alumno dado de baja excitosamente')
INSERT [dbo].[IdiomaControl] ([ID_IdiomaControl], [ID_Idioma], [nombreControl], [Traduccion]) VALUES (5231, 1, N'msbSeleccionarAlumnoAEliminar', N'Debe seleccionar un alumno a dar de baja')
INSERT [dbo].[IdiomaControl] ([ID_IdiomaControl], [ID_Idioma], [nombreControl], [Traduccion]) VALUES (5232, 1, N'lblCurso', N'Curso')
INSERT [dbo].[IdiomaControl] ([ID_IdiomaControl], [ID_Idioma], [nombreControl], [Traduccion]) VALUES (5233, 1, N'lblTurno', N'Turno')
INSERT [dbo].[IdiomaControl] ([ID_IdiomaControl], [ID_Idioma], [nombreControl], [Traduccion]) VALUES (5234, 1, N'lblAlumnosRegistrarNota', N'Alumnos')
INSERT [dbo].[IdiomaControl] ([ID_IdiomaControl], [ID_Idioma], [nombreControl], [Traduccion]) VALUES (5235, 1, N'lblMateriaRegistrarNota', N'Materia')
INSERT [dbo].[IdiomaControl] ([ID_IdiomaControl], [ID_Idioma], [nombreControl], [Traduccion]) VALUES (5236, 1, N'lblTrimestre', N'Trimestre')
INSERT [dbo].[IdiomaControl] ([ID_IdiomaControl], [ID_Idioma], [nombreControl], [Traduccion]) VALUES (5237, 1, N'btnRegistrarNota', N'Registrar nota')
INSERT [dbo].[IdiomaControl] ([ID_IdiomaControl], [ID_Idioma], [nombreControl], [Traduccion]) VALUES (5238, 1, N'btnGuardarNotaTrimestral', N'Calificar')
INSERT [dbo].[IdiomaControl] ([ID_IdiomaControl], [ID_Idioma], [nombreControl], [Traduccion]) VALUES (5239, 1, N'msbSeleccioneTrimestre', N'Debe seleccionar un trimestre a calificar')
INSERT [dbo].[IdiomaControl] ([ID_IdiomaControl], [ID_Idioma], [nombreControl], [Traduccion]) VALUES (5240, 1, N'msbNotaYaExistente', N'El alumno ya tiene una calificacion para esa materia en ese trimestre')
INSERT [dbo].[IdiomaControl] ([ID_IdiomaControl], [ID_Idioma], [nombreControl], [Traduccion]) VALUES (5241, 1, N'msbCalificadoTrimestreExito', N'Alumno calificado exitosamente')
INSERT [dbo].[IdiomaControl] ([ID_IdiomaControl], [ID_Idioma], [nombreControl], [Traduccion]) VALUES (5242, 1, N'msbSeleccioneAlumnoYMateria', N'Debe seleccionar un alumno y una materia')
INSERT [dbo].[IdiomaControl] ([ID_IdiomaControl], [ID_Idioma], [nombreControl], [Traduccion]) VALUES (5243, 1, N'msbDesbloqueoExitoso', N'Se ha desbloqueado al usuario exitosamente')
INSERT [dbo].[IdiomaControl] ([ID_IdiomaControl], [ID_Idioma], [nombreControl], [Traduccion]) VALUES (5244, 1, N'msbDesbloqueoSeleccionar', N'Debe seleccionar un usuario a desbloquear')
INSERT [dbo].[IdiomaControl] ([ID_IdiomaControl], [ID_Idioma], [nombreControl], [Traduccion]) VALUES (5246, 1, N'btnDesbloquearUsuario', N'Desbloquear')
INSERT [dbo].[IdiomaControl] ([ID_IdiomaControl], [ID_Idioma], [nombreControl], [Traduccion]) VALUES (5247, 1, N'msbUsuarioOcupado', N'Ya existe un usuario con esa informacion')
INSERT [dbo].[IdiomaControl] ([ID_IdiomaControl], [ID_Idioma], [nombreControl], [Traduccion]) VALUES (5248, 1, N'msbUsuarioEliminado', N'El usuario fue eliminado correctamente')
INSERT [dbo].[IdiomaControl] ([ID_IdiomaControl], [ID_Idioma], [nombreControl], [Traduccion]) VALUES (5249, 1, N'btnEliminarUsuario', N'Eliminar')
INSERT [dbo].[IdiomaControl] ([ID_IdiomaControl], [ID_Idioma], [nombreControl], [Traduccion]) VALUES (5250, 1, N'msbSeleccioneUsuarioEliminar', N'Debe seleccionar un usuario a eliminar')
INSERT [dbo].[IdiomaControl] ([ID_IdiomaControl], [ID_Idioma], [nombreControl], [Traduccion]) VALUES (5251, 2, N'btnBajaAlumno', N'Delete student')
INSERT [dbo].[IdiomaControl] ([ID_IdiomaControl], [ID_Idioma], [nombreControl], [Traduccion]) VALUES (5252, 2, N'nuevoIdiomaToolStripMenuItem', N'New Language')
INSERT [dbo].[IdiomaControl] ([ID_IdiomaControl], [ID_Idioma], [nombreControl], [Traduccion]) VALUES (5253, 1, N'usuariosBloqueadosToolStripMenuItem', N'Usuarios bloqueados')
INSERT [dbo].[IdiomaControl] ([ID_IdiomaControl], [ID_Idioma], [nombreControl], [Traduccion]) VALUES (5254, 1, N'eliminarUsuarioToolStripMenuItem', N'Eliminar usuario')
INSERT [dbo].[IdiomaControl] ([ID_IdiomaControl], [ID_Idioma], [nombreControl], [Traduccion]) VALUES (5255, 2, N'usuariosBloqueadosToolStripMenuItem', N'Blocked users')
INSERT [dbo].[IdiomaControl] ([ID_IdiomaControl], [ID_Idioma], [nombreControl], [Traduccion]) VALUES (5256, 2, N'eliminarUsuarioToolStripMenuItem', N'Deleted users')
INSERT [dbo].[IdiomaControl] ([ID_IdiomaControl], [ID_Idioma], [nombreControl], [Traduccion]) VALUES (5257, 2, N'btnRegistrarNota', N'Register score')
SET IDENTITY_INSERT [dbo].[IdiomaControl] OFF
GO
SET IDENTITY_INSERT [dbo].[Materia] ON 

INSERT [dbo].[Materia] ([ID_Materia], [Año], [Descripcion], [Dia], [HoraInicio], [HoraFin], [ID_Profesor]) VALUES (1, 1, N'Matematica', N'Lunes', 8, 10, 6)
INSERT [dbo].[Materia] ([ID_Materia], [Año], [Descripcion], [Dia], [HoraInicio], [HoraFin], [ID_Profesor]) VALUES (2, 1, N'Lengua', N'Lunes', 10, 12, NULL)
INSERT [dbo].[Materia] ([ID_Materia], [Año], [Descripcion], [Dia], [HoraInicio], [HoraFin], [ID_Profesor]) VALUES (3, 2, N'Fisica', N'Lunes', 9, 11, NULL)
INSERT [dbo].[Materia] ([ID_Materia], [Año], [Descripcion], [Dia], [HoraInicio], [HoraFin], [ID_Profesor]) VALUES (4, 3, N'Biologia', N'Miercoles', 10, 12, NULL)
INSERT [dbo].[Materia] ([ID_Materia], [Año], [Descripcion], [Dia], [HoraInicio], [HoraFin], [ID_Profesor]) VALUES (1004, 4, N'Fisica', N'Viernes', 12, 14, NULL)
INSERT [dbo].[Materia] ([ID_Materia], [Año], [Descripcion], [Dia], [HoraInicio], [HoraFin], [ID_Profesor]) VALUES (2004, 2, N'Geografia', N'Jueves', 8, 10, NULL)
INSERT [dbo].[Materia] ([ID_Materia], [Año], [Descripcion], [Dia], [HoraInicio], [HoraFin], [ID_Profesor]) VALUES (2005, 2, N'masda', N'Lunes', 8, 10, NULL)
SET IDENTITY_INSERT [dbo].[Materia] OFF
GO
SET IDENTITY_INSERT [dbo].[Nota] ON 

INSERT [dbo].[Nota] ([ID_Nota], [ID_Materia], [ID_Alumno], [Nota], [Previa], [Trimestre]) VALUES (9, 1, 9, CAST(10.00 AS Decimal(5, 2)), 0, NULL)
INSERT [dbo].[Nota] ([ID_Nota], [ID_Materia], [ID_Alumno], [Nota], [Previa], [Trimestre]) VALUES (10, 2, 9, CAST(7.00 AS Decimal(5, 2)), 0, NULL)
INSERT [dbo].[Nota] ([ID_Nota], [ID_Materia], [ID_Alumno], [Nota], [Previa], [Trimestre]) VALUES (13, 2004, 9, CAST(10.00 AS Decimal(5, 2)), 0, 1)
INSERT [dbo].[Nota] ([ID_Nota], [ID_Materia], [ID_Alumno], [Nota], [Previa], [Trimestre]) VALUES (14, 2004, 9, CAST(6.00 AS Decimal(5, 2)), 0, 2)
INSERT [dbo].[Nota] ([ID_Nota], [ID_Materia], [ID_Alumno], [Nota], [Previa], [Trimestre]) VALUES (15, 3, 9, CAST(10.00 AS Decimal(5, 2)), 0, 1)
INSERT [dbo].[Nota] ([ID_Nota], [ID_Materia], [ID_Alumno], [Nota], [Previa], [Trimestre]) VALUES (16, 2005, 9, CAST(10.00 AS Decimal(5, 2)), 0, 1)
SET IDENTITY_INSERT [dbo].[Nota] OFF
GO
SET IDENTITY_INSERT [dbo].[Permiso] ON 

INSERT [dbo].[Permiso] ([ID_Permiso], [Permiso], [IsFamilia], [DVH]) VALUES (5, N'440DA03C2E7CBB9CA6799BB9D4A68C5A', 1, N'32929')
INSERT [dbo].[Permiso] ([ID_Permiso], [Permiso], [IsFamilia], [DVH]) VALUES (18, N'D5D217CA0739EF79467325F2C345273D', 0, N'31390')
INSERT [dbo].[Permiso] ([ID_Permiso], [Permiso], [IsFamilia], [DVH]) VALUES (19, N'2A00A1C23D5B0950BF4F1EFBE1EFB6F478E4F99C82AEB4FA', 0, N'73584')
INSERT [dbo].[Permiso] ([ID_Permiso], [Permiso], [IsFamilia], [DVH]) VALUES (20, N'DA52162A2CCD31A2D71080ABC4843569', 0, N'31402')
INSERT [dbo].[Permiso] ([ID_Permiso], [Permiso], [IsFamilia], [DVH]) VALUES (21, N'5B9F2C785FACBEA2215366FB0A3F8020749BFB965EA487AC', 0, N'70679')
INSERT [dbo].[Permiso] ([ID_Permiso], [Permiso], [IsFamilia], [DVH]) VALUES (22, N'ACA2ED2DF50254594D06AAE0CACE8AF46BE125090B25E7C6', 0, N'70323')
INSERT [dbo].[Permiso] ([ID_Permiso], [Permiso], [IsFamilia], [DVH]) VALUES (23, N'DD4DC634743F5FD39D036BE32F5C4E759BBEEEF81EA2B0AE', 0, N'73079')
INSERT [dbo].[Permiso] ([ID_Permiso], [Permiso], [IsFamilia], [DVH]) VALUES (24, N'9803DA9309F1B4B96DC5E6186771A8132563FDC36AD2AB93AC6A965E6EEFAAA7', 0, N'126052')
INSERT [dbo].[Permiso] ([ID_Permiso], [Permiso], [IsFamilia], [DVH]) VALUES (25, N'60DAFD274887964116CAC24A56C467919E3C71D14313A66A', 0, N'68047')
INSERT [dbo].[Permiso] ([ID_Permiso], [Permiso], [IsFamilia], [DVH]) VALUES (26, N'9803DA9309F1B4B96DC5E6186771A813C047FC5DC01B03F4D76C75959CA4830F', 0, N'121553')
INSERT [dbo].[Permiso] ([ID_Permiso], [Permiso], [IsFamilia], [DVH]) VALUES (27, N'BC72987283A8AF84069F3B29F6BA16C1', 0, N'32336')
INSERT [dbo].[Permiso] ([ID_Permiso], [Permiso], [IsFamilia], [DVH]) VALUES (28, N'9803DA9309F1B4B99EF2F43A125771AD7E03B05A6211F4499D431E2DF6CCDB5F', 0, N'123698')
INSERT [dbo].[Permiso] ([ID_Permiso], [Permiso], [IsFamilia], [DVH]) VALUES (31, N'34DF682D70D6C89FB5CF0E088951514A', 1, N'31463')
INSERT [dbo].[Permiso] ([ID_Permiso], [Permiso], [IsFamilia], [DVH]) VALUES (33, N'5B9F2C785FACBEA28BB2A66D2DF3A910C7489127F487243F', 0, N'69248')
SET IDENTITY_INSERT [dbo].[Permiso] OFF
GO
SET IDENTITY_INSERT [dbo].[Profesor] ON 

INSERT [dbo].[Profesor] ([ID_Profesor], [Nombre], [Apellido], [Email], [DNI]) VALUES (3, N'nicalas', N'battaglia', N'2342323', N'asdasdad')
INSERT [dbo].[Profesor] ([ID_Profesor], [Nombre], [Apellido], [Email], [DNI]) VALUES (4, N'dasdasd', N'asdasd', N'2323232', N'sdasdasda')
INSERT [dbo].[Profesor] ([ID_Profesor], [Nombre], [Apellido], [Email], [DNI]) VALUES (5, N'Martina', N'Donadio', N'34343556', N'martinadondaisodsdnflskjdnf')
INSERT [dbo].[Profesor] ([ID_Profesor], [Nombre], [Apellido], [Email], [DNI]) VALUES (6, N'asdasd', N'asdasda', N'3423423', N'dasdasda@live.com')
SET IDENTITY_INSERT [dbo].[Profesor] OFF
GO
SET IDENTITY_INSERT [dbo].[Promedios] ON 

INSERT [dbo].[Promedios] ([ID_PromedioMAteria], [ID_Materia], [ID_Alumno], [Promedio]) VALUES (1, 2004, 9, CAST(8.00 AS Decimal(5, 2)))
INSERT [dbo].[Promedios] ([ID_PromedioMAteria], [ID_Materia], [ID_Alumno], [Promedio]) VALUES (2, 3, 9, CAST(10.00 AS Decimal(5, 2)))
INSERT [dbo].[Promedios] ([ID_PromedioMAteria], [ID_Materia], [ID_Alumno], [Promedio]) VALUES (3, 2005, 9, CAST(10.00 AS Decimal(5, 2)))
SET IDENTITY_INSERT [dbo].[Promedios] OFF
GO
SET IDENTITY_INSERT [dbo].[Usuario] ON 

INSERT [dbo].[Usuario] ([ID_Usuario], [Nombre], [Apellido], [DNI], [Username], [Contraseña], [Email], [FechaNacimiento], [IntentosIngreso], [Bloqueado], [Direccion], [DVH]) VALUES (1021, N'julianexo', N'perez demonty', N'42679056', N'8F95C6D1DFA80209', N'2228fd0cb1d1142cad99e5cfe0d871dd47b913b9cf5ebc7d73f94d0ebf92a62b', N'jperezdemonty@live.com.ar', CAST(N'2000-03-21' AS Date), 3, 0, N'26E3E1FB93F0B7B0C3D7F32BD0AAE6D9', N'255788')
INSERT [dbo].[Usuario] ([ID_Usuario], [Nombre], [Apellido], [DNI], [Username], [Contraseña], [Email], [FechaNacimiento], [IntentosIngreso], [Bloqueado], [Direccion], [DVH]) VALUES (1024, N'martina', N'donadio', N'3423423', N'CDFFA89531C6CB41A2B9D0C895DE7AD0', N'368a8e8328795f7b9c9de58ce869ab5116afa7fa4cc06c2dfce2299aae16405c', N'martinadonadio@gmail.com', CAST(N'2000-01-25' AS Date), 3, 0, N'A82D3ACECEA869060A1743090A0CE608', N'262816')
SET IDENTITY_INSERT [dbo].[Usuario] OFF
GO
SET IDENTITY_INSERT [dbo].[UsuarioCambios] ON 

INSERT [dbo].[UsuarioCambios] ([ID_UsuarioCambios], [Nombre], [Apellido], [DNI], [Email], [FechaNacimiento], [Direccion], [ID_Modificador], [Fecha], [ID_Usuario]) VALUES (1, N'julian', N'perez demonty', N'42679056', N'jperezdemonty@live.com.ar', CAST(N'2021-09-05' AS Date), N'jorge 443', 1021, CAST(N'2021-10-08T00:00:00.000' AS DateTime), 1021)
INSERT [dbo].[UsuarioCambios] ([ID_UsuarioCambios], [Nombre], [Apellido], [DNI], [Email], [FechaNacimiento], [Direccion], [ID_Modificador], [Fecha], [ID_Usuario]) VALUES (2, N'juliandasdasdasd', N'perez demonty', N'42679056', N'jperezdemonty@live.com.ar', CAST(N'2021-09-05' AS Date), N'jorge 443', 1021, CAST(N'2021-10-08T00:00:00.000' AS DateTime), 1021)
INSERT [dbo].[UsuarioCambios] ([ID_UsuarioCambios], [Nombre], [Apellido], [DNI], [Email], [FechaNacimiento], [Direccion], [ID_Modificador], [Fecha], [ID_Usuario]) VALUES (4, N'julian', N'perez demonty', N'42679056', N'jperezdemonty@live.com.ar', CAST(N'2021-09-05' AS Date), N'jorge 443', 1021, CAST(N'2021-10-08T00:00:00.000' AS DateTime), 1021)
INSERT [dbo].[UsuarioCambios] ([ID_UsuarioCambios], [Nombre], [Apellido], [DNI], [Email], [FechaNacimiento], [Direccion], [ID_Modificador], [Fecha], [ID_Usuario]) VALUES (5, N'julian', N'perez demonty', N'42679056', N'jperezdemonty@live.com.ar', CAST(N'2021-09-05' AS Date), N'jorge 443', 1021, CAST(N'2021-10-08T23:20:38.777' AS DateTime), 1021)
INSERT [dbo].[UsuarioCambios] ([ID_UsuarioCambios], [Nombre], [Apellido], [DNI], [Email], [FechaNacimiento], [Direccion], [ID_Modificador], [Fecha], [ID_Usuario]) VALUES (6, N'juliandasdasdasd', N'perez demonty', N'42679056', N'jperezdemonty@live.com.ar', CAST(N'2021-09-05' AS Date), N'jorge 443', 1021, CAST(N'2021-10-08T23:27:02.183' AS DateTime), 1021)
INSERT [dbo].[UsuarioCambios] ([ID_UsuarioCambios], [Nombre], [Apellido], [DNI], [Email], [FechaNacimiento], [Direccion], [ID_Modificador], [Fecha], [ID_Usuario]) VALUES (7, N'juliana', N'xd', N'42679056', N'jperezdemonty@live.com.ar', CAST(N'2000-03-21' AS Date), N'jorge 443', 1021, CAST(N'2021-10-09T00:21:10.173' AS DateTime), 1021)
INSERT [dbo].[UsuarioCambios] ([ID_UsuarioCambios], [Nombre], [Apellido], [DNI], [Email], [FechaNacimiento], [Direccion], [ID_Modificador], [Fecha], [ID_Usuario]) VALUES (8, N'julian', N'perez demonty', N'42679056', N'jperezdemonty@live.com.ar', CAST(N'2021-09-05' AS Date), N'jorge 443', 1021, CAST(N'2021-10-09T00:21:20.610' AS DateTime), 1021)
INSERT [dbo].[UsuarioCambios] ([ID_UsuarioCambios], [Nombre], [Apellido], [DNI], [Email], [FechaNacimiento], [Direccion], [ID_Modificador], [Fecha], [ID_Usuario]) VALUES (9, N'martina', N'perez demonty', N'42679056', N'jperezdemonty@live.com.ar', CAST(N'2021-09-05' AS Date), N'jorge 443', 1021, CAST(N'2021-10-09T15:02:43.423' AS DateTime), 1021)
INSERT [dbo].[UsuarioCambios] ([ID_UsuarioCambios], [Nombre], [Apellido], [DNI], [Email], [FechaNacimiento], [Direccion], [ID_Modificador], [Fecha], [ID_Usuario]) VALUES (10, N'juliana', N'xd', N'42679056', N'jperezdemonty@live.com.ar', CAST(N'2000-03-21' AS Date), N'jorge 443', 1021, CAST(N'2021-10-09T15:03:13.527' AS DateTime), 1021)
INSERT [dbo].[UsuarioCambios] ([ID_UsuarioCambios], [Nombre], [Apellido], [DNI], [Email], [FechaNacimiento], [Direccion], [ID_Modificador], [Fecha], [ID_Usuario]) VALUES (11, N'julian', N'perez demonty', N'42679056', N'jperezdemonty@live.com.ar', CAST(N'2000-03-21' AS Date), N'jorge 443', 1021, CAST(N'2021-10-09T15:03:31.323' AS DateTime), 1021)
INSERT [dbo].[UsuarioCambios] ([ID_UsuarioCambios], [Nombre], [Apellido], [DNI], [Email], [FechaNacimiento], [Direccion], [ID_Modificador], [Fecha], [ID_Usuario]) VALUES (12, N'julian', N'perez demonty', N'42679056', N'jperezdemonty@live.com.ar', CAST(N'2000-03-21' AS Date), N'26E3E1FB93F0B7B0C3D7F32BD0AAE6D9', 1021, CAST(N'2021-11-24T01:00:34.907' AS DateTime), 1021)
INSERT [dbo].[UsuarioCambios] ([ID_UsuarioCambios], [Nombre], [Apellido], [DNI], [Email], [FechaNacimiento], [Direccion], [ID_Modificador], [Fecha], [ID_Usuario]) VALUES (13, N'julianexo', N'perez demonty', N'42679056', N'jperezdemonty@live.com.ar', CAST(N'2000-03-21' AS Date), N'26E3E1FB93F0B7B0C3D7F32BD0AAE6D9', 1021, CAST(N'2021-11-25T00:07:14.447' AS DateTime), 1021)
SET IDENTITY_INSERT [dbo].[UsuarioCambios] OFF
GO
SET IDENTITY_INSERT [dbo].[UsuarioPermiso] ON 

INSERT [dbo].[UsuarioPermiso] ([ID_UsuarioPermiso], [ID_Usuario], [ID_Permiso], [DVH]) VALUES (4, 1021, 5, 596)
INSERT [dbo].[UsuarioPermiso] ([ID_UsuarioPermiso], [ID_Usuario], [ID_Permiso], [DVH]) VALUES (6, 1021, 19, 708)
INSERT [dbo].[UsuarioPermiso] ([ID_UsuarioPermiso], [ID_Usuario], [ID_Permiso], [DVH]) VALUES (7, 1021, 20, 692)
INSERT [dbo].[UsuarioPermiso] ([ID_UsuarioPermiso], [ID_Usuario], [ID_Permiso], [DVH]) VALUES (8, 1021, 21, 695)
INSERT [dbo].[UsuarioPermiso] ([ID_UsuarioPermiso], [ID_Usuario], [ID_Permiso], [DVH]) VALUES (9, 1021, 22, 698)
INSERT [dbo].[UsuarioPermiso] ([ID_UsuarioPermiso], [ID_Usuario], [ID_Permiso], [DVH]) VALUES (10, 1021, 24, 790)
INSERT [dbo].[UsuarioPermiso] ([ID_UsuarioPermiso], [ID_Usuario], [ID_Permiso], [DVH]) VALUES (11, 1021, 23, 790)
INSERT [dbo].[UsuarioPermiso] ([ID_UsuarioPermiso], [ID_Usuario], [ID_Permiso], [DVH]) VALUES (12, 1021, 25, 796)
INSERT [dbo].[UsuarioPermiso] ([ID_UsuarioPermiso], [ID_Usuario], [ID_Permiso], [DVH]) VALUES (13, 1021, 26, 800)
INSERT [dbo].[UsuarioPermiso] ([ID_UsuarioPermiso], [ID_Usuario], [ID_Permiso], [DVH]) VALUES (14, 1021, 27, 804)
INSERT [dbo].[UsuarioPermiso] ([ID_UsuarioPermiso], [ID_Usuario], [ID_Permiso], [DVH]) VALUES (15, 1021, 28, 808)
INSERT [dbo].[UsuarioPermiso] ([ID_UsuarioPermiso], [ID_Usuario], [ID_Permiso], [DVH]) VALUES (19, 1021, 18, 815)
INSERT [dbo].[UsuarioPermiso] ([ID_UsuarioPermiso], [ID_Usuario], [ID_Permiso], [DVH]) VALUES (22, 1021, 33, 794)
INSERT [dbo].[UsuarioPermiso] ([ID_UsuarioPermiso], [ID_Usuario], [ID_Permiso], [DVH]) VALUES (23, 1024, 5, 708)
SET IDENTITY_INSERT [dbo].[UsuarioPermiso] OFF
GO
ALTER TABLE [dbo].[UsuarioCambios] ADD  CONSTRAINT [DF_UsuarioCambios_FechaModificacion]  DEFAULT (getdate()) FOR [Fecha]
GO
ALTER TABLE [dbo].[Bitacora]  WITH CHECK ADD  CONSTRAINT [FK_Bitacora_Criticidad] FOREIGN KEY([idCriticidad])
REFERENCES [dbo].[Criticidad] ([IDCriticidad])
GO
ALTER TABLE [dbo].[Bitacora] CHECK CONSTRAINT [FK_Bitacora_Criticidad]
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
ALTER TABLE [dbo].[CursoAlumno]  WITH CHECK ADD  CONSTRAINT [FK_CursoAlumno_Alumno] FOREIGN KEY([ID_Alumno])
REFERENCES [dbo].[Alumno] ([ID_Alumno])
GO
ALTER TABLE [dbo].[CursoAlumno] CHECK CONSTRAINT [FK_CursoAlumno_Alumno]
GO
ALTER TABLE [dbo].[CursoAlumno]  WITH CHECK ADD  CONSTRAINT [FK_CursoAlumno_Curso] FOREIGN KEY([ID_Curso])
REFERENCES [dbo].[Curso] ([ID_Curso])
GO
ALTER TABLE [dbo].[CursoAlumno] CHECK CONSTRAINT [FK_CursoAlumno_Curso]
GO
ALTER TABLE [dbo].[CursoMateria]  WITH CHECK ADD  CONSTRAINT [FK_CursoMateria_Curso] FOREIGN KEY([ID_Curso])
REFERENCES [dbo].[Curso] ([ID_Curso])
GO
ALTER TABLE [dbo].[CursoMateria] CHECK CONSTRAINT [FK_CursoMateria_Curso]
GO
ALTER TABLE [dbo].[CursoMateria]  WITH CHECK ADD  CONSTRAINT [FK_CursoMateria_Materia] FOREIGN KEY([ID_Materia])
REFERENCES [dbo].[Materia] ([ID_Materia])
GO
ALTER TABLE [dbo].[CursoMateria] CHECK CONSTRAINT [FK_CursoMateria_Materia]
GO
ALTER TABLE [dbo].[IdiomaControl]  WITH CHECK ADD  CONSTRAINT [FK_IdiomaControl_Idioma] FOREIGN KEY([ID_Idioma])
REFERENCES [dbo].[Idioma] ([ID_Idioma])
GO
ALTER TABLE [dbo].[IdiomaControl] CHECK CONSTRAINT [FK_IdiomaControl_Idioma]
GO
ALTER TABLE [dbo].[Materia]  WITH CHECK ADD  CONSTRAINT [FK_Materia_Profesor] FOREIGN KEY([ID_Profesor])
REFERENCES [dbo].[Profesor] ([ID_Profesor])
GO
ALTER TABLE [dbo].[Materia] CHECK CONSTRAINT [FK_Materia_Profesor]
GO
ALTER TABLE [dbo].[Nota]  WITH CHECK ADD  CONSTRAINT [FK_Nota_Alumno] FOREIGN KEY([ID_Alumno])
REFERENCES [dbo].[Alumno] ([ID_Alumno])
GO
ALTER TABLE [dbo].[Nota] CHECK CONSTRAINT [FK_Nota_Alumno]
GO
ALTER TABLE [dbo].[Nota]  WITH CHECK ADD  CONSTRAINT [FK_Nota_Materia] FOREIGN KEY([ID_Materia])
REFERENCES [dbo].[Materia] ([ID_Materia])
GO
ALTER TABLE [dbo].[Nota] CHECK CONSTRAINT [FK_Nota_Materia]
GO
ALTER TABLE [dbo].[Promedios]  WITH CHECK ADD  CONSTRAINT [FK_Promedios_Alumno] FOREIGN KEY([ID_Alumno])
REFERENCES [dbo].[Alumno] ([ID_Alumno])
GO
ALTER TABLE [dbo].[Promedios] CHECK CONSTRAINT [FK_Promedios_Alumno]
GO
ALTER TABLE [dbo].[Promedios]  WITH CHECK ADD  CONSTRAINT [FK_Promedios_Materia] FOREIGN KEY([ID_Materia])
REFERENCES [dbo].[Materia] ([ID_Materia])
GO
ALTER TABLE [dbo].[Promedios] CHECK CONSTRAINT [FK_Promedios_Materia]
GO
ALTER TABLE [dbo].[UsuarioCambios]  WITH CHECK ADD  CONSTRAINT [FK_UsuarioCambios_Usuario] FOREIGN KEY([ID_Usuario])
REFERENCES [dbo].[Usuario] ([ID_Usuario])
GO
ALTER TABLE [dbo].[UsuarioCambios] CHECK CONSTRAINT [FK_UsuarioCambios_Usuario]
GO
ALTER TABLE [dbo].[UsuarioPermiso]  WITH CHECK ADD  CONSTRAINT [FK_UsuarioPermiso_Permiso] FOREIGN KEY([ID_Permiso])
REFERENCES [dbo].[Permiso] ([ID_Permiso])
GO
ALTER TABLE [dbo].[UsuarioPermiso] CHECK CONSTRAINT [FK_UsuarioPermiso_Permiso]
GO
ALTER TABLE [dbo].[UsuarioPermiso]  WITH CHECK ADD  CONSTRAINT [FK_UsuarioPermiso_Usuario] FOREIGN KEY([ID_Usuario])
REFERENCES [dbo].[Usuario] ([ID_Usuario])
GO
ALTER TABLE [dbo].[UsuarioPermiso] CHECK CONSTRAINT [FK_UsuarioPermiso_Usuario]
GO
/****** Object:  StoredProcedure [dbo].[AGREGAR_FAMILIA]    Script Date: 27/11/2021 19:36:38 ******/
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
/****** Object:  StoredProcedure [dbo].[AGREGAR_PERMISO]    Script Date: 27/11/2021 19:36:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE   Procedure [dbo].[AGREGAR_PERMISO]
@familia nvarchar(max)
as
begin

INSERT INTO Permiso values(@familia,0,0)

return @@IDENTITY

end
GO
/****** Object:  StoredProcedure [dbo].[Agregar_Profesor]    Script Date: 27/11/2021 19:36:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE   PROCEDURE [dbo].[Agregar_Profesor]
@nombre nvarchar(50), @apellido nvarchar(50), @email nvarchar(50),
@DNI nvarchar(50)
as begin
insert into Profesor values (@nombre, @apellido, @email, @DNI)
return @@IDENTITY
end
GO
/****** Object:  StoredProcedure [dbo].[ASIGNAR_PERMISO_A_USUARIO]    Script Date: 27/11/2021 19:36:38 ******/
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
/****** Object:  StoredProcedure [dbo].[AsignarAlumnoACurso]    Script Date: 27/11/2021 19:36:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create   procedure [dbo].[AsignarAlumnoACurso]
@idAlumno int, @idCurso int
as begin
insert into CursoAlumno values (@idAlumno, @idCurso)

--actualizo los cupos del curso
update Curso set Cupo = (Cupo-1) where ID_Curso = @idCurso
end
GO
/****** Object:  StoredProcedure [dbo].[AsignarProfesorAMateria]    Script Date: 27/11/2021 19:36:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE   PROCEDURE [dbo].[AsignarProfesorAMateria]
@id_materia int, @id_profesor int
as begin
update Materia set ID_Profesor = @id_profesor where ID_Materia = @id_materia
end
GO
/****** Object:  StoredProcedure [dbo].[BajaAlumno]    Script Date: 27/11/2021 19:36:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE   procedure [dbo].[BajaAlumno]
@idAlumno int
as begin

declare @cursoID int

update Alumno set Activo = 0 where ID_Alumno = @idAlumno

set @cursoID = (select ID_Curso from CursoAlumno where ID_Alumno=@idAlumno)

delete CursoAlumno where ID_Alumno=@idAlumno

delete Nota where ID_Alumno= @idAlumno

--Actualizo el cupo del curso
update Curso set Cupo = (Cupo+1) where ID_Curso = @cursoID
end
GO
/****** Object:  StoredProcedure [dbo].[BloquearUsuario]    Script Date: 27/11/2021 19:36:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE   procedure [dbo].[BloquearUsuario]
@Username nvarchar(max)
as begin
declare @idUsuario int
set @idUsuario = (select ID_Usuario from Usuario where Username= @Username)
update Usuario set Bloqueado=1 where Username=@Username
return @idUsuario
end
GO
/****** Object:  StoredProcedure [dbo].[BuscarAlumnos]    Script Date: 27/11/2021 19:36:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE   procedure [dbo].[BuscarAlumnos]
@nombre nvarchar(50)=null, @apellido nvarchar(50)=null, @dni nvarchar(50)=null
as begin

select * from Alumno
where (Nombre = @nombre or @nombre is null) and
(Apellido = @apellido or @apellido is null) and
(DNI = @dni or @dni is null)
and Activo = 1
end
GO
/****** Object:  StoredProcedure [dbo].[BuscarAlumnosPorCurso]    Script Date: 27/11/2021 19:36:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create   procedure [dbo].[BuscarAlumnosPorCurso]
@Grado int, @turno nvarchar(100)
as begin

select Alumno.* from Curso
inner join CursoAlumno on Curso.ID_Curso = CursoAlumno.ID_Curso
inner join Alumno on CursoAlumno.ID_Alumno = Alumno.ID_Alumno

where AñoSecundaria = @Grado and Turno = @turno
end
GO
/****** Object:  StoredProcedure [dbo].[BuscarMateriasPorCurso]    Script Date: 27/11/2021 19:36:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create   procedure [dbo].[BuscarMateriasPorCurso]
@Grado int, @turno nvarchar(100)
as begin

select Materia.* from Curso
inner join CursoMateria on Curso.ID_Curso = CursoMateria.ID_Curso
inner join Materia on CursoMateria.ID_Materia = Materia.ID_Materia

where AñoSecundaria = @Grado and Turno = @turno
end
GO
/****** Object:  StoredProcedure [dbo].[BuscarTexto]    Script Date: 27/11/2021 19:36:38 ******/
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
/****** Object:  StoredProcedure [dbo].[CalcularPromedio]    Script Date: 27/11/2021 19:36:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create   procedure [dbo].[CalcularPromedio]
@idAlumno int, @idMateria int, @nota int
as begin

--si ya existe updateo, sino inserto
if exists (select * from Promedios where ID_Alumno = @idAlumno and ID_Materia = @idMateria)
	begin
		declare @promedio decimal(5,2)
		set @promedio = (select AVG(Nota) from Nota where ID_Alumno = @idAlumno and ID_Materia = @idMateria)
		update Promedios set Promedio = @promedio where ID_Alumno = @idAlumno and ID_Materia = @idMateria
	end
else
	begin
		insert into Promedios (ID_Alumno, ID_Materia, Promedio) values (@idAlumno, @idMateria, @nota)
	end
end
GO
/****** Object:  StoredProcedure [dbo].[COMPROBAR_FAMILIA_A_QUITAR_USUARIO]    Script Date: 27/11/2021 19:36:38 ******/
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
/****** Object:  StoredProcedure [dbo].[COMPROBAR_PATENTE_A_QUITAR_USUARIO]    Script Date: 27/11/2021 19:36:38 ******/
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
/****** Object:  StoredProcedure [dbo].[ControlesATraducir]    Script Date: 27/11/2021 19:36:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE   PROCEDURE [dbo].[ControlesATraducir]
@idioma nvarchar(100)
as begin
declare @id_idioma int
set @id_idioma = (select ID_Idioma from Idioma where Idioma=@idioma)

select distinct nombreControl from IdiomaControl
except
select distinct nombreControl from IdiomaControl where ID_Idioma=@id_idioma
end
GO
/****** Object:  StoredProcedure [dbo].[CrearAuditoria]    Script Date: 27/11/2021 19:36:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE   PROCEDURE [dbo].[CrearAuditoria]
@Nombre nvarchar(50),
@Apellido nvarchar(50),
@Dni nvarchar(50),
@Username nvarchar(max),
@Contraseña nvarchar(max),
@Email nvarchar(50),
@FechaNacimiento date,
@Direccion nvarchar(max),
@idUsuario int,
@idModificador int
as begin
insert into UsuarioCambios
values(@Nombre,@Apellido,@Dni,@Email,@FechaNacimiento,@Direccion,@idModificador, GETDATE(), @idUsuario)

return @@IDENTITY
end
GO
/****** Object:  StoredProcedure [dbo].[CrearAuditoriaUsuario]    Script Date: 27/11/2021 19:36:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE   PROCEDURE [dbo].[CrearAuditoriaUsuario]
@Nombre nvarchar(50),
@Apellido nvarchar(50),
@Dni nvarchar(50),
@Email nvarchar(50),
@FechaNacimiento date,
@Direccion nvarchar(max),
@idUsuario int,
@idModificador int
as begin
insert into UsuarioCambios
values(@Nombre,@Apellido,@Dni,@Email,@FechaNacimiento,@Direccion,@idModificador, GETDATE(), @idUsuario)

end
GO
/****** Object:  StoredProcedure [dbo].[CrearCursosPorAño]    Script Date: 27/11/2021 19:36:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create   procedure [dbo].[CrearCursosPorAño]
@añoActual int
as begin

IF @añoActual > (select max(AñoFecha) from Curso)
begin
insert into Curso values(@añoActual,1,30,'Mañana')
insert into Curso values(@añoActual,1,30,'Tarde')
insert into Curso values(@añoActual,2,40,'Mañana')
insert into Curso values(@añoActual,2,30,'Tarde')
insert into Curso values(@añoActual,3,35,'Mañana')
insert into Curso values(@añoActual,3,35,'Tarde')
insert into Curso values(@añoActual,4,25,'Mañana')
insert into Curso values(@añoActual,4,25,'Tarde')
insert into Curso values(@añoActual,5,20,'Mañana')
insert into Curso values(@añoActual,5,20,'Tarde')
insert into Curso values(@añoActual,6,20,'Mañana')
insert into Curso values(@añoActual,6,20,'Tarde')

return 1
end

else
begin
	return 0
end
end

GO
/****** Object:  StoredProcedure [dbo].[CrearMateria]    Script Date: 27/11/2021 19:36:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE   procedure [dbo].[CrearMateria]
@Año int, @descripcion nvarchar(50), @dia nvarchar(50), @horaInicio int, @horaFin int, @idCurso int
as begin
declare @idNuevaMateria int
insert into Materia (Año, Descripcion, Dia, HoraInicio, HoraFin) values(@Año, @descripcion, @dia, @horaInicio, @horaFin)
set @idNuevaMateria = @@IDENTITY
insert into CursoMateria values (@idCurso, @idNuevaMateria)
end
GO
/****** Object:  StoredProcedure [dbo].[CrearUsuario]    Script Date: 27/11/2021 19:36:38 ******/
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
/****** Object:  StoredProcedure [dbo].[CursosCuposDisponibles]    Script Date: 27/11/2021 19:36:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create   procedure [dbo].[CursosCuposDisponibles]
@gradoCurso int
as begin
select * from Curso where AñoSecundaria = @gradoCurso and Cupo > 0
end
GO
/****** Object:  StoredProcedure [dbo].[DESASIGNAR_PERMISO_A_USUARIO]    Script Date: 27/11/2021 19:36:38 ******/
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
/****** Object:  StoredProcedure [dbo].[DesbloquearUsuario]    Script Date: 27/11/2021 19:36:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create   procedure [dbo].[DesbloquearUsuario]
@idUsuario int
as begin
update Usuario set Bloqueado = 0, IntentosIngreso = 3 where ID_Usuario = @idUsuario
end
GO
/****** Object:  StoredProcedure [dbo].[DVH_GUARDAR]    Script Date: 27/11/2021 19:36:38 ******/
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
/****** Object:  StoredProcedure [dbo].[DVH_OBTENER_SUMA_TABLA]    Script Date: 27/11/2021 19:36:38 ******/
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
/****** Object:  StoredProcedure [dbo].[DVH_REGISTRO_COMPLETO]    Script Date: 27/11/2021 19:36:38 ******/
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
/****** Object:  StoredProcedure [dbo].[DVH_TRAER_DVH_REGISTRO]    Script Date: 27/11/2021 19:36:38 ******/
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
/****** Object:  StoredProcedure [dbo].[DVH_TRAER_TABLA_COMPLETA]    Script Date: 27/11/2021 19:36:38 ******/
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
/****** Object:  StoredProcedure [dbo].[DVV_GUARDAR]    Script Date: 27/11/2021 19:36:38 ******/
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
/****** Object:  StoredProcedure [dbo].[DVV_OBTENER_TABLA_PARTICULAR]    Script Date: 27/11/2021 19:36:38 ******/
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
/****** Object:  StoredProcedure [dbo].[DVV_TABLA_COMPLETA]    Script Date: 27/11/2021 19:36:38 ******/
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
/****** Object:  StoredProcedure [dbo].[EliminarUsuario]    Script Date: 27/11/2021 19:36:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE   procedure [dbo].[EliminarUsuario]
@idUsuario int
as begin
delete Usuario where ID_Usuario=@idUsuario
delete UsuarioPermiso where ID_Usuario = @idUsuario
end
GO
/****** Object:  StoredProcedure [dbo].[FAMILIA_ELIMINAR]    Script Date: 27/11/2021 19:36:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create Procedure [dbo].[FAMILIA_ELIMINAR]
@familia nvarchar(max)

as
begin

Declare @id_familia int set @id_familia = (Select p.ID_Permiso from Permiso p where p.Permiso = @familia and p.IsFamilia = 1) 

BEGIN TRY
	Delete from UsuarioPermiso where ID_Permiso = @id_familia
	Delete from Compuesto where ID_Familia = @id_familia
	Delete from Permiso where ID_Permiso = @id_familia
END TRY

BEGIN CATCH
	PRINT('ERROR')
END CATCH

end
GO
/****** Object:  StoredProcedure [dbo].[GuardarIdioma]    Script Date: 27/11/2021 19:36:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create   procedure [dbo].[GuardarIdioma]
@idioma nvarchar(100)
as begin
insert into Idioma values (@idioma)
end
GO
/****** Object:  StoredProcedure [dbo].[GuardarTraduccion]    Script Date: 27/11/2021 19:36:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE   PROCEDURE [dbo].[GuardarTraduccion]
@traduccion nvarchar(100), @idioma nvarchar(100), @NombreControl nvarchar(100)
as begin
declare @id_idioma int
set @id_idioma = (select ID_Idioma from Idioma where Idioma=@idioma)

insert into IdiomaControl values (@id_idioma, @NombreControl, @traduccion)
end
GO
/****** Object:  StoredProcedure [dbo].[IniciarSesion]    Script Date: 27/11/2021 19:36:38 ******/
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
/****** Object:  StoredProcedure [dbo].[ListarBitacora]    Script Date: 27/11/2021 19:36:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE   PROCEDURE [dbo].[ListarBitacora]
@fechaDesde date=null, @fechaHasta date=null, 
@criticidad nvarchar(30)=null, @usuario nvarchar(max)=null
as begin
declare @idCriticidad int
set @idCriticidad = (select IDCriticidad from Criticidad where Descripcion=@criticidad)

select Accion,bitacora.Descripcion,Fecha,Criticidad.Descripcion as Criticidad , Username
from Bitacora
inner join Criticidad on Bitacora.idCriticidad = Criticidad.IDCriticidad
where 
((CONVERT(date,Fecha,103) >= @fechaDesde ) or (@fechaDesde is null )) and
((CONVERT(date,Fecha,103) <= @fechaHasta ) or (@fechaHasta is null )) and
((Bitacora.idCriticidad=@idCriticidad) or (@criticidad is null)) and
((Bitacora.Username = @usuario) or (@usuario is null ))
order by Fecha desc
end
GO
/****** Object:  StoredProcedure [dbo].[ListarIdiomas]    Script Date: 27/11/2021 19:36:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create   procedure [dbo].[ListarIdiomas]
as begin
select * from Idioma
end
GO
/****** Object:  StoredProcedure [dbo].[ListarMateriasParaIngresoAlumno]    Script Date: 27/11/2021 19:36:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE   procedure [dbo].[ListarMateriasParaIngresoAlumno]
@curso int, @turno nvarchar(50)
as begin
select Materia.* from CursoMateria
inner join Materia on CursoMateria.ID_Materia = Materia.ID_Materia
inner join Curso on CursoMateria.ID_Curso = Curso.ID_Curso
--hago curso -1 porque se supone que si entras a x año tenes que tener las notas de los años anteriores y no de ese porque vas a entrar
where Materia.Año <= @curso-1 and Curso.Turno=@turno
order by Materia.Año asc
end
GO
/****** Object:  StoredProcedure [dbo].[listarMateriasSinProfesor]    Script Date: 27/11/2021 19:36:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create   procedure [dbo].[listarMateriasSinProfesor]
as begin
select * from Materia where ID_Profesor is null
end
GO
/****** Object:  StoredProcedure [dbo].[ListarUsuariosBloqueados]    Script Date: 27/11/2021 19:36:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create   procedure [dbo].[ListarUsuariosBloqueados]
as begin
select * from Usuario where Bloqueado = 1
end
GO
/****** Object:  StoredProcedure [dbo].[ModificarUsuario]    Script Date: 27/11/2021 19:36:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE   PROCEDURE [dbo].[ModificarUsuario]
@idUsuario int,
@Nombre nvarchar(50),
@Apellido nvarchar(50),
@Dni nvarchar(50),
@Email nvarchar(50),
@FechaNacimiento date,
@Direccion nvarchar(max)
as begin

Update Usuario set Nombre = @Nombre, Apellido = @Apellido, DNI = @Dni, Email = @Email, FechaNacimiento = @FechaNacimiento, Direccion = @Direccion where ID_Usuario = @idUsuario

end
GO
/****** Object:  StoredProcedure [dbo].[MostrarIntentoLog]    Script Date: 27/11/2021 19:36:38 ******/
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
/****** Object:  StoredProcedure [dbo].[OBTENER_AUDITORIA_USUARIO]    Script Date: 27/11/2021 19:36:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE   PROCEDURE [dbo].[OBTENER_AUDITORIA_USUARIO]
@ID_USUARIO INT
AS BEGIN

SELECT 
UsuarioCambios.Nombre,
UsuarioCambios.Apellido,
UsuarioCambios.Direccion,
UsuarioCambios.DNI,
UsuarioCambios.Email,
UsuarioCambios.FechaNacimiento,
UsuarioCambios.Fecha,
Usuario.Username,
Usuario.ID_Usuario
FROM UsuarioCambios
inner join Usuario on UsuarioCambios.ID_Usuario = Usuario.ID_Usuario
where UsuarioCambios.ID_Usuario = @ID_USUARIO
order by Fecha desc

end
GO
/****** Object:  StoredProcedure [dbo].[OBTENER_PATENTE_X_FAMILIA]    Script Date: 27/11/2021 19:36:38 ******/
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
/****** Object:  StoredProcedure [dbo].[OBTENER_PATENTSE_QUITANDO_PATENTES_FAMILIA]    Script Date: 27/11/2021 19:36:38 ******/
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
/****** Object:  StoredProcedure [dbo].[OBTENER_PERMISOS]    Script Date: 27/11/2021 19:36:38 ******/
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
/****** Object:  StoredProcedure [dbo].[OBTENER_PERMISOS_EXLUYENTES_AL_USUARIO]    Script Date: 27/11/2021 19:36:38 ******/
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
/****** Object:  StoredProcedure [dbo].[OBTENER_PERMISOS_GENERAL]    Script Date: 27/11/2021 19:36:38 ******/
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
/****** Object:  StoredProcedure [dbo].[OBTENER_PERMISOS_X_USUARIO]    Script Date: 27/11/2021 19:36:38 ******/
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
/****** Object:  StoredProcedure [dbo].[OBTENER_USUARIOS]    Script Date: 27/11/2021 19:36:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE   PROCEDURE [dbo].[OBTENER_USUARIOS]

AS BEGIN
select * from Usuario
END
GO
/****** Object:  StoredProcedure [dbo].[ObtenerUsuarioLogin]    Script Date: 27/11/2021 19:36:38 ******/
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
/****** Object:  StoredProcedure [dbo].[PERMISO_COMPROBAR_EXISTENCIA]    Script Date: 27/11/2021 19:36:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[PERMISO_COMPROBAR_EXISTENCIA]
@nombrePermiso nvarchar(max), @isFamilia bit

as
begin

IF EXISTS (Select p.ID_Permiso from Permiso p where p.Permiso = @nombrePermiso and p.IsFamilia = @isFamilia) 
	BEGIN
		Select 1 as Contador
	END
ELSE
	BEGIN
		Select 0 as Contador
	END

end
GO
/****** Object:  StoredProcedure [dbo].[PonerNotaTrimestral]    Script Date: 27/11/2021 19:36:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE   procedure [dbo].[PonerNotaTrimestral]
@idAlumno int, @idMateria int, @notaNumerica decimal(5,2), @trimestre int
as begin

insert into Nota (ID_Materia,ID_Alumno,Nota,Previa,Trimestre)
values (@idMateria, @idAlumno, @notaNumerica, 0, @trimestre)

exec CalcularPromedio @idAlumno, @idMateria, @notaNumerica
end
GO
/****** Object:  StoredProcedure [dbo].[ReactivarAlumno]    Script Date: 27/11/2021 19:36:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create   procedure [dbo].[ReactivarAlumno]
@idAlumno int
as begin
update Alumno set Activo = 1 where ID_Alumno=@idAlumno
end
GO
/****** Object:  StoredProcedure [dbo].[ReestablecerInicioSesion]    Script Date: 27/11/2021 19:36:38 ******/
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
/****** Object:  StoredProcedure [dbo].[RegistrarAlumno]    Script Date: 27/11/2021 19:36:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE   procedure [dbo].[RegistrarAlumno]
@nombre nvarchar(50), @apellido nvarchar(50), @Email nvarchar(50), @dni nvarchar(50)
as begin
insert into Alumno values(@nombre, @apellido, @Email, @dni,1)

return @@IDENTITY
end
GO
/****** Object:  StoredProcedure [dbo].[RegistrarBitacora]    Script Date: 27/11/2021 19:36:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE   PROCEDURE [dbo].[RegistrarBitacora]
@Accion nvarchar(100), @Descripcion nvarchar(max),
@Criticidad nvarchar(30), @usuario nvarchar(max)
as begin
declare @idCriticidad int
declare @lastID int
set @idCriticidad = (select IDCriticidad from Criticidad where Descripcion = @Criticidad)

insert into Bitacora 
(Accion,
Descripcion,
Fecha,
Username,
idCriticidad,
DVH)

values (
@Accion,
@Descripcion,
GETDATE(),
@usuario,
@idCriticidad,
0)

set @lastID = (select @@IDENTITY)

return @lastID
end
GO
/****** Object:  StoredProcedure [dbo].[RegistrarNotasHistoricas]    Script Date: 27/11/2021 19:36:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE   procedure [dbo].[RegistrarNotasHistoricas]
@idAlumno int, @idMateria int, @notaNumerica decimal(5,2), @previa bit
as begin
insert into Nota values(@idMateria, @idAlumno, @notaNumerica, @previa,null)
end
GO
/****** Object:  StoredProcedure [dbo].[SP_FAMILIA_AGREGAR_PATENTE]    Script Date: 27/11/2021 19:36:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [dbo].[SP_FAMILIA_AGREGAR_PATENTE]
@patente nvarchar(max), @familia nvarchar(max)

as
begin

IF @patente != @familia
	BEGIN
		
		Declare @id_permiso as int set @id_permiso = (Select p.ID_Permiso from Permiso p where p.Permiso = @patente and IsFamilia = 0)

		Declare @id_familia as int set @id_familia = (Select p.ID_Permiso from Permiso p where p.Permiso = @familia and IsFamilia = 1)

		Insert into Compuesto values (@id_permiso,@id_familia,0)

		return @@identity

	END
ELSE
	BEGIN
		RAISERROR('No se puede agregar la familia a si misma',0,0)
	END

end
GO
/****** Object:  StoredProcedure [dbo].[SP_FAMILIA_COMPROBAR_ELIMINACION_SIN_FILTRAR_USUARIO]    Script Date: 27/11/2021 19:36:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create Procedure [dbo].[SP_FAMILIA_COMPROBAR_ELIMINACION_SIN_FILTRAR_USUARIO]
@familia nvarchar(max)
--COMPRUEBA QUE UNA FAMILIA SE PUEDA ELIMINAR VERIFICANDO QUE TODOS LOS USUARIOS (INCLUIDO EL DE SESION) POSEAN DE ALGUNA FORMA
--LAS PATENTES QUE COMPONEN LA FAMILIA MEDIANTE PATENTES SUELTAS O HEREDADAS DE ALGUNA OTRA FAMILIA
as
begin

--LOTE DE PRUEBAS 19,29,34
--Teniendo una familia admin con 5 patentes, le sacamos una patente y un usuario posee admin con 4 patentes y otro usuario posee la patente restante
--Se puede eliminar la familia ya que hay usuario/s que tienen la suma de las patentes de esa familia.

--Obtengo ID de familia
Declare @id_familia int set @id_familia = (Select p.ID_Permiso from Permiso p where p.Permiso = @familia and p.IsFamilia = 1) 

--Obtengo cantidad de patentes totales donde el isFamilia sea FALSE
Declare @cantidadPatentes int set @cantidadPatentes = (select COUNT(p.Permiso) as cantidad from Compuesto c 
														inner join Permiso p on p.ID_Permiso = c.ID_Permiso 
														where c.ID_Familia = @id_familia and p.IsFamilia = 0) 

--Obtengo las patentes del ID de familia
select p.Permiso 
into #patentesFamilia 
from Compuesto c 
inner join Permiso p on p.ID_Permiso = c.ID_Permiso 
where c.ID_Familia = @id_familia and p.IsFamilia = 0

--Obtengo todas las familias menos la familia del ID
SELECT distinct p.ID_Permiso,up.ID_Usuario INTO #tabla 
FROM Permiso  p 
inner join Compuesto c on p.ID_Permiso= c.ID_Familia 
inner join UsuarioPermiso up on up.ID_Permiso = p.ID_Permiso 
where p.IsFamilia = 1 and c.ID_Familia != @id_familia

--Obtengo todas las patentes que tenga la familia pasada
SELECT distinct T.permiso into #patentes FROM
(   
	--Obtene las patente y el usuario que esten dentro de las patentes de la tabla #patentesFamilia y no sean familia (patentes sueltas)
	SELECT p.permiso, up.ID_Usuario 
	FROM Permiso p 
	inner join UsuarioPermiso up on p.ID_Permiso = up.ID_Permiso and p.IsFamilia = 0 
	where p.Permiso in (select pf.Permiso from #patentesFamilia pf)
    UNION ALL
	-- Obtiene las patentes y el usuario que sean de la familia que este dentro de #patentesFamilia
    select p.Permiso, t.ID_Usuario
	from Permiso p 
	inner join Compuesto c on p.ID_Permiso = c.ID_Permiso 
	inner join #tabla t on t.ID_Permiso = c.ID_Familia where p.Permiso in (select pf.Permiso from #patentesFamilia pf)
) T 

--Cuenta las patentes por usuario si es igual a la cantidad de patentes
SELECT count(p.permiso) cantidad into #contar from #patentes p having count(p.permiso)  = @cantidadPatentes
	
--Selecciona la tabla. Devuelve 0 o mas
select COUNT(*) as Contador from #contar

end
GO
/****** Object:  StoredProcedure [dbo].[SP_PATENTE_COMPROBAR_QUITAR_A_FAMILIA]    Script Date: 27/11/2021 19:36:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create Procedure [dbo].[SP_PATENTE_COMPROBAR_QUITAR_A_FAMILIA]
@familia nvarchar(max), @patente nvarchar(max)
--COMPRUEBA QUE UNA PATENTE PUEDA QUITARSE DE UNA FAMILIA SI HAY UN USUARIO O USUARIOS QUE POSEA ESA PATENTE SUELTA O HEREDADA DE OTRA FAMILIA
as
begin

--LOTE DE PRUEBA 27,32

Declare @id_familia int set @id_familia = (Select p.ID_Permiso from Permiso p  where p.Permiso = @familia and p.IsFamilia = 1)

Declare @id_patente int set @id_patente = (Select p.ID_Permiso from Permiso p where p.Permiso = @patente)

SELECT distinct p.ID_Permiso INTO #tablaFamilias
FROM Permiso  p 
inner join Compuesto c on p.ID_Permiso= c.ID_Familia 
inner join UsuarioPermiso up on up.ID_Permiso = p.ID_Permiso 
where p.IsFamilia = 1 and c.ID_Familia != @id_familia --Trae familias de los usuarios

SELECT DISTINCT T.permiso into #patentesFiltradas FROM
(   SELECT p.permiso
	FROM Permiso p 
	inner join UsuarioPermiso up on p.ID_Permiso = up.ID_Permiso and p.IsFamilia = 0 
	where p.ID_Permiso = @id_patente
    UNION ALL
    select p.Permiso
	from Permiso p 
	inner join Compuesto c on p.ID_Permiso = c.ID_Permiso 
	inner join #tablaFamilias t on t.ID_Permiso = c.ID_Familia
	where p.ID_Permiso = @id_patente 
) T 

Select COUNT(1) as Contador from #patentesFiltradas

end
GO
/****** Object:  StoredProcedure [dbo].[SP_PATENTE_COMPROBAR_USUARIO]    Script Date: 27/11/2021 19:36:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [dbo].[SP_PATENTE_COMPROBAR_USUARIO]
@patente nvarchar(max), @id_usuario int
as
begin

Declare @id_patente int set @id_patente = (Select ID_Permiso from Permiso where Permiso = @patente)

SELECT distinct p.ID_Permiso,up.ID_Usuario INTO #tablaFamilias
FROM Permiso  p 
inner join Compuesto c on p.ID_Permiso= c.ID_Familia 
inner join UsuarioPermiso up on up.ID_Permiso = p.ID_Permiso 
where p.IsFamilia = 1 and up.ID_Usuario = @id_usuario --Trae familias del usuario

SELECT T.ID_Usuario, COUNT(T.permiso) cantidad into #usuarioPatente FROM
(   SELECT p.permiso, up.ID_Usuario 
	FROM Permiso p 
	inner join UsuarioPermiso up on p.ID_Permiso = up.ID_Permiso and p.IsFamilia = 0 
	where p.ID_Permiso = @id_patente and up.ID_Usuario = @id_usuario --Trae patentes unicas de usuario que recibe y que no sea familia
    UNION ALL
    select p.Permiso, t.ID_Usuario
	from Permiso p 
	inner join Compuesto c on p.ID_Permiso = c.ID_Permiso 
	inner join #tablaFamilias t on t.ID_Permiso = c.ID_Familia
	where p.ID_Permiso = @id_patente  --Trae patentes a partir de las familias del usuario distinto a lo que recibe (en este caso una patente)
) T group by T.Permiso, T.ID_Usuario

Select COUNT(1) as Contador from #usuarioPatente

end
GO
/****** Object:  StoredProcedure [dbo].[SP_PATENTE_DESASIGNAR_A_FAMILIA]    Script Date: 27/11/2021 19:36:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create Procedure [dbo].[SP_PATENTE_DESASIGNAR_A_FAMILIA]
@patente nvarchar(max), @familia nvarchar(max)

as
begin

Declare @id_permiso as int set @id_permiso = (Select p.ID_Permiso from Permiso p where p.Permiso = @patente and IsFamilia = 0)

Declare @id_familia as int set @id_familia = (Select p.ID_Permiso from Permiso p where p.Permiso = @familia and IsFamilia = 1)

Declare @id_compuesto as int set @id_compuesto = (Select c.ID_Compuesto from Compuesto c where c.ID_Permiso = @id_permiso and c.ID_Familia = @id_familia)

Delete from Compuesto where ID_Compuesto = @id_compuesto

end
GO
/****** Object:  StoredProcedure [dbo].[SumarIntentoDeLog]    Script Date: 27/11/2021 19:36:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE   procedure [dbo].[SumarIntentoDeLog]
@Username nvarchar(max)
as begin

declare @idUsuario int
set @idUsuario = (select ID_Usuario from Usuario where Username = @Username)
update Usuario
Set IntentosIngreso = IntentosIngreso - 1 where Username=@Username

return @idUsuario
end
GO
/****** Object:  StoredProcedure [dbo].[ValidadHorarioNuevaMateria]    Script Date: 27/11/2021 19:36:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create   procedure [dbo].[ValidadHorarioNuevaMateria]
@anio int, @dia nvarchar(50), @horainicio int, @horaFin int
as begin

select * from Materia where Año=@anio and Dia=@dia and (HoraInicio between @horainicio and @horaFin) and HoraFin between @horainicio and @horaFin

end
GO
/****** Object:  StoredProcedure [dbo].[ValidarNotaDisponibleParaTrimestre]    Script Date: 27/11/2021 19:36:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create   procedure [dbo].[ValidarNotaDisponibleParaTrimestre]
@idAlumno int, @idMateria int, @trimestre int
as begin

select * from Nota where ID_Alumno= @idAlumno and ID_Materia= @idMateria and Trimestre = @trimestre

end
GO
/****** Object:  StoredProcedure [dbo].[ValidarNuevoIdioma]    Script Date: 27/11/2021 19:36:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE   PROCEDURE [dbo].[ValidarNuevoIdioma]
@idioma nvarchar(100)
as begin
select * from Idioma where Idioma=@idioma
end
GO
/****** Object:  StoredProcedure [dbo].[ValidarUsuarioDisponible]    Script Date: 27/11/2021 19:36:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE   procedure [dbo].[ValidarUsuarioDisponible]
@username nvarchar(max), @mail nvarchar(100), @dni nvarchar(50)
as begin
select * from Usuario where Username= @username or DNI=@dni or Email=@mail
end
GO
/****** Object:  StoredProcedure [dbo].[VerificarExistenciaAlumno]    Script Date: 27/11/2021 19:36:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create   procedure [dbo].[VerificarExistenciaAlumno]
@dni nvarchar(50)
as begin
select * from Alumno where DNI=@dni
end
GO
/****** Object:  StoredProcedure [dbo].[VerificarMateriasDelCursoParaNuevaMateria]    Script Date: 27/11/2021 19:36:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE   PROCEDURE [dbo].[VerificarMateriasDelCursoParaNuevaMateria]
as begin
select * from Curso where ID_Curso not in (SELECT ID_Curso
FROM CursoMateria
GROUP BY ID_Curso
HAVING COUNT(ID_Curso) >= 5)
and AñoFecha = YEAR( getdate() )
end
GO
/****** Object:  StoredProcedure [dbo].[VerificarUsuario]    Script Date: 27/11/2021 19:36:38 ******/
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
