using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace PTLavaCar.Helpers
{
    public static class ControllerHelper
    {
        public static async Task<JsonResult> EjecutarFormularioAsync<TModel>(
            Controller controller,
            TModel model,
            Func<TModel, Task> logicaAccion,
            string mensajeExito,
            string mensajeError)
        {
            if (!controller.ModelState.IsValid)
            {
                var errores = controller.ModelState.ToDictionary(
                    kvp => kvp.Key,
                    kvp => kvp.Value.Errors.Select(e => e.ErrorMessage).ToArray()
                );

                return new JsonResult(new { success = false, errors = errores });
            }

            try
            {
                await logicaAccion(model);
                return new JsonResult(new { success = true, message = mensajeExito });
            }
            catch
            {
                return new JsonResult(new { success = false, message = mensajeError });
            }
        }
    }
}
