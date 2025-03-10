using AutoMapper;
using HelpDesk.Core.Entities;
using HelpDesk.Infrastructure.Contexts;
using HelpDesk.Infrastructure.Dtos;
using HelpDesk.Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace HelpDesk.Infrastructure.Repositories
{
    public class TicketAttachmentRepository : ITicketAttachmentRepository
    {
        private readonly StoreContext _storeContext;
        private readonly IMapper _mapper;

        public TicketAttachmentRepository(StoreContext storeContext, IMapper mapper)
        {
            _storeContext = storeContext;
            _mapper = mapper;
        }

        public async Task CreateAsync(TicketAttachmentDto dto)
        {
            var value = _mapper.Map<TicketAttachment>(dto);
            await _storeContext.AddAsync(value);
            await SaveAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var value = await GetByIdAsync(id);
            if (value != null)
            {
                var ticketAttachment = await _storeContext.TicketAttachments.FindAsync(id);
                if (ticketAttachment != null)
                {
                    _storeContext.Remove(ticketAttachment);
                    await SaveAsync();
                }
            }
        }

        public async Task<List<TicketAttachmentDto>> GetAllAsync()
        {
            return await _storeContext.TicketAttachments
                .OrderBy(x => x.CreatedDate)
                .Select(x => _mapper.Map<TicketAttachmentDto>(x))
                .ToListAsync();
        }

        public async Task<TicketAttachmentDto?> GetByIdAsync(Guid id)
        {
            var value = await _storeContext.TicketAttachments.FirstOrDefaultAsync(x => x.Id == id);
            return _mapper.Map<TicketAttachmentDto>(value);
        }

        public async Task<IEnumerable<TicketAttachmentDto>> GetTicketAttachmentByTicketAsync(Guid id)
        {
            return await _storeContext.TicketAttachments
                .Where(x => x.TicketId == id)
                .Select(x => _mapper.Map<TicketAttachmentDto>(x))
                .ToListAsync();
        }

        public async Task SaveAsync()
        {
            await _storeContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(TicketAttachmentDto dto)
        {
            var value = _mapper.Map<TicketAttachment>(dto);
            _storeContext.Update(value);
            await SaveAsync();
        }
    }
}
