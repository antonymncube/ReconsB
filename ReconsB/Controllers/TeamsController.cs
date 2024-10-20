using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ReconsB.Data;
using ReconsB.Models;

namespace ReconsB.Controllers
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Route("api/[controller]")]
    [ApiController]
    public class TeamController : ControllerBase
    {
        private readonly AddDbContext _context;  // Remove static

        public TeamController(AddDbContext context)
        {
            _context = context;
        }

        // List of teams for static data (you might want to remove this if using database)
        private static List<Team> Teams = new List<Team>
        {
            new Team
            {
                Id = 1,
                Name = "Toyota",
                Country = "South Africa",
                TeamPrincipal = "Anthony"
            },
            new Team
            {
                Id = 2,
                Name = "Ferrari",
                Country = "Italy",
                TeamPrincipal = "Carlos"
            },
            new Team
            {
                Id = 3,
                Name = "Mercedes",
                Country = "Germany",
                TeamPrincipal = "Toto"
            }
        };

        // Get all team details
        [HttpGet("GetTeamDetails")]
        public async Task<IActionResult> Get()
        {
            var teams = await _context.Teams.ToListAsync();
            return Ok(teams);
        }

        // Get a single team by ID
        [HttpGet("team/{id:int}")]
        public async Task<IActionResult> Get(int id)
        {
            var team = await _context.Teams.FirstOrDefaultAsync(x => x.Id == id);

            if (team == null)
                return BadRequest("Invalid ID");

            return Ok(team);
        }

        // Create a new team
        [HttpPost]
        public async Task<IActionResult> Post(Team team)
        {
            await _context.Teams.AddAsync(team);
            await _context.SaveChangesAsync();   

            return CreatedAtAction(nameof(Get), new { id = team.Id }, team);   
        }

        // Update the country of a team
        [HttpPatch("{id:int}")]
        public async Task<IActionResult> Patch(int id, string country)
        {
            var team = await _context.Teams.FirstOrDefaultAsync(x => x.Id == id);

            if (team == null)
                return BadRequest("Invalid ID");

            team.Country = country;

            await _context.SaveChangesAsync();  // Save changes

            return NoContent();
        }
    }
}
