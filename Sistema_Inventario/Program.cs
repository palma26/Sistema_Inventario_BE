using Microsoft.EntityFrameworkCore;
using Sistema_Inventario.Context;
using Sistema_Inventario.Services;
using Sistema_Inventario.Services.Interfaces;
using Sistema_Inventario.Utilis;
using System;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddDbContext<InventarioDbContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("Conexion")));

builder.Services.AddScoped<IEmpresa, EmpresaService>();
builder.Services.AddScoped<ISucursal, SucursalService>();
builder.Services.AddScoped<IBodega, BodegaService>();
builder.Services.AddScoped<ICategoria, CategoriaService>();
builder.Services.AddScoped<IProducto, ProductoService>();
builder.Services.AddScoped<ICliente, ClienteService>();
builder.Services.AddScoped<IProveedor, ProveedorService>();

builder.Services.AddAutoMapper(typeof(InventarioMapper));


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
