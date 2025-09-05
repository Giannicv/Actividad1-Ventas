using System;
using System.ComponentModel.DataAnnotations;

namespace AppBlazor.Entities
{
    public class VentaCLS
    {
        [Required(ErrorMessage = "El número de empleado es requerido")]
        public int? Num_Empl { get; set; }

        [Required(ErrorMessage = "El nombre es obligatorio")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "La edad es requerida")]
        [Range(18, 120, ErrorMessage = "La edad debe ser un número mayor o igual a 18")]
        public int? Edad { get; set; }

        [Required(ErrorMessage = "El cargo es requerido")]
        public string Cargo { get; set; }

        [Required(ErrorMessage = "La fecha de contrato es requerida")]
        public DateTime? FechaContrato { get; set; }

        [Required(ErrorMessage = "La cuota es requerida")]
        [Range(0, double.MaxValue, ErrorMessage = "La cuota debe ser un valor numérico positivo")]
        public decimal? Cuota { get; set; }

        [Required(ErrorMessage = "Las ventas son requeridas")]
        [Range(0, double.MaxValue, ErrorMessage = "Las ventas deben ser un valor numérico positivo")]
        public decimal? Ventas { get; set; }

        //
        [Range (1,int.MaxValue, ErrorMessage = "Debe seleccionar una sucursal")]
        public int idsucursal { get; set; }
        [Range(1, int.MaxValue, ErrorMessage = "Debe seleccionar un jefe")]
        public int idjefe { get; set; }
    }
}
