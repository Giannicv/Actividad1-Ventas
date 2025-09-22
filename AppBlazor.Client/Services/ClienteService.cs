using AppBlazor.Entities;

namespace AppBlazor.Client.Services
{
    public class ClienteService
    {
        private List<ClienteListCLS> clientes;
        private VentaService ventaService; 

        public ClienteService(VentaService _ventaService)
        {
            ventaService = _ventaService;

            clientes = new List<ClienteListCLS>();
            clientes.Add(new ClienteListCLS
            {
                CodigoCliente = 1,
                NombreCliente = "Jhael Arguedas",
                RepresentanteId = 1,
                RepresentanteNombre = "Juan Perez",
                LimiteCredito = 5000
            });
            clientes.Add(new ClienteListCLS
            {
                CodigoCliente = 2,
                NombreCliente = "Mena Guerreros",
                RepresentanteId = 2,
                RepresentanteNombre = "Pablo Duran",
                LimiteCredito = 10000
            });
        }

        // Listar todos los clientes
        public List<ClienteListCLS> ListarClientes()
        {
            return clientes;
        }

        // Filtrar clientes por nombre
        public List<ClienteListCLS> FiltrarClientes(string nombreCliente)
        {
            if (string.IsNullOrEmpty(nombreCliente))
                return ListarClientes();

            return clientes
                .Where(c => c.NombreCliente.ToUpper().Contains(nombreCliente.ToUpper()))
                .ToList();
        }

        // Recuperar cliente por ID (para editar)
        public ClienteCLS RecuperarClientePorID(int codigoCliente)
        {
            var obj = clientes.FirstOrDefault(c => c.CodigoCliente == codigoCliente);
            if (obj != null)
            {
                return new ClienteCLS
                {
                    CodigoCliente = obj.CodigoCliente,
                    NombreCliente = obj.NombreCliente,
                    RepresentanteId = obj.RepresentanteId,
                    LimiteCredito = obj.LimiteCredito
                };
            }
            else
            {
                return new ClienteCLS();
            }
        }

        // Guardar nuevo cliente
        public void GuardarCliente(ClienteCLS oCliente)
        {
            // Buscamos el nombre del representante usando el servicio de ventas
            var representante = ventaService.listarVentas()
                .FirstOrDefault(v => v.num_Empl == oCliente.RepresentanteId);

            clientes.Add(new ClienteListCLS
            {
                CodigoCliente = oCliente.CodigoCliente ?? 0,
                NombreCliente = oCliente.NombreCliente,
                RepresentanteId = oCliente.RepresentanteId,
                RepresentanteNombre = representante?.Nombre ?? "",
                LimiteCredito = oCliente.LimiteCredito ?? 0
            });
        }

        // Eliminar cliente
        public void EliminarCliente(int codigoCliente)
        {
            clientes = clientes.Where(c => c.CodigoCliente != codigoCliente).ToList();
        }
    }
}
