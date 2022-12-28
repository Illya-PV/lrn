using Learning.Bll.Implementation;
using Learning.Bll.Interfaces;
using Learning.Dal.Context;
using Learning.Dal.Intarfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddTransient<IBankContext, BankContext>();
builder.Services.AddTransient<IUserContext, UserContext>();
builder.Services.AddTransient<IProductContext, ProductContext>();
builder.Services.AddTransient<IUserPurchasedProductContext, UserPurchasedProductContext>();
builder.Services.AddTransient<IBankService, BankService>();
builder.Services.AddTransient<IUserService, UserService>();
builder.Services.AddTransient<IProductService, ProductService>();
builder.Services.AddTransient<IUserPurchasedProductService, UserPurchasedProductService>();


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
