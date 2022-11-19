using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Versionamento.Domain.Dto
{
    [DisplayName("Usuario")]
    public class UsuarioDto : Dto
    {
        public UsuarioDto()
            => Id = Guid.NewGuid();

        [Required(ErrorMessage = "Campo 'Nome' obrigatório")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Campo 'Login' obrigatório")]
        public string Login { get; set; }

        [Required(ErrorMessage = "Campo 'Senha' obrigatório")]
        public string Senha { get; set; }
    }
}