using Microsoft.EntityFrameworkCore;
using System.Linq;
using Versionamento.Data.Common;
using Versionamento.Data.Context;
using Versionamento.Domain.Entities;
using Versionamento.Domain.Interfaces.Data;

namespace Versionamento.Data.Repositories
{
    public class UsuarioRepository : Repository<Usuario>, IUsuarioRepository
    {
        public UsuarioRepository(VersionamentoContext context) : base(context)
        {
        }

        public Usuario PesquisarPorLoginSenha(string login, string senha)
            => _context.Set<Usuario>().Where(u => u.Login.ToUpper().Equals(login.ToUpper()) && u.Senha.ToUpper()
            .Equals(senha.ToUpper())).AsNoTracking().FirstOrDefault();
    }
}