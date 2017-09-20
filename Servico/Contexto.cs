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
    }
}
