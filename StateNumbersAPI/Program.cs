using Application;
using FluentValidation;
using FluentValidation.AspNetCore;
using Infrastructure;
using Microsoft.EntityFrameworkCore;
using StateNumbersAPI.FluentValidation;
using StateNumbersAPI.MiddleWares;
using StateNumbersAPI.ModelValidation;
using StateNumbersAPI.Services;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
ConfigurationManager configuration = builder.Configuration;

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
   c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo { Title = "StateNumbers", Version = "v1" });
});

builder.Services.AddDbContext<APIDBContext>(options =>
options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"),
     b => b.MigrationsAssembly("StateNumbersAPI")));

builder.Services.AddScoped<INumbersRepository, NumbersRepository>();
builder.Services.AddScoped<IBookNumberRepository, BookNumberRepository>();
builder.Services.AddScoped<IOrderNumberRepository, OrderNumberReporsitory>();
builder.Services.AddTransient(typeof(IUnitOfWork), typeof(UnitOfWork));
builder.Services.AddTransient(typeof(INumberService), typeof(NumberService));
builder.Services.AddTransient(typeof(IBookNumberService), typeof(BookNumberService));
builder.Services.AddTransient(typeof(IOrderNumberService), typeof(OrderNumberService));

builder.Services.AddTransient<GlobalExceptionhandlingMiddleWare>();

builder.Services.AddValidatorsFromAssemblyContaining<NumberValidator>();
builder.Services.AddValidatorsFromAssemblyContaining<BookNumbersValidator>();
builder.Services.AddValidatorsFromAssemblyContaining<OrderNumbersValidator>();

builder.Services.AddControllers()
   .AddFluentValidation(c =>
   c.RegisterValidatorsFromAssembly(Assembly.GetExecutingAssembly()));

var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
   app.UseSwagger();
   app.UseSwaggerUI();
}

app.UseMiddleware<GlobalExceptionhandlingMiddleWare>();
app.UseAuthorization();

app.MapControllers();

app.Run();
