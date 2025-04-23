using Microsoft.Extensions.Configuration;
using PTLavaCar.DataAccess;
using PTLavaCar.Models;
using PTLavaCar.Models.Models;

namespace PTLavaCar.BussinesLogic
{
    public class Vehiculo_ServicioLogic
    {
        private DAVehiculo_Servicio _DAVehiculo_Servicio;

        public Vehiculo_ServicioLogic(IConfiguration configuration)
        {
            _DAVehiculo_Servicio = new DAVehiculo_Servicio();
        }
        public async Task<Vehiculo_ServicioModel> Agregar(Vehiculo_ServicioModel model)
        {
            try
            {
                var entidad = await _DAVehiculo_Servicio.Agregar(model);
                model =new Vehiculo_ServicioModel(entidad);
                return model;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public async Task<Vehiculo_ServicioModel> Actualizar(Vehiculo_ServicioModel model)
        {
            try
            {
                var entidad = await _DAVehiculo_Servicio.Actualizar(model);
                model = new Vehiculo_ServicioModel(entidad);
                return model;
            }
            catch (Exception e)
            {
                throw e;
            }
        }        
        public async Task<Vehiculo_ServicioModel> Eliminar(Vehiculo_ServicioModel model)
        {
            try
            {
                Vehiculo_ServicioModel ObjetoModel = new Vehiculo_ServicioModel(await _DAVehiculo_Servicio.Eliminar(model));
                return ObjetoModel;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public async Task<IEnumerable<Vehiculo_ServicioModel>> Listar()
        {
            try
            {
                var ListaObjetoBD = await _DAVehiculo_Servicio.Listar();
                IEnumerable<Vehiculo_ServicioModel> ListaRespuestaModel = ListaObjetoBD.Select(ObjetoBD => new Vehiculo_ServicioModel(ObjetoBD)).ToList();

                return ListaRespuestaModel;
            }
            catch (Exception e)
            {
                return new List<Vehiculo_ServicioModel>().AsEnumerable();
            }
        }

        public async Task<IEnumerable<Vehiculo_ServicioViewModel>> ListarVM()
        {
            try
            {
                var ListaObjetoBD = await _DAVehiculo_Servicio.ListarVM();
                return ListaObjetoBD;
            }
            catch (Exception e)
            {
                return new List<Vehiculo_ServicioViewModel>().AsEnumerable();
            }
        }

        public async Task<Vehiculo_ServicioModel> ObtenerId(int idVehiculo_Servicio)
        {
            try
            {
                Vehiculo_ServicioModel ObjetoModel = new Vehiculo_ServicioModel(await _DAVehiculo_Servicio.ObtenerId(idVehiculo_Servicio));

                return ObjetoModel;
            }
            catch (Exception e)
            {
                throw e;
            }
        }


    }
}
