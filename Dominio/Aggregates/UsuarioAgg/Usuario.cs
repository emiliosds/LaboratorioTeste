using System;

namespace Dominio.Aggregates.UsuarioAgg
{
    public class Usuario : EntityBase
    {
        public string NomeCompleto { get; set; }

        public string Email { get; set; }

        public string Senha { get; set; }

        public DateTime DataCriacao { get; set; }
    }
}