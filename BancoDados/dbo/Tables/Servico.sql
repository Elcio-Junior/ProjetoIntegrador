CREATE TABLE [dbo].[Servico]
(
	[ServicoId] INT IDENTITY NOT NULL, 
    [NomeServico] VARCHAR(50) NULL, 
    [Tipo] VARCHAR(50) NULL, 
    [Descricao] TEXT NULL, 
    [DtCriada] NCHAR(10) NULL, 
    [DtAlterado] NCHAR(10) NULL, 
    [Valor] FLOAT NULL,

    CONSTRAINT [PK_Servico] PRIMARY KEY CLUSTERED ([ServicoId] ASC)
);
