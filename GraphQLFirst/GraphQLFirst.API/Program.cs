using GraphQLFirst.API.Services;
using Microsoft.EntityFrameworkCore;

namespace GraphQLFirst.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //this migration will create the database if it does not exist when the application starts
            IHost host = CreateHostBuilder(args).Build();

            using (IServiceScope scope = host.Services.CreateScope())
            {
                IDbContextFactory<SchoolDbContext> contextFactory = scope.ServiceProvider.GetRequiredService<IDbContextFactory<SchoolDbContext>>();

                using(SchoolDbContext context = contextFactory.CreateDbContext())
                {
                    context.Database.Migrate();
                }

            }
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
            .ConfigureWebHostDefaults(webBuilder =>
            {
                webBuilder.UseStartup<Startup>();
            });
    }
}
