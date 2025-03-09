using HelpDesk.Core.Entities;
using HelpDesk.Infrastructure.Dtos;
using HelpDesk.Infrastructure.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HelpDesk.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SupportAgentController : ControllerBase
    {
        private readonly ISupportAgentRepository _supportAgentRepository;

        public SupportAgentController(ISupportAgentRepository supportAgentRepository)
        {
            _supportAgentRepository = supportAgentRepository;
        }

        [HttpGet("GetSupportAgents")]
        [ProducesResponseType(200, Type = typeof(List<SupportAgent>))]
        public async Task<IActionResult> GetSupportAgents()
        {
            var value = await _supportAgentRepository.GetAllAsync();
            return Ok(value);
        }

        [HttpGet("GetSupportAgentById/{id}")]
        [ProducesResponseType(200, Type = typeof(SupportAgent))]
        [ProducesResponseType(400)]
        public async Task<IActionResult> GetSupportAgentById(Guid id)
        {
            var value = await _supportAgentRepository.GetByIdAsync(id);
            if (value == null) return NotFound("Support Agent not found.");
            return Ok(value);
        }

        [HttpGet("GetSupportAgentByEmail/{email}")]
        [ProducesResponseType(200, Type = typeof(SupportAgentDto))]
        [ProducesResponseType(404)]
        public async Task<IActionResult> GetSupportAgentByEmail(string email)
        {
            var value = await _supportAgentRepository.GetSupportAgentByEmailAsync(email);
            if (value == null) return NotFound("Support Agent not found.");
            return Ok(value);
        }

        [HttpGet("GetSupportAgentByUserName/{userName}")]
        [ProducesResponseType(200, Type = typeof(SupportAgentDto))]
        [ProducesResponseType(404)]
        public async Task<IActionResult> GetSupportAgentByUserName(string userName)
        {
            var value = await _supportAgentRepository.GetSupportAgentByUserNameAsync(userName);
            if (value == null) return NotFound("Support Agent not found.");
            return Ok(value);
        }

        [HttpPost("CreateSupportAgent")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> CreateSupportAgent(SupportAgentDto dto)
        {
            await _supportAgentRepository.CreateAsync(dto);
            return Ok("Support Agent created successfully.");
        }

        [HttpDelete("DeleteSupportAgent/{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> DeleteSupportAgent(Guid id)
        {
            await _supportAgentRepository.DeleteAsync(id);
            return Ok("Support Agent deleted successfully.");
        }

        [HttpPut("UpdateSupportAgent/{id}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> UpdateSupportAgent(Guid id, SupportAgentDto dto)
        {
            if (id != dto.Id)
            {
                return BadRequest("ID mismatch.");
            }

            await _supportAgentRepository.UpdateAsync(dto);
            return Ok("Support Agent updated successfully.");
        }
    }
}
