using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UCSMeuDinheiro.EF.Context;
using UCSMeuDinheiro.EF.Models;

namespace UCSMeuDinheiro.EF.Menu
{
    internal class ActionMovimentarContaBancaria : IAction
    {
        public void Run()
        {
            using var ctxContaBancaria = new MeuDinheiroContext();
            using var ctxCliente = new MeuDinheiroContext();
            using var ctxMovimento = new MeuDinheiroContext();
            using var ctxExtrato = new MeuDinheiroContext();

            Console.WriteLine("--- Movimentação de Contas Bancárias ---");

            Console.WriteLine("Digite o número da conta que deseja realizar o movimento: ");
            string entradaNum = Console.ReadLine();

            int numConta = int.Parse(entradaNum ?? "0");

            var conta = ctxContaBancaria.ContasBancarias.Where(x => x.NumeroConta == numConta).FirstOrDefault();

            if (conta != null)
            {
                Console.WriteLine($"Conta Selecionada: {conta.NumeroConta} - {conta.Saldo} - Cliente: {conta.ClienteId}");
            }

            Console.WriteLine("Qual operação deseja realizar?");
            Console.WriteLine("1 - Saque");
            Console.WriteLine("2 - Depósito");
            string entradaOperacao = Console.ReadLine();

            if (entradaOperacao == "1" || entradaOperacao == "2")
            {
                string operacao = entradaOperacao == "1" ? "sacar" : "depositar";
                Console.WriteLine($"Qual valor deseja {operacao}?");
            }
            else
            {
                Console.WriteLine("Operação cancelada!");
                return;
            }

            string entradaValor = Console.ReadLine();
            decimal valor = decimal.Parse(entradaValor ?? "0");

            Console.WriteLine("Qual o motivo da movimentação?");
            string entradaMotivo = Console.ReadLine();

            if (entradaOperacao == "1")
            {
                valor = valor * -1;
            }

            Extratos extratos = new Extratos();
            extratos.NumeroConta = numConta;
            extratos.Descricao = entradaMotivo;
            extratos.Valor = valor;
            extratos.DataHoraMovimento = DateTime.Now;

            ctxExtrato.Extratos.Add(extratos);
            ctxExtrato.SaveChanges();

            var contaBancaria = ctxMovimento.ContasBancarias.Where(x => x.NumeroConta == numConta).First();

            contaBancaria.Saldo += valor;

            ctxMovimento.SaveChanges();

            Console.WriteLine("Conta movimentada com sucesso");
            Console.WriteLine();
        }
    }
}
