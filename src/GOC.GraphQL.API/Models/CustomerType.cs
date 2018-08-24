using System;
using GOC.GraphQL.API.Data.Models;
using GOC.GraphQL.API.Interfaces;
using GraphQL.Types;

namespace GOC.GraphQL.API.Models
{
    public class CustomerType : ObjectGraphType<Customer>
    {
        public CustomerType(IAddressRepository addressRepository)
        {
            Field(x => x.Id);
            Field(x => x.Name, true);
            Field(x => x.Email);
            Field<ListGraphType<AddressType>>("addresses",
                arguments: new QueryArguments(new QueryArgument<IntGraphType> { Name = "id" }),
                resolve: context => addressRepository.Get(context.Source.Id), description: "Customer's Addresses");
        }
    }
}
