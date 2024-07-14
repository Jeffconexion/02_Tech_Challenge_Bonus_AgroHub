using AgroHub.Api.Configurations;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddDependencyInjection();

//Api version configuration.
builder.VersionConfig();

var app = builder.Build();

//Api version configuration.
app.AddSwaggerGen();

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
