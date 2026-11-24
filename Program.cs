
using ClienteApi.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddSingleton<ConexaoBanco>();

var app = builder.Build();

app.MapControllers();

app.Run();
