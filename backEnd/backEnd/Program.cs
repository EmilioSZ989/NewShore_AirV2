using BackEnd.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Configuraci�n del contexto de la base de datos
builder.Services.AddDbContext<BackEnd.Data.MySQLiteContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("MySQLiteContext") ?? throw new InvalidOperationException("Connection string 'MySQLiteContext' not found.")));

// Configuraci�n de CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowOrigin", builder =>
    {
        builder.WithOrigins("http://localhost:4200") 
               .AllowAnyMethod()
               .AllowAnyHeader();
    });
});


// Agregar servicios al contenedor de inyecci�n de dependencias
builder.Services.AddScoped<TransportRepository>();
builder.Services.AddScoped<FlightRepository>();
builder.Services.AddScoped<JourneyRepository>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configuraci�n del pipeline de solicitudes HTTP
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Habilitar CORS
app.UseCors("AllowOrigin");

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
