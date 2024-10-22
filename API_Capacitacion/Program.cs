using API_Capacitacion.Data;
using API_Capacitacion.Data.Interfaces;
using API_Capacitacion.Data.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

PostgresSQLConfiguration postgresSqlConfiguration = new(Environment.GetEnvironmentVariable("CONNECTION_STRING") ?? "");
builder.Services.AddSingleton(postgresSqlConfiguration);

builder.Services.AddScoped<ITaskServices, TaskServices>();

builder.Services.AddScoped<IUserServices, UserServices>();

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
