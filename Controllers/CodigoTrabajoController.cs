using Microsoft.AspNetCore.Mvc;
using vacaciones_empleado.Models;
using vacaciones_empleado.Services;

namespace vacaciones_empleado.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CodigoTrabajoController : ControllerBase
{
  ICodigoTrabajoService service;
  public CodigoTrabajoController(ICodigoTrabajoService codigoTrabajoService)
  {
    service = codigoTrabajoService;
  }

  [HttpPost]
  public async Task<IActionResult> crearCodigoTrabajo([FromBody] CodigoTrabajo codigo)
  {
    await service.crear(codigo);
    return Ok();
  }

  [HttpGet]
  public IActionResult mostrarCodigosTrabajo()
  {
    return Ok(service.obtener());
  }

  [HttpPut("{id}")]
  public async Task<IActionResult> actualizarCodigoTrabajo([FromBody] CodigoTrabajo codigo, Guid id)
  {
    await service.actualizar(id, codigo);
    return Ok();
  }

  [HttpDelete("{id}")]
  public async Task<IActionResult> eliminarCodigoTrabajo(Guid id)
  {
    await service.eliminar(id);
    return Ok();
  }
}
