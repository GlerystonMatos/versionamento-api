using Microsoft.Extensions.DependencyInjection;
using Versionamento.Data.Repositories;
using Versionamento.Domain.Interfaces.Data;

namespace Versionamento.CrossCutting
{
    public static class InjectorRepository
    {
        public static void RegisterRepository(this IServiceCollection services)
        {
            services.AddScoped<IAnimalRepository, AnimalRepository>();
            services.AddScoped<IUsuarioRepository, UsuarioRepository>();
        }
    }
}