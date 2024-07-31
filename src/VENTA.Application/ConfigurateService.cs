using Microsoft.Extensions.DependencyInjection;
using VENTA.Application.Interface;
using VENTA.Application.Service;
using VENTA.Infrastructure;

namespace VENTA.Application
{
    public static class ConfigurateService
    {
        public static IServiceCollection ConfigurarAplicacion(this IServiceCollection services)
        {
            services.ConfigurarInfraestructura();
            services.AddTransient<IEventoService, EventoService>();

            return services;
        }
    }
}
