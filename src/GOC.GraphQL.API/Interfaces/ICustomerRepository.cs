using System.Collections.Generic;
using System.Threading.Tasks;
using GOC.GraphQL.API.Data.Models;

namespace GOC.GraphQL.API.Interfaces
{
    public interface ICustomerRepository
    {
        Task<Customer> Get(int id);
        Task<List<Customer>> All();
        Task<Customer> Update(Customer customer);
        Task<Customer> Add(Customer player);
        Task<Customer> Delete(int id);
    }
}
