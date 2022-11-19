using NUnit.Framework;
using Versionamento.Api.Security;
using Versionamento.Domain.Dto;

namespace Versionamento.NUnitTest.Security
{
    public class AccessTokenTest
    {
        [Test]
        public void GenerateToken()
        {
            UsuarioDto usuarioDto = new UsuarioDto();
            usuarioDto.Senha = "123";
            usuarioDto.Nome = "Teste";
            usuarioDto.Login = "Teste";

            Assert.IsNotEmpty(AccessToken.GenerateToken(usuarioDto));
        }
    }
}