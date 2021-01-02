CREATE TABLE [dbo].[Users] (
    [Id]               INT            IDENTITY (1, 1) NOT NULL,
    [Name]             NVARCHAR (100) NULL,
    [MobileNumber]     NVARCHAR (15)  NULL,
    [ContactAddressId] INT            NULL,
    [RoleId]           INT            NULL,
    CONSTRAINT [PK_Users_Id] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Users_ContactAddress_ContactAddressId] FOREIGN KEY ([ContactAddressId]) REFERENCES [dbo].[ContactAddress] ([Id]),
    CONSTRAINT [FK_Users_UserRoles_RoleId] FOREIGN KEY ([RoleId]) REFERENCES [dbo].[UserRoles] ([Id])
);

