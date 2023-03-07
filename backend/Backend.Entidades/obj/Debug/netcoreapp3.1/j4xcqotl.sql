IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;

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

CREATE INDEX [IX_actividades_id_usuario] ON [dbo].[actividades] ([id_usuario]);

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20230306045015_Usuarios', N'3.1.9');

GO

