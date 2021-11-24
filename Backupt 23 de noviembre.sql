USE [master]
GO
/****** Object:  Database [DIPLOMA]    Script Date: 23/11/2021 23:40:08 ******/
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
ALTER DATABASE [DIPLOMA] SET  ENABLE_BROKER 
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
/****** Object:  Table [dbo].[Alumno]    Script Date: 23/11/2021 23:40:08 ******/
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
/****** Object:  Table [dbo].[Bitacora]    Script Date: 23/11/2021 23:40:08 ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Compuesto]    Script Date: 23/11/2021 23:40:08 ******/
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
/****** Object:  Table [dbo].[Criticidad]    Script Date: 23/11/2021 23:40:08 ******/
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
/****** Object:  Table [dbo].[Curso]    Script Date: 23/11/2021 23:40:08 ******/
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
/****** Object:  Table [dbo].[CursoAlumno]    Script Date: 23/11/2021 23:40:08 ******/
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
/****** Object:  Table [dbo].[CursoMateria]    Script Date: 23/11/2021 23:40:08 ******/
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
/****** Object:  Table [dbo].[DVV]    Script Date: 23/11/2021 23:40:08 ******/
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
/****** Object:  Table [dbo].[Idioma]    Script Date: 23/11/2021 23:40:08 ******/
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
/****** Object:  Table [dbo].[IdiomaControl]    Script Date: 23/11/2021 23:40:08 ******/
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
/****** Object:  Table [dbo].[Materia]    Script Date: 23/11/2021 23:40:08 ******/
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
/****** Object:  Table [dbo].[Nota]    Script Date: 23/11/2021 23:40:08 ******/
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
/****** Object:  Table [dbo].[Permiso]    Script Date: 23/11/2021 23:40:08 ******/
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
/****** Object:  Table [dbo].[Profesor]    Script Date: 23/11/2021 23:40:08 ******/
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
/****** Object:  Table [dbo].[Promedios]    Script Date: 23/11/2021 23:40:08 ******/
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
/****** Object:  Table [dbo].[Usuario]    Script Date: 23/11/2021 23:40:08 ******/
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
/****** Object:  Table [dbo].[UsuarioCambios]    Script Date: 23/11/2021 23:40:08 ******/
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
/****** Object:  Table [dbo].[UsuarioPermiso]    Script Date: 23/11/2021 23:40:08 ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
ALTER TABLE [dbo].[UsuarioCambios] ADD  CONSTRAINT [DF_UsuarioCambios_FechaModificacion]  DEFAULT (getdate()) FOR [Fecha]
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
/****** Object:  StoredProcedure [dbo].[AGREGAR_FAMILIA]    Script Date: 23/11/2021 23:40:08 ******/
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
/****** Object:  StoredProcedure [dbo].[AGREGAR_PERMISO]    Script Date: 23/11/2021 23:40:08 ******/
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
/****** Object:  StoredProcedure [dbo].[Agregar_Profesor]    Script Date: 23/11/2021 23:40:08 ******/
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
/****** Object:  StoredProcedure [dbo].[ASIGNAR_PERMISO_A_USUARIO]    Script Date: 23/11/2021 23:40:08 ******/
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
/****** Object:  StoredProcedure [dbo].[AsignarAlumnoACurso]    Script Date: 23/11/2021 23:40:08 ******/
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
/****** Object:  StoredProcedure [dbo].[AsignarProfesorAMateria]    Script Date: 23/11/2021 23:40:08 ******/
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
/****** Object:  StoredProcedure [dbo].[BajaAlumno]    Script Date: 23/11/2021 23:40:08 ******/
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
/****** Object:  StoredProcedure [dbo].[BloquearUsuario]    Script Date: 23/11/2021 23:40:08 ******/
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
/****** Object:  StoredProcedure [dbo].[BuscarAlumnos]    Script Date: 23/11/2021 23:40:08 ******/
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
/****** Object:  StoredProcedure [dbo].[BuscarAlumnosPorCurso]    Script Date: 23/11/2021 23:40:08 ******/
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
/****** Object:  StoredProcedure [dbo].[BuscarMateriasPorCurso]    Script Date: 23/11/2021 23:40:08 ******/
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
/****** Object:  StoredProcedure [dbo].[BuscarTexto]    Script Date: 23/11/2021 23:40:08 ******/
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
/****** Object:  StoredProcedure [dbo].[CalcularPromedio]    Script Date: 23/11/2021 23:40:08 ******/
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
/****** Object:  StoredProcedure [dbo].[COMPROBAR_FAMILIA_A_QUITAR_USUARIO]    Script Date: 23/11/2021 23:40:08 ******/
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
/****** Object:  StoredProcedure [dbo].[COMPROBAR_PATENTE_A_QUITAR_USUARIO]    Script Date: 23/11/2021 23:40:08 ******/
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
/****** Object:  StoredProcedure [dbo].[ControlesATraducir]    Script Date: 23/11/2021 23:40:08 ******/
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
/****** Object:  StoredProcedure [dbo].[CrearAuditoria]    Script Date: 23/11/2021 23:40:08 ******/
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
/****** Object:  StoredProcedure [dbo].[CrearAuditoriaUsuario]    Script Date: 23/11/2021 23:40:08 ******/
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
/****** Object:  StoredProcedure [dbo].[CrearCursosPorAño]    Script Date: 23/11/2021 23:40:08 ******/
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
/****** Object:  StoredProcedure [dbo].[CrearMateria]    Script Date: 23/11/2021 23:40:08 ******/
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
/****** Object:  StoredProcedure [dbo].[CrearUsuario]    Script Date: 23/11/2021 23:40:08 ******/
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
/****** Object:  StoredProcedure [dbo].[CursosCuposDisponibles]    Script Date: 23/11/2021 23:40:08 ******/
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
/****** Object:  StoredProcedure [dbo].[DESASIGNAR_PERMISO_A_USUARIO]    Script Date: 23/11/2021 23:40:08 ******/
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
/****** Object:  StoredProcedure [dbo].[DesbloquearUsuario]    Script Date: 23/11/2021 23:40:08 ******/
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
/****** Object:  StoredProcedure [dbo].[DVH_GUARDAR]    Script Date: 23/11/2021 23:40:08 ******/
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
/****** Object:  StoredProcedure [dbo].[DVH_OBTENER_SUMA_TABLA]    Script Date: 23/11/2021 23:40:08 ******/
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
/****** Object:  StoredProcedure [dbo].[DVH_REGISTRO_COMPLETO]    Script Date: 23/11/2021 23:40:08 ******/
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
/****** Object:  StoredProcedure [dbo].[DVH_TRAER_DVH_REGISTRO]    Script Date: 23/11/2021 23:40:08 ******/
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
/****** Object:  StoredProcedure [dbo].[DVH_TRAER_TABLA_COMPLETA]    Script Date: 23/11/2021 23:40:08 ******/
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
/****** Object:  StoredProcedure [dbo].[DVV_GUARDAR]    Script Date: 23/11/2021 23:40:08 ******/
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
/****** Object:  StoredProcedure [dbo].[DVV_OBTENER_TABLA_PARTICULAR]    Script Date: 23/11/2021 23:40:08 ******/
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
/****** Object:  StoredProcedure [dbo].[DVV_TABLA_COMPLETA]    Script Date: 23/11/2021 23:40:08 ******/
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
/****** Object:  StoredProcedure [dbo].[FAMILIA_ELIMINAR]    Script Date: 23/11/2021 23:40:08 ******/
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
/****** Object:  StoredProcedure [dbo].[GuardarIdioma]    Script Date: 23/11/2021 23:40:08 ******/
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
/****** Object:  StoredProcedure [dbo].[GuardarTraduccion]    Script Date: 23/11/2021 23:40:08 ******/
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
/****** Object:  StoredProcedure [dbo].[IniciarSesion]    Script Date: 23/11/2021 23:40:08 ******/
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
/****** Object:  StoredProcedure [dbo].[ListarBitacora]    Script Date: 23/11/2021 23:40:08 ******/
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
/****** Object:  StoredProcedure [dbo].[ListarIdiomas]    Script Date: 23/11/2021 23:40:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create   procedure [dbo].[ListarIdiomas]
as begin
select * from Idioma
end
GO
/****** Object:  StoredProcedure [dbo].[ListarMateriasParaIngresoAlumno]    Script Date: 23/11/2021 23:40:08 ******/
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
/****** Object:  StoredProcedure [dbo].[listarMateriasSinProfesor]    Script Date: 23/11/2021 23:40:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create   procedure [dbo].[listarMateriasSinProfesor]
as begin
select * from Materia where ID_Profesor is null
end
GO
/****** Object:  StoredProcedure [dbo].[ListarUsuariosBloqueados]    Script Date: 23/11/2021 23:40:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create   procedure [dbo].[ListarUsuariosBloqueados]
as begin
select * from Usuario where Bloqueado = 1
end
GO
/****** Object:  StoredProcedure [dbo].[ModificarUsuario]    Script Date: 23/11/2021 23:40:08 ******/
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
/****** Object:  StoredProcedure [dbo].[MostrarIntentoLog]    Script Date: 23/11/2021 23:40:08 ******/
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
/****** Object:  StoredProcedure [dbo].[OBTENER_AUDITORIA_USUARIO]    Script Date: 23/11/2021 23:40:08 ******/
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
/****** Object:  StoredProcedure [dbo].[OBTENER_PATENTE_X_FAMILIA]    Script Date: 23/11/2021 23:40:08 ******/
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
/****** Object:  StoredProcedure [dbo].[OBTENER_PATENTSE_QUITANDO_PATENTES_FAMILIA]    Script Date: 23/11/2021 23:40:08 ******/
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
/****** Object:  StoredProcedure [dbo].[OBTENER_PERMISOS]    Script Date: 23/11/2021 23:40:08 ******/
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
/****** Object:  StoredProcedure [dbo].[OBTENER_PERMISOS_EXLUYENTES_AL_USUARIO]    Script Date: 23/11/2021 23:40:08 ******/
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
/****** Object:  StoredProcedure [dbo].[OBTENER_PERMISOS_GENERAL]    Script Date: 23/11/2021 23:40:08 ******/
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
/****** Object:  StoredProcedure [dbo].[OBTENER_PERMISOS_X_USUARIO]    Script Date: 23/11/2021 23:40:08 ******/
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
/****** Object:  StoredProcedure [dbo].[OBTENER_USUARIOS]    Script Date: 23/11/2021 23:40:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE   PROCEDURE [dbo].[OBTENER_USUARIOS]

AS BEGIN
select * from Usuario
END
GO
/****** Object:  StoredProcedure [dbo].[ObtenerUsuarioLogin]    Script Date: 23/11/2021 23:40:08 ******/
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
/****** Object:  StoredProcedure [dbo].[PERMISO_COMPROBAR_EXISTENCIA]    Script Date: 23/11/2021 23:40:08 ******/
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
/****** Object:  StoredProcedure [dbo].[PonerNotaTrimestral]    Script Date: 23/11/2021 23:40:08 ******/
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
/****** Object:  StoredProcedure [dbo].[ReactivarAlumno]    Script Date: 23/11/2021 23:40:08 ******/
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
/****** Object:  StoredProcedure [dbo].[ReestablecerInicioSesion]    Script Date: 23/11/2021 23:40:08 ******/
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
/****** Object:  StoredProcedure [dbo].[RegistrarAlumno]    Script Date: 23/11/2021 23:40:08 ******/
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
/****** Object:  StoredProcedure [dbo].[RegistrarBitacora]    Script Date: 23/11/2021 23:40:08 ******/
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
/****** Object:  StoredProcedure [dbo].[RegistrarNotasHistoricas]    Script Date: 23/11/2021 23:40:08 ******/
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
/****** Object:  StoredProcedure [dbo].[SP_FAMILIA_AGREGAR_PATENTE]    Script Date: 23/11/2021 23:40:08 ******/
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
/****** Object:  StoredProcedure [dbo].[SP_FAMILIA_COMPROBAR_ELIMINACION_SIN_FILTRAR_USUARIO]    Script Date: 23/11/2021 23:40:08 ******/
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
/****** Object:  StoredProcedure [dbo].[SP_PATENTE_COMPROBAR_QUITAR_A_FAMILIA]    Script Date: 23/11/2021 23:40:08 ******/
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
/****** Object:  StoredProcedure [dbo].[SP_PATENTE_COMPROBAR_USUARIO]    Script Date: 23/11/2021 23:40:08 ******/
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
/****** Object:  StoredProcedure [dbo].[SP_PATENTE_DESASIGNAR_A_FAMILIA]    Script Date: 23/11/2021 23:40:08 ******/
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
/****** Object:  StoredProcedure [dbo].[SumarIntentoDeLog]    Script Date: 23/11/2021 23:40:08 ******/
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
/****** Object:  StoredProcedure [dbo].[ValidadHorarioNuevaMateria]    Script Date: 23/11/2021 23:40:08 ******/
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
/****** Object:  StoredProcedure [dbo].[ValidarNotaDisponibleParaTrimestre]    Script Date: 23/11/2021 23:40:08 ******/
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
/****** Object:  StoredProcedure [dbo].[ValidarNuevoIdioma]    Script Date: 23/11/2021 23:40:08 ******/
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
/****** Object:  StoredProcedure [dbo].[ValidarUsuarioDisponible]    Script Date: 23/11/2021 23:40:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create   procedure [dbo].[ValidarUsuarioDisponible]
@username nvarchar(max)
as begin
select * from Usuario where Username= @username
end
GO
/****** Object:  StoredProcedure [dbo].[VerificarExistenciaAlumno]    Script Date: 23/11/2021 23:40:08 ******/
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
/****** Object:  StoredProcedure [dbo].[VerificarMateriasDelCursoParaNuevaMateria]    Script Date: 23/11/2021 23:40:08 ******/
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
/****** Object:  StoredProcedure [dbo].[VerificarUsuario]    Script Date: 23/11/2021 23:40:08 ******/
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
