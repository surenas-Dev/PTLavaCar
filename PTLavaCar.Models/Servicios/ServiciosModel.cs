using PTLavaCar.Models.Models;
using System.ComponentModel.DataAnnotations;

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

        [Required(ErrorMessage = "La descripción es obligatoria")]
        [StringLength(100, ErrorMessage = "La descripción no puede exceder los 100 caracteres")]
        public string Descripcion { get; set; }

        [Required(ErrorMessage = "El monto es obligatorio")]
        [Range(1, int.MaxValue, ErrorMessage = "El monto debe ser mayor que cero")]
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
    
