using System;
using System.Collections.Generic;

namespace GOC.GraphQL.API.Data.Models
{
    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Address> Addresses { get; set; }
        public string Email { get; set; }
    }
}
