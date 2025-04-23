namespace PTLavaCar.Models
{
    public class ServiciosViewModel
    {
        public ServiciosViewModel() {
        }
        public int ID_Servicio { get; set; }
        public string Descripcion { get; set; }
        public int Monto { get; set; }
        public List<VehiculoViewModel> VehiculosAsociados { get; set; } = new();

    }
}
