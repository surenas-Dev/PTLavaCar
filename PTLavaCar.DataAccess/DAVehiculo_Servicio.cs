using PTLavaCar.Models;
using PTLavaCar.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PTLavaCar.DataAccess
{
    public class DAVehiculo_Servicio
    {
        private LavaCarContext _context;
        public DAVehiculo_Servicio()
        {
            _context = new LavaCarContext();
        }
        public async Task<Vehiculo_Servicio> Agregar(Vehiculo_ServicioModel model)
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
