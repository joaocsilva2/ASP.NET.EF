using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class ContextoEF : DbContext, IDisposable
    {
        public ContextoEF() : base(ConfigurationManager.ConnectionStrings["SqlConnection"].ConnectionString)
        {

        }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Dependente> Dependentes { get; set; }

        public DbSet<UF> UF { get; set; }
        public DbSet<Cidade> Cidades { get; set; }
    }
}
