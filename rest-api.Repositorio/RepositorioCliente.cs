using rest_api.Data.Contexto;
using rest_api.Data.Interfaces;
using rest_api.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace rest_api.Repository
{
	public class RepositorioCliente
	{
		private IContexto _contexto;
		public RepositorioCliente(IContexto contexto)
		{
			_contexto = contexto;
		}

		public void Adicionar(Cliente cliente)
		{
			_contexto.Add(cliente);
		}

		public Cliente Selecionar(string cpf)
		{
			return _contexto.Find<Cliente>(cpf);
		}

		public void Atualizar(Cliente atualizado)
		{
			_contexto.Update(atualizado);
		}

		public void SalvarTudo()
		{
			_contexto.SaveChanges();
		}
	}
}
