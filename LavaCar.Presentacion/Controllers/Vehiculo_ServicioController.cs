using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using PTLavaCar.BussinesLogic;
using PTLavaCar.Models;

namespace UI.PTLavaCar.Controllers
{
    public class Vehiculo_ServicioController : Controller
    {
        private readonly Vehiculo_ServicioLogic _vehiculoServicio;
        private readonly VehiculoLogic _vehiculoLogic;
        private readonly ServiciosLogic _serviciosLogic;

        public Vehiculo_ServicioController(
            Vehiculo_ServicioLogic vehiculoServicio,
            VehiculoLogic vehiculoLogic,
            ServiciosLogic serviciosLogic)
        {
            _vehiculoServicio = vehiculoServicio;
            _vehiculoLogic = vehiculoLogic;
            _serviciosLogic = serviciosLogic;
        }

        public async Task<IActionResult> Index()
        {
            var lista = await _vehiculoServicio.ListarVM();
            return View(lista);
        }

        public async Task<IActionResult> Agregar()
        {
            await CargarCombos();
            return PartialView("_AgregarAsignacion", new Vehiculo_ServicioModel());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Agregar(Vehiculo_ServicioModel model)
        {
            if (ModelState.IsValid)
            {
                await _vehiculoServicio.Agregar(model);
                return RedirectToAction(nameof(Index));
            }

            await CargarCombos();
            return PartialView("_AgregarAsignacion", model);
        }

        public async Task<IActionResult> Modificar(int id)
        {
            var model = await _vehiculoServicio.ObtenerId(id);
            if (model == null) return NotFound();

            await CargarCombos(model.ID_Vehiculo, model.ID_Servicio);
            return PartialView("_ModificarAsignacion", model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Modificar(Vehiculo_ServicioModel model)
        {
            if (ModelState.IsValid)
            {
                await _vehiculoServicio.Actualizar(model);
                return RedirectToAction(nameof(Index));
            }

            await CargarCombos(model.ID_Vehiculo, model.ID_Servicio);
            return PartialView("_ModificarAsignacion", model);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var relacion = await _vehiculoServicio.ObtenerId(id);
            if (relacion == null) return NotFound();

            return View(relacion);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var model = await _vehiculoServicio.ObtenerId(id);
            if (model != null)
                await _vehiculoServicio.Eliminar(model);

            return RedirectToAction(nameof(Index));
        }


        private async Task CargarCombos(int? idVehiculo = null, int? idServicio = null)
        {
            var vehiculos = await _vehiculoLogic.Listar();
            var servicios = await _serviciosLogic.Listar();

            ViewBag.Vehiculos = vehiculos.Select(v => new SelectListItem
            {
                Value = v.ID_Vehiculo.ToString(),
                Text = $"{v.Placa} - {v.Dueno}",
                Selected = idVehiculo.HasValue && v.ID_Vehiculo == idVehiculo.Value
            }).ToList();

            ViewBag.Servicios = servicios.Select(s => new SelectListItem
            {
                Value = s.ID_Servicio.ToString(),
                Text = s.Descripcion,
                Selected = idServicio.HasValue && s.ID_Servicio == idServicio.Value
            }).ToList();
        }
    }
}
