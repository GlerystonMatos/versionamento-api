using System.Linq;

namespace Versionamento.Domain.Interfaces.Common
{
    public interface IRepository<TModel>
    {
        IQueryable<TModel> ObterTodos();
    }
}