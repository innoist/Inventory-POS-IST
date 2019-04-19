CREATE TABLE [dbo].[Customer] (
    [Id]                 BIGINT         IDENTITY (1, 1) NOT NULL,
    [Name]               NVARCHAR (500) NOT NULL,
    [Phone]              NVARCHAR (100) NULL,
    [Address]            NVARCHAR (500) NULL,
    [Email]              NVARCHAR (100) NULL,
    [Comments]           NVARCHAR (500) NULL,
    [RecCreatedDate]     DATETIME       NOT NULL,
    [RecLastUpdatedDate] DATETIME       NOT NULL,
    [RecCreatedBy]       NVARCHAR (128) NOT NULL,
    [RecLastUpdatedBy]   NVARCHAR (128) NOT NULL,
    CONSTRAINT [PK_Customer] PRIMARY KEY CLUSTERED ([Id] ASC)
);

