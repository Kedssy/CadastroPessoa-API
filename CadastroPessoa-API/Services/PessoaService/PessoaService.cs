using CadastroPessoa_API.DataManager;
using CadastroPessoa_API.Dtos;
using CadastroPessoa_API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Threading.Tasks;

namespace CadastroPessoa_API.Services.PessoaService
{
    public class PessoaService : IPessoaInterface
    {
        private ApplicationDataContext _context;
        PessoaDto pessoaDto = new PessoaDto();

        public  PessoaService(ApplicationDataContext context) 
        {
            _context = context;
        } 

        public async Task<ServiceResponse<PessoaDto>> CreatePessoa(PessoaDto pessoaDto)
        {
            ServiceResponse<PessoaDto> serviceResponse = new ServiceResponse<PessoaDto>();

            try
            {
                ValidatePessoa(pessoaDto);

                Pessoa pessoa = new Pessoa();
                pessoa.Nome = pessoaDto.Nome;
                pessoa.Cpf = pessoaDto.Cpf;
                pessoa.DtNascimento = pessoaDto.DtNascimento;
                pessoa.Ativo = true;
                pessoa.DtAlteracao = DateTime.Now.ToLocalTime();
                

                if (pessoaDto.Telefones?.Any() == true)
                {
                    pessoa.Telefones = pessoaDto.Telefones.Select(t => new Telefone { NrTelefone = t }).ToList();
                }

                _context.Add(pessoa);
                await _context.SaveChangesAsync();

                serviceResponse.Data = pessoaDto.GetInstance(pessoa);
            }

            catch (Exception ex)
            {
                serviceResponse.Message = ex.Message;
                serviceResponse.Sucess = false;
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<PessoaDto>> UpdatePessoa(PessoaDto pessoaDto)
        {
            ServiceResponse<PessoaDto> serviceResponse = new ServiceResponse<PessoaDto>();

            try
            {
                Pessoa pessoa = _context.Pessoas.FirstOrDefault(p => p.Id == pessoaDto.Id);

                if (pessoa == null)
                {
                    throw new ArgumentException($"Pessoa com id: {pessoaDto.Id} não encontrada.");
                }

                ValidatePessoa(pessoaDto);

                pessoa.Nome = pessoaDto.Nome;
                pessoa.DtNascimento = pessoaDto.DtNascimento;
                pessoa.Cpf = pessoaDto.Cpf;
                pessoa.DtAlteracao = DateTime.Now.ToLocalTime();

                _context.Pessoas.Update(pessoa);
                await _context.SaveChangesAsync();

                serviceResponse.Data = pessoaDto.GetInstance(pessoa);

            }
            catch (Exception ex)
            {
                serviceResponse.Message = ex.Message;
                serviceResponse.Sucess = false;
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<PessoaDto>> DeletePessoa(int id)
        {
            ServiceResponse<PessoaDto> serviceResponse = new ServiceResponse<PessoaDto>();

            try
            {

                Pessoa pessoa = _context.Pessoas.FirstOrDefault(p => p.Id == id);

                if (pessoa == null)
                {
                    throw new ArgumentException($"Pessoa com id: {id} não encontrada.");
                }

                _context.Pessoas.Remove(pessoa);
                await _context.SaveChangesAsync();

            }
            catch (Exception ex)
            {
                serviceResponse.Message = ex.Message;
                serviceResponse.Sucess = false;
            }
            return serviceResponse;
        }

        public async Task<ServiceResponse<PessoaDto>> FindPessoaById(int id)
        {
            ServiceResponse<PessoaDto> serviceResponse = new ServiceResponse<PessoaDto>();

            try
            {
                
                Pessoa pessoa = _context.Pessoas.FirstOrDefault(p => p.Id == id);

                if (pessoa == null)
                {
                    throw new ArgumentException($"Pessoa com id: {id} não encontrada.");
                }

                serviceResponse.Data = pessoaDto.GetInstance(pessoa);

            }
            catch (Exception ex)
            {
                serviceResponse.Message = ex.Message;
                serviceResponse.Sucess = false;
            }

            return serviceResponse;
        }

        public  async Task<ServiceResponse<List<PessoaDto>>> FindPessoas()
        {
           ServiceResponse<List<PessoaDto>> serviceResponse = new ServiceResponse<List<PessoaDto>>();

            try
            {
                serviceResponse.Data = pessoaDto.GetListInstance(_context.Pessoas.ToList());

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

        public async Task<ServiceResponse<PessoaDto>> InactivatePessoa(int id)
        {
            ServiceResponse<PessoaDto> serviceResponse = new ServiceResponse<PessoaDto>();

            try
            {
                Pessoa pessoa = _context.Pessoas.FirstOrDefault(p => p.Id == id);
                pessoa.Ativo = false;
                pessoa.DtAlteracao  =   DateTime.Now.ToLocalTime();

                _context.Pessoas.Update(pessoa);
                
                await _context.SaveChangesAsync();

                serviceResponse.Data = pessoaDto.GetInstance(pessoa);

            }
            catch (Exception ex)
            {
                serviceResponse.Message = ex.Message;
                serviceResponse.Sucess = false;
            }

            return serviceResponse;
        }

        public void ValidatePessoa(PessoaDto pessoaDto)
        {
            if (pessoaDto.Nome.IsNullOrEmpty())
            {
                throw new ArgumentException("Por favor, informe o nome da pessoa.");
            }

            if (pessoaDto.Cpf.IsNullOrEmpty())
            {
                throw new ArgumentException("Por favor, informe o CPF da pessoa.");
            }

            if (!ValidateCpf(pessoaDto.Cpf))
            {
                throw new ArgumentException("CPF inválido. Por favor, verifique.");
            }

            if (pessoaDto.Telefones.IsNullOrEmpty())
            {
                throw new ArgumentException("Por favor, informe ao menos um telefone para a pessoa.");
            }
        }

        public bool ValidateCpf(string cpf)
        {
            if (cpf.Length != 11)
                return false;

            if (cpf.Distinct().Count() == 1)
                return false;

            return true;
        }
    }
}
