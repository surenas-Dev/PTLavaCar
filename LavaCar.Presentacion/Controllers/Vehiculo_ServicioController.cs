using Microsoft.AspNetCore.Mvc;
using PTLavaCar.BussinesLogic;
using PTLavaCar.Models;

namespace UI.PTLavaCar.Controllers
{
    public class Vehiculo_ServicioController : Controller
    {
        private readonly Vehiculo_ServicioLogic _vehiculoServicio;

        public Vehiculo_ServicioController(IConfiguration configuration)
        {
            _vehiculoServicio = new Vehiculo_ServicioLogic(configuration);
        }

        public async Task<IActionResult> Index()
        {
            var lista = await _vehiculoServicio.ListarVM();
            return View(lista);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Vehiculo_ServicioModel model)
        {
            if (ModelState.IsValid)
            {
                await _vehiculoServicio.Agregar(model);
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var relacion = await _vehiculoServicio.ObtenerId(id);
            if (relacion == null) return NotFound();

            return View(relacion);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var model = await _vehiculoServicio.ObtenerId(id);
            if (model != null)
                await _vehiculoServicio.Eliminar(model);

            return RedirectToAction(nameof(Index));
        }
    }
}