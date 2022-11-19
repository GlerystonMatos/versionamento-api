using Versionamento.Domain.Entities;
using Versionamento.Domain.Interfaces.Common;

namespace Versionamento.Domain.Interfaces.Data
{
    public interface IUsuarioRepository : IRepository<Usuario>
    {
        Usuario PesquisarPorLoginSenha(string login, string senha);
    }
}