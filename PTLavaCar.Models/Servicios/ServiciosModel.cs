using PTLavaCar.Models.Models;

namespace PTLavaCar.Models
{
    public class ServiciosModel
    {
        public ServiciosModel() { 
        }
        public ServiciosModel(Servicios objetoBD) {
            ID_Servicio= objetoBD.ID_Servicio;
            Descripcion = objetoBD.Descripcion;
            Monto= objetoBD.Monto;
        }
        public int ID_Servicio { get; set; }
        public string Descripcion { get; set; }
        public int Monto { get; set; }
        public Servicios ConvertObjetoBD(){
            return new Servicios { 
                ID_Servicio = ID_Servicio,
                Descripcion= Descripcion, 
                Monto= Monto 
            };
        }
    }
}
    
