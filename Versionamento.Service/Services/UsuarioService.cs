using AutoMapper;
using AutoMapper.QueryableExtensions;
using System.Linq;
using Versionamento.Domain.Dto;
using Versionamento.Domain.Exception;
using Versionamento.Domain.Interfaces.Data;
using Versionamento.Domain.Interfaces.Services;

namespace Versionamento.Service.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IMapper _mapper;
        private readonly IUsuarioRepository _usuarioRepository;

        public UsuarioService(IMapper mapper, IUsuarioRepository usuarioRepository)
        {
            _mapper = mapper;
            _usuarioRepository = usuarioRepository;
        }

        public IQueryable<UsuarioDto> ObterTodos()
            => _usuarioRepository.ObterTodos().ProjectTo<UsuarioDto>(_mapper.ConfigurationProvider);

        private UsuarioDto PesquisarPorLoginSenha(string login, string senha)
            => _mapper.Map<UsuarioDto>(_usuarioRepository.PesquisarPorLoginSenha(login, senha));

        public UsuarioDto ObterUsuarioParaAutenticacao(LoginDto loginDto)
        {
            UsuarioDto usuario = PesquisarPorLoginSenha(loginDto.Login, loginDto.Senha);

            if (usuario == null)
            {
                throw new VersionamentoException("Usuário não localizado.");
            }

            return usuario;
        }
    }
}