using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UCSMeuDinheiro.EF.Models
{
    internal class ContasBancarias
    {
        [Key]
        public int NumeroConta { get; set; }

        public decimal? Saldo { get; set; }

        public int? ClienteId { get; set; }
    }
}
