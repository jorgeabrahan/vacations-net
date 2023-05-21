using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace vacaciones_empleado.Models;

public class Vacaciones
{
  [Key]
  public Guid VacacionesId { get; set; }

  [ForeignKey("EmpleadoId")]
  public Guid EmpleadoId { get; set; }

  [Required]
  [MaxLength(250)]
  public String? Fecha { get; set; }

  public virtual Empleado? Empleado { get; set; }
}