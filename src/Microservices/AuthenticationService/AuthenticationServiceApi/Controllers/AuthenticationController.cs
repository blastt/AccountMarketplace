﻿using AuthenticationServiceApi.Data;
using AuthenticationServiceApi.Models;
using AuthenticationServiceApi.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace AuthenticationServiceApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly ITokenBuilder _tokenBuilder;

        public AuthenticationController(
            ApplicationDbContext context,
            ITokenBuilder tokenBuilder)
        {
            _context = context;
            _tokenBuilder = tokenBuilder;
        }
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] ApplicationUser user)
        {
            var dbUser = await _context
                .Users
                .SingleOrDefaultAsync(u => u.UserName == user.UserName);

            if (dbUser == null)
            {
                return NotFound("User not found.");
            }

            // This is just an example, made for simplicity; do not store plain passwords in the database
            // Always hash and salt your passwords
            //var isValid = dbUser.Password == user.Password;
            var token = _tokenBuilder.BuildToken("");

            return Ok(token);
        }
    }
}
