using CadastroPessoa_API.DataManager;
using CadastroPessoa_API.Dtos;
using CadastroPessoa_API.Models;
using CadastroPessoa_API.Services.PessoaService;
using Microsoft.EntityFrameworkCore;


namespace CadastroPessoa_API.Services.TelefoneService
{
    public class TelefoneService : ITelefoneInterface
    {
        private ApplicationDataContext _context;
        private readonly IPessoaInterface _pessoaService;
        TelefoneDto telefoneDto = new TelefoneDto();

        public TelefoneService(ApplicationDataContext context, IPessoaInterface pessoaService)
        {
            _context = context;
            _pessoaService = pessoaService;
        }

  

        public async Task<ServiceResponse<TelefoneDto>> CreateTelefone(TelefoneDto telefoneDto)
        {
            ServiceResponse<TelefoneDto> serviceResponse = new ServiceResponse<TelefoneDto>();
            try
            {
                ValidateTelefone(telefoneDto);

                Telefone telefone = new Telefone();
                telefone.NrTelefone = telefoneDto.NrTelefone;

                
                
                telefone.Pessoa = _context.Pessoas.FirstOrDefault(p => p.Id == telefoneDto.IdPessoa);

                _context.Add(telefone);
                await _context.SaveChangesAsync();

                serviceResponse.Data = telefoneDto.GetInstance(telefone);

            }
            catch (Exception ex) 
            {
                serviceResponse.Message = ex.Message;
                serviceResponse.Sucess = false;
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<TelefoneDto>> DeleteTelefone(int id)
        {
            ServiceResponse<TelefoneDto> serviceResponse = new ServiceResponse<TelefoneDto>();

            try
            {

                Telefone telefone = _context.Telefone.FirstOrDefault(p => p.Id == id);

                if (telefone == null)
                {
                    throw new ArgumentException($"Telefone com id: {id} não encontrado.");
                }

                _context.Telefone.Remove(telefone);
                await _context.SaveChangesAsync();

            }
            catch (Exception ex)
            {
                serviceResponse.Message = ex.Message;
                serviceResponse.Sucess = false;
            }
            return serviceResponse;
        }

        public async Task<ServiceResponse<TelefoneDto>> FindTelefoneById(int id)
        {
            ServiceResponse<TelefoneDto> serviceResponse = new ServiceResponse<TelefoneDto>();

            try
            {

                Telefone telefone = _context.Telefone.FirstOrDefault(t => t.Id == id);

                if (telefone == null)
                {
                    throw new ArgumentException($"Telefone com id: {id} não encontrado.");
                }

                serviceResponse.Data = telefoneDto.GetInstance(telefone);

            }
            catch (Exception ex)
            {
                serviceResponse.Message = ex.Message;
                serviceResponse.Sucess = false;
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<List<TelefoneDto>>> FindTelefones()
        {
            ServiceResponse<List<TelefoneDto>> serviceResponse = new ServiceResponse<List<TelefoneDto>>();

            try
            {
                serviceResponse.Data = telefoneDto.GetListInstance(_context.Telefone.Include(t => t.Pessoa).ToList());

                if (serviceResponse.Data.Count == 0)
                {
                    serviceResponse.Message = "Nenhum registro encontrado";
                }

            }
            catch (Exception ex)
            {
                serviceResponse.Message = ex.Message;
                serviceResponse.Sucess = false;

            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<TelefoneDto>> UpdateTelefone(TelefoneDto telefoneDto)
        {
            ServiceResponse<TelefoneDto> serviceResponse = new ServiceResponse<TelefoneDto>();
            try
            {
                ValidateTelefone(telefoneDto);

                Telefone telefone = _context.Telefone.FirstOrDefault(t => t.Id == telefoneDto.Id);

                if (telefone == null)
                {
                    throw new ArgumentException($"Telefone com id: {telefoneDto.Id} não encontrado.");
                }

                telefone.NrTelefone = telefoneDto.NrTelefone;

                _context.Telefone.Update(telefone);
                await _context.SaveChangesAsync();

                serviceResponse.Data = telefoneDto.GetInstance(telefone);
            }
            catch (Exception ex)
            {

                serviceResponse.Message = ex.Message;
                serviceResponse.Sucess = false;
            }

            return serviceResponse;
        }

        public  void ValidateTelefone(TelefoneDto telefoneDto)
        {

            if (string.IsNullOrEmpty(telefoneDto.NrTelefone))
            {
                throw new ArgumentException("Por favor, informe o número de telefone.");
            }

            if (!telefoneDto.NrTelefone.All(char.IsDigit))
            {
                throw new ArgumentException("O número de telefone deve conter apenas dígitos.");
            }

            if(telefoneDto.IdPessoa == 0) 
            {
                throw new ArgumentException("Informe o ID da pessoa para inserir o telefone.");
            }

            Telefone telefone = _context.Telefone.FirstOrDefault(t => t.NrTelefone == telefoneDto.NrTelefone);

            if (telefone != null) 
            {
                throw new ArgumentException($"Número de telefone: {telefone.NrTelefone} já existe no banco.");
            }

            Pessoa pessoa = _context.Pessoas.FirstOrDefault(p => p.Id == telefoneDto.IdPessoa);
            if (pessoa == null)
            {
                throw new ArgumentException($"Não foi possível encontrar a pessoa com o ID {telefoneDto.IdPessoa}");
            }

        }
    }
}
