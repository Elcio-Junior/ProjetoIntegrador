using Modelo;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servico
{
    public class Contexto : DbContext
    {
        public Contexto() : base("DefaultConnection")
        {

        }

        public DbSet<Cliente> Clientes { get; set; }

        public DbSet<Equipamento> Equipamentoes { get; set; }

        public DbSet<Ordem> Ordens { get; set; }

        public DbSet<OrdemItem> OrdemItens { get; set; }

        public DbSet<TipoServico> TipoServicos { get; set; }

        public DbSet<ServicoP> Servicos { get; set; }
    }
}
