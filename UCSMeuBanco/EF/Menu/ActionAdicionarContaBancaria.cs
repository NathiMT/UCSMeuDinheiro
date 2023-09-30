using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UCSMeuDinheiro.EF.Context;
using UCSMeuDinheiro.EF.Models;

namespace UCSMeuDinheiro.EF.Menu
{
    internal class ActionAdicionarContaBancaria : IAction
    {
        public void Run()
        {
            Console.WriteLine("--- Inclusão de Contas Bancárias ---");

            Console.WriteLine("Digite o número da conta: ");
            string entradaNum = Console.ReadLine();

            int numConta = int.Parse(entradaNum ?? "0");

            Console.WriteLine("Digite o código do cliente: ");
            string entradaIdCliente = Console.ReadLine();

            int idCliente = int.Parse(entradaIdCliente ?? "0");

            MeuDinheiroContext ctx = new();

            ctx.ContasBancarias.Add(new ContasBancarias
            {
                NumeroConta = numConta,
                ClienteId = idCliente,
                Saldo = 0
            });

            ctx.SaveChanges();

            Console.WriteLine("Conta bancária adicionada com sucesso!");
            Console.WriteLine();
        }
    }
}
