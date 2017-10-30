using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using PrinterRepair.Commands.Creating;
using PrinterRepair.Core.Factories;
using PrinterRepair.Data;
using PrinterRepairService.Models;
using System.Collections.Generic;
using System.Data.Entity;

namespace PrinterRepairServiceTests.Commands.Creating.CreatePrinterCommands
{
    [TestClass]
    public class ExecuteShould
    {
        [TestMethod]
        public void CreatePrinterAndAddItToDtabase_WhenParametersAreCorrect()
        {
            // Arrange
            var contextMock = new Mock<IPrinterServiceContext>();
            var factoryMock = new Mock<IModelFactory>();
            var printerMock = new Mock<Printer>();

            //IQueryable<Printer> printers = new List<Printer>() { printerMock.Object }.AsQueryable();

            var setMock = new Mock<DbSet<Printer>>();
            //setMock.As<IQueryable<Printer>>().Setup(m => m.Provider).Returns(printers.Provider);
            //setMock.As<IQueryable<Printer>>().Setup(m => m.Expression).Returns(printers.Expression);
            //setMock.As<IQueryable<Printer>>().Setup(m => m.ElementType).Returns(printers.ElementType);
            //setMock.As<IQueryable<Printer>>().Setup(m => m.GetEnumerator()).Returns(() => printers.GetEnumerator());

            contextMock.Setup(c => c.Printers).Returns(setMock.Object);
            factoryMock.Setup(f => f.CreatePrinter()).Returns(printerMock.Object);

            List<string> parameters = new List<string>()
            {
                "Samsung",
                "ML450",
                "Laser"
            };

            var command = new CreatePrinterCommand(contextMock.Object, factoryMock.Object);

            // Act
            command.Execute(parameters);

            // Assert
            //Assert.AreEqual(printerMock.Object, contextMock.Object.Printers.Single());
            setMock.Verify(m => m.Add(It.IsAny<Printer>()), Times.Once);
        }
    }
}
