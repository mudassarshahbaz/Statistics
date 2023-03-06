using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Statistics.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Statistics.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StatisticsController : ControllerBase
    {
        private readonly ILogger<StatisticsController> _logger;
        private readonly IStatisticsService _service;

        public StatisticsController(ILogger<StatisticsController> logger, IStatisticsService service)
        {
            _logger = logger;
            _service = service;
        }

        [HttpGet]
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Get()
        {
            try
            {
                var response = await _service.Get();

                if (response.Any())
                {
                    return Ok(response);
                }
                else
                {
                    return Ok("Records not found, Use Post API First.");
                }
            }
            catch (Exception)
            {
                return NotFound();
            }
        }

        [HttpPost]
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Post()
        {
            try
            {
                await _service.Post();
                var response = await _service.Get();
                
                return Ok(response);
            }
            catch (Exception)
            {
                return NotFound();
            }
        }
    }
}
