using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Middleware.Middlewares
{
    public class TempoExecucao
    {
        private readonly RequestDelegate _next;

        public TempoExecucao(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            await _next(context);
        }
    }
}