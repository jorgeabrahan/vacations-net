using Microsoft.AspNetCore.Mvc;
using vacaciones_empleado.Models;
using vacaciones_empleado.Services;

namespace vacaciones_empleado.Controllers;

[ApiController]
[Route("api/[controller]")]
public class EmpleadoController : ControllerBase
{
  IEmpleadoService service;
  public EmpleadoController(IEmpleadoService empleadoService)
  {
    service = empleadoService;
  }

  [HttpPost]
  public async Task<IActionResult> crearEmpleado([FromBody] Empleado empleado)
  {
    await service.crear(empleado);
    return Ok();
  }

  [HttpGet]
  public IActionResult mostrarEmpleados()
  {
    return Ok(service.obtener());
  }

  [HttpPut("{id}")]
  public async Task<IActionResult> actualizarEmpleado([FromBody] Empleado empleado, Guid id)
  {
    await service.actualizar(id, empleado);
    return Ok();
  }

  [HttpDelete("{id}")]
  public async Task<IActionResult> eliminarEmpleado(Guid id)
  {
    await service.eliminar(id);
    return Ok();
  }
}
