using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mime;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NumberOrdering.API.Services;

namespace NumberOrdering.API.Controllers
{
    [ApiController]
    public class NumberOrderingController
    {
        private readonly string resultPath = Path.Combine(Environment.CurrentDirectory, "Results", "results.txt");

        [HttpGet]
        [Route("api/numbers")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Get()
        {
            try
            {
                string text = await File.ReadAllTextAsync(resultPath);

                int[] numbers = Array.ConvertAll(text.Split(","), s => int.Parse(s));

                return new OkObjectResult(numbers);
            }
            catch (Exception e)
            {
                return new NotFoundResult();
            }
        }

        [HttpPost]
        [Route("api/ordering")]
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> Order([FromBody] int[] numbers)
        {
            var service = new NumberOrderingService(numbers);

            service.Order();

            await File.WriteAllTextAsync(resultPath, string.Join(",", service.Numbers));

            return new OkObjectResult(service.Numbers);
        }
    }
}
