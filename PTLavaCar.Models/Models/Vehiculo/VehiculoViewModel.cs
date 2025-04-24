using System.ComponentModel.DataAnnotations;

namespace PTLavaCar.Models
{
    public class VehiculoViewModel
    {
        public VehiculoViewModel() { 
        }
        public int ID_Vehiculo { get; set; }
        [Required(ErrorMessage = "La placa es obligatoria")]
        [StringLength(30)]
        public string Placa { get; set; }
        [Required(ErrorMessage = "El nombre del dueño es obligatorio")]
        public string Dueno { get; set; }
        [Required(ErrorMessage = "La marca es obligatoria")]
        [StringLength(50)]
        public string Marca { get; set; }
    }
}
