using System.Collections.Generic;
using System.Threading.Tasks;
using GOC.GraphQL.API.Data.Models;

namespace GOC.GraphQL.API.Interfaces
{
    public interface IAddressRepository
    {
        Task<List<Address>> Get(int addressId);
    }
}
