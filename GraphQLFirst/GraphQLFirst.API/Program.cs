using GraphQLFirst.API;

/** Invokes Startup.cs keeping the code organized in separed files*/
var builder = WebApplication.CreateBuilder(args);

var startup = new Startup(builder.Configuration);
startup.ConfigureServices(builder.Services);

var app = builder.Build();

startup.Configure(app, builder.Environment);

app.Run();
