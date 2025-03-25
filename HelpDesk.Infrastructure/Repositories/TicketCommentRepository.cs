using AutoMapper;
using HelpDesk.Core.Entities;
using HelpDesk.Infrastructure.Contexts;
using HelpDesk.Infrastructure.Dtos;
using HelpDesk.Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace HelpDesk.Infrastructure.Repositories
{
    public class TicketCommentRepository : ITicketCommentRepository
    {
        private readonly StoreContext _storeContext;
        private readonly IMapper _mapper;

        public TicketCommentRepository(StoreContext storeContext, IMapper mapper)
        {
            _storeContext = storeContext;
            _mapper = mapper;
        }

        public async Task CreateAsync(TicketCommentDto dto)
        {
            var value = _mapper.Map<TicketComment>(dto);
            await _storeContext.AddAsync(value);
            await SaveAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var value = await GetByIdAsync(id);
            if (value != null)
            {
                var ticketComments = await _storeContext.TicketComments.FindAsync(id);
                if (ticketComments != null)
                {
                    _storeContext.Remove(ticketComments);
                    await SaveAsync();
                }
            }
        }

        public async Task<List<TicketCommentDto>> GetAllAsync()
        {
            return await _storeContext.TicketComments
                .OrderBy(x => x.CreatedDate)
                .Select(x => _mapper.Map<TicketCommentDto>(x))
                .ToListAsync();
        }

        public async Task<TicketCommentDto?> GetByIdAsync(Guid id)
        {
            var value = await _storeContext.TicketComments.FirstOrDefaultAsync(x => x.Id == id);
            return _mapper.Map<TicketCommentDto>(value);
        }

        public async Task<IEnumerable<TicketCommentDto>> GetTicketCommentByAuthorAsync(Guid id)
        {
            return await _storeContext.TicketComments
                .Where(x => x.AuthorId == id)
                .Select(x => _mapper.Map<TicketCommentDto>(x))
                .ToListAsync();
        }

        public async Task<IEnumerable<TicketCommentDto>> GetTicketCommentByTicketAsync(Guid id)
        {
            return await _storeContext.TicketComments
                .Where(x => x.TicketId == id)
                .Select(x => _mapper.Map<TicketCommentDto>(x))
                .ToListAsync();
        }

        public async Task SaveAsync()
        {
            await _storeContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(TicketCommentDto dto)
        {
            var value = _mapper.Map<TicketAttachment>(dto);
            _storeContext.Update(value);
            await SaveAsync();
        }
    }
}
