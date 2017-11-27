CREATE TABLE [dbo].[OrdemItem](
	[OrdemItemId] [int] IDENTITY(1,1) NOT NULL,
	[OrdemId] [int] NOT NULL,
	[ServicoId] [int] NOT NULL,
	[Valor] [decimal](18, 2) NOT NULL,
	[Quantidade] [int] NOT NULL,
 CONSTRAINT [PK_OrdemItem] PRIMARY KEY CLUSTERED 
(
	[OrdemItemId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[OrdemItem]  WITH CHECK ADD  CONSTRAINT [FK_OrdemItem_Ordem] FOREIGN KEY([OrdemId])
REFERENCES [dbo].[Ordem] ([OrdemId])
GO

ALTER TABLE [dbo].[OrdemItem] CHECK CONSTRAINT [FK_OrdemItem_Ordem]
GO

ALTER TABLE [dbo].[OrdemItem]  WITH CHECK ADD  CONSTRAINT [FK_OrdemItem_Servico] FOREIGN KEY([ServicoId])
REFERENCES [dbo].[Servico] ([ServicoId])
GO

ALTER TABLE [dbo].[OrdemItem] CHECK CONSTRAINT [FK_OrdemItem_Servico]
GO