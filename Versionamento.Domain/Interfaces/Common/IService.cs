using System.Linq;

namespace Versionamento.Domain.Interfaces.Common
{
    public interface IService<TModel>
    {
        IQueryable<TModel> ObterTodos();
    }
}