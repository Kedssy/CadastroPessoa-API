using CadastroPessoa_API.Dtos;
using CadastroPessoa_API.Models;

namespace CadastroPessoa_API.Services.TelefoneService
{
    public interface ITelefoneInterface
    {
        Task<ServiceResponse<List<TelefoneDto>>> FindTelefones();

        Task<ServiceResponse<TelefoneDto>> CreateTelefone(TelefoneDto telefoneDto);

        Task<ServiceResponse<TelefoneDto>> FindTelefoneById(int id);

        Task<ServiceResponse<TelefoneDto>> UpdateTelefone(TelefoneDto telefoneDto);

        Task<ServiceResponse<TelefoneDto>> DeleteTelefone(int id);


    }
}
