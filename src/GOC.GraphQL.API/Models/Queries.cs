using System;
using GOC.GraphQL.API.Interfaces;
using GraphQL.Types;

namespace GOC.GraphQL.API.Models
{
    public class CustomerQuery : ObjectGraphType
    {
        public CustomerQuery(ICustomerRepository customerRepository)
        {
            Field<CustomerType>(
                "customer",
                arguments: new QueryArguments(new QueryArgument<IntGraphType> { Name = "id" }),
                resolve: context => customerRepository.Get(context.GetArgument<int>("id")));

            Field<ListGraphType<CustomerType>>(
                "customers",
                resolve: context => customerRepository.All());
        }
    }
}
