using Microsoft.AspNetCore.Mvc;
using PTLavaCar.BussinesLogic;
using PTLavaCar.Models;

namespace UI.PTLavaCar.Controllers
{
    public class ServiciosController : Controller
    {
        private readonly ServiciosLogic _serviciosLogic;

        public ServiciosController(ServiciosLogic serviciosLogic)
        {
            _serviciosLogic = serviciosLogic;
        }

        public async Task<IActionResult> Index()
        {
            var lista = await _serviciosLogic.ListarVM();
            return View(lista);
        }

        public IActionResult Agregar()
        {
            return PartialView("_AgregarServicio", new ServiciosModel());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Agregar(ServiciosModel model)
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
                await _serviciosLogic.Agregar(model);
                return Json(new { success = true, message = "¡Registro guardado con éxito!" });
            }
            catch
            {
                return Json(new { success = false, message = "Ocurrió un error al guardar el registro." });
            }
        }

        public async Task<IActionResult> Modificar(int id)
        {
            var model = await _serviciosLogic.ObtenerId(id);
            if (model == null) return NotFound();

            return PartialView("_ModificarServicio", model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Modificar(ServiciosModel model)
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
                await _serviciosLogic.Actualizar(model);
                return Json(new { success = true, message = "¡Registro modificado correctamente!" });
            }
            catch
            {
                return Json(new { success = false, message = "Ocurrió un error al modificar el registro." });
            }
        }
        public async Task<IActionResult> Delete(int id)
        {
            var servicios = await _serviciosLogic.ObtenerId(id);
            if (servicios == null) return NotFound();

            return View(servicios);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var model = await _serviciosLogic.ObtenerId(id);
            if (model != null)
                await _serviciosLogic.Eliminar(model);

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Reporte(int id)
        {
            var model = await _serviciosLogic.ObtenerReporte(id);
            if (model == null) return NotFound();

            return PartialView("Reporte", model);
        }
    }
}
