namespace PTLavaCar.Models
{
    public class Vehiculo_ServicioViewModel
    {
        public Vehiculo_ServicioViewModel()
        {

        }
        public int ID_Vehiculo_Servicio { get; set; }
        public int ID_Servicio { get; set; }
        public string Servicios { get; set; }
        public int ID_Vehiculo { get; set; }
        public string Vehiculos { get; set; }
        public string Marca { get; set; }
        public string Dueno { get; set; }
        public List<ServiciosModel> Servicio { get; set; }
        public List<VehiculoModel> Vehiculo { get; set; }
        
    }
}
