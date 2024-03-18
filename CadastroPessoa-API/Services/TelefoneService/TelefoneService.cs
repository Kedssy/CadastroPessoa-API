using CadastroPessoa_API.DataManager;
using CadastroPessoa_API.Dtos;
using CadastroPessoa_API.Models;

namespace CadastroPessoa_API.Services.TelefoneService
{
    public class TelefoneService : ITelefoneInterface
    {
        private ApplicationDataContext _context;
        TelefoneDto telefoneDto = new TelefoneDto();

        public TelefoneService(ApplicationDataContext context)
        {
            _context = context;
        }

        public Task<ServiceResponse<TelefoneDto>> CreateTelefone(TelefoneDto telefoneDto)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResponse<TelefoneDto>> DeleteTelefone(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResponse<TelefoneDto>> FindTelefoneById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResponse<List<TelefoneDto>>> FindTelefones()
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResponse<TelefoneDto>> UpdateTelefone(TelefoneDto telefoneDto)
        {
            throw new NotImplementedException();
        }
    }
}
