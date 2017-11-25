CREATE TABLE [dbo].[Equipamento] (
    [EquipamentoId]          INT            IDENTITY (1, 1) NOT NULL,
    [Modelo]      NVARCHAR (255) NULL,
    [Marca]       NVARCHAR (255) NULL,
    [Ano]         DATETIME       NULL,
    [NumeroSerie] NVARCHAR (255) NULL,
    [IdCliente]   INT            NULL,
    [IdOrdem]	  INT            NULL,

    CONSTRAINT [PK_Equipamento] PRIMARY KEY CLUSTERED ([EquipamentoId] ASC),
	CONSTRAINT [FK_Equipamento_Cliente] FOREIGN KEY ([IdCliente]) REFERENCES [dbo].[Cliente] ([ClienteId]),
	);
