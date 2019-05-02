CREATE TABLE [dbo].[Notes] (
    [Id]                 BIGINT         IDENTITY (1, 1) NOT NULL,
    [NotesDate]          DATETIME       NOT NULL,
    [NotesCategoryId]    BIGINT         NOT NULL,
    [Description]        NVARCHAR (MAX) NOT NULL,
    [IsOpen]             BIT            NOT NULL,
    [Amount]             DECIMAL (9, 2) NULL,
    [RecCreatedDate]     DATETIME       NOT NULL,
    [RecLastUpdatedDate] DATETIME       NOT NULL,
    [RecCreatedBy]       NVARCHAR (128) NOT NULL,
    [RecLastUpdatedBy]   NVARCHAR (128) NOT NULL,
    CONSTRAINT [PK_Notes] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Notes_NotesCategory] FOREIGN KEY ([NotesCategoryId]) REFERENCES [dbo].[NotesCategory] ([Id])
);

