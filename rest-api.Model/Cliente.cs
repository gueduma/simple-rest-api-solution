using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace rest_api.Entity
{
	public class Cliente
	{
		[Key]
		public string CPF { get; set; }
		public string Nome { get; set; }
		public Int64 Genero_id { get; set; }
		//public Genero Genero { get; set; }
		public DateTime? Atualizado_em { get; set; }
	}
}
