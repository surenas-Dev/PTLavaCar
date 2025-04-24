using PTLavaCar.Models.Models;
using System.ComponentModel.DataAnnotations;

namespace PTLavaCar.Models
{
    public class VehiculoModel
    {
        public VehiculoModel() { 
        }
        public VehiculoModel(Vehiculo objetoBD)
        {
            ID_Vehiculo = objetoBD.ID_Vehiculo;
            Placa = objetoBD.Placa;
            Dueno = objetoBD.Dueno;
            Marca = objetoBD.Marca;
        }

        public int ID_Vehiculo { get; set; }

        [Required(ErrorMessage = "La placa es obligatoria")]
        public string Placa { get; set; }

        [Required(ErrorMessage = "El nombre del dueño es obligatorio")]
        [RegularExpression(@"^[a-zA-Z\s]+$", ErrorMessage = "El nombre del dueño no puede contener números")]
        public string Dueno { get; set; }

        [Required(ErrorMessage = "La marca es obligatoria")]
        public string Marca { get; set; }

        #region Metodos
        public Vehiculo ConvertObjetoBD(){
            return new Vehiculo
            {
                ID_Vehiculo= ID_Vehiculo,
                Placa = Placa,
                Dueno = Dueno,
                Marca = Marca,
            };
        }
        #endregion Metodos
    }
}
    
