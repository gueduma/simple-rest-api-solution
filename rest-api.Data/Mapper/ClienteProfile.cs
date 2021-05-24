using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using rest_api.Entity;

namespace rest_api.Data.Mapper
{
	public class ClienteProfile : Profile
	{
		public ClienteProfile()
		{
			CreateMap<Cliente, Cliente>();
		}
	}
}
