using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using rest_api.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace rest_api.Data.Interfaces
{
	public interface IContexto
	{
		DbSet<Cliente> Cliente { get; set; }
		DbSet<Genero> Genero { get; set; }
		int SaveChanges();

		EntityEntry<TEntity> Add<TEntity>(TEntity entity) where TEntity : class;

		TEntity Find<TEntity>(params object[] keyValues) where TEntity : class;

		EntityEntry Update(object entity);

	}
}
