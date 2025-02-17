using Core.Domain;
using Core.Service.MQ;
using Customer.API.Test;
using RabbitMQ.Client;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IMyProductRepository, MyProductRepository>();

builder.Services.AddSingleton<IConnectionFactory>(sp =>
{
    return new ConnectionFactory
    {
        HostName = "localhost",
        Port = 15672,
        UserName = "admin",
        Password = "admin"
    };
});
builder.Services.AddScoped<IMQClient, MQClient>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
