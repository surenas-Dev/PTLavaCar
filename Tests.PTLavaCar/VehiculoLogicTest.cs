using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using PTLavaCar.BussinesLogic;
using PTLavaCar.DataAccess;
using PTLavaCar.Models.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

[TestClass]
public class VehiculoLogicTest
{
    private Mock<DAVehiculo> _mockDAVehiculo;
    private VehiculoLogic _vehiculoLogic;

    [TestInitialize]
    public void Setup()
    {
        _mockDAVehiculo = new Mock<DAVehiculo>();

        // Datos simulados
        var vehiculosSimulados = new List<Vehiculo>
        {
            new Vehiculo { Placa = " ABC 023 " },
            new Vehiculo { Placa = " XYZ 999 " }
        };

        // Configurar el mock para devolver la lista
        _mockDAVehiculo.Setup(m => m.Listar()).ReturnsAsync(vehiculosSimulados);

        _vehiculoLogic = new VehiculoLogic(_mockDAVehiculo.Object);
    }

    [TestMethod]
    [DataRow("ABC 023")]
    public async Task ExistePlacaTest(string placa)
    {
        var lista = await _vehiculoLogic.Listar(); // Usá el mock
        var existe = lista.Any(v => v.Placa == placa);

        Assert.IsTrue(existe, $"No se encontró la placa {placa}");
    }
}
