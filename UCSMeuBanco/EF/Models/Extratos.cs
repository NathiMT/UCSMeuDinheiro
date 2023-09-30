using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UCSMeuDinheiro.EF.Models
{
    internal class Extratos
    {
        [Key]
        public int IdOrdem { get; set; }

        public int? NumeroConta { get; set; }

        public decimal? Valor { get; set; }

        public string? Descricao { get; set; }

        public DateTime? DataHoraMovimento { get; set; }
    }
}
