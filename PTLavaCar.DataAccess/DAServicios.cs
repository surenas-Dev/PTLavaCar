using PTLavaCar.Models.Models;
using PTLavaCar.Models;
using Microsoft.EntityFrameworkCore;
namespace PTLavaCar.DataAccess
{
    public class DAServicios
    {
        private LavaCarContext _context;

        public DAServicios()
        {
            _context = new LavaCarContext();
        }
        public async Task<Servicios> Agregar(ServiciosModel model)
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
        public async Task<Servicios> Actualizar(ServiciosModel model)
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

        public async Task<IEnumerable<Servicios>> Listar()
        {
            using (var ContextoBD = new LavaCarContext())
            {
                try
                {
                    IEnumerable<Servicios> Lista = await ContextoBD.Servicios.ToListAsync();

                    return Lista;
                }
                catch (Exception e)
                {
                    return null;
                }
            }
        }
        public async Task<Servicios> ObtenerId(string idServicios)
        {
            using (var ContextoBD = new LavaCarContext())
                try
                {
                    Servicios ObjetoBD = await ContextoBD
                   .Servicios.OrderByDescending(x => x.Id == idServicios)
                   .FirstOrDefaultAsync();
                    return ObjetoBD;
                }
                catch (Exception e)
                {
                    throw e;
                }
        }
        public async Task<IEnumerable<ServiciosViewModel>> ListarVM()
        {
            try
            {
                using (var ContextoBD = new LavaCarContext())
                {
                    IEnumerable<ServiciosViewModel> ListaBD = ContextoBD.Servicios
                                            .Select(s => new ServiciosViewModel()
                                            {
                                                ID_Servicio = s.ID_Servicio,
                                                Descripcion = s.Descripcion,
                                                Monto = s.Monto,
                                            }).ToList();
                    return ListaBD;
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public async Task<Servicios> Eliminar(ServiciosModel Model)
        {
            using (var ContextoBD = new LavaCarContext())
                try
                {
                    var AntiguoReg = ContextoBD.Servicios.AsNoTracking().FirstOrDefault(u => u.ID_Servicio == Model.ID_Servicio);
                    var entry = ContextoBD.Entry(AntiguoReg);
                    ContextoBD.Servicios.Remove(AntiguoReg);
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
