using System.Runtime.InteropServices;
using System.Xml.Linq;
using MapiServerCS.models;
using Microsoft.AspNetCore.Mvc;

namespace MapiServerCS.controllers;

[ApiController]
[Route("[controller]")]


public class MapController : ControllerBase
{
    private readonly ILogger<MapController> _logger;

    public MapController(ILogger<MapController> logger)
    {
        _logger = logger;
    }


    [HttpGet("/map/{id}")]
	public Map Get(int id)
	{
        foreach(Map m in maps)
        {
            if (m.MapId = id)
            {
                return m
            }
        }
		return new Map("abc", "def", "efg", id);
	}

    [HttpPost]
    public Map Post([FromBody] Map m)
    {
        return m;
    }

    [HttpPut("/map/{id}")]
    public Map Put(int id, [FromBody] Map m)
    {
        return m;
    }

    [HttpDelete("/map/{id}")]
    public string Delete(int id)
    {
        return "ok";
    }

}

