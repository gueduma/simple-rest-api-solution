using Microsoft.EntityFrameworkCore;
using rest_api.Data.Interfaces;
using rest_api.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace rest_api.Tests.Support
{
	public class ContextoTeste : DbContext, IContexto, IDisposable
	{
        private List<Genero> _genero;
        private List<Cliente> _cliente; 
		public ContextoTeste(List<Genero> genero, List<Cliente> cliente)
		{
            _genero = genero;
            _cliente = cliente;
		}

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseInMemoryDatabase("Teste1234567");
		}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Genero>().HasData(_genero.ToArray());

            modelBuilder.Entity<Cliente>().HasData(_cliente.ToArray());
        }

        public DbSet<Cliente> Cliente { get; set; }
		public DbSet<Genero> Genero { get; set; }
	}
}
