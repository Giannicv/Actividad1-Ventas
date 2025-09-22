using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppBlazor.Entities
{
    public class ClienteCLS
    {
        [Required(ErrorMessage = "El código de cliente es requerido")]
        public int? CodigoCliente { get; set; }

        [Required(ErrorMessage = "El nombre del cliente es obligatorio")]
        public string NombreCliente { get; set; } = string.Empty;

        [Range(1, int.MaxValue, ErrorMessage = "Debe seleccionar un representante")]
        public int RepresentanteId { get; set; }

        [Required(ErrorMessage = "El límite de crédito es requerido")]
        [Range(0, double.MaxValue, ErrorMessage = "El límite de crédito debe ser positivo")]
        public decimal? LimiteCredito { get; set; }
    }

}
