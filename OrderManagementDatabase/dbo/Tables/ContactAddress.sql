CREATE TABLE [dbo].[ContactAddress] (
    [Id]      INT           NOT NULL,
    [City]    NVARCHAR (50) NULL,
    [State]   NVARCHAR (50) NULL,
    [Country] NVARCHAR (50) NULL,
    [PinCode] NVARCHAR (6)  NULL,
    CONSTRAINT [PK_ContactAddress_Id] PRIMARY KEY CLUSTERED ([Id] ASC)
);

