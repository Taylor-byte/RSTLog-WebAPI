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
    [Authorize]
    public class TransTypeController : ControllerBase
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<TransTypeController> _logger;
        private readonly IMapper _mapper;

        public TransTypeController(IUnitOfWork unitOfWork, ILogger<TransTypeController> logger,
            IMapper mapper)
        {
            _unitOfWork = unitOfWork;

            _logger = logger;

            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetTransTypes()
        {
            try
            {
                var TransTypes = await _unitOfWork.TransType.GetAll();
                var results = _mapper.Map<IEnumerable<TransTypeDTO>>(TransTypes);
                return Ok(results);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Something went wrong in the {nameof(GetTransTypes)}");
                return StatusCode(500, "Internal Server Error. Please try again later.");
            }
        }

        [HttpGet("{id:int}", Name = "GetTransTypes")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetTransType(int id)
        {
            try
            {
                var TransType = await _unitOfWork.TransType.Get(q => q.Id == id);
                var result = _mapper.Map<TransTypeDTO>(TransType);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Something went wrong in the {nameof(GetTransType)}");
                return StatusCode(500, "Internal Server Error. Please try again later.");
            }
        }

        [Authorize(Roles = "Administrator")]
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]

        public async Task<IActionResult> CreateTransType([FromBody] CreateTransTypeDTO TransTypeDTO)
        {
            if (!ModelState.IsValid)
            {
                _logger.LogError($"Invalid POST attempt in {nameof(CreateTransType)}");
                return BadRequest(ModelState);
            }

            try
            {
                var transType = _mapper.Map<TransType>(TransTypeDTO);
                await _unitOfWork.TransType.Insert(transType);
                await _unitOfWork.Save();

                //Created at route returns object to slient
                //return CreatedAtRoute("GetTransType", new { id = transType.Id }, transType);
                return Ok();
            }
            catch (Exception ex)
            {

                _logger.LogError(ex, $"Something went wrong in the {nameof(CreateTransType)}");
                return StatusCode(500, "Internal Server Error. Please try again later.");
            }

        }

        [HttpPut("{id:int}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> UpdateTransType(int id, [FromBody] UpdateTransTypeDTO TransTypeDTO)
        {
            if (!ModelState.IsValid || id < 1)
            {
                _logger.LogError($"Invalid UPDATE attempt in {nameof(UpdateTransType)}");
                return BadRequest(ModelState);
            }

            try
            {
                var TransType = await _unitOfWork.TransType.Get(q => q.Id == id);
                if (TransType == null)
                {
                    _logger.LogError($"Invalid UPDATE attempt in {nameof(UpdateTransType)}");
                    return BadRequest("IData submitted is invalid");
                }

                _mapper.Map(TransTypeDTO, TransType);
                _unitOfWork.TransType.Update(TransType);
                await _unitOfWork.Save();

                return NoContent();
            }
            catch (Exception ex)
            {

                _logger.LogError(ex, $"Something went wrong in the {nameof(UpdateTransType)}");
                return StatusCode(500, "Internal Server Error. Please try again later.");
            }
        }

        [HttpDelete("id:int")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeleteTransType(int id)
        {
            if (id < 1)
            {
                _logger.LogError($"Invalid DELETE attempt in {nameof(DeleteTransType)}");
                return BadRequest();
            }

            try
            {
                var days = await _unitOfWork.TransType.Get(q => q.Id == id);
                if (days == null)
                {
                    _logger.LogError($"Invalid DELETE attempt in {nameof(DeleteTransType)}");
                    return BadRequest("Data submitted is invalid");
                }

                await _unitOfWork.TransType.Delete(id);
                await _unitOfWork.Save();

                return NoContent();
            }
            catch (Exception ex)
            {

                _logger.LogError(ex, $"Something went wrong in the {nameof(DeleteTransType)}");
                return StatusCode(500, "Internal Server Error. Please try again later.");
            }
        }

    }
}
