using Ejercicio4Modulo3.Domain;
using System.Threading.Tasks;

namespace Ejercicio4Modulo3.Servicios.Interface
{
    public interface Iservicios
    {
        public Task<List<Proveedor>> GetProvedorAsync();
        public Task AddProvedorAsync(Proveedor nuevo);
        Task<bool> ExisteProveedorAsync(string codProveedor);
    }
}
