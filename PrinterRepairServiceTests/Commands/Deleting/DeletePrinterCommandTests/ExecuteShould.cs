using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using PrinterRepair.Commands.Deleting;
using PrinterRepair.Data;
using PrinterRepairService.Models;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace PrinterRepairServiceTests.Commands.Deleting.DeletePrinterCommandTests
{
    [TestClass]
    public class ExecuteShould
    {
        [TestMethod]
        public void RemovePrinterFromDatabase_WhenDeleteCommandIsCalled()
        {
            // Arrange
            var contextMock = new Mock<IPrinterServiceContext>();
            var printerMock = new Mock<Printer>();
            //var printerMock2 = new Mock<Printer>();
           
            IQueryable<Printer> printers = new List<Printer>()
                        { printerMock.Object }
                        .AsQueryable();

            var setMock = new Mock<DbSet<Printer>>();
            setMock.As<IQueryable<Printer>>().Setup(m => m.Provider).Returns(printers.Provider);
            setMock.As<IQueryable<Printer>>().Setup(m => m.Expression).Returns(printers.Expression);
            setMock.As<IQueryable<Printer>>().Setup(m => m.ElementType).Returns(printers.ElementType);
            setMock.As<IQueryable<Printer>>().Setup(m => m.GetEnumerator()).Returns(() => printers.GetEnumerator());

            contextMock.Setup(c => c.Printers).Returns(setMock.Object);
            var printerId = contextMock.Object.Printers.Single().UserId.ToString();

            var parameters = new List<string>() { printerId };

            var command = new DeletePrinterCommand(contextMock.Object);

            // Act
            command.Execute(parameters);

            //Assert
            Assert.AreEqual(0, contextMock.Object.Printers.Count());
            //Assert.AreEqual(false, contextMock.Object.Printers.Contains(printerMock.Object));
        }
    }
}
