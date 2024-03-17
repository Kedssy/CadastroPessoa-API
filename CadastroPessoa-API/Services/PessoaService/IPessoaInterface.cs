using CadastroPessoa_API.Dtos;
using CadastroPessoa_API.Models;

namespace CadastroPessoa_API.Services.PessoaService
{
    public interface IPessoaInterface
    {
        Task<ServiceResponse<List<PessoaDto>>> FindPessoas();

        Task<ServiceResponse<PessoaDto>> CreatePessoa(PessoaDto pessoa);

        Task<ServiceResponse<PessoaDto>> FindPessoaById(int id);

        Task<ServiceResponse<PessoaDto>> UpdatePessoa(PessoaDto pessoa);

        void DeletePessoa(int id);

        Task<ServiceResponse<PessoaDto>> InactivatePessoa(int id);

    }
}
