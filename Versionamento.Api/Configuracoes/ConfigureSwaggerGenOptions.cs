using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Reflection;
using Versionamento.Api.Filter;

namespace Versionamento.Api.Configuracoes
{
    public class ConfigureSwaggerGenOptions : IConfigureOptions<SwaggerGenOptions>
    {
        private readonly IApiVersionDescriptionProvider _apiVersionDescriptionProvider;

        public ConfigureSwaggerGenOptions(IApiVersionDescriptionProvider apiVersionDescriptionProvider)
            => _apiVersionDescriptionProvider = apiVersionDescriptionProvider;

        public void Configure(SwaggerGenOptions options)
        {
            foreach (ApiVersionDescription description in _apiVersionDescriptionProvider.ApiVersionDescriptions)
            {
                options.SwaggerDoc(description.GroupName, CreateOpenApiInfo(description));
            }

            ConfigureOptions(options);
        }

        private static OpenApiInfo CreateOpenApiInfo(ApiVersionDescription description)
        {
            var info = new OpenApiInfo()
            {
                Title = "Versionamento",
                Version = description.ApiVersion.ToString(),
                Description = "Documentação da api do projeto Versionamento.<br/>" +
                    "Para usar o OData nos endpoints onde o mesmo está disponível é necessário utilizar o prefixo “OData”.<br/>" +
                    "A autenticação da api deve ser feita enviando o usuário e a senha para o endpoint /Login/Authenticate.<br/>" +
                    "Em seguida o token deve ser enviado no Header da requisição: Authorization – Bearer Token."
            };

            if (description.IsDeprecated)
            {
                info.Description += " (deprecated)";
            }

            return info;
        }

        private static void ConfigureOptions(SwaggerGenOptions options)
        {
            AddSecurityDefinition(options);
            AddSecurityRequirement(options);
            AddSwaggerXmlComments(options);
            AddSwaggerFilters(options);
            AddSwaggerCustomSchemaIds(options);
        }

        private static void AddSecurityDefinition(SwaggerGenOptions options)
        {
            options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
            {
                Name = "Authorization",
                In = ParameterLocation.Header,
                Type = SecuritySchemeType.ApiKey,
                Description = "Por favor insira JWT com Bearer no campo",
            });
        }

        private static void AddSecurityRequirement(SwaggerGenOptions options)
        {
            options.AddSecurityRequirement(new OpenApiSecurityRequirement
            {
                {
                    new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference
                        {
                            Id = "Bearer",
                            Type = ReferenceType.SecurityScheme,
                        }
                    },
                    new string[] {}
                }
            });
        }

        private static void AddSwaggerXmlComments(SwaggerGenOptions options)
        {
            string xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
            string xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
            options.IncludeXmlComments(xmlPath);
        }

        private static void AddSwaggerFilters(SwaggerGenOptions options)
        {
            options.SchemaFilter<SwaggerSchemaFilter>();
            options.DocumentFilter<SwaggerDocumentFilter>();
            options.OperationFilter<SwaggerDefaultValuesFilter>();
        }

        private static void AddSwaggerCustomSchemaIds(SwaggerGenOptions options)
        {
            options.CustomSchemaIds(x => (x.GetCustomAttributes<DisplayNameAttribute>().Count() > 0)
            ? x.GetCustomAttributes<DisplayNameAttribute>().SingleOrDefault().DisplayName
            : x.Name);
        }
    }
}