using PTLavaCar.Models.Models;

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
        public string Placa { get; set; }
        public string Dueno { get; set; }
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
    
