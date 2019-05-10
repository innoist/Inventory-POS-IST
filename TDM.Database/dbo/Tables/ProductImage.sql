CREATE TABLE [dbo].[ProductImage] (
    [ItemImageId] BIGINT         IDENTITY (1, 1) NOT NULL,
    [ProductId]   BIGINT         NOT NULL,
    [ImagePath]   NVARCHAR (100) NULL,
    CONSTRAINT [PK_ProductImage] PRIMARY KEY CLUSTERED ([ItemImageId] ASC),
    CONSTRAINT [FK_ProductImage_Products] FOREIGN KEY ([ProductId]) REFERENCES [dbo].[Products] ([ProductId])
);



