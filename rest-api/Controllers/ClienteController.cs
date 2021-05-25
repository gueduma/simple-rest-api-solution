using Microsoft.AspNetCore.Mvc;
using rest_api.Business.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace rest_api.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class ClienteController : Controller
	{
		ServicoContaCorrente _servicoContaCorrente;
		public ClienteController(ServicoContaCorrente servicoContaCorrente)
		{
			_servicoContaCorrente = servicoContaCorrente;
			//_repositorioCliente = new ServicoContaCorrente(new Data.Contexto.Contexto());
		}

		public IActionResult Get()
		{
			_servicoContaCorrente.AdicionarOuAtualizarCliente(
				new Entity.Cliente()
				{
					CPF = "42827626837",
					Nome = "Guilherme",
					Genero_id = 9,
					//Genero = new Entity.Genero()
					//{
					//	Genero_id = 0,
					//	Descricao = "Outra nova definição de Genero",
					//},
					Atualizado_em = DateTime.Now
				});

			return Ok("Criado");
		}
	}
}
