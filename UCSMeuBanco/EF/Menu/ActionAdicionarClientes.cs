using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UCSMeuDinheiro.EF.Context;
using UCSMeuDinheiro.EF.Models;

namespace UCSMeuDinheiro.EF.Menu
{
    internal class ActionAdicionarClientes : IAction
    {
        public void Run()
        {
            Console.WriteLine("--- Inclusão de Clientes ---");

            Console.WriteLine("Digite o nome do cliente: ");
            string entradaNome = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(entradaNome))
            {
                throw new Exception("O nome é obrigatório!");
            }

            Console.WriteLine("Digite o sobrenome do cliente: ");
            string entradaSobrenome = Console.ReadLine();
                      
            MeuDinheiroContext ctx = new();

            ctx.Clientes.Add(new Clientes
            {
                Nome = entradaNome,
                Sobrenome = entradaSobrenome
            });

            ctx.SaveChanges();

            Console.WriteLine("Cliente adicionado com sucesso!");
            Console.WriteLine();
        }
    }
}
