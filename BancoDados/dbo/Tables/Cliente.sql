CREATE TABLE [dbo].[Cliente] (
    [ClienteId]        INT            IDENTITY (1, 1) NOT NULL,
    [Nome]      NVARCHAR (255) NULL,
    [Endereco]  TEXT           NULL,
    [Telefone]  NVARCHAR (50)  NULL,
    [Documento] NVARCHAR (14)  NULL,
    CONSTRAINT [PK_Cliente] PRIMARY KEY CLUSTERED ([ClienteId] ASC)
);

