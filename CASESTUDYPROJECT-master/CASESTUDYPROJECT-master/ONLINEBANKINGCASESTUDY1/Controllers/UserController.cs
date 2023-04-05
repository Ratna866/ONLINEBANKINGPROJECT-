using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using ONLINEBANKINGCASESTUDY1.Models;
using System;
using System.Linq;

namespace ONLINEBANKINGCASESTUDY1.Controllers
{

        [Route("api/[controller]")]
        [ApiController]
        [EnableCors("AllowOrigin")]
        public class UserController : ControllerBase
        {
            private readonly IConfiguration _config;
            public readonly onlinebankingDbContext  _context;
            public UserController(IConfiguration config, onlinebankingDbContext context)
            {
                _config = config;
                _context = context;
            }
            [HttpPost("CreateUser")]
            public IActionResult Create(User user)
            {
                if (_context.Users.Where(u => u.Email == user.Email).FirstOrDefault() != null)
                {
                    return Ok("Already Exist");
                }
                user.MemberSince = DateTime.Now;
                _context.Users.Add(user);
                _context.SaveChanges();
                return Ok("success");
            }
        }
    }


