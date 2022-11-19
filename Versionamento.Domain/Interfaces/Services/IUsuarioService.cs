using Versionamento.Domain.Dto;
using Versionamento.Domain.Interfaces.Common;

namespace Versionamento.Domain.Interfaces.Services
{
    public interface IUsuarioService : IService<UsuarioDto>
    {
        UsuarioDto ObterUsuarioParaAutenticacao(LoginDto loginDto);
    }
}