using Aplicacao.DTO;
using Dominio.Aggregates.UsuarioAgg;
using Dominio.Repositories;
using Infraestrutura.Transversal;
using System;

namespace Aplicacao.Service
{
    public class UsuarioService
    {
        private readonly ICriptografiaService _criptografiaService;
        private readonly IUsuarioRepository _usuarioRepository;

        public UsuarioService(ICriptografiaService criptografiaService, IUsuarioRepository usuarioRepository)
        {
            _criptografiaService = criptografiaService;
            _usuarioRepository = usuarioRepository;
        }

        public UsuarioDTO CriarUsuario(UsuarioDTO usuarioDTO)
        {
            if (!usuarioDTO.Email.IsValidEmail())
                throw new ArgumentException("E-mail inválido.");

            if (!usuarioDTO.Senha.IsValidPassword())
                throw new ArgumentException("Senha inválida.");

            var usuario = new Usuario
            {
                Id = Guid.NewGuid(),
                Email = usuarioDTO.Email.ToLower(),
                Senha = _criptografiaService.Encriptar(usuarioDTO.Senha),
                DataCriacao = DateTimeProvider.Instance.GetNow()
            };

            _usuarioRepository.Salvar(usuario);

            return (UsuarioDTO)usuario;
        }
    }
}