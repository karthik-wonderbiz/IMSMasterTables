using MasterTables.Application.Interfaces;
using MasterTables.Application.Mapping;
using MasterTables.Application.Services;
using MasterTables.Domain.Interfaces;
using MasterTables.Infrastructure.Data;
using MasterTables.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using MasterTables.Application.Commands;
using FluentValidation.AspNetCore;
using MasterTables.Application.Validators.CreateCommandValidator;
using MasterTables.Application.Validators.UpdateCommandValidator;
using MasterTables.Api;

var builder = WebApplication.CreateBuilder(args);

// AutoMapper configuration
builder.Services.AddAutoMapper(typeof(ProductMappingProfile));

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

// DbContext configuration
builder.Services.AddDbContext<MasterTablesDbContext>(options =>
    options.UseSqlServer(connectionString, b => b.MigrationsAssembly("MasterTables.Api")));

Console.WriteLine(connectionString);

builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(CreateCustomerCommand).Assembly));


// Register repositories and services
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IProductService, ProductService>();

builder.Services.AddScoped<IVendorRepository, VendorRepository>();
builder.Services.AddScoped<IVendorService, VendorService>();

builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();
builder.Services.AddScoped<ICustomerService, CustomerService>();

builder.Services.AddScoped<ITaxRepository, TaxRepository>();
builder.Services.AddScoped<ITaxService, TaxService>();

// Controller services
builder.Services.AddControllers()
    .AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<CreateProductCommandValidator>())
    .AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<UpdateProductCommandValidator>());

// Enable Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Middleware configuration
app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

await app.RunAsync();