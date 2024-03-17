using CadastroPessoa_API.Models;
using Microsoft.IdentityModel.Tokens;

namespace CadastroPessoa_API.Dtos
{
    public class PessoaDto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public DateTime DtNascimento { get; set; }
        public bool Ativo { get; set; }
        public DateTime DtRecord { get; set; }
        public DateTime DtAlteracao { get; set; }
        public List<string> Telefones { get; set; }

        internal static PessoaDto? GetInstance(Pessoa entity)
        {
            PessoaDto dto = new PessoaDto();

            dto.Id = entity.Id;
            dto.Nome = entity.Nome;
            dto.Cpf = entity.Cpf;
            dto.DtNascimento = entity.DtNascimento;
            dto.Ativo = entity.Ativo;
            dto.DtRecord = entity.DtRecord;
            dto.DtAlteracao = entity.DtAlteracao;

            if (entity.Telefones.IsNullOrEmpty())
            {
                //dto.Telefones
            }



            return dto;
        }

        internal static List<PessoaDto?> GetListInstance(List<Pessoa> list)
        {
            return list.Select(p => GetInstance(p)).ToList();
        }

    }
}
