using PaySafe.API.Extensions;
using PaySafe.IoC;

var builder = WebApplication.CreateBuilder(args).ConfigureHost();

var services = builder.Services;
var configuration = builder.Configuration;
var environment = builder.Environment;

services.AddControllers();

services.AddCommonServices(configuration, environment);

var app = builder.Build();

app.UseCommonAppConfiguration();

await app.RunAsync();