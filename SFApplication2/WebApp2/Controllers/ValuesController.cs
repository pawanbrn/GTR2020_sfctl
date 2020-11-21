using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApp2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        static List<string> languages = new List<string>() {
            "C#","ASP.NET","MVC"
        };
        // GET api/values
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return languages;
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return languages[id];
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] DTO dto)
        {
            languages.Add(dto.TestDomain);
        }

       

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }

    
   
}


