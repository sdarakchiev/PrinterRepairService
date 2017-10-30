using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using PrinterRepair.Commands.Listing;
using PrinterRepair.Data;
using PrinterRepairService.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace PrinterRepairServiceTests.Commands.Listing.ListUserCommandTests
{
    [TestClass]
    public class ExecuteShould
    {
        [TestMethod]
        public void ReturnUsersToString_WhenParametersAreCorrect()
        {
            // Arrange
            var contextMock = new Mock<IPrinterServiceContext>();

            IQueryable<User> users = new List<User>()
            {
                new User {Id = 1, FirstName = "Ivan", LastName = "Petrov"},
                new User {Id = 2, FirstName = "Geri", LastName = "Nikol"},
                new User {Id = 3, FirstName = "100", LastName =  "Kila"}
            }.AsQueryable();

            var setMock = new Mock<DbSet<User>>();

            setMock.As<IQueryable<User>>().Setup(m => m.Provider).Returns(users.Provider);
            setMock.As<IQueryable<User>>().Setup(m => m.Expression).Returns(users.Expression);
            setMock.As<IQueryable<User>>().Setup(m => m.ElementType).Returns(users.ElementType);
            setMock.As<IQueryable<User>>().Setup(m => m.GetEnumerator()).Returns(() => users.GetEnumerator());

            contextMock.Setup(c => c.Users).Returns(setMock.Object);

            var command = new ListUserCommand(contextMock.Object);

            var expectedResult = string.Join(Environment.NewLine, users);

            // Act
            var actualResult = command.Execute(It.IsAny<IList<string>>());

            //Assert
            Assert.AreEqual(expectedResult, actualResult);
        }
    }
}
