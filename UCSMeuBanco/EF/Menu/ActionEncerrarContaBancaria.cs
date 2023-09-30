using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UCSMeuDinheiro.EF.Context;

namespace UCSMeuDinheiro.EF.Menu
{
    internal class ActionEncerrarContaBancaria : IAction
    {
        public void Run()
        {
            Console.WriteLine("--- Encerramento de Conta Bancária ---");

            Console.WriteLine("Digite o número da conta bancária que você deseja encerrar: ");
            string entrada = Console.ReadLine();

            int numConta = int.Parse(entrada ?? "0");

            MeuDinheiroContext ctx = new();

            var conta = ctx.ContasBancarias.Where(x => x.NumeroConta == numConta).FirstOrDefault();

            if (conta != null)
            {
                ctx.ContasBancarias.Remove(conta);

                ctx.SaveChanges();

                Console.WriteLine("Conta encerrada com sucesso!");
            }
            else
            {
                Console.WriteLine("Conta não encontrada. Verifique o número e tente novamente!");
            }
            Console.WriteLine();
        }
    }
}
