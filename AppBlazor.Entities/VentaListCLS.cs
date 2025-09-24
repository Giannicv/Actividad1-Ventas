using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppBlazor.Entities
{
    public class VentaListCLS
    {
        public int? num_Empl { get; set; }
        public string Nombre { get; set; }
        public int? Edad { get; set; }
        public string Cargo { get; set; }
        public DateTime? FechaContrato { get; set; }
        public decimal? Cuota { get; set; }
        public decimal? Ventas { get; set; }

        public string CodigoSucursal { get; set; } = string.Empty;
        public int idsucursal { get; set; }
        public string nombrejefe { get; set; } = string.Empty;

    }
}
