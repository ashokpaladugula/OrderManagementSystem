CREATE TYPE [dbo].[TVP_OrderItems] AS TABLE (
    [Id]        INT             NULL,
    [Quantity]  NUMERIC (18, 2) NULL,
    [OrderId]   INT             NULL,
    [ProductId] INT             NULL);

