using System.Runtime.InteropServices;
using System.Security.Claims;
using System.Xml.Linq;
using MapiServerCS.db;
using MapiServerCS.models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace MapiServerCS.controllers;

[ApiController]
[Route("[controller]")]


public class MapController : ControllerBase
{

    private readonly ILogger<MapController> _logger;
    private readonly MapiContext _dbContext;
    private readonly string? _userId;

    public MapController(ILogger<MapController> logger, MapiContext dbContext, IHttpContextAccessor httpContextAccessor)
    {
        _userId = httpContextAccessor.HttpContext?.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        _logger = logger;
        _dbContext = dbContext;
        
    }


    [HttpGet("/map/{id}")]
	public async Task<ActionResult<Map>> Get(string id)
    {
        var selectedMap = await _dbContext.Maps.Include(map => map.Locations).FirstAsync(map => map.Id == id);
        
        if (selectedMap == null)
        {
            return NotFound();
        }
        return selectedMap;
    }

    [Authorize]
    [HttpPost]
    public async Task<ActionResult<Map>> Post([FromBody] MapDTO m)
    {
        var map = new Map(m.Heading, m.Description, m.Theme, _userId);
        await _dbContext.Maps.AddAsync(map);
        await _dbContext.SaveChangesAsync();

        return CreatedAtAction(
            nameof(Get),
            new MapDTO(map));
    }

    [Authorize]
    [HttpPut]
    public async Task<ActionResult<Map>> Put([FromBody] MapUpdateDTO m)
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

    [Authorize]
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

    [HttpGet("/map/list")]
    public async Task<ActionResult<Map>> Get()
    {
        var allMaps = await _dbContext.Maps.Include(e => e.Locations).ToArrayAsync();

        return CreatedAtAction(
            nameof(Get),
            allMaps);
    }
    

}

