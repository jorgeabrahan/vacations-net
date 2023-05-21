using vacaciones_empleado.Models;
namespace vacaciones_empleado.Services;

public class VacacionesService : IVacacionesService
{
  VacacionesEmpleadoContext context;
  public VacacionesService(VacacionesEmpleadoContext dbContext)
  {
    context = dbContext;
  }

  public async Task crear(Vacaciones vacaciones)
  {
    vacaciones.VacacionesId = Guid.NewGuid();
    await context.AddAsync(vacaciones);
    await context.SaveChangesAsync();
  }

  public IEnumerable<Vacaciones>? obtener()
  {
    return context.Vacaciones;
  }

  public async Task actualizar(Guid id, Vacaciones actualizado)
  {
    var vacaciones = context.Vacaciones?.Find(id);
    if (vacaciones == null) return;
    vacaciones.Fecha = actualizado.Fecha;
    await context.SaveChangesAsync();
  }

  public async Task eliminar(Guid id)
  {
    var vacaciones = context.Vacaciones?.Find(id);
    if (vacaciones == null) return;
    context.Remove(vacaciones);
    await context.SaveChangesAsync();
  }
}

public interface IVacacionesService
{
  Task crear(Vacaciones vacaciones);
  IEnumerable<Vacaciones>? obtener();
  Task actualizar(Guid id, Vacaciones actualizado);
  Task eliminar(Guid id);
}
