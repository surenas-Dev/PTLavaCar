using Microsoft.AspNetCore.Mvc;
using PTLavaCar.BussinesLogic;
using PTLavaCar.Models;

namespace UI.PTLavaCar.Controllers
{
    public class VehiculoController : Controller
    {
        private readonly VehiculoLogic _vehiculoLogic;

        public VehiculoController(VehiculoLogic vehiculoLogic)
        {
            _vehiculoLogic = vehiculoLogic;
        }

        public async Task<IActionResult> Index()
        {
            var lista = await _vehiculoLogic.ListarVM();
            return View(lista);
        }

        public IActionResult Agregar()
        {
            return PartialView("_AgregarVehiculo", new VehiculoModel());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Agregar(VehiculoModel model)
        {
            if (!ModelState.IsValid)
            {
                var errors = ModelState.ToDictionary(
                    kvp => kvp.Key,
                    kvp => kvp.Value.Errors.Select(e => e.ErrorMessage).ToArray()
                );
                return Json(new { success = false, errors });
            }

            try
            {
                await _vehiculoLogic.Agregar(model);
                return Json(new { success = true, message = "¡Vehículo guardado con éxito!" });
            }
            catch
            {
                return Json(new { success = false, message = "Ocurrió un error al guardar el vehículo." });
            }
        }

        public async Task<IActionResult> Modificar(int id)
        {
            var model = await _vehiculoLogic.ObtenerId(id);
            if (model == null) return NotFound();

            return PartialView("_ModificarVehiculo", model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Modificar(VehiculoModel model)
        {
            if (!ModelState.IsValid)
            {
                var errors = ModelState.ToDictionary(
                    kvp => kvp.Key,
                    kvp => kvp.Value.Errors.Select(e => e.ErrorMessage).ToArray()
                );
                return Json(new { success = false, errors });
            }

            try
            {
                await _vehiculoLogic.Actualizar(model);
                return Json(new { success = true, message = "¡Vehículo modificado correctamente!" });
            }
            catch
            {
                return Json(new { success = false, message = "Ocurrió un error al modificar el vehículo." });
            }
        }

        public async Task<IActionResult> Delete(int id)
        {
            var vehiculo = await _vehiculoLogic.ObtenerId(id);
            if (vehiculo == null) return NotFound();

            return View(vehiculo);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var model = await _vehiculoLogic.ObtenerId(id);
            if (model != null)
                await _vehiculoLogic.Eliminar(model);

            return RedirectToAction(nameof(Index));
        }
    }
}
