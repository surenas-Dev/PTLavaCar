using Microsoft.EntityFrameworkCore;
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

        public async Task<Vehiculo_Servicio> Actualizar(Vehiculo_ServicioModel model)
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

        public async Task<IEnumerable<Vehiculo_Servicio>> Listar()
        {
            using (var ContextoBD = new LavaCarContext())
            {
                try
                {
                    IEnumerable<Vehiculo_Servicio> Lista = await ContextoBD.Vehiculo_Servicio.ToListAsync();

                    return Lista;
                }
                catch (Exception e)
                {
                    return null;
                }
            }
        }
        public async Task<Vehiculo_Servicio> ObtenerId(int idVehiculo_Servicio)
        {
            using (var ContextoBD = new LavaCarContext())
                try
                {
                    Vehiculo_Servicio ObjetoBD = await ContextoBD
                   .Vehiculo_Servicio.OrderByDescending(x => x.ID_Vehiculo_Servicio == idVehiculo_Servicio)
                   .FirstOrDefaultAsync();
                    return ObjetoBD;
                }
                catch (Exception e)
                {
                    throw e;
                }
        }
        public async Task<IEnumerable<Vehiculo_ServicioViewModel>> ListarVM()
        {
            try
            {
                using (var ContextoBD = new LavaCarContext())
                {
                    IEnumerable<Vehiculo_ServicioViewModel> ListaBD = ContextoBD.Vehiculo_Servicio
                                            .Select(s => new Vehiculo_ServicioViewModel()
                                            {
                                                ID_Vehiculo_Servicio = s.ID_Vehiculo_Servicio,
                                                Servicios = s.ID_ServicioNavigation.Descripcion,
                                                Vehiculos = s.ID_VehiculoNavigation.Placa,
                                            }).ToList();
                    return ListaBD;
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public async Task<Vehiculo_Servicio> Eliminar(Vehiculo_ServicioModel Model)
        {
            using (var ContextoBD = new LavaCarContext())
                try
                {
                    var AntiguoReg = ContextoBD.Vehiculo_Servicio.AsNoTracking().FirstOrDefault(u => u.ID_Vehiculo_Servicio == Model.ID_Vehiculo_Servicio);
                    var entry = ContextoBD.Entry(AntiguoReg);
                    ContextoBD.Vehiculo_Servicio.Remove(AntiguoReg);
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
