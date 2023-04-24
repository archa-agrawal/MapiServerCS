using System;
using System.Runtime.InteropServices;
using System.Xml.Linq;
using MapiServerCS.db;
using MapiServerCS.models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Diagnostics;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;

namespace MapiServerCS.controllers;
[ApiController]
[Route("controller")]

public class UserController : ControllerBase
{
	private readonly ILogger<UserController> _logger;
	private readonly MapiContext _dbContext;

	public UserController(ILogger<UserController> logger, MapiContext dbContext)
	{
		_logger = logger;
		_dbContext = dbContext;
	}

	[HttpPost("/user/register")]
	public async Task<ActionResult<User>> Post([FromBody] User u)
	{
		await _dbContext.Users.AddAsync(u);
		await _dbContext.SaveChangesAsync();

		return u;
	}

	[HttpPost("/user/login")]
	public async Task<ActionResult<User>> Login([FromBody] UserDTO u)
	{
		var requestedUser = await _dbContext.Users.FirstAsync(user => user.Email == u.Email);
     

        if (requestedUser == null)
		{
			return NotFound();
		} else if (requestedUser.Password != u.Password)
		{
			return NotFound();
		} else
		{
			var claims = new List<Claim>
			{
				new Claim(ClaimTypes.Name, requestedUser.Email),
				new Claim(ClaimTypes.NameIdentifier, requestedUser.Id)
			};
            var claimsIdentity = new ClaimsIdentity(claims, "Login");

            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity));
			return requestedUser;
        }
	}

    [Authorize]
    [HttpPost("/user/logout")]
	public async Task<ActionResult<User>> Logout()
	{
        await HttpContext.SignOutAsync();
		return NoContent();
    }

}

