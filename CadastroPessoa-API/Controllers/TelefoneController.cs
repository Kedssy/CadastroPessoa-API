using CadastroPessoa_API.Dtos;
using CadastroPessoa_API.Models;
using CadastroPessoa_API.Services.TelefoneService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CadastroPessoa_API.Controllers
{
    [Route("api/telefone")]
    [ApiController]
    public class TelefoneController : ControllerBase
    {

        private readonly ITelefoneInterface _telefoneInterface;
        public TelefoneController(ITelefoneInterface telefoneInterface)
        {
            _telefoneInterface = telefoneInterface;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResponse<TelefoneDto>>> FindTelefoneById(int id)
        {
            var serviceResponse = await _telefoneInterface.FindTelefoneById(id);

            if (!serviceResponse.Sucess)
            {
                return BadRequest(new { serviceResponse.Data, serviceResponse.Message, serviceResponse.Sucess });
            }

            return Ok(serviceResponse);

        } 

        [HttpGet]
        public async Task<ActionResult<ServiceResponse<List<TelefoneDto>>>> FindTelefones()
        {
            var serviceResponse = await _telefoneInterface.FindTelefones();

            if (!serviceResponse.Sucess)
            {
                return BadRequest(new { serviceResponse.Data, serviceResponse.Message, serviceResponse.Sucess });
            }

            return Ok(serviceResponse);
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<TelefoneDto>>> CreateTelefone(TelefoneDto telefoneDto)
        {

            var serviceResponse = await _telefoneInterface.CreateTelefone(telefoneDto);

            if (!serviceResponse.Sucess)
            {
                return BadRequest(new { serviceResponse.Data,serviceResponse.Message,serviceResponse.Sucess });
            }

            return Ok(serviceResponse);
          

        }

        [HttpPut]
        public async Task<ActionResult<ServiceResponse<TelefoneDto>>> UpdateTelefone(TelefoneDto telefoneDto)
        {
            var serviceResponse = await _telefoneInterface.UpdateTelefone(telefoneDto);

            if (!serviceResponse.Sucess)
            {
                return BadRequest(new { serviceResponse.Data, serviceResponse.Message, serviceResponse.Sucess });
            }

            return Ok(serviceResponse);
        }


        [HttpDelete]
        public async Task<ActionResult<ServiceResponse<TelefoneDto>>> DeleteTelefone(int id)
        {

            var serviceResponse = await _telefoneInterface.DeleteTelefone(id);

            if (!serviceResponse.Sucess)
            {
                return BadRequest(new { serviceResponse.Data, serviceResponse.Message, serviceResponse.Sucess });
            }

            return Ok(serviceResponse);


        }
    }
}
