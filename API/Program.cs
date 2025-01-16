using BLL.Agents;
using BLL.Customers;
using BLL.Tests;
using BLL.Tests.Results;
using DAL.Mock;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddTransient<ICustomerRepository, CustomerRepositoryMock>(); //TODO replace mock for real implementation
builder.Services.AddTransient<IAgentRepository, AgentRepositoryMock>(); //TODO replace mock for real implementation
builder.Services.AddTransient<ITestRepository, TestRepositoryMock>(); //TODO replace mock for real implementation
builder.Services.AddTransient<IResultRepository, ResultRepositoryMock>(); //TODO replace mock for real implementation

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
    app.UseSwagger();
    app.UseSwaggerUI();
//}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
