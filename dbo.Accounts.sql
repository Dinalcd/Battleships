CREATE TABLE [dbo].[Accounts] (
    [Id]       INT           IDENTITY (1, 1) NOT NULL,
    [username] NVARCHAR (50) NULL,
    [password] NVARCHAR (max) NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

