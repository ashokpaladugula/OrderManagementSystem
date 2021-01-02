CREATE TABLE [dbo].[UserRoles] (
    [Id]       INT           IDENTITY (1, 1) NOT NULL,
    [Name]     NVARCHAR (50) NULL,
    [IsActive] BIT           NULL,
    CONSTRAINT [PK_UserRoles_Id] PRIMARY KEY CLUSTERED ([Id] ASC)
);

