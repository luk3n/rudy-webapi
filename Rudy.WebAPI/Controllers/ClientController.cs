using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Rudy.Services.Interfaces;
using Rudy.Common.Configuration;
using Rudy.Common.Data.Pagination;
using Rudy.DTO;
using System;

namespace Rudy.WebAPI.Controllers
{
    [Route("api/clients")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly IClientService _clientService;
        private readonly IConfigurationManager _configurationManager;

        public ClientController(IClientService clientService, IConfigurationManager configurationManager)
        {
            _clientService = clientService;
            _configurationManager = configurationManager;
        }

        /// <summary>
        /// Get a client by ID
        /// </summary>
        /// <param name="id">The ID of the client</param>
        /// <returns>The specified client</returns>
        [HttpGet("{id:int}", Name = "byId")]
        public async Task<IActionResult> GetClient(int id)
        {
            var result = await _clientService.GetClient(id);

            return Ok(result);
        }

        /// <summary>
        /// Get all the clients. Default page size: 10 elements
        /// </summary>
        /// <param name="options">The paging options</param>
        /// <returns>A list of clients, paged using the specified settings</returns>
        [HttpGet]
        public async Task<IActionResult> GetClients([FromQuery]PagingOptions options)
        {
            var result = await _clientService.GetAll(options);

            return Ok(result);
        }

        /// <summary>
        /// Create a new client
        /// </summary>
        /// <param name="client">The client's information</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> PostClient([FromBody] ClientDTO client)
        {
            CreateResponseDTO result;

            try
            {
                result = await _clientService.CreateClient(client);

                if (result == null)
                    return StatusCode(500, "An error occured when trying to create client");
            }
            catch (Exception)
            {
                return StatusCode(500, "Internal server error");
            }

            return CreatedAtRoute("byId", new { id = result.Id }, result);
        }

        /// <summary>
        /// Edit a client
        /// </summary>
        /// <param name="client">The client's information</param>
        /// <returns></returns>
        [HttpPut]
        public async Task<IActionResult> PutClient([FromBody] ClientDTOEdit client)
        {
            try
            {
                var result = await _clientService.EditClient(client);

                if (!result)
                    return NotFound("An error occurred when trying to edit client");
            }
            catch (Exception)
            {
                return StatusCode(500, "Internal server error");
            }

            return NoContent();
        }

        /// <summary>
        /// Delete a client by ID
        /// </summary>
        /// <param name="id">The ID of the client</param>
        /// <returns></returns>
        [HttpDelete]
        public async Task<IActionResult> DeleteClient(int id)
        {
            try
            {
                var result = await _clientService.DeleteClient(id);

                if (!result)
                    return NotFound("An error occurred when trying to delete client");
            }
            catch (Exception)
            {
                return StatusCode(500, "Internal server error");
            }

            return NoContent();
        }
    }
}