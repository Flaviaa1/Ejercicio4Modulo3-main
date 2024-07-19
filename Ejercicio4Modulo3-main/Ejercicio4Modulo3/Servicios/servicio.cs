using Ejercicio4Modulo3.Domain;
using Ejercicio4Modulo3.Repository;
using Ejercicio4Modulo3.Servicios.Interface;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Ejercicio4Modulo3.Servicios
{
    public class Servicio : Iservicios
    {
        private readonly Ejercicio4Modulo3Context _context;
        public Servicio(Ejercicio4Modulo3Context contexto)
        {
            _context = contexto;
        }
        public async Task<bool> ExisteProveedorAsync(string codProveedor)
        {
            return await _context.Proveedors.AnyAsync(p => p.CodProveedor == codProveedor);
        }


        public async Task<List<Proveedor>> GetProvedorAsync()
        {

            var resultado = await _context.Proveedors.ToListAsync();
            return resultado;

        }
         public async Task AddProvedorAsync(Proveedor nuevo)
        {
           _context.Proveedors.Add(nuevo);
            _context.SaveChanges();
        }

        
    }
}
