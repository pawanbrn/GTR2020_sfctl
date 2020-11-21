using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using WebApp21.Facades;

namespace WebApp21.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class TestRunController : ControllerBase
    {
        TestFacade _facade = new TestFacade();

        [HttpGet]
        public string Get()
        {
            return "Value";
        }

        [HttpPost]
        public IActionResult Post([FromBody] DTO dto)
        {
            var listResults = new List<string>();

            listResults =  _facade.RunTestsAsync(dto);
            var result = new ObjectResult(new { statusCode = FacadeStatusCode.Created, currentDate = DateTime.Now, result = listResults });
            result.StatusCode = (int)FacadeStatusCode.Created;
            return result;
        }


    }
}
