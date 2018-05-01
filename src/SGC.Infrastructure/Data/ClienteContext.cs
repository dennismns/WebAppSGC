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

			modelBuilder.Entity<Endereco>().ToTable("Endereco");

			modelBuilder.Entity<Profissao>().ToTable("Profissao");

			modelBuilder.Entity<ProfissaoCliente>().ToTable("ProfissaoCliente");

			#region Configuraçoes de cliente

			modelBuilder.Entity<Cliente>()
				.HasKey(c => c.ClienteID);


			modelBuilder.Entity<Cliente>()
				.HasMany(c => c.Contatos)
				.WithOne(c => c.Cliente)
				.HasForeignKey(c => c.ClienteId)
				.HasPrincipalKey(c => c.ClienteID);
				


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
				.HasOne(c => c.Cliente)
				.WithMany(c => c.Contatos)
				.HasForeignKey(c => c.ClienteId)
				.HasPrincipalKey(c => c.ClienteID);
				



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

			#region configurações de Profissao

			modelBuilder.Entity<Profissao>()
				.Property(p => p.Nome)
				.HasColumnType("varchar(400)")
				.IsRequired();


			modelBuilder.Entity<Profissao>()
				.Property(p => p.CBO)
				.HasColumnType("varchar(10)")
				.IsRequired();

			modelBuilder.Entity<Profissao>()
				.Property(p => p.Descricao)
				.HasColumnType("varchar(1000)")
				.IsRequired();

			#endregion

			#region Configurações de Endereço

			modelBuilder.Entity<Endereco>()
				.Property(e => e.Bairro)
				.HasColumnType("varchar(200)")
				.IsRequired();

			modelBuilder.Entity<Endereco>()
				.Property(e => e.CEP)
				.HasColumnType("varchar(15)")
				.IsRequired();

			modelBuilder.Entity<Endereco>()
				.Property(e => e.Logradouro)
				.HasColumnType("varchar(200)")
				.IsRequired();


			modelBuilder.Entity<Endereco>()
				.Property(e => e.Logradouro)
				.HasColumnType("varchar(400)");


			#endregion


			#region configurações de profissao cliente

			modelBuilder.Entity<ProfissaoCliente>()
				.HasKey(c => c.Id);

			modelBuilder.Entity<ProfissaoCliente>()
				.HasOne(pc => pc.Cliente)
				.WithMany(c => c.ProfissoesClientes)
				.HasForeignKey(c => c.ClienteId);

			modelBuilder.Entity<ProfissaoCliente>()
				.HasOne(pc => pc.Profissao)
				.WithMany(c => c.ProfissoesClientes)
				.HasForeignKey(c => c.ProfissaoID);
			#endregion


			#region configuraçoes Menu

			modelBuilder.Entity<Menu>()
				.HasMany(x => x.SubMenu)
				.WithOne()
				.HasForeignKey(x => x.MenuId);

			#endregion

		}


	}
}
