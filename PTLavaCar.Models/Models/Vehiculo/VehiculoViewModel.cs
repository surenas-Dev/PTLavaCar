using System.ComponentModel.DataAnnotations;

namespace PTLavaCar.Models
{
    public class VehiculoViewModel
    {
        public VehiculoViewModel() { 
        }

        public int ID_Vehiculo { get; set; }

        [Required(ErrorMessage = "La placa es obligatoria")]
        [StringLength(20, ErrorMessage = "La placa no puede exceder los 20 caracteres")]
        public string Placa { get; set; }

        [Required(ErrorMessage = "El dueño es obligatorio")]
        [StringLength(100, ErrorMessage = "El nombre del dueño no puede exceder los 100 caracteres")]
        [RegularExpression(@"^[^\d]+$", ErrorMessage = "El nombre del dueño no puede contener números")]
        public string Dueno { get; set; }

        [Required(ErrorMessage = "La marca es obligatoria")]
        [StringLength(50, ErrorMessage = "La marca no puede exceder los 50 caracteres")]
        public string Marca { get; set; }
    }
}
