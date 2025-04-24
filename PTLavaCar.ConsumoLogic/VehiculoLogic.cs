using PTLavaCar.DataAccess;
using PTLavaCar.Models;

namespace PTLavaCar.BussinesLogic
{
    public class VehiculoLogic
    {
        private readonly DAVehiculo _daVehiculo;

        public VehiculoLogic(DAVehiculo daVehiculo)
        {
            _daVehiculo = daVehiculo;
        }

        public async Task<VehiculoModel> Agregar(VehiculoModel model)
        {
            var entidad = await _daVehiculo.Agregar(model);
            return new VehiculoModel(entidad);
        }

        public async Task<VehiculoModel> Actualizar(VehiculoModel model)
        {
            var entidad = await _daVehiculo.Actualizar(model);
            return new VehiculoModel(entidad);
        }

        public async Task<VehiculoModel> Eliminar(VehiculoModel model)
        {
            var entidad = await _daVehiculo.Eliminar(model);
            return new VehiculoModel(entidad);
        }

        public async Task<IEnumerable<VehiculoModel>> Listar()
        {
            var lista = await _daVehiculo.Listar();
            return lista.Select(v => new VehiculoModel(v));
        }

        public async Task<IEnumerable<VehiculoViewModel>> ListarVM()
        {
            return await _daVehiculo.ListarVM();
        }

        public async Task<VehiculoModel> ObtenerId(int idVehiculo)
        {
            var entidad = await _daVehiculo.ObtenerId(idVehiculo);
            return new VehiculoModel(entidad);
        }
    }
}
