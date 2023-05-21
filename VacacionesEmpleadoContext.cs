using Microsoft.EntityFrameworkCore;
using vacaciones_empleado.Models;

namespace vacaciones_empleado;

public class VacacionesEmpleadoContext : DbContext
{
  public DbSet<Cargo>? Cargo { get; set; }
  public DbSet<CodigoTrabajo>? CodigoTrabajo { get; set; }
  public DbSet<Empleado>? Empleado { get; set; }
  public DbSet<Vacaciones>? Vacaciones { get; set; }

  public VacacionesEmpleadoContext(DbContextOptions<VacacionesEmpleadoContext> options) : base(options) { }
}