using Microsoft.EntityFrameworkCore;
using SGC.ApplicationCore.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace SGC.Infrastructure.Data
{
   public class ClienteContext: DbContext
    {
		public ClienteContext(DbContextOptions<ClienteContext> options) : base(options)
		{

		}

		public DbSet<Cliente> Clientes { get; set; }

		public DbSet<Contato> Contatos { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			//base.OnModelCreating(modelBuilder);

			modelBuilder.Entity<Cliente>().ToTable("Cliente");

			modelBuilder.Entity<Contato>().ToTable("Contato");


			#region Configuraçoes de cliente
			modelBuilder.Entity<Cliente>()
				.Property(c => c.Nome)
				.HasColumnType("varchar(200)")
				.IsRequired();

			modelBuilder.Entity<Cliente>()
				.Property(c => c.CPF)
				.HasColumnType("varchar(11)")
				.IsRequired();
			#endregion

			#region configuração Contato
			modelBuilder.Entity<Contato>()
				.Property(c => c.Nome)
				.HasColumnType("varchar(200)")
				.IsRequired();


			modelBuilder.Entity<Contato>()
				.Property(c => c.Email)
				.HasColumnType("varchar(100)")
				.IsRequired();

			modelBuilder.Entity<Contato>()
				.Property(c => c.Telefone)
				.HasColumnType("varchar(15)");


			#endregion


		}


	}
}
