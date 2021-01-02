CREATE TABLE [dbo].[OrderItems] (
    [Id]        INT NOT NULL,
    [Quantity]  INT NULL,
    [OrderId]   INT NULL,
    [ProductId] INT NULL,
    CONSTRAINT [PK_OrderItems_Id] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_OrderItems_Orders_OrderId] FOREIGN KEY ([OrderId]) REFERENCES [dbo].[Orders] ([Id]),
    CONSTRAINT [FK_OrderItems_Products_ProductId] FOREIGN KEY ([ProductId]) REFERENCES [dbo].[Products] ([Id])
);

