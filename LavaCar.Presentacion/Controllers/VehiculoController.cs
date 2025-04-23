using Microsoft.AspNetCore.Mvc;
using PTLavaCar.BussinesLogic;
using PTLavaCar.Models;

namespace UI.PTLavaCar.Controllers
{
    public class VehiculoController : Controller
    {
        private readonly VehiculoLogic _vehiculoLogic;

        public VehiculoController(IConfiguration configuration)
        {
            _vehiculoLogic = new VehiculoLogic(configuration);
        }

        public async Task<IActionResult> Index()
        {
            var lista = await _vehiculoLogic.ListarVM();
            return View(lista);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(VehiculoModel model)
        {
            if (ModelState.IsValid)
            {
                await _vehiculoLogic.Agregar(model);
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var vehiculo = await _vehiculoLogic.ObtenerId(id);
            if (vehiculo == null) return NotFound();

            return View(vehiculo);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(VehiculoModel model)
        {
            if (ModelState.IsValid)
            {
                await _vehiculoLogic.Actualizar(model);
                return RedirectToAction(nameof(Index));
            }
            return View(model);
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
