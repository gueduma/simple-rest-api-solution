using AutoMapper;
using BoDi;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using rest_api.Business.Service;
using rest_api.Data.Interfaces;
using rest_api.Data.Mapper;
using rest_api.Entity;
using rest_api.Tests.Support;
using System;
using System.Collections.Generic;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace rest_api.Tests.Steps
{
	[Binding]
	public class AtualizacaoDeClienteSteps
	{

		private List<Cliente> _tabelaCliente;
		private List<Genero> _tabelaGenero;
		private ServicoContaCorrente _servico;
		private Cliente _clienteTestes;
		private ContextoTeste _contexto;
		private IObjectContainer _container;

		public AtualizacaoDeClienteSteps(IObjectContainer container)
		{
			_container = container;
		}

		public void Setup()
		{
			var mconfig = new MapperConfiguration(cfg => cfg.AddProfile(new ClienteProfile()));
			var mapper = mconfig.CreateMapper();

			_contexto = new ContextoTeste(_tabelaGenero, _tabelaCliente);
			_contexto.Database.EnsureCreated();

			_container.RegisterInstanceAs<IMapper>(mapper);
			_container.RegisterInstanceAs<IContexto>(_contexto);
			_servico = _container.Resolve<ServicoContaCorrente>();
		}

		[Given(@"que eu queira atualizar um cliente")]
		public void DadoQueEuQueiraAtualizarUmCliente()
		{
			//ScenarioContext.Current.Pending();
		}

		[Given(@"que a tabela de genero esteja com o seguinte estado")]
		public void DadoQueATabelaDeGeneroEstejaComOSeguinteEstado(Table table)
		{
			_tabelaGenero = (List<Genero>)table.CreateSet(ConverteTabelaGenero);
		}

		[Given(@"que a tabela de clientes esteja com o seguinte estado")]
		public void DadoQueATabelaDeClientesEstejaComOSeguinteEstado(Table table)
		{
			_tabelaCliente = (List<Cliente>)table.CreateSet(ConverteTabelaCliente);

			_clienteTestes = ((List<Cliente>)table.CreateSet(ConverteTabelaCliente))[0];

			Setup();
		}

		public static Cliente ConverteTabelaCliente(TableRow row)
		{
			return new Cliente()
			{
				CPF = row["CPF"].ToString(),
				Nome = row["CPF"].ToString(),
				Genero_id = Convert.ToInt32(row["Genero_id"]),
				Atualizado_em = Convert.ToDateTime(row["Atualizado_em"] == "NULL" ? null : row["Atualizado_em"])
			};
		}

		public static Genero ConverteTabelaGenero(TableRow row)
		{
			return new Genero()
			{
				Genero_id = Convert.ToInt32(row["Genero_id"]),
				Descricao = row["Descricao"].ToString()
			};
		}

		[When(@"atualizo o genero do cliente '(.*)' para (.*)")]
		public void QuandoAtualizoOGenenoDoClientePara(string CPF, int genero)
		{
			_clienteTestes.Genero_id = genero;
			_servico.AdicionarOuAtualizarCliente(_clienteTestes);
		}

		[Then(@"o registro do cliente deveria ficar da seguinte forma")]
		public void EntaoORegistroDoClienteDeveriaFicarDaSeguinteForma(Table table)
		{
			List<Cliente> clienteEsperado = (List<Cliente>)table.CreateSet(ConverteTabelaCliente);

			var clienteBase = _servico.PegarCliente(clienteEsperado[0].CPF);

			Assert.AreEqual(clienteEsperado[0].Genero_id, clienteBase.Genero_id);
			Assert.AreEqual(clienteEsperado[0].Nome, clienteBase.Nome);
		}
	}
}
