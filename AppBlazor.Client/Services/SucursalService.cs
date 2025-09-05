using AppBlazor.Entities;

namespace AppBlazor.Client.Services
{
    public class SucursalService
    {
        private List<Sucursal> lista;
        public SucursalService()
        {
            lista = new List<Sucursal>();
            lista.Add(new Sucursal { idsucursal = 1, nombresucursal = "Cochamba" });
            lista.Add(new Sucursal { idsucursal = 2, nombresucursal = "Santa Cruz" });
            lista.Add(new Sucursal { idsucursal = 3, nombresucursal = "La Paz" });
            lista.Add(new Sucursal { idsucursal = 4, nombresucursal = "Oruro" });
            lista.Add(new Sucursal { idsucursal = 5, nombresucursal = "Potosi" });
        }
        public List<Sucursal> listarSucursales()
        {
            return lista;
        }
        public int recuperarSucursalPorID(string nombresucursal)
        {
            var obj = lista.Where(p => p.nombresucursal == nombresucursal).FirstOrDefault();
            if (obj == null)
            {
                return 0;
            }
            else
            {
                return obj.idsucursal;
            }
        }
        public string recuperarNombreSucursalPorID(int idsucursal)
        {
            var obj = lista.Where(p => p.idsucursal == idsucursal).FirstOrDefault();
            if (obj == null)
            {
                return "";
            }
            else
            {
                return obj.nombresucursal;
            }
        }

    }
}
