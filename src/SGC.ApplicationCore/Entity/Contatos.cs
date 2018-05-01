using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SGC.ApplicationCore.Entity
{
    public class Contato 
    {
		public Contato ()
		{

		}

		[Key]
		public int ContatoId { get; set; }

		public string Nome { get; set; }

		public string Telefone { get; set; }

		public string Email { get; set; }

		public int ClienteId { get; set; }

		public Cliente Cliente { get; set; }
	}
}
