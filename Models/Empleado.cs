using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace vacaciones_empleado.Models;

public class Empleado
{
  [Key]
  public Guid EmpleadoId { get; set; }


  [ForeignKey("CargoId")]
  public Guid CargoId { get; set; }

  [Required]
  [MaxLength(250)]
  public String? Nombre { get; set; }

  [Required]
  [MaxLength(250)]
  public String? FechaIngreso { get; set; }

  public Boolean Disponible { get; set; }

  public virtual Cargo? Cargo { get; set; }
}