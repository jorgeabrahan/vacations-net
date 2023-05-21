using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace vacaciones_empleado.Models;

public class CodigoTrabajo
{
  [Key]
  public Guid CodigoTrabajoId { get; set; }

  [Required]
  public int Antiguedad { get; set; }

  [Required]
  public int DiasOtorgados { get; set; }

  public Boolean Vigente { get; set; }
}
