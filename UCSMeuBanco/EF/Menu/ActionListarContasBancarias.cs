using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UCSMeuDinheiro.EF.Context;
using UCSMeuDinheiro.EF.Models;

namespace UCSMeuDinheiro.EF.Menu
{
    internal class ActionListarContasBancarias : IAction
    {
        public void Run()
        {
            Console.WriteLine("--- Listagem de Contas ---");
            Console.WriteLine("Digite o código do cliente que você deseja buscar as contas: ");
            string entrada = Console.ReadLine();

            int idCliente = int.Parse(entrada ?? "0");

            MeuDinheiroContext ctx = new();

            var conta = ctx.ContasBancarias.Where(x => x.ClienteId == idCliente).ToList();

            if (conta.Count > 0)
            {
                foreach (var item in conta)
                {
                    Console.WriteLine($"Conta: {item.NumeroConta} - {item.Saldo} - Cliente: {item.ClienteId}");
                }
            }
            else
            {
                Console.WriteLine($"Nenhuma conta encontrada para o código {idCliente}!");

            }
            Console.WriteLine();
        }
    }
}
