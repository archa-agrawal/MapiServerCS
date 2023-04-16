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
        var selectedMap = await _dbContext.Maps.FindAsync(id);
        
        if (selectedMap == null)
        {
            return NotFound();
        }
        return selectedMap;
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

    [HttpPut]
    public async Task<ActionResult<Map>> Put([FromBody] MapUpdate m)
    {
        var selectedMap = await _dbContext.Maps.FindAsync(m.Id);
        selectedMap.Heading = m.Heading;
        selectedMap.Description = m.Description;
        await _dbContext.SaveChangesAsync();

        return CreatedAtAction(
            nameof(Get),
            new { id = m.Id },
            m);
 
    }

    [HttpDelete("/map/{id}")]
    public async Task<ActionResult<Map>> Delete(string id)
    {
        var selectedMap = await _dbContext.Maps.FindAsync(id);

        if (selectedMap == null)
        {
            return NotFound();
        }
        _dbContext.Maps.Remove(selectedMap);
        await _dbContext.SaveChangesAsync();

        return NoContent();
      
    }

}

