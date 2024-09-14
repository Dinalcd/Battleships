CREATE TABLE [dbo].[Highscore] (
    [Id] INT NOT NULL,
	[username] NVARCHAR (50)  NULL,
    [score] NVARCHAR (MAX) NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

