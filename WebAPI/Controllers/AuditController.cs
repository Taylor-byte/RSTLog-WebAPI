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
    [Route("api/[controller]")]
    [ApiController]
    public class AuditController : ControllerBase
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<AuditController> _logger;
        private readonly IMapper _mapper;

        public AuditController(IUnitOfWork unitOfWork, ILogger<AuditController> logger,
            IMapper mapper)
        {
            _unitOfWork = unitOfWork;

            _logger = logger;

            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetAudits([FromQuery] RequestParams requestParams)
        {
            try
            {
                var audits = await _unitOfWork.Audit.GetAudits(requestParams);
                //new
                string param = System.Text.Json.JsonSerializer.Serialize(requestParams);
                Response.Headers.Add("X-Pagination", param);
                Response.Headers.Add("Access-Control-Expose-Headers", "X-Pagination");

                var results = _mapper.Map<IList<AuditDTO>>(audits);
                return Ok(results);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Something went wrong in the {nameof(GetAudits)}");
                return StatusCode(500, "Internal Server Error. Please try again later.");
            }
        }

        //[HttpGet]
        //[ProducesResponseType(StatusCodes.Status200OK)]
        //[ProducesResponseType(StatusCodes.Status500InternalServerError)]
        //public async Task<IActionResult> GetAudits()
        //{
        //    try
        //    {
        //        var Audit = await _unitOfWork.Audit.GetAll();
        //        var results = _mapper.Map<IList<AuditDTO>>(Audit);
        //        return Ok(results);
        //    }
        //    catch (Exception ex)
        //    {
        //        _logger.LogError(ex, $"Something went wrong in the {nameof(GetAudits)}");
        //        return StatusCode(500, "Internal Server Error. Please try again later.");
        //    }
        //}

        [HttpGet("{id:int}", Name = "GetAudit")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetAudit(int id)
        {
            try
            {
                var audit = await _unitOfWork.Audit.Get(q => q.Id == id, new List<string> { "TransType", "Employee" });
                var result = _mapper.Map<AuditDTO>(audit);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Something went wrong in the {nameof(GetAudit)}");
                return StatusCode(500, "Internal Server Error. Please try again later.");
            }
        }

        //[Authorize(Roles = "Administrator")]
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]

        public async Task<IActionResult> CreateAudit([FromBody] CreateAuditDTO AuditDTO)
        {
            if (!ModelState.IsValid)
            {
                _logger.LogError($"Invalid POST attempt in {nameof(CreateAudit)}");
                return BadRequest(ModelState);
            }

            try
            {
                var audit = _mapper.Map<Audit>(AuditDTO);
                await _unitOfWork.Audit.Insert(audit);
                await _unitOfWork.Save();

                //Created at route returns object to slient
                return CreatedAtRoute("GetAudit", new { id = audit.Id }, audit);
            }
            catch (Exception ex)
            {

                _logger.LogError(ex, $"Something went wrong in the {nameof(CreateAudit)}");
                return StatusCode(500, "Internal Server Error. Please try again later.");
            }

        }

        [HttpPut("{id:int}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> UpdateAudit(int id, [FromBody] UpdateAuditDTO AuditDTO)
        {
            if (!ModelState.IsValid || id < 1)
            {
                _logger.LogError($"Invalid UPDATE attempt in {nameof(UpdateAudit)}");
                return BadRequest(ModelState);
            }

            try
            {
                var Audit = await _unitOfWork.Audit.Get(q => q.Id == id);
                if (Audit == null)
                {
                    _logger.LogError($"Invalid UPDATE attempt in {nameof(UpdateAudit)}");
                    return BadRequest("IData submitted is invalid");
                }

                _mapper.Map(AuditDTO, Audit);
                _unitOfWork.Audit.Update(Audit);
                await _unitOfWork.Save();

                return NoContent();
            }
            catch (Exception ex)
            {

                _logger.LogError(ex, $"Something went wrong in the {nameof(UpdateAudit)}");
                return StatusCode(500, "Internal Server Error. Please try again later.");
            }
        }

        [HttpDelete("id:int")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeleteAudit(int id)
        {
            if (id < 1)
            {
                _logger.LogError($"Invalid DELETE attempt in {nameof(DeleteAudit)}");
                return BadRequest();
            }

            try
            {
                var Audit = await _unitOfWork.Audit.Get(q => q.Id == id);
                if (Audit == null)
                {
                    _logger.LogError($"Invalid DELETE attempt in {nameof(DeleteAudit)}");
                    return BadRequest("Data submitted is invalid");
                }

                await _unitOfWork.Audit.Delete(id);
                await _unitOfWork.Save();

                return NoContent();
            }
            catch (Exception ex)
            {

                _logger.LogError(ex, $"Something went wrong in the {nameof(DeleteAudit)}");
                return StatusCode(500, "Internal Server Error. Please try again later.");
            }
        }
    }
}
