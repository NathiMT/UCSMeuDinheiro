using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UCSMeuDinheiro.EF.Menu
{
    internal class ActionSair : IAction
    {
        public void Run() 
        {
            Environment.Exit(0);
        }
    }
}
