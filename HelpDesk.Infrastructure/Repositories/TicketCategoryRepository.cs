using AutoMapper;
using HelpDesk.Core.Entities;
using HelpDesk.Infrastructure.Contexts;
using HelpDesk.Infrastructure.Dtos;
using HelpDesk.Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace HelpDesk.Infrastructure.Repositories
{
    public class TicketCategoryRepository : ITicketCategoryRepository
    {
        private readonly StoreContext _storeContext;
        private readonly IMapper _mapper;

        public TicketCategoryRepository(StoreContext storeContext, IMapper mapper)
        {
            _mapper = mapper;
            _storeContext = storeContext;
        }

        public async Task CreateAsync(TicketCategoryDto dto)
        {
            var value = _mapper.Map<TicketCategory>(dto);
            await _storeContext.AddAsync(value);
            await SaveAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var value = await GetByIdAsync(id);
            if (value != null)
            {
                var ticketCategory = await _storeContext.TicketCategories.FindAsync(id);
                if (ticketCategory != null)
                {
                    _storeContext.Remove(ticketCategory);
                    await SaveAsync();
                }
            }
        }

        public async Task<List<TicketCategoryDto>> GetAllAsync()
        {
            return await _storeContext.TicketCategories
                .OrderBy(x => x.CreatedDate)
                .Select(x => _mapper.Map<TicketCategoryDto>(x))
                .ToListAsync();
        }

        public async Task<TicketCategoryDto?> GetByIdAsync(Guid id)
        {
            var value = await _storeContext.TicketCategories.FirstOrDefaultAsync(x => x.Id == id);
            return _mapper.Map<TicketCategoryDto>(value);
        }

        public async Task<TicketCategoryDto> GetTicketCategoryByNameAsync(string name)
        {
            var value = await _storeContext.TicketCategories
                .FirstOrDefaultAsync(x => x.Name.Equals(name));
            return _mapper.Map<TicketCategoryDto>(value);
        }

        public async Task SaveAsync()
        {
            await _storeContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(TicketCategoryDto dto)
        {
            var value = _mapper.Map<TicketCategoryDto>(dto);
            _storeContext.Update(value);
            await SaveAsync();
        }
    }
}
