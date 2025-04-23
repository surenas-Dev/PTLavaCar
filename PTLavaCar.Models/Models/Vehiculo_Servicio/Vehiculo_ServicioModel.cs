using PTLavaCar.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace PTLavaCar.Models
{
    public class Vehiculo_ServicioModel
    {
        public Vehiculo_ServicioModel(){
        }

        public Vehiculo_ServicioModel (Vehiculo_Servicio objetoBD)
        {
            ID_Vehiculo_Servicio = objetoBD.ID_Vehiculo_Servicio;
            ID_Servicio = objetoBD.ID_Servicio;
            ID_Vehiculo = objetoBD.ID_Vehiculo;
        }
        public int ID_Vehiculo_Servicio { get; set; }
        public int ID_Servicio { get; set; }
        public int ID_Vehiculo { get; set; }
        #region Metodos
        public Vehiculo_Servicio ConvertObjetoBD()
        {
            return new Vehiculo_Servicio
            {
                ID_Vehiculo_Servicio = ID_Vehiculo_Servicio,
                ID_Servicio = ID_Servicio,
                ID_Vehiculo = ID_Vehiculo
            };
        }
        #endregion Metodos
    }
}
