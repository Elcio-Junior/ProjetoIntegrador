CREATE TABLE [dbo].[Ordem] (
	
	[Id]				INT             IDENTITY (1, 1) NOT NULL, 
    [NumeroOS]			NVARCHAR(50) NOT NULL, 
    [DtAberturaOs]		DATETIME NULL, 
    [DtFechamentoOS]	DATETIME NULL, 
    [Status]			NVARCHAR(50) NULL, 
    [IdCliente]			INT NULL, 
    CONSTRAINT [PK_Ordem] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Ordem_Cliente] FOREIGN KEY ([IdCliente]) REFERENCES [dbo].[Cliente] ([Id])
	
);
