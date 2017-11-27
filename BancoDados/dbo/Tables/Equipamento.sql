CREATE TABLE [dbo].[Equipamento](
	[EquipamentoId] [int] IDENTITY(1,1) NOT NULL,
	[ClienteId] [int] NULL,
	[Modelo] [varchar](50) NOT NULL,
	[Tipo] [varchar](50) NOT NULL,
	[Marca] [varchar](50) NOT NULL,
	[Ano] [int] NOT NULL,
	[NumeroSerie] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Equipamento] PRIMARY KEY CLUSTERED 
(
	[EquipamentoId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[Equipamento]  WITH CHECK ADD  CONSTRAINT [FK_Equipamento_Cliente] FOREIGN KEY([ClienteId])
REFERENCES [dbo].[Cliente] ([ClienteId])
GO

ALTER TABLE [dbo].[Equipamento] CHECK CONSTRAINT [FK_Equipamento_Cliente]
GO
