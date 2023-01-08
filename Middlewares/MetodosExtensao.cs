using Microsoft.AspNetCore.Builder;
using Middleware.Middlewares;

public static class MetodosExtensao
{
    public static IApplicationBuilder UseTempoExecucao(this IApplicationBuilder app)
    {
        app.UseMiddleware<TempoExecucao>();
        return app;
    }
}