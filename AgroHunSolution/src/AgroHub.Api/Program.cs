using AgroHub.Api.Configurations;
using AgroHub.Api.Middleware;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddDependencyInjection();

builder.ApiVersionConfig();
builder.AddLogging();
builder.AddFluentValidation();

var app = builder.Build();
app.AddSwaggerGen();
app.UseHttpsRedirection();
app.UseAuthorization();
app.UseLoggingMiddleware();
app.MapControllers();
app.Run();
