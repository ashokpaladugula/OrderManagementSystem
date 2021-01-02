CREATE TABLE [dbo].[Products] (
    [Id]               INT             NOT NULL,
    [Name]             NVARCHAR (250)  NULL,
    [Weight]           NUMERIC (18, 2) NULL,
    [Height]           NUMERIC (18, 2) NULL,
    [Image]            VARBINARY (MAX) NULL,
    [Barcode]          NVARCHAR (100)  NULL,
    [AvaiableQuantity] INT             NULL,
    CONSTRAINT [PK_Products_Id] PRIMARY KEY CLUSTERED ([Id] ASC)
);

