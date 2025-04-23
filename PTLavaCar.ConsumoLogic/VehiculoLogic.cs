using Microsoft.Extensions.Configuration;
using PTLavaCar.DataAccess;
using PTLavaCar.Models;

namespace PTLavaCar.BussinesLogic
{
    public class VehiculoLogic
    {
        private DAVehiculo _DAVehiculo;

        public VehiculoLogic(IConfiguration configuration)
        {
            _DAVehiculo = new DAVehiculo();
        }
        public async Task<VehiculoModel> Agregar(VehiculoModel model)
        {
            try
            {
                var entidad = await _DAVehiculo.Agregar(model);
                model = new VehiculoModel(entidad);
                return model;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public async Task<VehiculoModel> Actualizar(VehiculoModel model)
        {
            try
            {
                var entidad = await _DAVehiculo.Actualizar(model);
                model = new VehiculoModel(entidad);
                return model;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public async Task<VehiculoModel> Eliminar(VehiculoModel model)
        {
            try
            {
                VehiculoModel ObjetoModel = new VehiculoModel(await _DAVehiculo.Eliminar(model));
                return ObjetoModel;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public async Task<IEnumerable<VehiculoModel>> Listar()
        {
            try
            {
                var ListaObjetoBD = await _DAVehiculo.Listar();
                IEnumerable<VehiculoModel> ListaRespuestaModel = ListaObjetoBD.Select(ObjetoBD => new VehiculoModel(ObjetoBD)).ToList();

                return ListaRespuestaModel;
            }
            catch (Exception e)
            {
                return new List<VehiculoModel>().AsEnumerable();
            }
        }

        public async Task<IEnumerable<VehiculoViewModel>> ListarVM()
        {
            try
            {
                var ListaObjetoBD = await _DAVehiculo.ListarVM();
                return ListaObjetoBD;
            }
            catch (Exception e)
            {
                return new List<VehiculoViewModel>().AsEnumerable();
            }
        }

        public async Task<VehiculoModel> ObtenerId(int idVehiculo)
        {
            try
            {
                VehiculoModel ObjetoModel = new VehiculoModel(await _DAVehiculo.ObtenerId(idVehiculo));

                return ObjetoModel;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
