using Microsoft.AspNetCore.Mvc;
using vacaciones_empleado.Models;
using vacaciones_empleado.Services;

namespace vacaciones_empleado.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CargoController : ControllerBase
{
  ICargoService service;
  public CargoController(ICargoService cargoService)
  {
    service = cargoService;
  }

  [HttpPost]
  public async Task<IActionResult> crearCargo([FromBody] Cargo cargo)
  {
    await service.crear(cargo);
    return Ok();
  }

  [HttpGet]
  public IActionResult mostrarCargos()
  {
    return Ok(service.obtener());
  }

  [HttpPut("{id}")]
  public async Task<IActionResult> actualizarCargo([FromBody] Cargo cargo, Guid id)
  {
    await service.actualizar(id, cargo);
    return Ok();
  }

  [HttpDelete("{id}")]
  public async Task<IActionResult> eliminarCargo(Guid id)
  {
    await service.eliminar(id);
    return Ok();
  }
}
