using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Middleware
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {   // Middlewares inline
            // Adicionado Tempo inicio e fim do Middleware
            app.Use(async (context, next) =>
            {
                context.Response.ContentType = "text/plain; charset=utf-8";
                var watch = Stopwatch.StartNew();
                await next();
                watch.Stop();
                await context.Response.WriteAsync($"\nTempo de execução: {watch.ElapsedMilliseconds} ms");
            });


            // Adicionado Middleware
            app.Use(async (context, next) =>
            {
                // Middleware chamado no inicio
                await context.Response.WriteAsync("===");

                // Middleware chamado o proximo
                await next();

                // Middleware chamado no final
                await context.Response.WriteAsync("===");
            });
            
            app.Use(async (context, next) =>
            {
                await context.Response.WriteAsync(">>>");
                await next();
                await context.Response.WriteAsync("<<<");
            });


            app.Use(async (context, next) =>
            {
                await context.Response.WriteAsync("[[[");
                await next();
                await context.Response.WriteAsync("]]]");
            });

            // Middleware Final
            app.Run(async context => 
            {
                await context.Response.WriteAsync(" Middleware Terminal ");
            });
        }
    }
}
