using HelpDesk.Core.Entities;
using HelpDesk.Infrastructure.Dtos;

namespace HelpDesk.Infrastructure.Interfaces
{
    public interface ICustomerRepository : IBaseRepository<Customer, CustomerDto>
    {
        Task<IEnumerable<CustomerDto>> GetUserByEmailAsync(string email);
        Task<IEnumerable<CustomerDto>> GetUserByUserNameAsync(string userName);
    }
}
