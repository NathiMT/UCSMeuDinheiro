using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UCSMeuDinheiro.EF.Context;

namespace UCSMeuDinheiro.EF.Menu
{
    internal class ActionListarExtrato : IAction
    {
        public void Run()
        {
            Console.WriteLine("--- Extrato Bancário ---");
            Console.WriteLine("Digite o número da conta que você deseja visualizar o extrato: ");
            string entrada = Console.ReadLine();

            int numConta = int.Parse(entrada ?? "0");

            MeuDinheiroContext ctx = new();

            var extrato = ctx.Extratos.Where(x => x.NumeroConta == numConta).ToList();

            if (extrato.Count > 0)
            {
                foreach (var item in extrato)
                {
                    Console.WriteLine($"{item.Valor} - {item.Descricao} - Data e Hora do Movimento: {item.DataHoraMovimento}");
                }
            }
            else
            {
                Console.WriteLine($"Nenhum movimento encontrado para a conta {numConta}!");

            }
            Console.WriteLine();
        }
    }
}
