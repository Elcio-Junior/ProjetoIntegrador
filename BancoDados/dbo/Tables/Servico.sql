CREATE TABLE [dbo].[Servico](
	[ServicoId] [int] IDENTITY(1,1) NOT NULL,
	[TipoServicoId] [int] NOT NULL,
	[Descricao] [varchar](150) NOT NULL,
	[Valor] [decimal](18, 2) NULL,
 CONSTRAINT [PK_Servico] PRIMARY KEY CLUSTERED 
(
	[ServicoId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[Servico]  WITH CHECK ADD  CONSTRAINT [FK_Servico_TipoServico] FOREIGN KEY([TipoServicoId])
REFERENCES [dbo].[TipoServico] ([TipoServicoId])
GO

ALTER TABLE [dbo].[Servico] CHECK CONSTRAINT [FK_Servico_TipoServico]
GO

