using CadastroPessoa_API.DataManager;
using CadastroPessoa_API.Models;

namespace CadastroPessoa_API.Services.PessoaService
{
    public class PessoaService : IPessoaInterface
    {
        private ApplicationDataContext _context;
        public  PessoaService(ApplicationDataContext context) 
        {
            _context = context;
        } 

        public Task<ServiceResponse<List<Pessoa>>> CreatePessoa(Pessoa pessoa)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResponse<List<Pessoa>>> DeletePessoa(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResponse<Pessoa>> FindPessoaById(int id)
        {
            throw new NotImplementedException();
        }

        public  async Task<ServiceResponse<List<Pessoa>>> FindPessoas()
        {
           ServiceResponse<List<Pessoa>> serviceResponse = new ServiceResponse<List<Pessoa>>();

            try
            {
                serviceResponse.Dados = _context.Pessoas.ToList();
                 
            }
            catch (Exception ex)
            {
                serviceResponse.Mensagem = ex.Message;
                serviceResponse.Sucesso = false;
               
            }

            return serviceResponse;
        }

        public Task<ServiceResponse<List<Pessoa>>> GetPessoas()
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResponse<List<Pessoa>>> InactivatePessoa(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResponse<List<Pessoa>>> UpdatePessoa(Pessoa pessoa)
        {
            throw new NotImplementedException();
        }
    }
}
