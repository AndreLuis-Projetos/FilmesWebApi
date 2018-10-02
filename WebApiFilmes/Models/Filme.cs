using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiFilmes.Models
{
    public class Filme
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public DateTime AnoLancamento { get; set; }
        public int AvaliarFilme { get; set; }
    }
}
