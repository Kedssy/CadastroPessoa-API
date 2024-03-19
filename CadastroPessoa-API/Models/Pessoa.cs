﻿    using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CadastroPessoa_API.Models
{
    public class Pessoa
    {
        [Key]
        public int Id { get; set; }

        public String Nome { get; set; }

        public String Cpf { get; set; }

        public DateTime DtNascimento { get; set; }

        public bool Ativo { get; set; }

        public DateTime DtRecord { get; set; } = DateTime.Now.ToLocalTime();

        public DateTime DtAlteracao { get; set; }

        [InverseProperty("Pessoa")]
        public List<Telefone> Telefones { get; set; } = new List<Telefone>();
    }
}
