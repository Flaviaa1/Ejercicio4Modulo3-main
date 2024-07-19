
using Ejercicio4Modulo3.Domain;
using Ejercicio4Modulo3.Repository;

namespace Ejercicio4Modulo3.middlewaress
{
    
        public class globalExpHand : IMiddleware
        {
            private readonly Ejercicio4Modulo3Context _context;

            public globalExpHand(Ejercicio4Modulo3Context context)
            {
                _context = context;
            }

            public async Task InvokeAsync(HttpContext context, RequestDelegate next)
            {
          
                var log = new Log
                {
                    Fecha = DateTime.UtcNow,
                    Path = context.Request.Path,
                    Method = context.Request.Method,
                };

                try
                {
                    await next(context); 

                   
                    log.Success = true;
                }
                catch (Exception)
                {
                   
                    log.Success = false;

                   
                    throw;
                }
                finally
                {

                    _context.Logs.Add(log);
                    await _context.SaveChangesAsync();
                }
            }
        }
    }

