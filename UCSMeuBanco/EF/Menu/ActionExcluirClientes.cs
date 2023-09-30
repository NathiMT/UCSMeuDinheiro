using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UCSMeuDinheiro.EF.Context;
using UCSMeuDinheiro.EF.Models;

namespace UCSMeuDinheiro.EF.Menu
{
    internal class ActionExcluirClientes : IAction
    {
        public void Run()
        {
            Console.WriteLine("--- Exclusão de Clientes ---");

            Console.WriteLine("Digite o código do cliente que você deseja excluir: ");
            string entrada = Console.ReadLine();

            int idCliente = int.Parse(entrada ?? "0");

            MeuDinheiroContext ctx = new();

            var cliente = ctx.Clientes.Where(x => x.Id == idCliente).FirstOrDefault();

            if (cliente != null) 
            {
                ctx.Clientes.Remove(cliente);

                ctx.SaveChanges();

                Console.WriteLine("Cliente excluído com sucesso!");
            }
            else
            {
                Console.WriteLine("Cliente não encontrado. Verifique o código e tente novamente!");
            }
            Console.WriteLine();
        }
    }
}
