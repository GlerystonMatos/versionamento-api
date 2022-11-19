using Versionamento.Data.Common;
using Versionamento.Data.Context;
using Versionamento.Domain.Entities;
using Versionamento.Domain.Interfaces.Data;

namespace Versionamento.Data.Repositories
{
    public class AnimalRepository : Repository<Animal>, IAnimalRepository
    {
        public AnimalRepository(VersionamentoContext context) : base(context)
        {
        }
    }
}