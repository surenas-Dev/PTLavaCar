using Microsoft.EntityFrameworkCore;
using PTLavaCar.Models;
using PTLavaCar.Models.Models;

namespace PTLavaCar.DataAccess
{
    public class DAVehiculo_Servicio
    {
        private readonly LavaCarContext _context;

        public DAVehiculo_Servicio(LavaCarContext context)
        {
            _context = context;
        }

        public async Task<Vehiculo_Servicio> Agregar(Vehiculo_ServicioModel model)
        {
            var entidad = model.ConvertObjetoBD();
            _context.Add(entidad);
            await _context.SaveChangesAsync();
            return entidad;
        }

        public async Task<Vehiculo_Servicio> Actualizar(Vehiculo_ServicioModel model)
        {
            var entidad = model.ConvertObjetoBD();
            _context.Entry(entidad).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return entidad;
        }

        public async Task<IEnumerable<Vehiculo_Servicio>> Listar()
        {
            return await _context.Vehiculo_Servicio
                .Include(vs => vs.ID_ServicioNavigation)
                .Include(vs => vs.ID_VehiculoNavigation)
                .ToListAsync();
        }

        public async Task<Vehiculo_Servicio> ObtenerId(int idVehiculo_Servicio)
        {
            return await _context.Vehiculo_Servicio
                .Include(vs => vs.ID_ServicioNavigation)
                .Include(vs => vs.ID_VehiculoNavigation)
                .FirstOrDefaultAsync(x => x.ID_Vehiculo_Servicio == idVehiculo_Servicio);
        }

        public async Task<IEnumerable<Vehiculo_ServicioViewModel>> ListarVM()
        {
            return await _context.Vehiculo_Servicio
                .Include(s => s.ID_ServicioNavigation)
                .Include(s => s.ID_VehiculoNavigation)
                .Select(s => new Vehiculo_ServicioViewModel
                {
                    ID_Vehiculo_Servicio = s.ID_Vehiculo_Servicio,
                    Servicios = s.ID_ServicioNavigation.Descripcion,
                    Vehiculos = s.ID_VehiculoNavigation.Placa,
                    Dueno = s.ID_VehiculoNavigation.Dueno,
                    Marca = s.ID_VehiculoNavigation.Marca
                }).ToListAsync();
        }

        public async Task<Vehiculo_Servicio> Eliminar(Vehiculo_ServicioModel model)
        {
            var entidad = await _context.Vehiculo_Servicio.FindAsync(model.ID_Vehiculo_Servicio);
            _context.Vehiculo_Servicio.Remove(entidad);
            await _context.SaveChangesAsync();
            return entidad;
        }
    }
}
