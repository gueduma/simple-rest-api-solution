using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace rest_api.Entity
{
	public class Genero
	{
		[Key]
		public Int64 Genero_id { get; set; }
		public string Descricao { get; set; }
	}
}
