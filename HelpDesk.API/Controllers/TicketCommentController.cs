using HelpDesk.Core.Entities;
using HelpDesk.Infrastructure.Dtos;
using HelpDesk.Infrastructure.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace HelpDesk.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TicketCommentController : ControllerBase
    {
        private readonly ITicketCommentRepository _ticketCommentRepository;

        public TicketCommentController(ITicketCommentRepository ticketCommentRepository)
        {
            _ticketCommentRepository = ticketCommentRepository;
        }

        [HttpGet("GetTicketComments")]
        [ProducesResponseType(200, Type = typeof(List<TicketComment>))]
        public async Task<IActionResult> GetTicketComments()
        {
            var value = await _ticketCommentRepository.GetAllAsync();
            return Ok(value);
        }

        [HttpGet("GetTicketCommentById/{id}")]
        [ProducesResponseType(200, Type = typeof(TicketComment))]
        [ProducesResponseType(400)]
        public async Task<IActionResult> GetTicketCommentById(Guid id)
        {
            var value = await _ticketCommentRepository.GetByIdAsync(id);
            if (value == null) return NotFound("Ticket Comment not found.");
            return Ok(value);
        }

        [HttpGet("GetTicketCommentByTicketId/{ticketId}")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<TicketCommentDto>))]
        [ProducesResponseType(404)]
        public async Task<IActionResult> GetCommentsByTicketId(Guid ticketId)
        {
            var values = await _ticketCommentRepository.GetTicketCommentByTicketAsync(ticketId);
            if (values == null || !values.Any())
                return NotFound("Ticket Comment not found.");

            return Ok(values);
        }

        [HttpGet("GetTicketCommentByAuthorId/{authorId}")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<TicketCommentDto>))]
        [ProducesResponseType(404)]
        public async Task<IActionResult> GetCommentByAuthorId(Guid authorId)
        {
            var values = await _ticketCommentRepository.GetTicketCommentByAuthorAsync(authorId);
            if (values == null || !values.Any())
                return NotFound("Ticket Comment not found.");

            return Ok(values);
        }

        [HttpPost("CreateTicketComment")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> CreateTicketComment(TicketCommentDto dto)
        {
            await _ticketCommentRepository.CreateAsync(dto);
            return Ok("Ticket Comment created successfully.");
        }

        [HttpDelete("DeleteTicketComment/{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> DeleteTicketComment(Guid id)
        {
            await _ticketCommentRepository.DeleteAsync(id);
            return Ok("Ticket Comment deleted successfully.");
        }

        [HttpPut("UpdateTicketComment/{id}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> UpdateTicketComment(Guid id, TicketCommentDto dto)
        {
            if (id != dto.Id)
            {
                return BadRequest("ID mismatch.");
            }

            await _ticketCommentRepository.UpdateAsync(dto);
            return Ok("Ticket Comment updated successfully.");
        }
    }
}
