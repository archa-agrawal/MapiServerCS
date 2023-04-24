using System.Runtime.InteropServices;
using System.Xml.Linq;
using MapiServerCS.db;
using MapiServerCS.models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MapiServerCS.controllers;
[ApiController]
[Route("[controller]")]


public class LocationController : ControllerBase
{
	private readonly ILogger<LocationController> _logger;
	private readonly MapiContext _dbContext;

	public LocationController(ILogger<LocationController> logger, MapiContext dbContext)
	{
		_logger = logger;
		_dbContext = dbContext;
	}

    [Authorize]
    [HttpPost]
    public async Task<ActionResult<Location>> Post([FromBody] Location l)
    {
        await _dbContext.Locations.AddAsync(l);
        await _dbContext.SaveChangesAsync();

        var newLocation = await _dbContext.Locations.FindAsync(l.Id);

		return newLocation;
    }

    [Authorize]
    [HttpDelete]
	public async Task<ActionResult<Location>> Delete(string id)
	{
		var selectedLocation = await _dbContext.Locations.FindAsync(id);
		_dbContext.Locations.Remove(selectedLocation);
		await _dbContext.SaveChangesAsync();

		return NoContent();
	}
}

