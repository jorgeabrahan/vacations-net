using Microsoft.AspNetCore.Mvc;
using vacaciones_empleado.Models;
using vacaciones_empleado.Services;

namespace vacaciones_empleado.Controllers;

[ApiController]
[Route("api/[controller]")]
public class VacacionesController : ControllerBase
{

  IVacacionesService service;
  public VacacionesController(IVacacionesService vacacionesService)
  {
    service = vacacionesService;
  }

  [HttpPost]
  public async Task<IActionResult> crearVacaciones([FromBody] Vacaciones vacaciones)
  {
    await service.crear(vacaciones);
    return Ok();
  }

  [HttpGet]
  public IActionResult mostrarVacaciones()
  {
    return Ok(service.obtener());
  }

  [HttpPut("{id}")]
  public async Task<IActionResult> actualizarVacaciones([FromBody] Vacaciones vacaciones, Guid id)
  {
    await service.actualizar(id, vacaciones);
    return Ok();
  }

  [HttpDelete("{id}")]
  public async Task<IActionResult> eliminarVacaciones(Guid id)
  {
    await service.eliminar(id);
    return Ok();
  }
}
