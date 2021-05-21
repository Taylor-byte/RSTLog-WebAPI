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
    public class TransTypeControllerTests
    {
        TransTypeController _controller;
        IUnitOfWork _unitOfWork;
        ILogger<TransTypeController> _logger;
        IMapper _mapper;
        private int id;
        private RequestParams requestParams;

        public TransTypeControllerTests()
        {

            _controller = new TransTypeController(_unitOfWork, _logger, _mapper);


        }
        //Get one so get by Id
        [Fact]
        public void Get_WhenCalled_ReturnsOkResult()
        {
            // Act
            var okResult = _controller.GetTransType(id);

            // Assert
            Assert.IsType<OkObjectResult>(okResult.Result);
        }
        //Get all, so get the list of Customers
        [Fact]
        public void Get_WhenCalled_ReturnsAllItems()
        {
            // Act
            var okResult = _controller.GetTransTypes(requestParams, id).Result as OkObjectResult;

            // Assert
            var items = Assert.IsType<List<TransTypeDTO>>(okResult.Value);
            Assert.Equal(3, items.Count);
        }

        [Fact]
        public void GetById_UnknownGuidPassed_ReturnsNotFoundResult()
        {
            // Act
            var notFoundResult = _controller.GetTransType(id.NewId());
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
            var tesId = new Id("1");
            // Act
            var okResult = _controller.GetTransType(testId).Result as OkObjectResult;
            // Assert
            Assert.IsType<TransTypeDTO>(okResult.Value);
            Assert.Equal(testId, (okResult.Value as TransTypeDTO).Id);
        }
    }
}
