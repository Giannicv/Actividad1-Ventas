using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppBlazor.Entities
{
    public class SucursalListCLS
    {
        public int idsucursal { get; set; }
        public string CodigoSucursal { get; set; } = string.Empty;
        
        public string Ciudad { get; set; } = string.Empty;
        public string Region { get; set; } = string.Empty;
        public int idjefe { get; set; }
        public string DirectorNombre { get; set; } = string.Empty;
        public decimal ObjetivoVenta { get; set; }
        public decimal VentasReales { get; set; }
    }
}
