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

        public async Task<Vehiculo> Actualizar(VehiculoModel model)
        {
            using (var ContextoBD = new LavaCarContext())
                try
                {
                    var entry = ContextoBD.Entry(model.ConvertObjetoBD());
                    entry.State = EntityState.Modified;
                    await ContextoBD.SaveChangesAsync();

                    return model.ConvertObjetoBD();
                }
                catch (Exception e)
                {
                    throw e;
                }
        }

        public async Task<IEnumerable<Vehiculo>> Listar()
        {
            using (var ContextoBD = new LavaCarContext())
            {
                try
                {
                    IEnumerable<Vehiculo> Lista = await ContextoBD.Vehiculo.ToListAsync();

                    return Lista;
                }
                catch (Exception e)
                {
                    return null;
                }
            }
        }
        public async Task<Vehiculo> ObtenerId(int idVehiculo)
        {
            using (var ContextoBD = new LavaCarContext())
                try
                {
                    Vehiculo ObjetoBD = await ContextoBD
                   .Vehiculo.OrderByDescending(x => x.ID_Vehiculo == idVehiculo)
                   .FirstOrDefaultAsync();
                    return ObjetoBD;
                }
                catch (Exception e)
                {
                    throw e;
                }
        }
        public async Task<IEnumerable<VehiculoViewModel>> ListarVM()
        {
            try
            {
                using (var ContextoBD = new LavaCarContext())
                {
                    IEnumerable<VehiculoViewModel> ListaBD = ContextoBD.Vehiculo
                                            .Select(s => new VehiculoViewModel()
                                            {
                                                ID_Vehiculo = s.ID_Vehiculo,
                                                Placa = s.Placa,
                                                Dueno = s.Dueno,
                                                Marca = s.Marca
                                            }).ToList();
                    return ListaBD;
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public async Task<Vehiculo> Eliminar(VehiculoModel Model)
        {
            using (var ContextoBD = new LavaCarContext())
                try
                {
                    var AntiguoReg = ContextoBD.Vehiculo.AsNoTracking().FirstOrDefault(u => u.ID_Vehiculo == Model.ID_Vehiculo);
                    var entry = ContextoBD.Entry(AntiguoReg);
                    ContextoBD.Vehiculo.Remove(AntiguoReg);
                    ContextoBD.SaveChanges();

                    return AntiguoReg;
                }
                catch (Exception e)
                {
                    throw e;
                }
        }
    }
}
