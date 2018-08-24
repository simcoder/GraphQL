using System;
namespace GOC.GraphQL.API
{
    public class AppSettings
    {
        public PostGres PostGres { get; set; }
    }
    public class PostGres
    {
        public string ConnectionString { get; set; }
    }
}
