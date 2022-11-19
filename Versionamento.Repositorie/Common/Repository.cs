using Microsoft.EntityFrameworkCore;
using System.Linq;
using Versionamento.Data.Context;
using Versionamento.Domain.Entities;
using Versionamento.Domain.Interfaces.Common;

namespace Versionamento.Data.Common
{
    public abstract class Repository<TModel> : IRepository<TModel> where TModel : Entity
    {
        protected readonly VersionamentoContext _context;

        public Repository(VersionamentoContext context)
            => _context = context;

        public virtual IQueryable<TModel> ObterTodos()
            => _context.Set<TModel>().AsNoTracking().AsQueryable();
    }
}