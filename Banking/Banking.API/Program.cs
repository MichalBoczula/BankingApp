using Banking.Application.DependencyInjection;
using Banking.Persistance.Context;
using Banking.Persistance.DependencyInjection;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddApplication();
builder.Services.AddPersistance(builder.Configuration);

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var dbContextQueries = scope.ServiceProvider.GetRequiredService<QueryDbContext>();
    var dbContextComamnds = scope.ServiceProvider.GetRequiredService<CommandDbContext>();
    dbContextQueries.Database.Migrate();
    dbContextComamnds.Database.Migrate();
}

// Configure the HTTP request pipeline.
app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

// Adjust the URLs to listen on 0.0.0.0 and the specific ports
app.Urls.Add("http://0.0.0.0:8080");
app.Urls.Add("http://0.0.0.0:8081");

app.Run();
