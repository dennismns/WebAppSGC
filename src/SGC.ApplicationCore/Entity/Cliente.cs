using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SGC.ApplicationCore.Entity
{
    public class Cliente
    {
		public Cliente()
		{
		}

		[Key]
		public int ClienteID { get; set; }

		public string Nome { get; set; }

		public string CPF { get; set; }

		public ICollection<Contato> Contatos { get; set; }

		public Endereco Endereco { get; set; }

		public ICollection<ProfissaoCliente> ProfissoesClientes { get; set; }
	}
}
