using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using ONLINEBANKINGCASESTUDY1.Models;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace ONLINEBANKINGCASESTUDY1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
            public IConfiguration _configuration;
            public readonly onlinebankingDbContext _context;
            public AuthController(IConfiguration configuration, onlinebankingDbContext context)
            {
                _context = context;
                _configuration = configuration;
            }
            [HttpPost]
            public async Task<IActionResult> Post(User user)
            {
                if (user != null && user.Email != null && user.Password != null)
                {
                    var userData = await GetUser(user.Email, user.Password);
                    var jwt = _configuration.GetSection("Jwt").Get<Jwt>();

                if (user != null)
                {
                    var claims = new[]
                    {
                       // new Claim(JwtRegisteredClaimNames.Sub, jwt.Subject),
                        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                        new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),
                        new Claim("Id",user.UserId.ToString()),
                        new Claim("Email",user.Email),
                        new Claim("Password",user.Password)

                    };
                
                        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwt.key));
                        var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
                        var token = new JwtSecurityToken(
                            jwt.Issuer,
                            jwt.Audience,
                            claims,
                            expires: DateTime.Now.AddMinutes(20),
                            signingCredentials: signIn
                            );
                        return Ok(new JwtSecurityTokenHandler().WriteToken(token));
                    }
                    else
                    {
                        return BadRequest("Invalid Credentials");
                    }
                }
                else
                {
                    return BadRequest("Invalid Credentials");
                }
            }
            [HttpGet]
            public async Task<User> GetUser(string Email, string Password)
            {
                return await _context.Users.FirstOrDefaultAsync(u => u.Email == Email && u.Password == Password);

            }
        }
    }


