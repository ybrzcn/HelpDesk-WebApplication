using HelpDesk.Core.Entities;
using HelpDesk.Core.Enums;
using HelpDesk.Infrastructure.Dtos;
using HelpDesk.Infrastructure.Interfaces;
using HelpDesk.Infrastructure.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HelpDesk.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TicketLogController : ControllerBase
    {
        private readonly ITicketLogRepository _ticketLogRepository;

        public TicketLogController(ITicketLogRepository ticketLogRepository)
        {
            _ticketLogRepository = ticketLogRepository;
        }

        [HttpGet("GetTicketLogs")]
        [ProducesResponseType(200, Type = typeof(List<TicketLog>))]
        public async Task<IActionResult> GetTicketLogs()
        {
            var value = await _ticketLogRepository.GetAllAsync();
            return Ok(value);
        }

        [HttpGet("GetTicketLogById/{id}")]
        [ProducesResponseType(200, Type = typeof(TicketLog))]
        [ProducesResponseType(400)]
        public async Task<IActionResult> GetTicketLogById(Guid id)
        {
            var value = await _ticketLogRepository.GetByIdAsync(id);
            if (value == null) return NotFound("Ticket Log not found.");
            return Ok(value);
        }

        [HttpGet("GetTicketLogByTicketId/{ticketId}")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<TicketLogDto>))]
        [ProducesResponseType(404)]
        public async Task<IActionResult> GetTicketLogByTicketId(Guid ticketId)
        {
            var values = await _ticketLogRepository.GetTicketLogByTicketAsync(ticketId);
            if (values == null || !values.Any())
                return NotFound("Ticket Log not found.");

            return Ok(values);
        }

        [HttpGet("GetTicketLogByUserId/{userId}")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<TicketLogDto>))]
        [ProducesResponseType(404)]
        public async Task<IActionResult> GetTicketLogByUserId(Guid userId)
        {
            var values = await _ticketLogRepository.GetTicketLogByUserAsync(userId);
            if (values == null || !values.Any())
                return NotFound("Ticket Log not found.");

            return Ok(values);
        }

        [HttpGet("GetTicketLogByAction/{action}")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<TicketLogDto>))]
        [ProducesResponseType(404)]
        public async Task<IActionResult> GetTicketLogByAction(TicketAction action)
        {
            var values = await _ticketLogRepository.GetTicketLogByActionAsync(action);
            if (values == null || !values.Any())
                return NotFound("Ticket Log not found.");

            return Ok(values);
        }

        [HttpPost("CreateTicketLog")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> CreateTicketLog(TicketLogDto dto)
        {
            await _ticketLogRepository.CreateAsync(dto);
            return Ok("Ticket Log created successfully.");
        }

        [HttpDelete("DeleteTicketLog/{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> DeleteTicketLog(Guid id)
        {
            await _ticketLogRepository.DeleteAsync(id);
            return Ok("Ticket Log deleted successfully.");
        }

        [HttpPut("UpdateTicketLog/{id}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> UpdateTicketLog(Guid id, TicketLogDto dto)
        {
            if (id != dto.Id)
            {
                return BadRequest("ID mismatch.");
            }

            await _ticketLogRepository.UpdateAsync(dto);
            return Ok("Ticket Log updated successfully.");
        }
    }
}
