using AppBlazor.Entities;
using System.ComponentModel.DataAnnotations;
using Xunit;
using System.Collections.Generic;

public class ClienteFormTest
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
        var cliente = new ClienteCLS();
        var errores = ValidarModelo(cliente);
        Assert.Contains(errores, e => e.ErrorMessage == "El código de cliente es requerido");
        Assert.Contains(errores, e => e.ErrorMessage == "El nombre del cliente es obligatorio");
        Assert.Contains(errores, e => e.ErrorMessage == "Debe seleccionar un representante");
        Assert.Contains(errores, e => e.ErrorMessage == "El límite de crédito es requerido");
    }

    [Fact]
    public void ValidacionCorrecta()
    {
        var cliente = new ClienteCLS { CodigoCliente = 1, NombreCliente = "Cliente1", RepresentanteId = 1, LimiteCredito = 5000m };
        var errores = ValidarModelo(cliente);
        Assert.Empty(errores);
    }
}
