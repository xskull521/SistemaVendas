using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaVendas.Dominio.Entidades
{
    public class HistoricoVendas
    {
        public int IdHistorico { get; set; }
        public int ClienteId { get; set; }
        public int IdProduto { get; set; }
        public string TipoPagamento { get; set; }
    }
}
