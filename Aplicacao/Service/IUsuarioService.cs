using Aplicacao.DTO;

namespace Aplicacao.Service
{
    public interface IUsuarioService
    {
        UsuarioDTO CriarUsuario(UsuarioDTO usuarioDTO);
    }
}