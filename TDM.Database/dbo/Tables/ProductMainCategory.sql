CREATE TABLE [dbo].[ProductMainCategory] (
    [CategoryId]         BIGINT         IDENTITY (1, 1) NOT NULL,
    [Name]               NVARCHAR (200) NOT NULL,
    [Description]        NVARCHAR (500) NOT NULL,
    [RecCreatedDate]     DATETIME       NOT NULL,
    [RecLastUpdatedDate] DATETIME       NOT NULL,
    [RecCreatedBy]       NVARCHAR (128) NOT NULL,
    [RecLastUpdatedBy]   NVARCHAR (128) NOT NULL,
    CONSTRAINT [PK_MainCategory] PRIMARY KEY CLUSTERED ([CategoryId] ASC)
);

