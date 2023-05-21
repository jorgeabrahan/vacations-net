using vacaciones_empleado.Models;
namespace vacaciones_empleado.Services;

public class CargoService : ICargoService
{
  VacacionesEmpleadoContext context;
  public CargoService(VacacionesEmpleadoContext dbContext)
  {
    context = dbContext;
  }

  public async Task crear(Cargo cargo)
  {
    cargo.CargoId = Guid.NewGuid();
    await context.AddAsync(cargo);
    await context.SaveChangesAsync();
  }

  public IEnumerable<Cargo>? obtener()
  {
    return context.Cargo;
  }

  public async Task actualizar(Guid id, Cargo actualizado)
  {
    var cargo = context.Cargo?.Find(id);
    if (cargo == null) return;
    cargo.Nombre = actualizado.Nombre;
    await context.SaveChangesAsync();
  }

  public async Task eliminar(Guid id)
  {
    var cargo = context.Cargo?.Find(id);
    if (cargo == null) return;
    context.Remove(cargo);
    await context.SaveChangesAsync();
  }
}

public interface ICargoService
{
  Task crear(Cargo cargo);
  IEnumerable<Cargo>? obtener();
  Task actualizar(Guid id, Cargo actualizado);
  Task eliminar(Guid id);
}