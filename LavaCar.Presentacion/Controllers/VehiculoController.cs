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
            if (ModelState.IsValid)
            {
                await _vehiculoLogic.Agregar(model);
                return RedirectToAction(nameof(Index));
            }
            return PartialView("_AgregarVehiculo", model);
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
            if (ModelState.IsValid)
            {
                await _vehiculoLogic.Actualizar(model);
                return RedirectToAction(nameof(Index));
            }
            return PartialView("_ModificarVehiculo", model);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var vehiculo = await _vehiculoLogic.ObtenerId(id);
            if (vehiculo == null) return NotFound();

            return View(vehiculo);
        }

        [HttpPost, ActionName("Delete")]
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
