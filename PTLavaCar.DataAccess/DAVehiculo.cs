using Microsoft.EntityFrameworkCore;
using PTLavaCar.Models;
using PTLavaCar.Models.Models;

namespace PTLavaCar.DataAccess
{
    public class DAVehiculo
    {
        private readonly LavaCarContext _context;

        public DAVehiculo(LavaCarContext context)
        {
            _context = context;
        }
        public DAVehiculo()
        {
            _context = new LavaCarContext(); 
        }

        public async Task<Vehiculo> Agregar(VehiculoModel model)
        {
            var entidad = model.ConvertObjetoBD();
            _context.Add(entidad);
            await _context.SaveChangesAsync();
            return entidad;
        }

        public async Task<Vehiculo> Actualizar(VehiculoModel model)
        {
            var entidad = model.ConvertObjetoBD();
            _context.Entry(entidad).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return entidad;
        }

        public async Task<IEnumerable<Vehiculo>> Listar()
        {
            return await _context.Vehiculo.ToListAsync();
        }
        public virtual async Task<IEnumerable<Vehiculo>> ListarTest()
        {
            return await _context.Vehiculo.ToListAsync();
        }

        public async Task<Vehiculo> ObtenerId(int idVehiculo)
        {
            return await _context.Vehiculo.FirstOrDefaultAsync(v => v.ID_Vehiculo == idVehiculo);
        }

        public async Task<IEnumerable<VehiculoViewModel>> ListarVM()
        {
            return await _context.Vehiculo
                .Select(s => new VehiculoViewModel
                {
                    ID_Vehiculo = s.ID_Vehiculo,
                    Placa = s.Placa,
                    Dueno = s.Dueno,
                    Marca = s.Marca
                }).ToListAsync();
        }

        public async Task<Vehiculo> Eliminar(VehiculoModel model)
        {
            var entidad = await _context.Vehiculo.FindAsync(model.ID_Vehiculo);
            if (entidad != null)
            {
                _context.Vehiculo.Remove(entidad);
                await _context.SaveChangesAsync();
            }
            return entidad;
        }
    }
}
