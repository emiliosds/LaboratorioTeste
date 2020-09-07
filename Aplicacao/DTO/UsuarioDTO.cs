using Dominio.Aggregates.UsuarioAgg;
using System;

namespace Aplicacao.DTO
{
    public class UsuarioDTO
    {
        public Guid Id { get; set; }

        public string Email { get; set; }

        public string Senha { get; set; }
        public DateTime DataCriacao { get; set; }

        public static explicit operator UsuarioDTO(Usuario entidade)
        {
            return new UsuarioDTO
            {
                Id = entidade.Id,
                Email = entidade.Email,
                Senha = entidade.Senha,
                DataCriacao = entidade.DataCriacao
            };
        }
    }
}