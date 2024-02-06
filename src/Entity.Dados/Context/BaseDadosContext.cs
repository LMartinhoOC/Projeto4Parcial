using Entity.Dados.Mappings;
using Entity.Entidades;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Dados.Context
{
    public class BaseDadosContext : DbContext
    {        
        public BaseDadosContext(DbContextOptions<BaseDadosContext> options)
            : base(options)
        {
        }

        public DbSet<Cliente> Clientes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ClienteMapping());
        }
    }
}
