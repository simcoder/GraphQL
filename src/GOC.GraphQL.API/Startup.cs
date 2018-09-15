using GOC.GraphQL.API.Data;
using GOC.GraphQL.API.Interfaces;
using GOC.GraphQL.API.Models;
using GOC.GraphQL.API.Repositories;
using GraphQL;
using GraphQL.Types;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Mvc.ViewComponents;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SimpleInjector;
using SimpleInjector.Integration.AspNetCore.Mvc;
using SimpleInjector.Lifestyles;

namespace GOC.GraphQL.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            AppSettings = Configuration.GetSection("GraphQLService").Get<AppSettings>();

        }
        private Container Container { get; } = new Container();

        public static AppSettings AppSettings { get; set; }


        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            services.AddSingleton<CustomerType>();
            services.AddSingleton<AddressType>();
            services.AddSingleton<CustomerInputType>();
            services.AddSingleton<StateInputType>();
            services.AddSingleton<AddressInputType>();



            services.AddTransient<IAddressRepository, AddressRepository>();
            services.AddTransient<ICustomerRepository, CustomerRepository>();
            var optionss = DbContextOptionsBuilder();
            services.AddDbContext<DatabaseContext>(options => options.UseNpgsql(AppSettings.PostGres.ConnectionString));

            services.AddCors(options => options.AddPolicy("AllowAllOrigins", builder =>
                       builder.AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader()));
            IntegrateSimpleInjector(services);
            InitializeContainer(services);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            InitializeDatabase();
            app.UseGraphiQl();
            app.UseCors("AllowAllOrigins");
            app.UseMvc();

        }

        private void IntegrateSimpleInjector(IServiceCollection services)
        {
            Container.Options.DefaultScopedLifestyle = new AsyncScopedLifestyle();

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            services.AddSingleton<IControllerActivator>(
                new SimpleInjectorControllerActivator(Container));
            services.AddSingleton<IViewComponentActivator>(
                new SimpleInjectorViewComponentActivator(Container));

            services.EnableSimpleInjectorCrossWiring(Container);
            services.UseSimpleInjectorAspNetRequestScoping(Container);
        }

        protected void InitializeContainer(IServiceCollection services)
        {
            //repos and service
            Container.Register<ICustomerRepository, CustomerRepository>(Lifestyle.Scoped);
            Container.Register<IAddressRepository, AddressRepository>(Lifestyle.Scoped);

            // database context registration
            var options = DbContextOptionsBuilder();
            Container.Register(() => new DatabaseContext(options.Options), Lifestyle.Scoped);
            Container.Register<CustomerQuery, CustomerQuery>(Lifestyle.Scoped);
            Container.Register<CustomerMutation, CustomerMutation>(Lifestyle.Scoped);
            Container.Register<IDocumentExecuter>(() => new DocumentExecuter(), Lifestyle.Scoped);
            // graphQL schema
            var sp = services.BuildServiceProvider();
            Container.Register<ISchema>(() => new GraphQLSchema(new FuncDependencyResolver(type => sp.GetService(type)), Container), Lifestyle.Scoped);
            Container.Verify();
        }

        private void InitializeDatabase()
        {
            var options = DbContextOptionsBuilder();
            var dbContext = new DatabaseContext(options.Options);
            dbContext.Database.Migrate();
        }
        private DbContextOptionsBuilder<DatabaseContext> DbContextOptionsBuilder()
        {
            var options = new DbContextOptionsBuilder<DatabaseContext>();
            options.UseNpgsql(AppSettings.PostGres.ConnectionString);
            return options;
        }
    }
}
