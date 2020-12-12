using Microsoft.AspNetCore.Mvc;
using System;
using WebApp21.Facades;

namespace WebApp21.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class TestRunController : ControllerBase
    {
        readonly TestFacade _facade = new TestFacade();

        [HttpGet]
        public string Get()
        {
            return "Value";
        }

        [HttpPost]
        public IActionResult Post([FromBody] DTO dto)
        {
            var listResults = _facade.RunTestsAsync(dto);
            var result = new ObjectResult(new
            {
                statusCode = FacadeStatusCode.Created, currentDate = DateTime.Now, result = listResults
            }) {StatusCode = (int) FacadeStatusCode.Created};
            return result;
        }


    }
}
