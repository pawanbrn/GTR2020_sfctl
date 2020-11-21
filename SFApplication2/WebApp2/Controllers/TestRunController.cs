using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp2.Facades;

namespace WebApp2.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class TestRunController : ControllerBase
    {
        //private readonly ITestFacades _facade;

        static List<string> languages = new List<string>() {
            "C#","ASP.NET","MVC"
        };

       TestFacade _facade = new TestFacade();


        [HttpPost]
        public void Post([FromBody] DTO dto)
        {
            languages.Add(dto.TestDomain);
            _facade.RunTestsAsync(dto);
        }

        [HttpGet]
        public IEnumerable<string> Get()
        {
            return languages;
        }


    }
}
