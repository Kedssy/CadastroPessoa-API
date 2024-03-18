using CadastroPessoa_API.Models;

namespace CadastroPessoa_API.Dtos
{
    public class TelefoneDto : BaseDto<Telefone, TelefoneDto>
    {
        public int Id { get; set; }
        public string NrTelefone { get; set; }

        public int IdPessoa { get; set; }

        public override TelefoneDto GetInstance(Telefone entity)
        {
            TelefoneDto dto = new TelefoneDto();

            dto.Id = entity.Id;
            dto.NrTelefone = entity.NrTelefone;
            dto.IdPessoa = entity.Pessoa.Id;
                
            return dto;
        }

        public override List<TelefoneDto> GetListInstance(List<Telefone> list)
        {
            return list.Select(t => GetInstance(t)).ToList();
        }
    }
}
