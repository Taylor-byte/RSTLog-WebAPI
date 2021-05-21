using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPI.Controllers;
using WebAPI.IRepository;
using WebAPI.Models;
using WebAPI.Repository;
using Xunit;
using WebAPI.DTOs;

namespace APITests
{
    public class CustomerControllerTests
    {
        
        CustomerController _controller;
        IUnitOfWork _unitOfWork;
        ILogger<CustomerController> _logger;
        IMapper _mapper;
        private int id;
        private RequestParams requestParams;

        public CustomerControllerTests()
        {
            
            _controller = new CustomerController(_unitOfWork, _logger, _mapper);
            

        }
        //Get one so get by Id
        [Fact]
        public void Get_WhenCalled_ReturnsOkResult()
        {
            // Act
            var okResult = _controller.GetCustomer(id);

            // Assert
            Assert.IsType<OkObjectResult>(okResult.Result);
        }
        //Get all, so get the list of Customers
        [Fact]
        public void Get_WhenCalled_ReturnsAllItems()
        {
            // Act
            var okResult = _controller.GetCustomers(requestParams).Result as OkObjectResult;

            // Assert
            var items = Assert.IsType<List<Customer>>(okResult.Value);
            Assert.Equal(3, items.Count);
        }

        [Fact]
        public void GetById_UnknownGuidPassed_ReturnsNotFoundResult()
        {
            // Act
            var notFoundResult = _controller.Get(Guid.NewGuid());
            // Assert
            Assert.IsType<NotFoundResult>(notFoundResult.Result);
        }
        [Fact]
        public void GetById_ExistingGuidPassed_ReturnsOkResult()
        {
            // Arrange
            var testId = new Id("1");
            // Act
            var okResult = _controller.Get(testId);
            // Assert
            Assert.IsType<OkObjectResult>(okResult.Result);
        }
        [Fact]
        public void GetById_ExistingGuidPassed_ReturnsRightItem()
        {
            // Arrange
            var testId = new Id("1");
            // Act
            var okResult = _controller.Get(testId).Result as OkObjectResult;
            // Assert
            Assert.IsType<CustomerController>(okResult.Value);
            Assert.Equal(testId, (okResult.Value as CustomerDTO).Id);
        }

    }
}
