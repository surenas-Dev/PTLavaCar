using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PTLavaCar.BussinesLogic;
using PTLavaCar.Models;
using PTLavaCar.Models.Models;

namespace UI.PTLavaCar.Controllers
{
    public class ServiciosController : Controller
    {
        private readonly ServiciosLogic _serviciosLogic;
        private readonly LavaCarContext _lavaCarContext;


        public ServiciosController(IConfiguration configuration)
        {
            _serviciosLogic = new ServiciosLogic(configuration);
        }

        public async Task<IActionResult> Index()
        {
            var lista = await _serviciosLogic.ListarVM();
            return View(lista);
        }

        public IActionResult Create()
        {
            return PartialView("_AgregarServicio", new ServiciosModel());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ServiciosModel model)
        {
            if (ModelState.IsValid)
            {
                await _serviciosLogic.Agregar(model);
                return RedirectToAction(nameof(Index));
            }
            return PartialView("_AgregarServicio", model);

        }

        public async Task<IActionResult> Edit(int id)
        {
            var model = await _serviciosLogic.ObtenerId(id);
            return PartialView("_ModificarServicio", model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(ServiciosModel model)
        {
            if (ModelState.IsValid)
            {
                await _serviciosLogic.Actualizar(model);
                return RedirectToAction(nameof(Index));
            }
            return PartialView("_ModificarServicio", model);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var servicios = await _serviciosLogic.ObtenerId(id);
            if (servicios == null) return NotFound();

            return View(servicios);
        }

        [HttpPost, ActionName("Delete")]
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
            var servicio = await _lavaCarContext.Servicios
                .Include(s => s.Vehiculo_Servicio)
                .ThenInclude(vs => vs.ID_VehiculoNavigation)
                .FirstOrDefaultAsync(s => s.ID_Servicio == id);

            if (servicio == null) return NotFound();

            var model = new ServiciosViewModel
            {
                ID_Servicio = servicio.ID_Servicio,
                Descripcion = servicio.Descripcion,
                Monto = (int)servicio.Monto, 
                VehiculosAsociados = servicio.Vehiculo_Servicio.Select(vs => new VehiculoViewModel
                {
                    ID_Vehiculo = vs.ID_VehiculoNavigation.ID_Vehiculo,
                    Placa = vs.ID_VehiculoNavigation.Placa,
                    Dueno = vs.ID_VehiculoNavigation.Dueno,
                    Marca = vs.ID_VehiculoNavigation.Marca
                }).ToList()
            };

            return View(model);
        }
    }
}
