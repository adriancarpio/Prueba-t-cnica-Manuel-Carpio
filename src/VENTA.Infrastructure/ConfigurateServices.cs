using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VENTA.Infrastructure.Data;
using VENTA.Infrastructure.Interface;
using VENTA.Infrastructure.Repository;

namespace VENTA.Infrastructure
{
    public static class ConfigurateServices
    {
        public static IServiceCollection ConfigurarInfraestructura(this IServiceCollection services)
        {
            services.AddTransient<IConnectionService, ConnectionService>();
            services.AddTransient<IEventoRepository, EventoRepository>();
            return services;
        }
    }
}
