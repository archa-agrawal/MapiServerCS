using System.Runtime.InteropServices;
using System.Xml.Linq;
using Microsoft.AspNetCore.Mvc;

namespace api_test.Controllers;

[ApiController]
[Route("[controller]")]
public class HelloController : ControllerBase
{
  
    [HttpGet(Name = "sayHello")]
    public string Get()
    {
        return "hello world";
    }
}