CREATE TABLE [dbo].[ProductCategory] (
    [CategoryId]         BIGINT         IDENTITY (1, 1) NOT NULL,
    [Name]               NVARCHAR (200) NOT NULL,
    [Description]        NVARCHAR (500) NOT NULL,
    [RecCreatedDate]     DATETIME       NOT NULL,
    [RecLastUpdatedDate] DATETIME       NOT NULL,
    [RecCreatedBy]       NVARCHAR (128) NOT NULL,
    [RecLastUpdatedBy]   NVARCHAR (128) NOT NULL,
    [MainCategoryId]     BIGINT         NULL,
    CONSTRAINT [PK_Category] PRIMARY KEY CLUSTERED ([CategoryId] ASC),
    CONSTRAINT [FK_ProductCategory_ProductMainCategory] FOREIGN KEY ([MainCategoryId]) REFERENCES [dbo].[ProductMainCategory] ([CategoryId])
);

