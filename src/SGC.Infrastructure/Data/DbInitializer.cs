using SGC.ApplicationCore.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SGC.Infrastructure.Data
{
	public static class DbInitializer
	{
		public static void Initialize(ClienteContext context)
		{
			if (context.Clientes.Any())
			{
				
				return;
			}

			var clientes = new Cliente[]
			{
				new Cliente
				{
					Nome="Maria da silva",						   
					CPF = "26847646896",

				},

				new Cliente
				{
					Nome="João da silva",
					CPF = "57827738397",

				}
			};

			context.AddRange(clientes);
			var contatos = new Contato[]
			{
				new Contato
				{
					Nome="Contato 01",
					Telefone = "1136559874",
					Email="contato01@teste.com",
					Cliente= clientes[0]
				},

				new Contato
				{
					Nome="Contato 02",
					Telefone = "1136559874",
					Email="contato02@teste.com",
					Cliente= clientes[1]

				}
			};

			

			context.AddRange(contatos);

			context.SaveChanges();

		}

	}
}
