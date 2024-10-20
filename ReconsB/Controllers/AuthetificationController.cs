using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using ReconsB.configurations;
using ReconsB.model;
using ReconsB.model.DTOs;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ReconsB.Controllers
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IConfiguration  _congiguration;

        public AuthenticationController(UserManager<IdentityUser> userManager, IConfiguration congiguration)
        {
            _userManager = userManager;
            _congiguration = congiguration;
        }


        [AllowAnonymous]
        [Route("login")]
        [HttpPost]

        public async Task<IActionResult> login([FromBody] UserLoginRequestDto loginRequest)
        {
            // Check if the model state is valid
            if (!ModelState.IsValid)
            {
                return BadRequest(new AuthResult()
                {
                    Errors = new List<string>() { "Invalid model state." }
                });
            }

            // Attempt to find the user by email
            var existingUser = await _userManager.FindByEmailAsync(loginRequest.Email);

            if (existingUser == null)
            {
                return BadRequest(new AuthResult()
                {
                    Errors = new List<string>() { "INVALID LOGIN DETAILS" }
                });
            }

            // Check if the password is correct
            var isCorrect = await _userManager.CheckPasswordAsync(existingUser, loginRequest.Password);

            if (!isCorrect)
            {
                return BadRequest(new AuthResult()
                {
                    Errors = new List<string>() { "INVALID LOGIN DETAILS" }
                });
            }

            // Generate the JWT token
            var jwtToken = GenerateJwtToken(existingUser);
            return Ok(new AuthResult()
            {
                Token = jwtToken,
                Results = true
            });
        }


        [HttpPost]
        [Route("Register")]
        public async Task<IActionResult> Register([FromBody] UserRegistrationRequestDto requestDto)
        {
            if (ModelState.IsValid)
            {
                // Check if the user already exists
                var userExists = await _userManager.FindByEmailAsync(requestDto.Email);

                if (userExists != null)
                {
                    return BadRequest(new AuthResult
                    {
                        Results = false,
                        Errors = new List<string> { "The email already exists" }
                    });
                }

                // Create new user
                var newUser = new IdentityUser
                {
                    Email = requestDto.Email,
                    UserName = requestDto.Name
                };

                var isCreated = await _userManager.CreateAsync(newUser, requestDto.Password);

                if (isCreated.Succeeded)
                {
                    // Generate JWT token
                    var token = GenerateJwtToken(newUser);

                    return Ok(new AuthResult
                    {
                        Results = true,
                        Token = token
                    });
                }

                return BadRequest(new AuthResult
                {
                    Results = false,
                    Errors = new List<string> { "Server error during user creation" }
                });
            }

            return BadRequest(new AuthResult
            {
                Results = false,
                Errors = new List<string> { "Invalid data" }
            });
        }

        // Method to generate JWT token
        private string GenerateJwtToken(IdentityUser user)
        {
            var jwtTokenHandler = new JwtSecurityTokenHandler();

            // Define the key and credentials
            var key = Encoding.UTF8.GetBytes(_congiguration.GetSection("JwtConfig:secret").Value);

            var credentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256);

            // Define claims for the token
            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.Email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.NameIdentifier, user.Id)
            };

            // Define token descriptor
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddHours(1),
                SigningCredentials = credentials
            };

            
            var token = jwtTokenHandler.CreateToken(tokenDescriptor);

            return jwtTokenHandler.WriteToken(token);
        }
    }
}
