using AutoMapper;
using HelpDesk.Core.Entities;
using HelpDesk.Core.Enums;
using HelpDesk.Infrastructure.Contexts;
using HelpDesk.Infrastructure.Dtos;
using HelpDesk.Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace HelpDesk.Infrastructure.Repositories
{
    public class TicketLogRepository : ITicketLogRepository
    {
        private readonly StoreContext _storeContext;
        private readonly IMapper _mapper;

        public TicketLogRepository(StoreContext storeContext, IMapper mapper)
        {
            _storeContext = storeContext;
            _mapper = mapper;
        }

        public async Task CreateAsync(TicketLogDto dto)
        {
            var value = _mapper.Map<TicketLog>(dto);
            await _storeContext.AddAsync(value);
            await SaveAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var value = await GetByIdAsync(id);
            if (value != null)
            {
                var ticketLogs = await _storeContext.TicketLogs.FindAsync(id);
                if (ticketLogs != null)
                {
                    _storeContext.Remove(ticketLogs);
                    await SaveAsync();
                }
            }
        }

        public async Task<List<TicketLogDto>> GetAllAsync()
        {
            return await _storeContext.TicketLogs
                .OrderBy(x => x.CreatedDate)
                .Select(x => _mapper.Map<TicketLogDto>(x))
                .ToListAsync();
        }

        public async Task<TicketLogDto?> GetByIdAsync(Guid id)
        {
            var value = await _storeContext.TicketComments.FirstOrDefaultAsync(x => x.Id == id);
            return _mapper.Map<TicketLogDto>(value);
        }

        public async Task<IEnumerable<TicketLogDto>> GetTicketLogByActionAsync(TicketAction action)
        {
            return await _storeContext.TicketLogs
                .Where(x => x.Action == action)
                .Select(x => _mapper.Map<TicketLogDto>(x))
                .ToListAsync();
        }

        public async Task<IEnumerable<TicketLogDto>> GetTicketLogByTicketAsync(Guid id)
        {
            return await _storeContext.TicketLogs
                .Where(x => x.TicketId == id)
                .Select(x => _mapper.Map<TicketLogDto>(x))
                .ToListAsync();
        }

        public async Task<IEnumerable<TicketLogDto>> GetTicketLogByUserAsync(Guid id)
        {
            return await _storeContext.TicketLogs
                .Where(x => x.UserId == id)
                .Select(x => _mapper.Map<TicketLogDto>(x))
                .ToListAsync();
        }

        public async Task SaveAsync()
        {
            await _storeContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(TicketLogDto dto)
        {
            var value = _mapper.Map<TicketLog>(dto);
            _storeContext.Update(value);
            await SaveAsync();
        }
    }
}
