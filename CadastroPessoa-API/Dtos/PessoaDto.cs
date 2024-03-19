using CadastroPessoa_API.Models;
using CadastroPessoa_API.Services.TelefoneService;

namespace CadastroPessoa_API.Dtos
{
    public class PessoaDto : BaseDto<Pessoa, PessoaDto>
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public string DtNascimento { get; set; }
        public bool Ativo { get; set; }
        public DateTime DtRecord { get; set; }
        public DateTime DtAlteracao { get; set; }
        public List<string> Telefones { get; set; }

        public override PessoaDto GetInstance(Pessoa entity)
        {
            PessoaDto dto = new PessoaDto();
            TelefoneDto telefoneDto = new TelefoneDto();
            dto.Id = entity.Id;
            dto.Nome = entity.Nome;
            dto.Cpf = entity.Cpf;
            dto.DtNascimento = entity.DtNascimento.ToString("dd/MM/yyyy");
            dto.Ativo = entity.Ativo;
            dto.DtRecord = entity.DtRecord;
            dto.DtAlteracao = entity.DtAlteracao;
            if (entity.Telefones != null)
            {
                dto.Telefones = entity.Telefones.Select(t => t.NrTelefone).ToList();
            }
            else
            {
                dto.Telefones = new List<string>();
            }

            return dto;
        }

        public override List<PessoaDto> GetListInstance(List<Pessoa> list)
        {
            return list.Select(p => GetInstance(p)).ToList();
        }
    }
}
