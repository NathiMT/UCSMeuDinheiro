using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UCSMeuDinheiro.EF.Context;
using UCSMeuDinheiro.EF.Models;

namespace UCSMeuDinheiro.EF.Menu
{
    internal class ActionAtualizarClientes : IAction
    {
        public void Run()
        {
            Console.WriteLine("--- Atualização de Clientes ---");

            Console.WriteLine("Digite o código do cliente que você deseja atualizar: ");
            string entrada = Console.ReadLine();

            int idCliente = int.Parse(entrada ?? "0");

            Console.WriteLine("Digite o nome do cliente: ");
            string entradaNome = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(entradaNome))
            {
                throw new Exception("O nome é obrigatório!");
            }

            Console.WriteLine("Digite o sobrenome do cliente: ");
            string entradaSobrenome = Console.ReadLine();

            MeuDinheiroContext ctx = new();

            var cliente = ctx.Clientes.Where(x => x.Id == idCliente).FirstOrDefault();

            if (cliente != null)
            {
                cliente.Nome = entradaNome;
                cliente.Sobrenome = entradaSobrenome;

                ctx.SaveChanges();

                Console.WriteLine("Cliente atualizado com sucesso!");
            }
            else
            {
                Console.WriteLine("Cliente não encontrado. Verifique o código e tente novamente!");
            }
            Console.WriteLine();
        }
    }
}
