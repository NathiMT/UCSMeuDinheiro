using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UCSMeuDinheiro.EF.Models
{
    internal class Clientes
    {
        [Key]
        public int Id { get; set; }

        public string? Nome { get; set; }

        public string? Sobrenome { get; set; }
    }
}
