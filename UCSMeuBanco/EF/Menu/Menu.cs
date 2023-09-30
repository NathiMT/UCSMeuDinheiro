using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UCSMeuDinheiro.EF.Menu
{
    internal class Menu
    {
        public List<MenuItem> MenuItems { get; set; } = new();
        public Menu()
        {
            MenuItems.Add(new MenuItem
            {
                Opcao = 0,
                Descricao = "Sair do Sistema",
                Action = new ActionSair()
            });

            MenuItems.Add(new MenuItem
            {
                Opcao = 1,
                Descricao = "Adicionar Cliente",
                Action = new ActionAdicionarClientes()
            });

            MenuItems.Add(new MenuItem
            {
                Opcao = 2,
                Descricao = "Listar Clientes",
                Action = new ActionListarClientes()
            });

            MenuItems.Add(new MenuItem
            {
                Opcao = 3,
                Descricao = "Deletar Cliente",
                Action = new ActionExcluirClientes()
            });

            MenuItems.Add(new MenuItem
            {
                Opcao = 4,
                Descricao = "Atualizar Cliente",
                Action = new ActionAtualizarClientes()
            });

            MenuItems.Add(new MenuItem
            {
                Opcao = 5,
                Descricao = "Adicionar Conta Bancária",
                Action = new ActionAdicionarContaBancaria()
            });

            MenuItems.Add(new MenuItem
            {
                Opcao = 6,
                Descricao = "Listar Contas",
                Action = new ActionListarContasBancarias()
            });

            MenuItems.Add(new MenuItem
            {
                Opcao = 7,
                Descricao = "Encerrar Conta Bancária",
                Action = new ActionEncerrarContaBancaria()
            });

            MenuItems.Add(new MenuItem 
            { 
                Opcao = 8,
                Descricao = "Extrato de Conta Bancária",
                Action = new ActionListarExtrato()
            });

            MenuItems.Add(new MenuItem 
            { 
                Opcao = 9, 
                Descricao = "Movimentar Conta Bancária",
                Action = new ActionMovimentarContaBancaria()
            });
        }

        public void Interact()
        {
            while (true)
            {
                foreach (var item in MenuItems)
                {
                    Console.Write($"{item.Opcao}) ");
                    Console.WriteLine(item.Descricao);
                }

                try
                {
                    string? entrada = Console.ReadLine();
                    int opcao = Convert.ToInt32(entrada);

                    var menu = MenuItems.Where(x => x.Opcao == opcao).FirstOrDefault();
                    if (menu == null)
                    {
                        throw new Exception("Opção inválida");
                    }

                    menu.Action?.Run();
                }
                catch (Exception exc)
                {
                    Console.WriteLine(exc.Message);
                }
            }
        }
    }
}
