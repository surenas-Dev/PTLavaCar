using Microsoft.EntityFrameworkCore;
using PTLavaCar.BussinesLogic;
using PTLavaCar.DataAccess;
using PTLavaCar.Models.Models;

var builder = WebApplication.CreateBuilder(args);

// Contexto de base de datos
builder.Services.AddDbContext<LavaCarContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("LavaCarConnection")));

// Registro de capas de acceso a datos
builder.Services.AddScoped<DAVehiculo>();
builder.Services.AddScoped<DAVehiculo_Servicio>();
builder.Services.AddScoped<DAServicios>();

// Registro de lógica de negocio
builder.Services.AddScoped<VehiculoLogic>();
builder.Services.AddScoped<Vehiculo_ServicioLogic>();
builder.Services.AddScoped<ServiciosLogic>();

// MVC
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Ruta de prueba de conexión
app.MapGet("/test-db", async (LavaCarContext db) =>
{
    try
    {
        await db.Database.OpenConnectionAsync();
        return "¡Conexión exitosa a la BD!";
    }
    catch (Exception ex)
    {
        return $"Error de conexión: {ex.Message}";
    }
});

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}

app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
