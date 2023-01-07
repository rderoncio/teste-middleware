using System.Diagnostics;
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
            context.Response.ContentType = "text/plain; charset=utf-8";
            var watch = Stopwatch.StartNew();
            await _next(context);;
            watch.Stop();
            await context.Response.WriteAsync($"\nTempo de execução: {watch.ElapsedMilliseconds} ms");
        }
    }
}