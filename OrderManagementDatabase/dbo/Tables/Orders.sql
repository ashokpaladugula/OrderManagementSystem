CREATE TABLE [dbo].[Orders] (
    [Id]       INT IDENTITY (1, 1) NOT NULL,
    [UserId]   INT NULL,
    [StatusId] INT NULL,
    CONSTRAINT [PK_Orders_Id] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Orders_CodeLists_StatusId] FOREIGN KEY ([StatusId]) REFERENCES [dbo].[CodeLists] ([Id]),
    CONSTRAINT [FK_Orders_Users_BuyerId] FOREIGN KEY ([UserId]) REFERENCES [dbo].[Users] ([Id])
);

