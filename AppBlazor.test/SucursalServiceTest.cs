using AppBlazor.Client.Services;
using AppBlazor.Entities;
using Xunit;
using System.Collections.Generic;
using System.Linq;

namespace AppBlazor.test
{
    public class SucursalServiceTest
    {
        private SucursalService _sucursalService;
        private JefeService _jefeService;

        public SucursalServiceTest()
        {
            _jefeService = new JefeService();
            _sucursalService = new SucursalService(_jefeService);
        }

        [Fact]
        public void ListarSucursales_RetornaTodasLasSucursalesIniciales()
        {
            var result = _sucursalService.ListarSucursales();
            Assert.NotNull(result);
            Assert.Equal(3, result.Count);
        }

        [Fact]
        public void FiltrarSucursales_RetornaSucursalesFiltradasPorNombre()
        {
            var result = _sucursalService.FiltrarSucursales("Central");
            Assert.NotNull(result);
            Assert.Single(result);
            Assert.Equal("Sucursal Central", result.First().nombresucursal);
        }

        [Fact]
        public void RecuperarSucursalPorID_RetornaSucursalCorrecta()
        {
            var result = _sucursalService.RecuperarSucursalPorID(1);
            Assert.NotNull(result);
            Assert.Equal(1, result.idsucursal);
            Assert.Equal("SC001", result.CodigoSucursal);
        }

        [Fact]
        public void GuardarSucursal_AgregaNuevaSucursal()
        {
            var nuevaSucursal = new Sucursal
            {
                CodigoSucursal = "OR001",
                nombresucursal = "Sucursal Oruro",
                Ciudad = "Oruro",
                Region = "Andina",
                idjefe = 1,
                ObjetivoVenta = 50000,
                VentasReales = 45000
            };
            _sucursalService.GuardarSucursal(nuevaSucursal);
            var result = _sucursalService.ListarSucursales();
            Assert.Equal(4, result.Count);
            Assert.Contains(result, s => s.CodigoSucursal == "OR001");
        }

        [Fact]
        public void ActualizarSucursal_ModificaSucursalExistente()
        {
            var sucursalActualizada = new Sucursal
            {
                idsucursal = 1,
                CodigoSucursal = "SC001-UPD",
                nombresucursal = "Sucursal Central Actualizada",
                Ciudad = "Santa Cruz",
                Region = "Oriental",
                idjefe = 2,
                ObjetivoVenta = 110000,
                VentasReales = 100000
            };
            _sucursalService.ActualizarSucursal(sucursalActualizada);
            var result = _sucursalService.RecuperarSucursalPorID(1);
            Assert.NotNull(result);
            Assert.Equal("SC001-UPD", result.CodigoSucursal);
            Assert.Equal("Sucursal Central Actualizada", result.nombresucursal);
            Assert.Equal(2, result.idjefe);
        }

        [Fact]
        public void EliminarSucursal_EliminaSucursalExistente()
        {
            var initialCount = _sucursalService.ListarSucursales().Count;
            _sucursalService.EliminarSucursal(1);
            var result = _sucursalService.ListarSucursales();
            Assert.Equal(initialCount - 1, result.Count);
            Assert.DoesNotContain(result, s => s.idsucursal == 1);
        }
    }
}
