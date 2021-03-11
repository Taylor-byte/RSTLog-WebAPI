﻿using AutoMapper;
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

        [Authorize(Roles = "Administrator")]
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


    }
}
