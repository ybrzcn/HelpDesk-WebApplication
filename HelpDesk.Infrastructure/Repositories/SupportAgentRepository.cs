using AutoMapper;
using HelpDesk.Core.Entities;
using HelpDesk.Infrastructure.Contexts;
using HelpDesk.Infrastructure.Dtos;
using HelpDesk.Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace HelpDesk.Infrastructure.Repositories
{
    public class SupportAgentRepository : ISupportAgentRepository
    {
        private readonly StoreContext _storeContext;
        private readonly IMapper _mapper;

        public SupportAgentRepository(StoreContext storeContext, IMapper mapper)
        {
            _storeContext = storeContext;
            _mapper = mapper;
        }

        public async Task CreateAsync(SupportAgentDto dto)
        {
            var value = _mapper.Map<SupportAgent>(dto);
            await _storeContext.AddAsync(value);
            await SaveAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var value = await GetByIdAsync(id);
            if (value != null)
            {
                var customer = await _storeContext.SupportAgents.FindAsync(id);
                if (customer != null)
                {
                    _storeContext.Remove(customer);
                    await SaveAsync();
                }
            }
        }

        public async Task<List<SupportAgentDto>> GetAllAsync()
        {
            return await _storeContext.SupportAgents
                .OrderBy(x => x.UserName)
                .Select(x => _mapper.Map<SupportAgentDto>(x))
                .ToListAsync();
        }

        public async Task<SupportAgentDto?> GetByIdAsync(Guid id)
        {
            var value = await _storeContext.SupportAgents.FirstOrDefaultAsync(x => x.Id == id);
            return _mapper.Map<SupportAgentDto>(value);
        }

        public async Task<SupportAgentDto> GetSupportAgentByEmailAsync(string email)
        {
            var value = await _storeContext.SupportAgents
                .FirstOrDefaultAsync(x => x.Email.Equals(email));
            return _mapper.Map<SupportAgentDto>(value);
        }

        public async Task<SupportAgentDto> GetSupportAgentByUserNameAsync(string userName)
        {
            var value = await _storeContext.SupportAgents
                .FirstOrDefaultAsync(x => x.UserName.Equals(userName));
            return _mapper.Map<SupportAgentDto>(value);
        }

        public async Task SaveAsync()
        {
            await _storeContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(SupportAgentDto dto)
        {
            var value = _mapper.Map<SupportAgent>(dto);
            _storeContext.Update(value);
            await SaveAsync();
        }
    }
}
