using GOC.GraphQL.API.Data.Models;
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
            Field<ListGraphType<AddressInputType>>("addresses");

        }
    }
    public class AddressInputType : InputObjectGraphType<Address>
    {
        public AddressInputType()
        {
            Name = "AddressInput";
            Field<StringGraphType>("address1");
            Field<StringGraphType>("address2");
            Field<StringGraphType>("zipCode");
            Field<StringGraphType>("city");
            Field<IntGraphType>("id");
            Field(r => r.State, type:typeof(StateInputType));
        }
    }
    public class StateInputType : InputObjectGraphType<State>
    {
        public StateInputType()
        {
            Name = "StateInput";
            //Field(field=>field.Id);
            Field(field => field.Name);
        }
    }

}
