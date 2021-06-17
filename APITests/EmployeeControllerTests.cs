using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPI.Controllers;
using WebAPI.DTOs;
using WebAPI.IRepository;
using Xunit;

namespace APITests
{
    public class EmployeeControllerTests
    {

        EmployeeController _controller;
        IUnitOfWork _unitOfWork;
        ILogger<EmployeeController> _logger;
        IMapper _mapper;
        private int id;
        private RequestParams requestParams;

        public EmployeeControllerTests()
        {

            _controller = new EmployeeController(_unitOfWork, _logger, _mapper);


        }
        //Get one so get by Id
        [Fact]
        public void Get_WhenCalled_ReturnsOkResult()
        {
            // Act
            var okResult = _controller.GetEmployee(id);

            // Assert
            Assert.IsType<OkObjectResult>(okResult.Result);
        }
        //Get all, so get the list of Customers
        //[Fact]
        //public void Get_WhenCalled_ReturnsAllItems()
        //{
        //    // Act
        //    var okResult = _controller.ControllerContext(requestParams, id).Result as OkObjectResult;

        //    // Assert
        //    var items = Assert.IsType<List<EmployeeDTO>>(okResult.Value);
        //    Assert.Equal(3, items.Count);
        //}

        //[Fact]
        //public void GetById_UnknownGuidPassed_ReturnsNotFoundResult()
        //{
        //    // Act
        //    var notFoundResult = _controller.Get(Guid.NewGuid());
        //    // Assert
        //    Assert.IsType<NotFoundResult>(notFoundResult.Result);
        //}
        //[Fact]
        //public void GetById_ExistingGuidPassed_ReturnsOkResult()
        //{
        //    // Arrange
        //    var testGuid = new Guid("1");
        //    // Act
        //    var okResult = _controller.Get(testGuid);
        //    // Assert
        //    Assert.IsType<OkObjectResult>(okResult.Result);
        //}
        //[Fact]
        //public void GetById_ExistingGuidPassed_ReturnsRightItem()
        //{
        //    // Arrange
        //    var testId = new Id("1");
        //    // Act
        //    var okResult = _controller.Get(testId).Result as OkObjectResult;
        //    // Assert
        //    Assert.IsType<EmployeeController>(okResult.Value);
        //    Assert.Equal(testId, (okResult.Value as EmployeeDTO).Id);
        //}
    }
}
