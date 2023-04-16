using System.Runtime.InteropServices;
using System.Xml.Linq;
using MapiServerCS.db;
using MapiServerCS.models;
using MapiServerCS.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MapiServerCS.controllers;

[ApiController]
[Route("[controller]")]


public class MapController : ControllerBase
{

    MapService mapService = new MapService();

    private readonly ILogger<MapController> _logger;
    private readonly MapiContext _dbContext;

    public MapController(ILogger<MapController> logger, MapiContext dbContext)
    {
        _logger = logger;
        _dbContext = dbContext;
    }


    [HttpGet("/map/{id}")]
	public async Task<ActionResult<Map>> Get(string id)
	{
        return await _dbContext.Maps.FindAsync(id);

    }

    [HttpPost]
    public async Task<ActionResult<Map>> Post([FromBody] Map m)
    {
        await _dbContext.Maps.AddAsync(m);
        await _dbContext.SaveChangesAsync();

        return CreatedAtAction(
            nameof(Get),
            new { id = m.Id },
            m);
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

