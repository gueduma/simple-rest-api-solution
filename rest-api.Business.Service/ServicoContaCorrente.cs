using AutoMapper;
using rest_api.Data.Contexto;
using rest_api.Data.Interfaces;
using rest_api.Entity;
using rest_api.Repository;
using System;

namespace rest_api.Business.Service
{
	public class ServicoContaCorrente : UnidadeTrabalho
	{
		private RepositorioCliente _repositorioCliente;
		private IMapper _mapper;
		public ServicoContaCorrente(IContexto contexto, IMapper mapper) : base(contexto)
		{
			_repositorioCliente = new RepositorioCliente(contexto);
			_mapper = mapper;
		}

		public void AdicionarOuAtualizarCliente(Cliente novo)
		{
			var clienteCadastrado = _repositorioCliente.Selecionar(novo.CPF);
			
			if (clienteCadastrado != null)
			{
				_mapper.Map(novo, clienteCadastrado);
				clienteCadastrado.Atualizado_em = DateTime.Now;
				_repositorioCliente.Atualizar(clienteCadastrado);
			}
			else
			{
				_repositorioCliente.Adicionar(novo);
			}

			SalvarTudo();
		}

		public Cliente PegarCliente(string cpf)
		{
			return _repositorioCliente.Selecionar(cpf);
		}
	}
}
