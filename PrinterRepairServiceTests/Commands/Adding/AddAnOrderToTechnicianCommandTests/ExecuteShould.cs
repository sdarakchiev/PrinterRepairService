using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using PrinterRepair.Commands.Adding;
using PrinterRepair.Data;
using PrinterRepairService.Models;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace PrinterRepairServiceTests.Commands.Adding.AddAnOrderToTechnicianCommandTests
{
    //[TestClass]
    //public class ExecuteShould
    //{
    //    [TestMethod]
    //    public void AddAnOrderToTechniciansOrderList_WhenParametersAreCorrect()
    //    {
    //        // Arrange
    //        var contextMock = new Mock<IPrinterServiceContext>();
    //        var orderMock = new Mock<Order>();
    //        var technicianMock = new Mock<Technician>();

    //        orderMock.Setup(o => o.Id == 1);
    //        technicianMock.Setup(t => t.Orders.Single() == orderMock.Object);


    //        List<string> parameters = new List<string>()
    //        {
    //            "1",
    //            "Pesho"
    //        };

    //        var command = new AddAnOrderToTechnicianCommand(contextMock.Object);

    //        // Act
    //        command.Execute(parameters);

    //        // Assert
    //    }
   // }
}
