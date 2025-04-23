using PTLavaCar.Models.Models;
using PTLavaCar.Models;
using Microsoft.EntityFrameworkCore;

namespace PTLavaCar.DataAccess
{
    public class DAVehiculo
    {
        private LavaCarContext _context;
        public DAVehiculo () { 
         _context = new LavaCarContext();
        }
        public async Task<Vehiculo> Agregar(VehiculoModel model)
        {
            using (var ContextoBD = new LavaCarContext())
                try
                {
                    var entry = ContextoBD.Add(model.ConvertObjetoBD());
                    await ContextoBD.SaveChangesAsync();

                    return model.ConvertObjetoBD();
                }
                catch (Exception e)
                {
                    throw e;
                }
        }
    }
}
