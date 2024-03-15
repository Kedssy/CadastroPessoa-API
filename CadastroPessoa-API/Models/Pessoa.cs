using System.ComponentModel.DataAnnotations;

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
    }
}
