using Microsoft.OData.Edm;
using Microsoft.OData.ModelBuilder;
using Versionamento.Domain.Dto;

namespace Versionamento.Api.Configuracoes
{
    public class EdmModelConfig
    {
        public static IEdmModel GetEdmModel()
        {
            ODataConventionModelBuilder odataBuilder = new ODataConventionModelBuilder();

            odataBuilder.EntitySet<AnimalDto>("Animal");
            odataBuilder.EntitySet<UsuarioDto>("Usuario");

            return odataBuilder.GetEdmModel();
        }
    }
}