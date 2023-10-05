using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using ProvaPub.Models;
using ProvaPub.Repository;
using ProvaPub.Services;

namespace ProvaPub.Tests
{
    [TestClass]
    public class CustomerServiceTests
    {
        [TestMethod]
        public async Task CanPurchase_InvalidCustomerId_ThrowsException()
        {
            // Arrange
            var customerId = -1;
            var purchaseValue = 100;
            var dbContext = new Mock<TestDbContext>();
            var customerService = new CustomerService(dbContext.Object);

            // Act and Assert
            await Assert.ThrowsExceptionAsync<ArgumentOutOfRangeException>(() =>
                customerService.CanPurchase(customerId, purchaseValue));
        }

        [TestMethod]
        public async Task CanPurchase_InvalidPurchaseValue_ThrowsException()
        {
            // Arrange
            var customerId = 1;
            var purchaseValue = -1;
            var dbContext = new Mock<TestDbContext>();
            var customerService = new CustomerService(dbContext.Object);

            // Act and Assert
            await Assert.ThrowsExceptionAsync<ArgumentOutOfRangeException>(() =>
                customerService.CanPurchase(customerId, purchaseValue));
        }

        [TestMethod]
        public async Task CanPurchase_CustomerDoesNotExist_ThrowsException()
        {
            // Arrange
            var customerId = 1;
            var purchaseValue = 100;
            var dbContext = new Mock<TestDbContext>();
            dbContext.Setup(d => d.Customers.FindAsync(customerId)).ReturnsAsync((Customer)null);
            var customerService = new CustomerService(dbContext.Object);

            // Act and Assert
            await Assert.ThrowsExceptionAsync<InvalidOperationException>(() =>
                customerService.CanPurchase(customerId, purchaseValue));
        }

        [TestMethod]
        public async Task CanPurchase_CustomerAlreadyPurchasedThisMonth_ReturnsFalse()
        {
            // Arrange
            var customerId = 1;
            var purchaseValue = 100;
            var dbContext = new Mock<TestDbContext>();
            dbContext.Setup(d => d.Customers.FindAsync(customerId)).ReturnsAsync(new Customer());
            dbContext.Setup(d => d.Orders.Any(s => s.CustomerId == customerId && s.OrderDate >= It.IsAny<DateTime>())); // Customer already purchased this month
            var customerService = new CustomerService(dbContext.Object);

            // Act
            var result = await customerService.CanPurchase(customerId, purchaseValue);

            // Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public async Task CanPurchase_FirstTimeCustomerPurchasingOverLimit_ReturnsFalse()
        {
            // Arrange
            var customerId = 1;
            var purchaseValue = 200;
            var dbContext = new Mock<TestDbContext>();
            dbContext.Setup(d => d.Customers.FindAsync(customerId)).ReturnsAsync(new Customer());
            dbContext.Setup(d => d.Orders.Any(s => s.CustomerId == customerId && s.OrderDate >= It.IsAny<DateTime>()));           
            dbContext.Setup(d => d.Customers.Any(s => s.Id == customerId && s.Orders.Any()));
                
            var customerService = new CustomerService(dbContext.Object);

            // Act
            var result = await customerService.CanPurchase(customerId, purchaseValue);

            // Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public async Task CanPurchase_ValidCustomerAndPurchaseValue_ReturnsTrue()
        {
            // Arrange
            var customerId = 1;
            var purchaseValue = 50;
            var dbContext = new Mock<TestDbContext>();
            dbContext.Setup(d => d.Customers.FindAsync(customerId)).ReturnsAsync(new Customer());
            dbContext.Setup(d => d.Orders.Any(s => s.CustomerId == customerId && s.OrderDate >= It.IsAny<DateTime>())); 
            dbContext.Setup(d => d.Customers.Any(s => s.Id == customerId && s.Orders.Any()));
            var customerService = new CustomerService(dbContext.Object);

            // Act
            var result = await customerService.CanPurchase(customerId, purchaseValue);

            // Assert
            Assert.IsTrue(result);
        }
    }
}
