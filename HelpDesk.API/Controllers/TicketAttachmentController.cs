using HelpDesk.Core.Entities;
using HelpDesk.Infrastructure.Dtos;
using HelpDesk.Infrastructure.Interfaces;
using HelpDesk.Infrastructure.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HelpDesk.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TicketAttachmentController : ControllerBase
    {
        private readonly ITicketAttachmentRepository _ticketAttachmentRepository;

        public TicketAttachmentController(ITicketAttachmentRepository ticketAttachmentRepository)
        {
            _ticketAttachmentRepository = ticketAttachmentRepository;
        }

        [HttpGet("GetTicketAttachments")]
        [ProducesResponseType(200, Type = typeof(List<TicketAttachment>))]
        public async Task<IActionResult> GetTicketAttachments()
        {
            var value = await _ticketAttachmentRepository.GetAllAsync();
            return Ok(value);
        }

        [HttpGet("GetTicketAttachmentById/{id}")]
        [ProducesResponseType(200, Type = typeof(TicketAttachment))]
        [ProducesResponseType(400)]
        public async Task<IActionResult> GetTicketAttachmentById(Guid id)
        {
            var value = await _ticketAttachmentRepository.GetByIdAsync(id);
            if (value == null) return NotFound("Ticket Attachment not found.");
            return Ok(value);
        }

        [HttpGet("GetTicketAttachmentByTicketId/{ticketId}")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<TicketAttachmentDto>))]
        [ProducesResponseType(404)]
        public async Task<IActionResult> GetCommentsByRecipeId(Guid ticketId)
        {
            var values = await _ticketAttachmentRepository.GetTicketAttachmentByTicketAsync(ticketId);
            if (values == null || !values.Any())
                return NotFound("Ticket Attachment not found.");

            return Ok(values);
        }

        [HttpPost("CreateTicketAttachment")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> CreateTicketAttachment(TicketAttachmentDto dto)
        {
            await _ticketAttachmentRepository.CreateAsync(dto);
            return Ok("Ticket Attachment created successfully.");
        }

        [HttpDelete("DeleteTicketAttachment/{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> DeleteTicketAttachment(Guid id)
        {
            await _ticketAttachmentRepository.DeleteAsync(id);
            return Ok("Ticket Attachment deleted successfully.");
        }

        [HttpPut("UpdateTicketAttachment/{id}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> UpdateTicketAttachment(Guid id, TicketAttachmentDto dto)
        {
            if (id != dto.Id)
            {
                return BadRequest("ID mismatch.");
            }

            await _ticketAttachmentRepository.UpdateAsync(dto);
            return Ok("Ticket Attachment updated successfully.");
        }
    }
}
