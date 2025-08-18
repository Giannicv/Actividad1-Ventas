using AppBlazor.Entities;
using System.ComponentModel.DataAnnotations;
using Xunit;
namespace AppBlazor.test
{
    public class VentaFormTest
    {
        private List<ValidationResult> ValidarModelo(object modelo)
        {
            var resultados = new List<ValidationResult>();
            var contexto = new ValidationContext(modelo,null,null);
            Validator.TryValidateObject(modelo, contexto, resultados, true);
            return resultados;
        }
        [Fact]
        public void ValidacionFallaCuandoCamposVacios()
        {
            var venta = new VentasCLS();

            var errores = ValidarModelo(venta);

            Assert.Contains(errores, e => e.ErrorMessage!.Contains("El número de empleado es requerido"));

            Assert.Contains(errores, e => e.ErrorMessage!.Contains("El nombre es requerido"));

            Assert.Contains(errores, e => e.ErrorMessage!.Contains("La edad debe ser un número mayor o igual a 18"));

            Assert.Contains(errores, e => e.ErrorMessage!.Contains("El cargo es requerido"));

            Assert.Contains(errores, e => e.ErrorMessage!.Contains("La fecha de contrato es requerida"));

            Assert.Contains(errores, e => e.ErrorMessage!.Contains("La cuota es requerida"));

            Assert.Contains(errores, e => e.ErrorMessage!.Contains("Las ventas son requeridas"));

        }
        [Fact]
        public void ValidacionDatosCorrectos()
        {
            var venta = new VentasCLS
            {
                Num_Empl = 1,
                Nombre = "Erick Chambi",
                Edad = 18,
                Cargo = "Vendedor",
                FechaContrato = new DateTime(2025, 5, 10),
                Cuota = 60,
                Ventas = 10
            };

            var errores = ValidarModelo(venta);

            Assert.Empty(errores);
        }
    }
}