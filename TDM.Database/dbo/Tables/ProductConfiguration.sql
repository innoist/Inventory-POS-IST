CREATE TABLE [dbo].[ProductConfiguration] (
    [Id]                 BIGINT          IDENTITY (1, 1) NOT NULL,
    [MaxAllowedDiscount] TINYINT         CONSTRAINT [DF_ProductConfiguration_MaxAllowedDiscount] DEFAULT ((0)) NOT NULL,
    [Emails]             NVARCHAR (MAX)  NULL,
    [SecurityPassword]   NVARCHAR (100)  NULL,
    [ProductCodePrefix]  NVARCHAR (20)   NULL,
    [Comments]           NVARCHAR (1000) NULL,
    [RecCreatedDate]     DATETIME        NOT NULL,
    [RecLastUpdatedDate] DATETIME        NOT NULL,
    [RecCreatedBy]       NVARCHAR (128)  NOT NULL,
    [RecLastUpdatedBy]   NVARCHAR (128)  NOT NULL,
    [DefaultVendorId]    BIGINT          NULL,
    CONSTRAINT [PK_ProductConfiguration] PRIMARY KEY CLUSTERED ([Id] ASC)
);

