CREATE TABLE [dbo].[Ordem](
	[OrdemId] [int] IDENTITY(1,1) NOT NULL,
	[ClienteId] [int] NOT NULL,
	[EquipamentoId] [int] NOT NULL,
	[Abertura] [datetime] NULL,
	[Fechamento] [datetime] NULL,
	[Descricao] [text] NULL,
 CONSTRAINT [PK_Ordem] PRIMARY KEY CLUSTERED 
(
	[OrdemId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO

ALTER TABLE [dbo].[Ordem]  WITH CHECK ADD  CONSTRAINT [FK_Ordem_Cliente] FOREIGN KEY([ClienteId])
REFERENCES [dbo].[Cliente] ([ClienteId])
GO

ALTER TABLE [dbo].[Ordem] CHECK CONSTRAINT [FK_Ordem_Cliente]
GO

ALTER TABLE [dbo].[Ordem]  WITH CHECK ADD  CONSTRAINT [FK_Ordem_Equipamento] FOREIGN KEY([EquipamentoId])
REFERENCES [dbo].[Equipamento] ([EquipamentoId])
GO

ALTER TABLE [dbo].[Ordem] CHECK CONSTRAINT [FK_Ordem_Equipamento]
GO
