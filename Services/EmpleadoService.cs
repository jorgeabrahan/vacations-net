using vacaciones_empleado.Models;
namespace vacaciones_empleado.Services;

public class EmpleadoService : IEmpleadoService
{
  VacacionesEmpleadoContext context;
  public EmpleadoService(VacacionesEmpleadoContext dbContext)
  {
    context = dbContext;
  }

  public async Task crear(Empleado empleado)
  {
    empleado.EmpleadoId = Guid.NewGuid();
    await context.AddAsync(empleado);
    await context.SaveChangesAsync();
  }

  public IEnumerable<Empleado>? obtener()
  {
    return context.Empleado;
  }

  public async Task actualizar(Guid id, Empleado actualizado)
  {
    var empleado = context.Empleado?.Find(id);
    if (empleado == null) return;
    empleado.Nombre = actualizado.Nombre;
    empleado.FechaIngreso = actualizado.FechaIngreso;
    empleado.Disponible = actualizado.Disponible;
    await context.SaveChangesAsync();
  }

  public async Task eliminar(Guid id)
  {
    var empleado = context.Empleado?.Find(id);
    if (empleado == null) return;
    context.Remove(empleado);
    await context.SaveChangesAsync();
  }
}

public interface IEmpleadoService
{
  Task crear(Empleado empleado);
  IEnumerable<Empleado>? obtener();
  Task actualizar(Guid id, Empleado actualizado);
  Task eliminar(Guid id);
}
