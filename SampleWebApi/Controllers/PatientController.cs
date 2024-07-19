using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace SampleWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientController : ControllerBase
    {
        private static readonly string[] Names = new[]
       {
            "Frank", "Brace", "Chan", "Chole", "Mike"
        };
        private readonly ILogger<PatientController> _logger;
        public PatientController(ILogger<PatientController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<Patient> GetPatients()
        {
            return Enumerable.Range(1, 5).Select(index => new Patient
            {
                BirthDate = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                Age = Random.Shared.Next(-20, 55),
                Name = Names[Random.Shared.Next(Names.Length)]
            })
           .ToArray();
        }
    }
}
