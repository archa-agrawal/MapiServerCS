using System.Runtime.InteropServices;
using System.Xml.Linq;
using MapiServerCS.models;
using MapiServerCS.Services;
using Microsoft.AspNetCore.Mvc;

namespace MapiServerCS.controllers;

[ApiController]
[Route("[controller]")]


public class MapController : ControllerBase
{

    MapService mapService = new MapService();

    private readonly ILogger<MapController> _logger;

    public MapController(ILogger<MapController> logger)
    {
        _logger = logger;
    }


    [HttpGet("/map/{id}")]
	public Map Get(string id)
	{
		return mapService.GetMap(id);
	}

    [HttpPost]
    public Map Post([FromBody] Map m)
    {
        return mapService.CreateMap(m);
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

