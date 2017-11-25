USE [projetoElcio]
GO

INSERT INTO TipoServico (Descricao)
     VALUES ('Elétrico'), ('Mecânico'), ('Pintura'), ('Lanternagem')
           
GO

INSERT INTO Servico (TipoServicoId, Descricao,Valor)
     VALUES (1, 'Troca de Lampadas', 20.00),
			(2, 'Reparo no Cabeçote', 1000.00)	,
			(3, 'Retorque no Parachoque', 500.00),
			(4, 'Desamassar de Parachoque', 150.00)
GO

INSERT INTO Equipamento (ClienteId, Modelo, Tipo, Marca, Ano, NumeroSerie)
     VALUES (1, '924f', 'Pá Carregadeira','Catepillar','2016', 2016001),
			(1, '924f', 'Pá Carregadeira','Catepillar','2016', 2016002),
			(1, '924f', 'Pá Carregadeira','Catepillar','2016', 2016003)
GO

INSERT INTO Ordem ([ClienteId],[EquipamentoId],[Abertura],[Fechamento],[Descricao])
     VALUES (1, 2, '20171122 12:00:00',  null, 'Problema no Cabeçote do Motor')
           
GO

INSERT INTO OrdemItem (OrdemId, ServicoId, Valor, Quantidade)
     VALUES (7, 2, 800.00, 1)
           
GO

select *From Cliente
select *From Equipamento
select *From Ordem
select *From OrdemItem
select *From Servico
select *From TipoServico



UPDATE [dbo].[Cliente]
   SET 
      CNPJ = '25.285.999/0001-09',
      CPF = '017.548.701-47'

	  where ClienteId = 1
 
GO

