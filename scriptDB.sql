USE [master]
GO 
CREATE DATABASE [DB_Usuarios]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'DB_Usuarios', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL13.MSSQLSERVER\MSSQL\DATA\SISFE.mdf' , SIZE = 73728KB   )
 LOG ON 
( NAME = N'DB_Usuarios_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL13.MSSQLSERVER\MSSQL\DATA\SISFE_log.ldf' , SIZE = 139264KB  )
GO
 

CREATE TABLE [dbo].[usuarios] (
    [id_usuario] INT NOT NULL IDENTITY,
    [nombre] VARCHAR(50) NOT NULL,
    [apellido] VARCHAR(50) NOT NULL,
    [correo_electronico] VARCHAR(50) NOT NULL,
    [fecha_nacimiento] DATETIME NOT NULL,
    [telefono] VARCHAR(8) NULL,
    [pais_residencia] VARCHAR(5) NOT NULL,
    [contacto] BIT NOT NULL,
    CONSTRAINT [PK_usuarios] PRIMARY KEY ([id_usuario])
);

GO

CREATE TABLE [dbo].[actividades] (
    [id_actividades] INT NOT NULL IDENTITY,
    [create_date] DATETIME NOT NULL,
    [id_usuario] INT NOT NULL,
    [actividad] VARCHAR(25) NOT NULL,
    CONSTRAINT [PK_actividades] PRIMARY KEY ([id_actividades]),
    CONSTRAINT [FK_actividades_usuarios_id_usuario] FOREIGN KEY ([id_usuario]) REFERENCES [dbo].[usuarios] ([id_usuario]) ON DELETE CASCADE
);

GO
 