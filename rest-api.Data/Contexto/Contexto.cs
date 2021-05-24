using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;
using rest_api.Data.Interfaces;
using rest_api.Entity;
using System;

namespace rest_api.Data.Contexto
{
	public class Contexto : DbContext, IContexto, IDisposable
	{
		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlServer(@"Data Source=DESKTOP-NLK4LPH\SQDSC001;Initial Catalog=rest-api;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
		}

		public DbSet<Cliente> Cliente { get; set; }
		public DbSet<Genero> Genero { get; set; }
	}
}
