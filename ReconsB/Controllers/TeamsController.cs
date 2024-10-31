//using Microsoft.AspNetCore.Authentication.JwtBearer;
//using Microsoft.AspNetCore.Authorization;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.EntityFrameworkCore;
//using ReconsB.Data;
//using ReconsB.model;
//using ReconsB.Model;
//using System.Numerics;

//namespace ReconsB.Controllers
//{
//    //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
//    [Route("api/[controller]")]
//    [ApiController]
//    public class TeamController : ControllerBase
//    {   
//        private readonly AddDbContext _context;
//        private readonly List<int> integers = new List<int> { 10, 25, 30, 5,25, 18, 42, 7, 60, 15, 22,10,7};

//        private readonly List<Player> players = new List<Player>
//        {
//               new Player { Name = "John", LastName = "Doe", Position = "Forward", Salary = 50000 },
//                new Player { Name = "Jane", LastName = "Smith", Position = "Midfielder", Salary = 60000 },
//                new Player { Name = "Bob", LastName = "Johnson", Position = "Defender", Salary = 55000},
//                new Player { Name = "Alice", LastName = "Brown", Position = "Goalkeeper", Salary = 65000 },
//                new Player { Name = "Charlie", LastName = "Davis", Position = "Forward", Salary = 52000 },
//                new Player { Name = "Emma", LastName = "Wilson", Position = "Midfielder", Salary = 58000 },
//                new Player { Name = "James", LastName = "Taylor", Position = "Defender", Salary = 57000 },
//                new Player { Name = "Olivia", LastName = "Anderson", Position = "Forward", Salary = 59000 },
//                new Player { Name = "Michael", LastName = "Thomas", Position = "Midfielder", Salary = 60000 },
//                new Player { Name = "Sophia", LastName = "Jackson", Position = "Defender", Salary = 55000 },
//                new Player { Name = "Lucas", LastName = "White", Position = "Goalkeeper", Salary = 65000 },
//                new Player { Name = "Mia", LastName = "Harris", Position = "Forward", Salary = 52000 },
//                new Player { Name = "Ethan", LastName = "Martin", Position = "Midfielder", Salary = 58000 },
//                new Player { Name = "Isabella", LastName = "Thompson", Position = "Defender", Salary = 57000 },
//                new Player { Name = "Liam", LastName = "Garcia", Position = "Forward", Salary = 59000 },
//                new Player { Name = "Ava", LastName = "Martinez", Position = "Midfielder", Salary = 60000 },
//                new Player { Name = "Noah", LastName = "Robinson", Position = "Defender", Salary = 55000 },
//                new Player { Name = "Charlotte", LastName = "Clark", Position = "Goalkeeper", Salary = 65000 },
//                new Player { Name = "Amelia", LastName = "Rodriguez", Position = "Forward", Salary = 52000 },
//                new Player { Name = "Mason", LastName = "Lewis", Position = "Midfielder", Salary = 58000 },
//                new Player { Name = "Harper", LastName = "Lee", Position = "Defender", Salary = 57000 }
//        };

       


//        public TeamController(AddDbContext context)
//        {
//            _context = context;
//        }

        

//        // Get all team details
//        [HttpGet("GetTeamDetails")]
//        public async Task<IActionResult> Get()
//        {
//            var teams = await _context.Teams.ToListAsync();
//            return Ok(teams);
//        }

//        // Get a single team by ID
//        [HttpGet("team/{id:int}")]
//        public async Task<IActionResult> Get(int id)
//        {
//            var team = await _context.Teams.FirstOrDefaultAsync(x => x.Id == id);

//            if (team == null)
//                return BadRequest("Invalid ID");

//            return Ok(team);
//        }

     
//        [HttpPost]
//        public async Task<IActionResult> Post(Team team)
//        {
//            await _context.Teams.AddAsync(team);
//            await _context.SaveChangesAsync();   

//            return CreatedAtAction(nameof(Get), new { id = team.Id }, team);   
//        }

//        // Update the country of a team
//        [HttpPatch("{id:int}")]
//        public async Task<IActionResult> Patch(int id, string country)
//        {
//            var team = await _context.Teams.FirstOrDefaultAsync(x => x.Id == id);

//            if (team == null)
//                return BadRequest("Invalid ID");

//            team.Country = country;

//            await _context.SaveChangesAsync();   

//            return NoContent();
//        }


//        [HttpGet("NumberofPlayers")]
//        public   IActionResult CountAllplayers()
//        {
//            var Numplayers = players.Count();
//            return Ok(Numplayers);
//        }

//        [HttpGet("evenNumbers")]
//        public IActionResult CountEven()
//        {
//            var Numplayers = integers.Where(x => x % 2 == 0);
//            return Ok(Numplayers);
//        }

//        [HttpGet("orderby")]
//        public IActionResult orderby()
//        {
//            var Numplayers = players.OrderBy(x=>x.Salary);
//            return Ok(Numplayers);
//        }

//        [HttpGet("FirstOrDefault")]
//        public IActionResult FirstOrDefault()
//        {
//            var Numplayers = players.FirstOrDefault(x => x.Salary <= 70000);
//            return Ok(Numplayers);
//        }


//        [HttpGet("Skip")]
//        public IActionResult skip()
//        {
//            var Numplayers = integers.Skip(3);
//            return Ok(Numplayers);
//        }
//    }





//}
