using PTLavaCar.DataAccess;
using PTLavaCar.Models;
using PTLavaCar.Models.Models;

namespace PTLavaCar.BussinesLogic
{
    public class Vehiculo_ServicioLogic
    {
        private readonly DAVehiculo_Servicio _dataAccess;

        public Vehiculo_ServicioLogic(DAVehiculo_Servicio dataAccess)
        {
            _dataAccess = dataAccess;
        }

        public async Task<Vehiculo_ServicioModel> Agregar(Vehiculo_ServicioModel model)
        {
            var entidad = await _dataAccess.Agregar(model);
            return new Vehiculo_ServicioModel(entidad);
        }

        public async Task<Vehiculo_ServicioModel> Actualizar(Vehiculo_ServicioModel model)
        {
            var entidad = await _dataAccess.Actualizar(model);
            return new Vehiculo_ServicioModel(entidad);
        }

        public async Task<Vehiculo_ServicioModel> Eliminar(Vehiculo_ServicioModel model)
        {
            var entidad = await _dataAccess.Eliminar(model);
            return new Vehiculo_ServicioModel(entidad);
        }

        public async Task<IEnumerable<Vehiculo_ServicioModel>> Listar()
        {
            var entidades = await _dataAccess.Listar();
            return entidades.Select(x => new Vehiculo_ServicioModel(x));
        }

        public async Task<IEnumerable<Vehiculo_ServicioViewModel>> ListarVM()
        {
            return await _dataAccess.ListarVM();
        }

        public async Task<Vehiculo_ServicioModel> ObtenerId(int id)
        {
            var entidad = await _dataAccess.ObtenerId(id);
            return new Vehiculo_ServicioModel(entidad);
        }
    }
}
