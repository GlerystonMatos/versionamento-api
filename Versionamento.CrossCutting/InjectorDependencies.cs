using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Versionamento.Data.Context;

namespace Versionamento.CrossCutting
{
    public static class InjectorDependencies
    {
        public static void RegisterDependencies(this IServiceCollection services, string defaultConnection)
        {
            services.AddDbContext<VersionamentoContext>(options => options.UseSqlServer(defaultConnection));
            services.RegisterRepository();
            services.RegisterService();
        }
    }
}