using ProjetoProposta.Application;
using ProjetoProposta.Infra.Data;
using ProjetoProposta.Infra.Messages.Extensions;
using ProjetoProposta.Infra.Messages.Settings;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

var teste = builder.Configuration.GetSection("RabbitMQ").Get<RabbitMqSettings>();
builder.Services.AddSwaggerGen();
builder.Services.AddDataBaseService(builder.Configuration);
builder.Services.AddApplicationService();
builder.Services.AddRabbitMQ(builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
