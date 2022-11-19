using Microsoft.Extensions.DependencyInjection;
using Versionamento.Domain.Interfaces.Services;
using Versionamento.Service.Services;

namespace Versionamento.CrossCutting
{
    public static class InjectorService
    {
        public static void RegisterService(this IServiceCollection services)
        {
            services.AddScoped<IAnimalService, AnimalService>();
            services.AddScoped<IUsuarioService, UsuarioService>();
        }
    }
}