using CadastroPessoa_API.Dtos;
using CadastroPessoa_API.Models;
using CadastroPessoa_API.Services.PessoaService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CadastroPessoa_API.Controllers
{
    [Route("api/pessoa")]
    [ApiController]
    public class PessoaController : ControllerBase
    {

        private readonly IPessoaInterface _pessoaInterface;
        public PessoaController(IPessoaInterface pessoaInterface)
        {
            _pessoaInterface = pessoaInterface;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResponse<PessoaDto>>> FindPessoaById(int id)
        {
            var serviceResponse = await _pessoaInterface.FindPessoaById(id);

            if (!serviceResponse.Sucess)
            {
                return BadRequest(new { serviceResponse.Data, serviceResponse.Message, serviceResponse.Sucess });
            }

            return Ok(serviceResponse);

        } 

        [HttpGet]
        public async Task<ActionResult<ServiceResponse<List<PessoaDto>>>> FindPessoas()
        {
            var serviceResponse = await _pessoaInterface.FindPessoas();

            if (!serviceResponse.Sucess)
            {
                return BadRequest(new { serviceResponse.Data, serviceResponse.Message, serviceResponse.Sucess });
            }

            return Ok(serviceResponse);
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<PessoaDto>>> CreatePessoa(PessoaDto pessoaDto)
        {

            var serviceResponse = await _pessoaInterface.CreatePessoa(pessoaDto);

            if (!serviceResponse.Sucess)
            {
                return BadRequest(new { serviceResponse.Data,serviceResponse.Message,serviceResponse.Sucess });
            }

            return Ok(serviceResponse);
          

        }

        [HttpPut]
        public async Task<ActionResult<ServiceResponse<PessoaDto>>> UpdatePessoa(PessoaDto pessoaDto)
        {
            var serviceResponse = await _pessoaInterface.UpdatePessoa(pessoaDto);

            if (!serviceResponse.Sucess)
            {
                return BadRequest(new { serviceResponse.Data, serviceResponse.Message, serviceResponse.Sucess });
            }

            return Ok(serviceResponse);
        }

        [HttpPut("inativaFuncionario")]
        public async Task<ActionResult<ServiceResponse<PessoaDto>>> InactivatePessoa(int id)
        {
            var serviceResponse = await _pessoaInterface.InactivatePessoa(id);

            if (!serviceResponse.Sucess)
            {
                return BadRequest(new { serviceResponse.Data, serviceResponse.Message, serviceResponse.Sucess });
            }

            return Ok(serviceResponse);
        }

        [HttpDelete]
        public async Task<ActionResult<ServiceResponse<PessoaDto>>> DeletePessoa(int id)
        {

            var serviceResponse = await _pessoaInterface.DeletePessoa(id);

            if (!serviceResponse.Sucess)
            {
                return BadRequest(new { serviceResponse.Data, serviceResponse.Message, serviceResponse.Sucess });
            }

            return Ok(serviceResponse);


        }
    }
}
