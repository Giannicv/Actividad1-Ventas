using System;
using System.ComponentModel.DataAnnotations;

namespace AppBlazor.Entities
{
    public class VentasCLS
    {
        [Required(ErrorMessage = "El número de empleado es requerido")]
        public int Num_Empl { get; set; }

        [Required(ErrorMessage = "El nombre es requerido")]
        public string Nombre { get; set; } 

        [Range(18, 120, ErrorMessage = "La edad debe ser un número mayor o igual a 18")]
        public int Edad { get; set; }

        [Required(ErrorMessage = "El cargo es requerido")]
        public string Cargo { get; set; }

        [Required(ErrorMessage = "La fecha de contrato es requerida")]
        [DataType(DataType.Date, ErrorMessage = "La fecha de contrato debe ser una fecha válida")]
        public DateTime FechaContrato { get; set; }

        [Required(ErrorMessage = "La cuota es requerida")]
        [Range(0, double.MaxValue, ErrorMessage = "La cuota debe ser un valor numérico positivo")]
        public decimal Cuota { get; set; }

        [Required(ErrorMessage = "Las ventas son requeridas")]
        [Range(0, double.MaxValue, ErrorMessage = "Las ventas deben ser un valor numérico positivo")]
        public decimal Ventas { get; set; }
    }
}
