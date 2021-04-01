using AutoMapper;
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
    //[Route("api/[controller]")]
    //[ApiController]
    //public class HoursController : ControllerBase
    //{

    //    private readonly IUnitOfWork _unitOfWork;
    //    private readonly ILogger<HoursController> _logger;
    //    private readonly IMapper _mapper;

    //    public HoursController(IUnitOfWork unitOfWork, ILogger<HoursController> logger, 
    //        IMapper mapper)
    //    {
    //        _unitOfWork = unitOfWork;

    //        _logger = logger;

    //        _mapper = mapper;
    //    }

    //    [HttpGet]
    //    [ProducesResponseType(StatusCodes.Status200OK)]
    //    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    //    public async Task<IActionResult> GetHours()
    //    {
    //        try
    //        {
    //            var Hours = await _unitOfWork.Hours.GetAll();
    //            var results = _mapper.Map<IList<HoursDTO>>(Hours);
    //            return Ok(results);
    //        }
    //        catch (Exception ex)
    //        {
    //            _logger.LogError(ex, $"Something went wrong in the {nameof(GetHours)}");
    //            return StatusCode(500, "Internal Server Error. Please try again later.");
    //        }
    //    }

    //    [HttpGet("{id:int}", Name = "GetHour")]
    //    [ProducesResponseType(StatusCodes.Status200OK)]
    //    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    //    public async Task<IActionResult> GetHour(int id)
    //    {
    //        try
    //        {
    //            var hour = await _unitOfWork.Hours.Get(q => q.Id == id, new List<string> { "Hours" });
    //            var result = _mapper.Map<HoursDTO>(hour);
    //            return Ok(result);
    //        }
    //        catch (Exception ex)
    //        {
    //            _logger.LogError(ex, $"Something went wrong in the {nameof(GetHour)}");
    //            return StatusCode(500, "Internal Server Error. Please try again later.");
    //        }
    //    }

    //    //[Authorize(Roles = "Administrator")]
    //    [HttpPost]
    //    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    //    [ProducesResponseType(StatusCodes.Status201Created)]
    //    [ProducesResponseType(StatusCodes.Status500InternalServerError)]

    //    public async Task<IActionResult> CreateHours([FromBody] CreateHoursDTO HoursDTO)
    //    {
    //        if (!ModelState.IsValid)
    //        {
    //            _logger.LogError($"Invalid POST attempt in {nameof(CreateHours)}");
    //            return BadRequest(ModelState);
    //        }

    //        try
    //        {
    //            var hours = _mapper.Map<Hours>(HoursDTO);
    //            await _unitOfWork.Hours.Insert(hours);
    //            await _unitOfWork.Save();

    //            //Created at route returns object to slient
    //            return CreatedAtRoute("GetHour", new { id = hours.Id }, hours);
    //        }
    //        catch (Exception ex)
    //        {

    //            _logger.LogError(ex, $"Something went wrong in the {nameof(CreateHours)}");
    //            return StatusCode(500, "Internal Server Error. Please try again later.");
    //        }

    //    }

    //    [HttpPut("{id:int}")]
    //    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    //    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    //    public async Task<IActionResult> UpdateHour(int id, [FromBody] UpdateHoursDTO hoursDTO)
    //    {
    //        if (!ModelState.IsValid || id < 1)
    //        {
    //            _logger.LogError($"Invalid UPDATE attempt in {nameof(UpdateHour)}");
    //            return BadRequest(ModelState);
    //        }

    //        try
    //        {
    //            var hours = await _unitOfWork.Hours.Get(q => q.Id == id);
    //            if (hours == null)
    //            {
    //                _logger.LogError($"Invalid UPDATE attempt in {nameof(UpdateHour)}");
    //                return BadRequest("IData submitted is invalid");
    //            }

    //            _mapper.Map(hoursDTO, hours);
    //            _unitOfWork.Hours.Update(hours);
    //            await _unitOfWork.Save();

    //            return NoContent();
    //        }
    //        catch (Exception ex)
    //        {

    //            _logger.LogError(ex, $"Something went wrong in the {nameof(UpdateHour)}");
    //            return StatusCode(500, "Internal Server Error. Please try again later.");
    //        }
    //    }

    //    [HttpDelete("id:int")]
    //    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    //    [ProducesResponseType(StatusCodes.Status201Created)]
    //    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    //    public async Task<IActionResult> DeleteHour(int id)
    //    {
    //        if (id < 1)
    //        {
    //            _logger.LogError($"Invalid DELETE attempt in {nameof(DeleteHour)}");
    //            return BadRequest();
    //        }

    //        try
    //        {
    //            var hours = await _unitOfWork.Hours.Get(q => q.Id == id);
    //            if (hours == null)
    //            {
    //                _logger.LogError($"Invalid DELETE attempt in {nameof(DeleteHour)}");
    //                return BadRequest("Data submitted is invalid");
    //            }

    //            await _unitOfWork.Hours.Delete(id);
    //            await _unitOfWork.Save();

    //            return NoContent();
    //        }
    //        catch (Exception ex)
    //        {

    //            _logger.LogError(ex, $"Something went wrong in the {nameof(DeleteHour)}");
    //            return StatusCode(500, "Internal Server Error. Please try again later.");
    //        }
    //    }
    //}
}
