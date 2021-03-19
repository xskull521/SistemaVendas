using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaVendas.Dominio.Entidades
{
    public class Fornecedor
    {
        public int IdFornecedor { get; set; }
        public int Cnpj { get; set; }
        public string Nome { get; set; }
        public string Endereço { get; set; }

    }
}
