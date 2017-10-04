﻿using Modelo;
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

        public System.Data.Entity.DbSet<Modelo.Equipamento> Equipamentoes { get; set; }

        public System.Data.Entity.DbSet<Modelo.Ordem> Ordems { get; set; }
    }
}
