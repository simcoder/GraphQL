using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GOC.GraphQL.API.Data;
using GOC.GraphQL.API.Data.Models;
using GOC.GraphQL.API.Interfaces;
using Microsoft.EntityFrameworkCore;
namespace GOC.GraphQL.API.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly DatabaseContext _db;
        public CustomerRepository(DatabaseContext db)
        {
            _db = db;
        }

        public async Task<Customer> Add(Customer customer)
        {
            await _db.Customers.AddAsync(customer);
            try{
                await _db.SaveChangesAsync();
            }
            catch(Exception e){
                
            }

            return customer;
        }

        public async Task<Customer> Update(Customer customer)
        {         
            try
            {
                _db.Attach(customer);
                _db.Entry(customer).State = EntityState.Modified;
                await _db.SaveChangesAsync();
            }
            catch (Exception e)
            {

            }

            return customer;
        }

        public async Task<List<Customer>> All()
        {
            return await _db.Customers.ToListAsync();
        }

        public async Task<Customer> Get(int id)
        {
            return await _db.Customers.FindAsync(id);
        }

        public async Task<Customer> Delete(int id){
            var customer = await _db.Customers.FindAsync(id);
            _db.Customers.Remove(customer);
            await _db.SaveChangesAsync();
            return customer;
        }
    }
}
