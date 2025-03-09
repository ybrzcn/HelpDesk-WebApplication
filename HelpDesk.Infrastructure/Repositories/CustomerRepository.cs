using AutoMapper;
using HelpDesk.Core.Entities;
using HelpDesk.Infrastructure.Contexts;
using HelpDesk.Infrastructure.Dtos;
using HelpDesk.Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace HelpDesk.Infrastructure.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly StoreContext _storeContext;
        private readonly IMapper _mapper;

        public CustomerRepository(StoreContext storeContext, IMapper mapper)
        {
            _storeContext = storeContext;
            _mapper = mapper;
        }

        public async Task CreateAsync(CustomerDto dto)
        {
            var value = _mapper.Map<Customer>(dto);
            await _storeContext.AddAsync(value);
            await SaveAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var value = await GetByIdAsync(id);
            if (value != null)
            {
                var customer = await _storeContext.Customers.FindAsync(id);
                if (customer != null)
                {
                    _storeContext.Remove(customer);
                    await SaveAsync();
                }
            }
        }

        public async Task<List<CustomerDto>> GetAllAsync()
        {
            return await _storeContext.Customers
                .OrderBy(x => x.UserName)
                .Select(x => _mapper.Map<CustomerDto>(x))
                .ToListAsync();
        }

        public async Task<CustomerDto?> GetByIdAsync(Guid id)
        {
            var value = await _storeContext.Customers.FirstOrDefaultAsync(x => x.Id == id);
            return _mapper.Map<CustomerDto>(value);
        }

        public async Task<CustomerDto> GetUserByEmailAsync(string email)
        {
            var value = await _storeContext.Customers
                .FirstOrDefaultAsync(x => x.Email.Equals(email));
            return _mapper.Map<CustomerDto>(value);
        }

        public async Task<CustomerDto> GetUserByUserNameAsync(string userName)
        {
            var value = await _storeContext.Customers
                .FirstOrDefaultAsync(x => x.UserName.Equals(userName));
            return _mapper.Map<CustomerDto>(value);
        }

        public async Task SaveAsync()
        {
            await _storeContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(CustomerDto dto)
        {
            var value = _mapper.Map<Customer>(dto);
            _storeContext.Update(value);
            await SaveAsync();
        }
    }
}
