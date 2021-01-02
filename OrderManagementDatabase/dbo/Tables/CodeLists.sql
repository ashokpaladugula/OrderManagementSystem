CREATE TABLE [dbo].[CodeLists] (
    [Id]       INT           IDENTITY (1, 1) NOT NULL,
    [Text]     NVARCHAR (50) NULL,
    [IsActive] BIT           NULL,
    CONSTRAINT [PK_Id] PRIMARY KEY CLUSTERED ([Id] ASC)
);

