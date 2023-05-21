using System.ComponentModel.DataAnnotations;

namespace vacaciones_empleado.Models;

public class Cargo
{
  [Key]
  public Guid CargoId { get; set; }

  [Required]
  [MaxLength(250)]
  public String? Nombre { get; set; }
}