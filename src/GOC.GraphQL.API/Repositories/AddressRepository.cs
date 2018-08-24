using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GOC.GraphQL.API.Data;
using GOC.GraphQL.API.Data.Models;
using GOC.GraphQL.API.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace GOC.GraphQL.API.Repositories
{
    public class AddressRepository : IAddressRepository
    {
        private readonly DatabaseContext _db;

        public AddressRepository(DatabaseContext db)
        {
            _db = db;
        }

        public async Task<List<Address>> Get(int customerId)
        {
            return await _db.Addresses.Include(ss => ss.State).Where(ss => ss.CustomerId == customerId).ToListAsync();
        }
    }
}
