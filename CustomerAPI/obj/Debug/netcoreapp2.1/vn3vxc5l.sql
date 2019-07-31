IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;

GO

CREATE TABLE [Customer] (
    [Id] int NOT NULL IDENTITY,
    [FirstName] nvarchar(max) NULL,
    [LastName] nvarchar(max) NULL,
    [Phone] nvarchar(max) NULL,
    CONSTRAINT [PK_Customer] PRIMARY KEY ([Id])
);

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20190729065812_Initial Migration', N'2.1.1-rtm-30846');

GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'FirstName', N'LastName', N'Phone') AND [object_id] = OBJECT_ID(N'[Customer]'))
    SET IDENTITY_INSERT [Customer] ON;
INSERT INTO [Customer] ([Id], [FirstName], [LastName], [Phone])
VALUES (1, N'Uncle', N'Bob', N'999-888-7777');
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'FirstName', N'LastName', N'Phone') AND [object_id] = OBJECT_ID(N'[Customer]'))
    SET IDENTITY_INSERT [Customer] OFF;

GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'FirstName', N'LastName', N'Phone') AND [object_id] = OBJECT_ID(N'[Customer]'))
    SET IDENTITY_INSERT [Customer] ON;
INSERT INTO [Customer] ([Id], [FirstName], [LastName], [Phone])
VALUES (2, N'Jan', N'Kirsten', N'111-222-3333');
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'FirstName', N'LastName', N'Phone') AND [object_id] = OBJECT_ID(N'[Customer]'))
    SET IDENTITY_INSERT [Customer] OFF;

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20190729070605_Initial Data Created for Customer', N'2.1.1-rtm-30846');

GO

