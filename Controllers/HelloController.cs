using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace TodoApi.Controllers
{
    [Route("api/hello")]
    public class HelloController : Controller
    {
        [HttpGet("{name}")]
        public IActionResult Hello(string name) => Ok($"Hello {name}");
    }
}
