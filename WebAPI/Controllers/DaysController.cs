using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.DTOs;
using WebAPI.IRepository;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DaysController : ControllerBase
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<DaysController> _logger;
        private readonly IMapper _mapper;

        public DaysController(IUnitOfWork unitOfWork, ILogger<DaysController> logger,
            IMapper mapper)
        {
            _unitOfWork = unitOfWork;

            _logger = logger;

            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetDays()
        {
            try
            {
                var Days = await _unitOfWork.Days.GetAll();
                var results = _mapper.Map<IList<DaysDTO>>(Days);
                return Ok(results);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Something went wrong in the {nameof(GetDays)}");
                return StatusCode(500, "Internal Server Error. Please try again later.");
            }
        }

        [HttpGet("{id:int}", Name = "GetDay")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetDay(int id)
        {
            try
            {
                var day = await _unitOfWork.Days.Get(q => q.Id == id, new List<string> { "Customer" });
                var result = _mapper.Map<DaysDTO>(day);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Something went wrong in the {nameof(GetDay)}");
                return StatusCode(500, "Internal Server Error. Please try again later.");
            }
        }

        //[Authorize(Roles = "Administrator")]
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]

        public async Task<IActionResult> CreateDays([FromBody] CreateDaysDTO daysDTO)
        {
            if (!ModelState.IsValid)
            {
                _logger.LogError($"Invalid POST attempt in {nameof(CreateDays)}");
                return BadRequest(ModelState);
            }

            try
            {
                var days = _mapper.Map<Days>(daysDTO);
                await _unitOfWork.Days.Insert(days);
                await _unitOfWork.Save();

                //Created at route returns object to slient
                return CreatedAtRoute("GetDay", new { id = days.Id }, days);
            }
            catch (Exception ex)
            {

                _logger.LogError(ex, $"Something went wrong in the {nameof(CreateDays)}");
                return StatusCode(500, "Internal Server Error. Please try again later.");
            }

        }

        [HttpPut("{id:int}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> UpdateDay(int id, [FromBody] UpdateDaysDTO daysDTO)
        {
            if (!ModelState.IsValid || id < 1)
            {
                _logger.LogError($"Invalid UPDATE attempt in {nameof(UpdateDay)}");
                return BadRequest(ModelState);
            }

            try
            {
                var days = await _unitOfWork.Days.Get(q => q.Id == id);
                if (days == null)
                {
                    _logger.LogError($"Invalid UPDATE attempt in {nameof(UpdateDay)}");
                    return BadRequest("IData submitted is invalid");
                }

                _mapper.Map(daysDTO, days);
                _unitOfWork.Days.Update(days);
                await _unitOfWork.Save();

                return NoContent();
            }
            catch (Exception ex)
            {

                _logger.LogError(ex, $"Something went wrong in the {nameof(UpdateDay)}");
                return StatusCode(500, "Internal Server Error. Please try again later.");
            }
        }

        [HttpDelete("id:int")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeleteDay(int id)
        {
            if (id < 1)
            {
                _logger.LogError($"Invalid DELETE attempt in {nameof(DeleteDay)}");
                return BadRequest();
            }

            try
            {
                var days = await _unitOfWork.Days.Get(q => q.Id == id);
                if (days == null)
                {
                    _logger.LogError($"Invalid DELETE attempt in {nameof(DeleteDay)}");
                    return BadRequest("Data submitted is invalid");
                }

                await _unitOfWork.Days.Delete(id);
                await _unitOfWork.Save();

                return NoContent();
            }
            catch (Exception ex)
            {

                _logger.LogError(ex, $"Something went wrong in the {nameof(DeleteDay)}");
                return StatusCode(500, "Internal Server Error. Please try again later.");
            }
        }


    }
}
