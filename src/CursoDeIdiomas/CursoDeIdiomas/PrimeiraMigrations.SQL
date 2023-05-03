IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;
GO

BEGIN TRANSACTION;
GO

CREATE TABLE [Alunos] (
    [Id] int NOT NULL IDENTITY,
    [Nome] nvarchar(max) NOT NULL,
    [Cpf] nvarchar(max) NOT NULL,
    [Email] nvarchar(max) NOT NULL,
    CONSTRAINT [PK_Alunos] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [Turmas] (
    [Id] int NOT NULL IDENTITY,
    [Numero] nvarchar(max) NOT NULL,
    [AnoLetivo] datetime2 NOT NULL,
    CONSTRAINT [PK_Turmas] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [AlunoTurma] (
    [AlunosId] int NOT NULL,
    [TurmasCadastradasId] int NOT NULL,
    CONSTRAINT [PK_AlunoTurma] PRIMARY KEY ([AlunosId], [TurmasCadastradasId]),
    CONSTRAINT [FK_AlunoTurma_Alunos_AlunosId] FOREIGN KEY ([AlunosId]) REFERENCES [Alunos] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_AlunoTurma_Turmas_TurmasCadastradasId] FOREIGN KEY ([TurmasCadastradasId]) REFERENCES [Turmas] ([Id]) ON DELETE CASCADE
);
GO

CREATE INDEX [IX_AlunoTurma_TurmasCadastradasId] ON [AlunoTurma] ([TurmasCadastradasId]);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20230501040557_PrimeiraMigations', N'7.0.5');
GO

COMMIT;
GO

