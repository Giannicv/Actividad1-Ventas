using AppBlazor.Client.Pages;
using AppBlazor.Entities;

namespace AppBlazor.Client.Services
{
    public class VentaService
    {
        private List<VentaListCLS> venta;
        public VentaService()
        {
            venta = new List<VentaListCLS>();
            venta.Add(new VentaListCLS { num_Empl = 1, Nombre = "Juan Perez", Edad = 19, Cargo = "Cajero", FechaContrato = new DateTime(2020, 10, 3), Cuota = 12, Ventas = 15 });
            venta.Add(new VentaListCLS { num_Empl = 2, Nombre = "Pablo Duran", Edad = 24, Cargo = "Gerente", FechaContrato = new DateTime(2015, 8, 24), Cuota = 52, Ventas = 65 });
        }
        public List<VentaListCLS> listarVentas()
        {
            return venta;
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
                return new VentaCLS { Num_Empl = obj.num_Empl, Nombre = obj.Nombre, Edad = obj.Edad, Cargo = obj.Cargo, FechaContrato = obj.FechaContrato, Cuota = obj.Cuota, Ventas = obj.Ventas };
            }
            else
            {
                return new VentaCLS();
            }
        }
        public void guardarVenta(VentaCLS oVenta)
        {
            venta.Add(new VentaListCLS { num_Empl = oVenta.Num_Empl, Nombre = oVenta.Nombre, Edad = oVenta.Edad, 
                Cargo = oVenta.Cargo, FechaContrato = oVenta.FechaContrato, Cuota = oVenta.Cuota, Ventas = oVenta.Ventas });
        }
    }
}
