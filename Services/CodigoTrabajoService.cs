using vacaciones_empleado.Models;
namespace vacaciones_empleado.Services;

public class CodigoTrabajoService : ICodigoTrabajoService
{
  VacacionesEmpleadoContext context;
  public CodigoTrabajoService(VacacionesEmpleadoContext dbContext)
  {
    context = dbContext;
  }

  public async Task crear(CodigoTrabajo codigoTrabajo)
  {
    codigoTrabajo.CodigoTrabajoId = Guid.NewGuid();
    await context.AddAsync(codigoTrabajo);
    await context.SaveChangesAsync();
  }

  public IEnumerable<CodigoTrabajo>? obtener()
  {
    return context.CodigoTrabajo;
  }

  public async Task actualizar(Guid id, CodigoTrabajo actualizado)
  {
    var codigoTrabajo = context.CodigoTrabajo?.Find(id);
    if (codigoTrabajo == null) return;
    codigoTrabajo.Antiguedad = actualizado.Antiguedad;
    codigoTrabajo.DiasOtorgados = actualizado.DiasOtorgados;
    codigoTrabajo.Vigente = actualizado.Vigente;
    await context.SaveChangesAsync();
  }

  public async Task eliminar(Guid id)
  {
    var codigoTrabajo = context.CodigoTrabajo?.Find(id);
    if (codigoTrabajo == null) return;
    context.Remove(codigoTrabajo);
    await context.SaveChangesAsync();
  }
}

public interface ICodigoTrabajoService
{
  Task crear(CodigoTrabajo codigoTrabajo);
  IEnumerable<CodigoTrabajo>? obtener();
  Task actualizar(Guid id, CodigoTrabajo actualizado);
  Task eliminar(Guid id);
}
