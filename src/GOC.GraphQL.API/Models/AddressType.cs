using GOC.GraphQL.API.Data.Models;
using GraphQL.Types;
namespace GOC.GraphQL.API.Models
{
    public class AddressType : ObjectGraphType<Address>
    {
        public AddressType()
        {
            Field(x => x.Id);
            Field(x => x.Address1);
            Field(x => x.Address2);
            Field(x => x.State.Name).Name("state");
            Field(x => x.City);
            Field(x => x.ZipCode);
        }
    }
}
