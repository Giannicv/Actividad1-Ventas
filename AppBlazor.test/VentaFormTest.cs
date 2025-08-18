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
        public void ValidarCampos()
        {

        }
    }
}