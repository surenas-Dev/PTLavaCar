using Microsoft.EntityFrameworkCore;
using PTLavaCar.Models;
using PTLavaCar.Models.Models;

namespace PTLavaCar.DataAccess
{
    public class DAServicios
    {
        private readonly LavaCarContext _context;

        public DAServicios(LavaCarContext context)
        {
            _context = context;
        }

        public async Task<Servicios> Agregar(ServiciosModel model)
        {
            var entidad = model.ConvertObjetoBD();
            _context.Add(entidad);
            await _context.SaveChangesAsync();
            return entidad;
        }

        public async Task<Servicios> Actualizar(ServiciosModel model)
        {
            var entidad = model.ConvertObjetoBD();
            _context.Entry(entidad).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return entidad;
        }

        public async Task<IEnumerable<Servicios>> Listar()
        {
            return await _context.Servicios.ToListAsync();
        }

        public async Task<Servicios> ObtenerId(int idServicios)
        {
            return await _context.Servicios
                .FirstOrDefaultAsync(x => x.ID_Servicio == idServicios);
        }

        public async Task<IEnumerable<ServiciosViewModel>> ListarVM()
        {
            return await _context.Servicios
                .Select(s => new ServiciosViewModel
                {
                    ID_Servicio = s.ID_Servicio,
                    Descripcion = s.Descripcion,
                    Monto = s.Monto
                }).ToListAsync();
        }

        public async Task<Servicios> Eliminar(ServiciosModel model)
        {
            var entidad = await _context.Servicios.FindAsync(model.ID_Servicio);
            if (entidad != null)
            {
                _context.Servicios.Remove(entidad);
                await _context.SaveChangesAsync();
            }
            return entidad;
        }
        public async Task<Servicios> ObtenerIdConVehiculos(int id)
        {
            return await _context.Servicios
                .Include(s => s.Vehiculo_Servicio)
                .ThenInclude(vs => vs.ID_VehiculoNavigation)
                .FirstOrDefaultAsync(s => s.ID_Servicio == id);
        }

    }
}
