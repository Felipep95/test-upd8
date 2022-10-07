using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections;
using System.Threading.Tasks;
using TestUpd8.Api.Contracts;
using TestUpd8.Api.DTOs.Request;
using TestUpd8.Api.Utils;

namespace TestUpd8.Api.Controllers
{
    [ApiController]
    [Route("api/upd8Test/client")]
    public class ClientController : ControllerBase
    {
        private readonly IClientService _clientService;

        public ClientController(IClientService userService)
        {
            _clientService = userService;
        }

        [Route("create")]
        [HttpPost]
        [ProducesResponseType(typeof(IEnumerable), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        public async ValueTask<IActionResult> Post([FromBody] CreateClientRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ClientMessages.InvalidData);
            }

            try
            {
                await _clientService.AddAsync(request);
                return Ok(ClientMessages.ClientCreatedSucessfully);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Route("{id}")]
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        public async ValueTask<IActionResult> GetById([FromRoute] Guid id)
        {
            try
            {
                return Ok(await _clientService.FindByIdAsync(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Route("list")]
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        public async ValueTask<IActionResult> GetAll()
        {
            try
            {
                return Ok(await _clientService.FindAllAsNoTrackingAsync());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Route("{id}")]
        [HttpPut]
        [ProducesResponseType(typeof(IEnumerable), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        public async ValueTask<IActionResult> Put([FromRoute] Guid id, UpdateClientRequest request)
        {
            try
            {
                return Ok(await _clientService.UpdateAsync(id, request));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Route("{id}")]
        [HttpDelete]
        [ProducesResponseType(typeof(IEnumerable), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        public IActionResult Delete([FromRoute] Guid id)
        {
            try
            {
                return Ok(_clientService.DeleteAsync(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
