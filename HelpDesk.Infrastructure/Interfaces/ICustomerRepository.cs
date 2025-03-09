using HelpDesk.Core.Entities;
using HelpDesk.Infrastructure.Dtos;

namespace HelpDesk.Infrastructure.Interfaces
{
    public interface ICustomerRepository : IBaseRepository<Customer, CustomerDto>
    {
        Task<CustomerDto> GetUserByEmailAsync(string email);
        Task<CustomerDto> GetUserByUserNameAsync(string userName);
    }
}
