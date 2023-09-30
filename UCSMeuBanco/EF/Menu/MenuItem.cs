using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UCSMeuDinheiro.EF.Menu
{
    internal class MenuItem
    {
        public int Opcao { get; set; }

        public string? Descricao { get; set; }

        public IAction? Action { get; set; }
    }
}
