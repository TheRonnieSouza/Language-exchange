using LanguageExchange.Application.Services.Language;
using LanguageExchange.Application.Services.LanguageServices;
using LanguageExchange.Application.Services.PaymentServices;
using LanguageExchange.Application.Services.UserServices;
using LanguageExchange.Infrastructure.Persistence;
using LanguageExchange.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<ILanguageRepository, LanguageRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IPaymentRepository, PaymentRepository>();

builder.Services.AddScoped<ILanguageService, LanguageService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IPaymentService, PaymentService>();

builder.Services.AddDbContext<LanguageExchangeDbContext>(options => options.UseInMemoryDatabase("LanguageExchangeDbContext"));
//{
//    options.UseInMemoryDatabase("LanguageExchangeDbContext");
//   // options.UseSqlServer(builder.Configuration.GetConnectionString("LanguageExchangeDbContext"));
//});

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
