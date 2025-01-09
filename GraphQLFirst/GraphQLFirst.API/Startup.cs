

using GraphQLFirst.API.Schema.Mutations;
using GraphQLFirst.API.Schema.Queries;
using GraphQLFirst.API.Schema.Subscriptions;

namespace GraphQLFirst.API
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddGraphQLServer()
                    .AddQueryType<Query>()
            .AddMutationType<Mutation>()
                    .AddSubscriptionType<Subscription>()
                    .AddInMemorySubscriptions();


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
