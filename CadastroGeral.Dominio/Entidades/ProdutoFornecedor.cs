using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaVendas.Dominio.Entidades
{
    public class ProdutoFornecedor
    {
        public int IdProdutoFornecedor { get; set; }
        public int IdFornecedor { get; set; }
        public int IdProduto { get; set; }
        public string NomeProduto { get; set; }
        public string Nomefornecedor { get; set; }
    }
}
