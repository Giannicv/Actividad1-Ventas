using AppBlazor.Client.Pages;
using AppBlazor.Entities;

namespace AppBlazor.Client.Services
{
    public class VentaService
    {
       // public event Func<string,Task> Onsearch = delegate { return Task.CompletedTask; };

       /* public async Task notificarBusqueda(string nombrerepresentante)
        {
            if(Onsearch != null)
            {
                await Onsearch.Invoke(nombrerepresentante);
            }
        }*/
        private List<VentaListCLS> venta;
        //
        private JefeService jefeService;
        private SucursalService sucursalService;

        public VentaService(JefeService _jefeService, SucursalService _sucursalService)
        {
            jefeService = _jefeService;
            sucursalService = _sucursalService;
            venta = new List<VentaListCLS>();
            venta.Add(new VentaListCLS { num_Empl = 1, Nombre = "Juan Perez", Edad = 19, Cargo = "Cajero", FechaContrato = new DateTime(2020, 10, 3), Cuota = 12, Ventas = 15, nombrejefe = "Juan Guerreros", nombresucursal = "La Paz" });
            venta.Add(new VentaListCLS { num_Empl = 2, Nombre = "Pablo Duran", Edad = 24, Cargo = "Gerente", FechaContrato = new DateTime(2015, 8, 24), Cuota = 52, Ventas = 65, nombrejefe = "Pedro Gonzales", nombresucursal = "Cochabamba" });
            
        }
        public List<VentaListCLS> listarVentas()
        {
            return venta;
        }
        public List<VentaListCLS> filtrarVentas(string nombretitulo)
        {
            List<VentaListCLS> v = listarVentas();
            if ( nombretitulo=="")
            {
                return v;
            }else
            {
                List<VentaListCLS> listaFiltrada = v.Where(p => 
                p.Nombre.ToUpper().Contains(nombretitulo.ToUpper())).ToList();
                return listaFiltrada;
            }
        }
        public void eliminarVenta(int numemp)
        {
            var listaQueda = venta.Where(p => p.num_Empl != numemp).ToList();
            venta= listaQueda;
        }
        public VentaCLS recuperaVentaPorID(int numemp)
        {
            var obj = venta.Where(p => p.num_Empl == numemp).FirstOrDefault();
            if(obj != null)
            {
                return new VentaCLS { Num_Empl = obj.num_Empl, Nombre = obj.Nombre, Edad = obj.Edad, Cargo = obj.Cargo, FechaContrato = obj.FechaContrato, Cuota = obj.Cuota, Ventas = obj.Ventas,
                idjefe = jefeService.recuperarJefePorID(obj.nombrejefe),
                idsucursal = sucursalService.recuperarSucursalPorID(obj.nombresucursal)};
            }
            else
            {
                return new VentaCLS();
            }
        }
        public void guardarVenta(VentaCLS oVenta)
        {
            venta.Add(new VentaListCLS { num_Empl = oVenta.Num_Empl, Nombre = oVenta.Nombre, Edad = oVenta.Edad, 
                Cargo = oVenta.Cargo, FechaContrato = oVenta.FechaContrato, Cuota = oVenta.Cuota, Ventas = oVenta.Ventas,
            nombrejefe = jefeService.recuperarNombreJefePorID(oVenta.idjefe),
            nombresucursal = sucursalService.recuperarNombreSucursalPorID(oVenta.idsucursal)});
        }
    }
}
