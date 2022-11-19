using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.DataProtection.AuthenticatedEncryption;
using Microsoft.AspNetCore.DataProtection.AuthenticatedEncryption.ConfigurationModel;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.AspNetCore.OData;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.SwaggerGen;
using Swashbuckle.AspNetCore.SwaggerUI;
using System.Linq;
using Versionamento.Api.Configuracoes;
using Versionamento.Api.Middleware;
using Versionamento.CrossCutting;
using Versionamento.Service.AutoMapper;

namespace Versionamento.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
            => _defaultConnection = configuration.GetValue<string>("ConnectionStrings:DefaultConnection");

        public string _defaultConnection { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors();
            services.AddControllers()
                .AddOData(opt => opt.Select().Expand().Filter().OrderBy().SetMaxTop(100).Count()
                .AddRouteComponents("OData", EdmModelConfig.GetEdmModel())
                .AddRouteComponents("OData/v{version}", EdmModelConfig.GetEdmModel()));

            services.AddJwtSetup();
            services.AddAutoMapper(typeof(AutoMapping));
            services.RegisterDependencies(_defaultConnection);

            services.AddDataProtection()
                .UseCryptographicAlgorithms(
                    new AuthenticatedEncryptorConfiguration()
                    {
                        EncryptionAlgorithm = EncryptionAlgorithm.AES_256_CBC,
                        ValidationAlgorithm = ValidationAlgorithm.HMACSHA256
                    });

            services.AddEndpointsApiExplorer()
                .AddSwaggerGen()
                .AddTransient<IConfigureOptions<SwaggerGenOptions>, ConfigureSwaggerGenOptions>();

            services.AddSwaggerSetup();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IApiVersionDescriptionProvider apiVersionDescriptionProvider)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStaticFiles();
            app.UseExceptionHandlerCuston();

            app.UseSwagger();
            app.UseSwaggerUI(ui =>
            {
                ui.EnableFilter();
                ui.DocExpansion(DocExpansion.None);
                ui.DocumentTitle = "Versionamento";
                ui.InjectStylesheet("/swagger-ui/custom.css");

                foreach (ApiVersionDescription description in apiVersionDescriptionProvider.ApiVersionDescriptions.OrderByDescending(v => v.GroupName))
                {
                    ui.SwaggerEndpoint($"/swagger/{description.GroupName}/swagger.json", description.GroupName.ToUpper());
                }
            });

            app.UseHttpsRedirection();
            app.UseRouting();

            app.UseCors(x => x
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}