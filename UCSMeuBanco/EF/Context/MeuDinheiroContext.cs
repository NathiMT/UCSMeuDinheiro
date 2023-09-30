using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using UCSMeuDinheiro.EF.Models;

namespace UCSMeuDinheiro.EF.Context
{
    internal class MeuDinheiroContext : DbContext
    {
        public DbSet<Clientes> Clientes { get; set; }

        public DbSet<ContasBancarias> ContasBancarias { get; set; }

        public DbSet<Extratos> Extratos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string connectionString = "Server=localhost;User Id=sa;Password=blog_6109;Database=MeuDinheiro;TrustServerCertificate=True";
            optionsBuilder.UseSqlServer(connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("dbo");
            base.OnModelCreating(modelBuilder);
        }

        public static void Test1()
        {
            MeuDinheiroContext ctx = new();

            var cliente = ctx.Clientes;

            foreach (var item in cliente)
            {
                Console.WriteLine($"Cliente: {item.Id} - {item.Nome} {item.Sobrenome}");
            }
        }

        public static void Test2()
        {
            MeuDinheiroContext ctx = new();

            var conta = ctx.ContasBancarias;

            foreach (var item in conta)
            {
                Console.WriteLine($"Conta: {item.NumeroConta} - {item.Saldo} - Cliente: {item.ClienteId}");
            }
        }

        public static void Test3()
        {
            MeuDinheiroContext ctx = new();

            var extrato = ctx.Extratos;

            foreach (var item in extrato)
            {
                Console.WriteLine($"Conta: {item.NumeroConta} - Movimento: {item.Valor} - {item.Descricao} - Data e Hora do Movimento: {item.DataHoraMovimento}");
            }
        }
    }
}
