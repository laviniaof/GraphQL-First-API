

using GraphQLFirst.API.Schema.Mutations;
using GraphQLFirst.API.Schema.Queries;
using GraphQLFirst.API.Schema.Subscriptions;
using GraphQLFirst.API.Services;
using Microsoft.EntityFrameworkCore;

namespace GraphQLFirst.API
{
    public class Startup
    {

        private readonly IConfiguration _configuration;

        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddGraphQLServer()
                    .AddQueryType<Query>()
            .AddMutationType<Mutation>()
                    .AddSubscriptionType<Subscription>()
                    .AddInMemorySubscriptions();

            string connectionString = _configuration.GetConnectionString("default");
            services.AddPooledDbContextFactory<SchoolDbContext>(o => o.UseSqlite(connectionString));


        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();
            /** Here we are mapping a single endpoint called graphql*/

            app.UseWebSockets();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGraphQL();
            });
        }
    }
}
