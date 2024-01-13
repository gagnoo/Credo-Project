using System.Reflection;
using Domain.Abstractions;
using Microsoft.EntityFrameworkCore;
using Persistence;
using Persistence.Abstractions.UnitOfWork;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);
Assembly presentationAssembly = typeof(Presentation.AssemblyReference).Assembly;
Assembly applicationAssembly = typeof(Application.AssemblyReference).Assembly;

ConfigurationManager configuration = builder.Configuration;

// Add services to the container.
builder.Services.AddDbContext<CredoDbContext>(options => { options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")); });
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddMediatR(config => { config.RegisterServicesFromAssembly(applicationAssembly); });
builder.Services.AddControllers()
       .AddApplicationPart(presentationAssembly);

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

WebApplication app = builder.Build();

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