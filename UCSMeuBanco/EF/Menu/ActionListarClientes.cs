using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UCSMeuDinheiro.EF.Context;

namespace UCSMeuDinheiro.EF.Menu
{
    internal class ActionListarClientes : IAction
    {
        public void Run()
        {
            Console.WriteLine("--- Listagem de Clientes ---");

            MeuDinheiroContext ctx = new();

            var cliente = ctx.Clientes;

            foreach (var item in cliente)
            {
                Console.WriteLine($"{item.Id} - {item.Nome} {item.Sobrenome}");                
            }
            Console.WriteLine();
        }
    }
}
