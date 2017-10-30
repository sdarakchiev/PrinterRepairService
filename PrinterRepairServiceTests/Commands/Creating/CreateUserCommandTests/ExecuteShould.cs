using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using PrinterRepair.Commands.Creating;
using PrinterRepair.Core.Factories;
using PrinterRepair.Data;
using PrinterRepairService.Models;
using System.Collections.Generic;
using System.Data.Entity;

namespace PrinterRepairServiceTests.Commands.Creating.CreateUserCommandTests
{
    [TestClass]
    public class ExecuteShould
    {
        [TestMethod]
        public void CreateUserAndAddItToDatabase_WhenParametersAreCorrect()
        {
            // Arrange
            var contextMock = new Mock<IPrinterServiceContext>();
            var factoryMock = new Mock<IModelFactory>();
            var userMock = new Mock<User>();
            
            var setMock = new Mock<DbSet<User>>();
           
            contextMock.Setup(c => c.Users).Returns(setMock.Object);
            factoryMock.Setup(f => f.CreateUser()).Returns(userMock.Object);

            var parameters = new List<string>()
            {
                "1",
                "Ivan",
                "Ivanov"
            };

            var command = new CreateUserCommand(contextMock.Object, factoryMock.Object);

            // Act
            command.Execute(parameters);

            //Assert
            //Assert.AreEqual(userMock.Object, contextMock.Object.Users.Single());
            setMock.Verify(m => m.Add(It.IsAny<User>()), Times.Once);
        }

        [TestMethod]
        public void ReturnCorrectMessage_WhenPArametersAreCorrect()
        {
            // Arrange
            var contextMock = new Mock<IPrinterServiceContext>();
            var factoryMock = new Mock<IModelFactory>();
            var userMock = new Mock<User>();


            var setMock = new Mock<DbSet<User>>();
            
            contextMock.Setup(c => c.Users).Returns(setMock.Object);
            factoryMock.Setup(f => f.CreateUser()).Returns(userMock.Object);

            var parameters = new List<string>()
            {
                "1",
                "Ivan",
                "Ivanov"
            };
            var expectedResult = "User with ID 1 was created";

            var command = new CreateUserCommand(contextMock.Object, factoryMock.Object);

            // Act
            var actualResult = command.Execute(parameters);

            //Assert
            Assert.AreEqual(expectedResult, actualResult);
        }
    }
}
