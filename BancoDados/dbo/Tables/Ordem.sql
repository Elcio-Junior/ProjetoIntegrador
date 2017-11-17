CREATE TABLE [dbo].[Ordem] (
	
    [OrdemId]			INT				IDENTITY (1, 1) NOT NULL, 
    [DtAberturaOs]		DATETIME							NULL, 
    [DtFechamentoOS]	DATETIME							NULL, 
    [Status]			NVARCHAR(50)						NULL, 
    [Descricao]			TEXT								NULL, 
    [IdCliente]			INT									NOT NULL,
	[IdEquipamento]		INT									NOT NULL,
	[IdServico]			INT									NOT NULL,

    CONSTRAINT [PK_Ordem] PRIMARY KEY CLUSTERED ([OrdemId] ASC),
    CONSTRAINT [FK_Ordem_Cliente] FOREIGN KEY ([IdCliente]) REFERENCES [dbo].[Cliente] ([ClienteId]),
    CONSTRAINT [FK_Ordem_Equipamento] FOREIGN KEY ([IdEquipamento]) REFERENCES [dbo].[Equipamento] ([EquipamentoId]),
    CONSTRAINT [FK_Ordem_Servico] FOREIGN KEY ([IdServico]) REFERENCES [dbo].[Servico] ([ServicoId])
);
