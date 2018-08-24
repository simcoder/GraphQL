using GraphQL;
using GraphQL.Types;
using SimpleInjector;

namespace GOC.GraphQL.API.Models
{
    public class GraphQLSchema : Schema
    {

        public GraphQLSchema(IDependencyResolver resolver, Container container): base(resolver)
        {
            Query =  container.GetInstance<CustomerQuery>();
            Mutation = container.GetInstance<CustomerMutation>();
        }
    }
}
