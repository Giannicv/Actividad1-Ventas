using AppBlazor.Entities;

namespace AppBlazor.Client.Services
{
    public class JefeService
    {
        private List<Jefe> lista;
        public JefeService()
        {
            lista = new List<Jefe>();
            lista.Add(new Jefe { idjefe = 1, nombrejefe = "Juan Guerreros" });
            lista.Add(new Jefe { idjefe = 2, nombrejefe = "Pedro Gonzales" });
            lista.Add(new Jefe { idjefe = 3, nombrejefe = "Maria Lopez" });
            lista.Add(new Jefe { idjefe = 4, nombrejefe = "Ana Torres" });
            lista.Add(new Jefe { idjefe = 5, nombrejefe = "Luis Ramirez" });

            
        }
        public List<Jefe> listarJefes()
        {
            return lista;
        }
        public int recuperarJefePorID(string nombrejefe)
        {
            var obj = lista.Where(p => p.nombrejefe == nombrejefe).FirstOrDefault();
            if (obj == null)
            {
                return 0; 
            }
            else
            {
                return obj.idjefe;
            }
        }
        public string recuperarNombreJefePorID(int idjefe)
        {
            var obj = lista.Where(p => p.idjefe == idjefe).FirstOrDefault();
            if (obj == null)
            {
                return ""; 
            }
            else
            {
                return obj.nombrejefe;
            }
        }

    }
}
