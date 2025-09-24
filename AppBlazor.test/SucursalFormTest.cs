using AppBlazor.Entities;
using System.ComponentModel.DataAnnotations;
using Xunit;
using System.Collections.Generic;

namespace AppBlazor.test
{
    public class SucursalFormTest
    {
        private List<ValidationResult> ValidarModelo(object modelo)
        {
            var resultados = new List<ValidationResult>();
            Validator.TryValidateObject(modelo, new ValidationContext(modelo), resultados, true);
            return resultados;
        }

        [Fact]
        public void ValidacionFallaCamposVacios()
        {
            var sucursal = new Sucursal();
            var errores = ValidarModelo(sucursal);
            Assert.Contains(errores, e => e.ErrorMessage == "El código de sucursal es requerido");
            Assert.Contains(errores, e => e.ErrorMessage == "El nombre de la sucursal es obligatorio");
            Assert.Contains(errores, e => e.ErrorMessage == "La ciudad es obligatoria");
            Assert.Contains(errores, e => e.ErrorMessage == "La región es obligatoria");
            Assert.Contains(errores, e => e.ErrorMessage == "Debe seleccionar un director");
            Assert.Contains(errores, e => e.ErrorMessage == "El objetivo de venta es requerido");
            Assert.Contains(errores, e => e.ErrorMessage == "Las ventas reales son requeridas");
        }

        [Fact]
        public void ValidacionCorrecta()
        {
            var sucursal = new Sucursal
            {
                CodigoSucursal = "C001",
                nombresucursal = "Sucursal Test",
                Ciudad = "Ciudad Test",
                Region = "Region Test",
                idjefe = 1,
                ObjetivoVenta = 1000m,
                VentasReales = 900m
            };
            var errores = ValidarModelo(sucursal);
            Assert.Empty(errores);
        }
    }
}
