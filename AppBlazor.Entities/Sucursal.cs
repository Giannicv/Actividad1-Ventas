using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppBlazor.Entities;
using System.ComponentModel.DataAnnotations;

namespace AppBlazor.Entities
{
    public class Sucursal
    {
        public int idsucursal { get; set; }

        [Required(ErrorMessage = "El código de sucursal es requerido")]
        public string CodigoSucursal { get; set; } = string.Empty;

        [Required(ErrorMessage = "La ciudad es obligatoria")]
        public string Ciudad { get; set; } = string.Empty;

        [Required(ErrorMessage = "La región es obligatoria")]
        public string Region { get; set; } = string.Empty;

        [Range(1, int.MaxValue, ErrorMessage = "Debe seleccionar un director")]
        public int idjefe { get; set; }
        public Jefe? Director { get; set; }

        [Required(ErrorMessage = "El objetivo de venta es requerido")]
        [Range(0, double.MaxValue, ErrorMessage = "El objetivo de venta debe ser positivo")]
        public decimal ObjetivoVenta { get; set; }

        [Required(ErrorMessage = "Las ventas reales son requeridas")]
        [Range(0, double.MaxValue, ErrorMessage = "Las ventas reales deben ser positivas")]
        public decimal VentasReales { get; set; }
    }
}
