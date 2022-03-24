using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace WebApplication2.Models
{
    public class Contexto: DbContext
    {

        public DbSet<Cliente> Clientes { get; set; }

        public System.Data.Entity.DbSet<WebApplication2.Models.Destino> Destinoes { get; set; }

        public System.Data.Entity.DbSet<WebApplication2.Models.Promocoes> Promocoes { get; set; }
    }
}