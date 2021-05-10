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
    public class CustomerControllerGetTest
    {
        
        CustomerController _controller;
        IUnitOfWork _unitOfWork;
        ILogger<CustomerController> _logger;
        IMapper _mapper;
        private int id;
        private RequestParams requestParams;

        public CustomerControllerGetTest()
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

    }
}
