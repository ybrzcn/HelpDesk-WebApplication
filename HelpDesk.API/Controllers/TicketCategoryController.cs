using HelpDesk.Core.Entities;
using HelpDesk.Infrastructure.Dtos;
using HelpDesk.Infrastructure.Interfaces;
using HelpDesk.Infrastructure.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace HelpDesk.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TicketCategoryController : ControllerBase
    {
        private readonly ITicketCategoryRepository _ticketCategoryRepository;

        public TicketCategoryController(ITicketCategoryRepository ticketCategoryRepository)
        {
            _ticketCategoryRepository = ticketCategoryRepository;
        }

        [HttpGet("GetTicketCategoryRepositories")]
        [ProducesResponseType(200, Type = typeof(List<TicketCategory>))]
        public async Task<IActionResult> GetTicketCategoryRepositories()
        {
            var value = await _ticketCategoryRepository.GetAllAsync();
            return Ok(value);
        }

        [HttpGet("GetTicketCategoryById/{id}")]
        [ProducesResponseType(200, Type = typeof(TicketCategory))]
        [ProducesResponseType(400)]
        public async Task<IActionResult> GetTicketCategoryById(Guid id)
        {
            var value = await _ticketCategoryRepository.GetByIdAsync(id);
            if (value == null) return NotFound("Ticket Category not found.");
            return Ok(value);
        }

        [HttpGet("GetTicketCategoryByName/{name}")]
        [ProducesResponseType(200, Type = typeof(TicketCategoryDto))]
        [ProducesResponseType(404)]
        public async Task<IActionResult> GetTicketCategoryByName(string name)
        {
            var value = await _ticketCategoryRepository.GetTicketCategoryByNameAsync(name);
            if (value == null) return NotFound("Ticket Category not found.");
            return Ok(value);
        }

        [HttpPost("CreateTicketCategory")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> CreateTicketCategory(TicketCategoryDto dto)
        {
            await _ticketCategoryRepository.CreateAsync(dto);
            return Ok("Ticket Category created successfully.");
        }

        [HttpDelete("DeleteTicketCategory/{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> DeleteTicketCategory(Guid id)
        {
            await _ticketCategoryRepository.DeleteAsync(id);
            return Ok("Ticket Category deleted successfully.");
        }

        [HttpPut("UpdateTicketCategory/{id}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> UpdateTicketCategory(Guid id, TicketCategoryDto dto)
        {
            if (id != dto.Id)
            {
                return BadRequest("ID mismatch.");
            }

            await _ticketCategoryRepository.UpdateAsync(dto);
            return Ok("Ticket Category updated successfully.");
        }
    }
}
