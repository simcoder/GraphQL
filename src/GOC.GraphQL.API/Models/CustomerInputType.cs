using GraphQL.Types;

namespace GOC.GraphQL.API.Models
{
    public class CustomerInputType : InputObjectGraphType
    {
        public CustomerInputType()
        {
            Name = "CustomerInput";
            Field<NonNullGraphType<StringGraphType>>("name");
            Field<StringGraphType>("email");
            Field<IntGraphType>("id");
        }
    }
}
