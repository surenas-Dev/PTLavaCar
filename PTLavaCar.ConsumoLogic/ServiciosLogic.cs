using PTLavaCar.DataAccess;
using PTLavaCar.Models;

namespace PTLavaCar.BussinesLogic
{
    public class ServiciosLogic
    {
        private readonly DAServicios _daServicios;

        public ServiciosLogic(DAServicios daServicios)
        {
            _daServicios = daServicios;
        }

        public async Task<ServiciosModel> Agregar(ServiciosModel model)
        {
            var entidad = await _daServicios.Agregar(model);
            return new ServiciosModel(entidad);
        }

        public async Task<ServiciosModel> Actualizar(ServiciosModel model)
        {
            var entidad = await _daServicios.Actualizar(model);
            return new ServiciosModel(entidad);
        }

        public async Task<ServiciosModel> Eliminar(ServiciosModel model)
        {
            var entidad = await _daServicios.Eliminar(model);
            return new ServiciosModel(entidad);
        }

        public async Task<IEnumerable<ServiciosModel>> Listar()
        {
            var lista = await _daServicios.Listar();
            return lista.Select(s => new ServiciosModel(s));
        }

        public async Task<IEnumerable<ServiciosViewModel>> ListarVM()
        {
            return await _daServicios.ListarVM();
        }

        public async Task<ServiciosModel> ObtenerId(int idServicios)
        {
            var entidad = await _daServicios.ObtenerId(idServicios);
            return new ServiciosModel(entidad);
        }
        public async Task<ServiciosViewModel> ObtenerReporte(int idServicio)
        {
            var servicio = await _daServicios.ObtenerIdConVehiculos(idServicio);

            if (servicio == null) return null;

            return new ServiciosViewModel
            {
                ID_Servicio = servicio.ID_Servicio,
                Descripcion = servicio.Descripcion,
                Monto = servicio.Monto,
                VehiculosAsociados = servicio.Vehiculo_Servicio.Select(vs => new VehiculoViewModel
                {
                    ID_Vehiculo = vs.ID_VehiculoNavigation.ID_Vehiculo,
                    Placa = vs.ID_VehiculoNavigation.Placa,
                    Dueno = vs.ID_VehiculoNavigation.Dueno,
                    Marca = vs.ID_VehiculoNavigation.Marca
                }).ToList()
            };
        }

    }
}
