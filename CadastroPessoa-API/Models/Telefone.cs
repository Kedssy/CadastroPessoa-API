using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace CadastroPessoa_API.Models
{
    public class Telefone
    {
        [Key]
        public int Id { get; set; }

        public string NrTelefone { get; set; }

        [InverseProperty("Telefones")]
        public Pessoa Pessoa { get; set; }
    }
}
