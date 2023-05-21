using vacaciones_empleado;
using vacaciones_empleado.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSqlServer<VacacionesEmpleadoContext>("Data Source=localhost; Initial Catalog=vacationsDB;user id=sa;password=Programaci0n$;Encrypt=False");
builder.Services.AddScoped<ICargoService, CargoService>();
builder.Services.AddScoped<ICodigoTrabajoService, CodigoTrabajoService>();
builder.Services.AddScoped<IEmpleadoService, EmpleadoService>();
builder.Services.AddScoped<IVacacionesService, VacacionesService>();

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
