using Ejercicio4Modulo3.Domain;
using Ejercicio4Modulo3.Domain.DTOprovedor;
using Ejercicio4Modulo3.Servicios.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Ejercicio4Modulo3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConsignaController : ControllerBase
    {
        public Iservicios _IServicios;

        public ConsignaController(Iservicios iservicios)
        {
            _IServicios = iservicios;

        }
        //listar todos los proveedores
        [HttpGet]
        [Route("listaProvedor")]
        public async Task<IActionResult> getProvedor()
        {

            var result = await _IServicios.GetProvedorAsync();
            return Ok(result);
        }
        //dar de alta a un provedor
        [HttpPost("AltaProvedor")]
        public async Task<IActionResult> createT([FromBody] prov NP)
        {
            if (NP == null || string.IsNullOrEmpty(NP.CodProveedor) || string.IsNullOrEmpty(NP.RazonSocial))
            {
                return BadRequest("Los datos del proveedor no son correctos.");
            }

            try
            {
                // Verificar si ya existe un proveedor con el mismo código utilizando el servicio
                var existeProveedor = await _IServicios.ExisteProveedorAsync(NP.CodProveedor);
                if (existeProveedor)
                {
                    // Si tiene el mismo codprovedor Success = false
                    throw new Exception("Ya existe un proveedor con el mismo código.");
                }

                var nuevoProveedor = new Proveedor()
                {
                    CodProveedor = NP.CodProveedor,
                    RazonSocial = NP.RazonSocial
                };

                
                await _IServicios.AddProvedorAsync(nuevoProveedor);

             
                return Ok(nuevoProveedor);
            }
            catch (Exception ex)
            {
                
                throw new Exception("Error al agregar el proveedor: " + ex.Message);
            }
            // Correr el script para tener los datos de la BD
            // Se debe crear con la arquitectura en capas( el controller y services) para poder unicamente dar de alta un proveedor y recuperar todos los proveedores
            // Todas las peticiones tienen que ser async
            // Crear un middleware personalizado, que grabe en base de datos en la tabla logs cada interaccion que exista con los endpoints expuestos:
            // Si hay un error en la peticion se debe grabar success = false  sino success = true
            // para completar los datos de path y verbo http deben usar los metodos/propiedades
            // de la variable "context" que se disponibiliza al implementar IMiddleware

        }
    }
}