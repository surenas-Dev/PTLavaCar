using Microsoft.Extensions.Configuration;
using PTLavaCar.DataAccess;
using PTLavaCar.Models;

namespace PTLavaCar.BussinesLogic
{
    public class ServiciosLogic
    {
        private DAServicios _DAServicios;

        public ServiciosLogic(IConfiguration configuration)
        {
            _DAServicios = new DAServicios();
        }
        public async Task<ServiciosModel> Agregar(ServiciosModel model)
        {
            try
            {
                var entidad = await _DAServicios.Agregar(model);
                model = new ServiciosModel(entidad);
                return model;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public async Task<ServiciosModel> Actualizar(ServiciosModel model)
        {
            try
            {
                var entidad = await _DAServicios.Actualizar(model);
                model = new ServiciosModel(entidad);
                return model;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public async Task<ServiciosModel> Eliminar(ServiciosModel model)
        {
            try
            {
                ServiciosModel ObjetoModel = new ServiciosModel(await _DAServicios.Eliminar(model));
                return ObjetoModel;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public async Task<IEnumerable<ServiciosModel>> Listar()
        {
            try
            {
                var ListaObjetoBD = await _DAServicios.Listar();
                IEnumerable<ServiciosModel> ListaRespuestaModel = ListaObjetoBD.Select(ObjetoBD => new ServiciosModel(ObjetoBD)).ToList();

                return ListaRespuestaModel;
            }
            catch (Exception e)
            {
                return new List<ServiciosModel>().AsEnumerable();
            }
        }

        public async Task<IEnumerable<ServiciosViewModel>> ListarVM()
        {
            try
            {
                var ListaObjetoBD = await _DAServicios.ListarVM();
                return ListaObjetoBD;
            }
            catch (Exception e)
            {
                return new List<ServiciosViewModel>().AsEnumerable();
            }
        }

        public async Task<ServiciosModel> ObtenerId(int idServicios)
        {
            try
            {
                ServiciosModel ObjetoModel = new ServiciosModel(await _DAServicios.ObtenerId(idServicios));

                return ObjetoModel;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
