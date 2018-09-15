using GOC.GraphQL.API.Data.Models;
using GOC.GraphQL.API.Interfaces;
using GraphQL.Types;

namespace GOC.GraphQL.API.Models
{
    public class CustomerMutation : ObjectGraphType
    {

        public CustomerMutation(ICustomerRepository customerRepository)
        {
            Name = "CreateCustomerMutation";

            Field<CustomerType>(
                "createCustomer",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<CustomerInputType>> { Name = "customer" }
                ),
                resolve: context =>
                {
                    var customer = context.GetArgument<Customer>("customer");
                    return customerRepository.Add(customer);
                });
            Name = "UpdateCustomerMutation";

            Field<CustomerType>(
                "updateCustomer",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<CustomerInputType>> { Name = "customer" }
                ),
                resolve: context =>
                {
                    var customer = context.GetArgument<Customer>("customer");
                    return customerRepository.Update(customer);
                });
            Name = "DeleteCustomerMutation";

            Field<CustomerType>(
                "deleteCustomer",
                arguments: new QueryArguments(new QueryArgument<IntGraphType> { Name = "id" }),
                resolve: context =>
                {
                    var customerId = context.GetArgument<int>("id");
                    return customerRepository.Delete(customerId);
                });
        }
    }
}
