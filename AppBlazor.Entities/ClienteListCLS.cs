using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppBlazor.Entities
{
    public class ClienteListCLS
    {
        public int CodigoCliente { get; set; }
        public string NombreCliente { get; set; } = string.Empty;
        public int RepresentanteId { get; set; }
        public string RepresentanteNombre { get; set; } = string.Empty;
        public decimal LimiteCredito { get; set; }
    }
}
