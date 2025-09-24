using AppBlazor.Entities;

namespace AppBlazor.Client.Services
{
    public class SucursalService
    {
        private List<SucursalListCLS> sucursales;
        private JefeService jefeService;

        public SucursalService(JefeService _jefeService)
        {
            jefeService = _jefeService;
            sucursales = new List<SucursalListCLS>();
            sucursales.Add(new SucursalListCLS
            {
                idsucursal = 1,
                CodigoSucursal = "SC001",
                Ciudad = "Santa Cruz",
                Region = "Oriental",
                idjefe = 1,
                DirectorNombre = jefeService.recuperarNombreJefePorID(1),
                ObjetivoVenta = 100000,
                VentasReales = 95000
            });
            sucursales.Add(new SucursalListCLS
            {
                idsucursal = 2,
                CodigoSucursal = "LP001",
                Ciudad = "La Paz",
                Region = "Andina",
                idjefe = 2,
                DirectorNombre = jefeService.recuperarNombreJefePorID(2),
                ObjetivoVenta = 80000,
                VentasReales = 82000
            });
            sucursales.Add(new SucursalListCLS
            {
                idsucursal = 3,
                CodigoSucursal = "CB001",
                Ciudad = "Cochabamba",
                Region = "Valle",
                idjefe = 3,
                DirectorNombre = jefeService.recuperarNombreJefePorID(3),
                ObjetivoVenta = 120000,
                VentasReales = 110000
            });
        }

        public List<SucursalListCLS> ListarSucursales()
        {
            return sucursales;
        }

        public List<SucursalListCLS> FiltrarSucursales(string filtro)
        {
            if (string.IsNullOrEmpty(filtro))
                return ListarSucursales();

            return sucursales
                .Where(s => s.CodigoSucursal.ToUpper().Contains(filtro.ToUpper()) ||
                            s.Ciudad.ToUpper().Contains(filtro.ToUpper()) ||
                            s.Region.ToUpper().Contains(filtro.ToUpper()))
                .ToList();
        }

        public Sucursal RecuperarSucursalPorID(int idsucursal)
        {
            var obj = sucursales.FirstOrDefault(s => s.idsucursal == idsucursal);
            if (obj != null)
            {
                return new Sucursal
                {
                    idsucursal = obj.idsucursal,
                    CodigoSucursal = obj.CodigoSucursal,
                    Ciudad = obj.Ciudad,
                    Region = obj.Region,
                    idjefe = obj.idjefe,
                    Director = jefeService.listarJefes().FirstOrDefault(j => j.idjefe == obj.idjefe),
                    ObjetivoVenta = obj.ObjetivoVenta,
                    VentasReales = obj.VentasReales
                };
            }
            else
            {
                return new Sucursal();
            }
        }

        public void GuardarSucursal(Sucursal oSucursal)
        {
            var director = jefeService.listarJefes()
                .FirstOrDefault(j => j.idjefe == oSucursal.idjefe);

            sucursales.Add(new SucursalListCLS
            {
                idsucursal = sucursales.Max(s => s.idsucursal) + 1,
                CodigoSucursal = oSucursal.CodigoSucursal,
                Ciudad = oSucursal.Ciudad,
                Region = oSucursal.Region,
                idjefe = oSucursal.idjefe,
                DirectorNombre = director?.nombrejefe ?? "",
                ObjetivoVenta = oSucursal.ObjetivoVenta,
                VentasReales = oSucursal.VentasReales
            });
        }

        public void ActualizarSucursal(Sucursal oSucursal)
        {
            var sucursalExistente = sucursales.FirstOrDefault(s => s.idsucursal == oSucursal.idsucursal);
            if (sucursalExistente != null)
            {
                var director = jefeService.listarJefes()
                    .FirstOrDefault(j => j.idjefe == oSucursal.idjefe);

                sucursalExistente.CodigoSucursal = oSucursal.CodigoSucursal;
                sucursalExistente.Ciudad = oSucursal.Ciudad;
                sucursalExistente.Region = oSucursal.Region;
                sucursalExistente.idjefe = oSucursal.idjefe;
                sucursalExistente.DirectorNombre = director?.nombrejefe ?? "";
                sucursalExistente.ObjetivoVenta = oSucursal.ObjetivoVenta;
                sucursalExistente.VentasReales = oSucursal.VentasReales;
            }
        }

        public void EliminarSucursal(int idsucursal)
        {
            sucursales = sucursales.Where(s => s.idsucursal != idsucursal).ToList();
        }
    }
}
