using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.DTOs;
using WebAPI.IRepository;
using WebAPI.Models;
using System.Text.Json;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    
    public class CustomerController : ControllerBase
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<CustomerController> _logger;
        private readonly IMapper _mapper;

        public CustomerController(IUnitOfWork unitOfWork, ILogger<CustomerController> logger,
            IMapper mapper)
        {
            _unitOfWork = unitOfWork;

            _logger = logger;

            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetCustomers([FromQuery] RequestParams requestParams)
        {
            try
            {
                var customers = await _unitOfWork.Customer.GetCustomers(requestParams);
                //new
                string param = System.Text.Json.JsonSerializer.Serialize(requestParams);
                Response.Headers.Add("X-Pagination", param);
                Response.Headers.Add("Access-Control-Expose-Headers", "X-Pagination");

                var results = _mapper.Map<IList<CustomerDTO>>(customers);
                return Ok(results);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Something went wrong in the {nameof(GetCustomers)}");
                return StatusCode(500, "Internal Server Error. Please try again later.");
            }
        }

        [HttpGet("{id:int}", Name = "GetCustomer")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetCustomer(int id)
        {
            try
            {                                                                                   //{ "Hours", "Days" })
                var customer = await _unitOfWork.Customer.Get(q => q.Id == id, new List<string> {"Audit"});
                var result = _mapper.Map<CustomerDTO>(customer);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Something went wrong in the {nameof(GetCustomer)}");
                return StatusCode(500, "Internal Server Error. Please try again later.");
            }
        }

        //[Authorize(Roles = "Administrator")]
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]

        public async Task<IActionResult> CreateCustomer([FromBody] CreateCustomerDTO customerDTO)
        {
            if(!ModelState.IsValid)
            {
                _logger.LogError($"Invalid POST attempt in {nameof(CreateCustomer)}");
                return BadRequest(ModelState);
            }

            try
            {
                var customer = _mapper.Map<Customer>(customerDTO);
                await _unitOfWork.Customer.Insert(customer);
                await _unitOfWork.Save();

                //Created at route returns object to slient
                return CreatedAtRoute("GetCustomer", new { id = customer.Id }, customer);
            }
            catch (Exception ex)
            {

                _logger.LogError(ex, $"Something went wrong in the {nameof(CreateCustomer)}");
                return StatusCode(500, "Internal Server Error. Please try again later.");
            }

        }

        [HttpPut("{id:int}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> UpdateCustomer(int id, [FromBody] UpdateCustomerDTO customerDTO)
        {
            if(!ModelState.IsValid || id < 1)
            {
                _logger.LogError($"Invalid UPDATE attempt in {nameof(UpdateCustomer)}");
                return BadRequest(ModelState);
            }

            try
            {
                var customer = await _unitOfWork.Customer.Get(q => q.Id == id);
                if (customer == null)
                {
                    _logger.LogError($"Invalid UPDATE attempt in {nameof(UpdateCustomer)}");
                    return BadRequest("Data submitted is invalid");
                }

                _mapper.Map(customerDTO, customer);
                _unitOfWork.Customer.Update(customer);
                await _unitOfWork.Save();

                return NoContent();
            }
            catch (Exception ex )
            {

                _logger.LogError(ex, $"Something went wrong in the {nameof(UpdateCustomer)}");
                return StatusCode(500, "Internal Server Error. Please try again later.");
            }
        }

        [HttpDelete("id:int")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeleteCustomer(int id)
        {
            if (id < 1)
            {
                _logger.LogError($"Invalid DELETE attempt in {nameof(DeleteCustomer)}");
                return BadRequest();
            }

            try
            {
                var customer = await _unitOfWork.Customer.Get(q => q.Id == id);
                if (customer == null)
                {
                    _logger.LogError($"Invalid DELETE attempt in {nameof(DeleteCustomer)}");
                    return BadRequest("Data submitted is invalid");
                }

                await _unitOfWork.Customer.Delete(id);
                await _unitOfWork.Save();

                return NoContent();
            }
            catch (Exception ex)
            {

                _logger.LogError(ex, $"Something went wrong in the {nameof(DeleteCustomer)}");
                return StatusCode(500, "Internal Server Error. Please try again later.");
            }
        }

    }
}
