using rest_api.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace rest_api.Data.Contexto
{
	public class UnidadeTrabalho
	{
		private IContexto _contexto;
		public UnidadeTrabalho(IContexto contexto)
		{
			_contexto = contexto;
		}

		public void SalvarTudo()
		{
			_contexto.SaveChanges();
		}
	}
}
