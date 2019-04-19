CREATE TABLE [dbo].[ProductImage] (
    [ItemImageID] BIGINT         IDENTITY (1, 1) NOT NULL,
    [ProductId]   BIGINT         NOT NULL,
    [ImagePath]   NVARCHAR (100) NULL,
    CONSTRAINT [PK_ProductImage] PRIMARY KEY CLUSTERED ([ItemImageID] ASC),
    CONSTRAINT [FK_ProductImage_Products] FOREIGN KEY ([ItemImageID]) REFERENCES [dbo].[Products] ([ProductId])
);

