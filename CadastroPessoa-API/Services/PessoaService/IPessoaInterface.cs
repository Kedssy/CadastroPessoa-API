using CadastroPessoa_API.Models;

namespace CadastroPessoa_API.Services.PessoaService
{
    public interface IPessoaInterface
    {
        Task<ServiceResponse<List<Pessoa>>> FindPessoas();

        Task<ServiceResponse<List<Pessoa>>> CreatePessoa(Pessoa pessoa);

        Task<ServiceResponse<Pessoa>> FindPessoaById(int id);

        Task<ServiceResponse<List<Pessoa>>> UpdatePessoa(Pessoa pessoa);

        Task<ServiceResponse<List<Pessoa>>> DeletePessoa(int id);

        Task<ServiceResponse<List<Pessoa>>> InactivatePessoa(int id);

    }
}
