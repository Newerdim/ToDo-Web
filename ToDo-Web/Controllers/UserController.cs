﻿using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using ToDo_Web.Data;
using ToDo_Web.Dtos;
using ToDo_Web.Helpers;
using ToDo_Web.Models;

namespace ToDo_Web.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IAuthRepository _repo;
        private readonly IOptions<AppSettings> _config;

        public UserController(IAuthRepository repo, IOptions<AppSettings> config)
        {
            this._repo = repo;
            this._config = config;
        }

        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<IActionResult> Login(UserForLoginDto userForLoginDto)
        {
            var userFromRepo = await _repo.Login(userForLoginDto.Username, userForLoginDto.Password);

            if (userFromRepo == null)
                return Unauthorized();

            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, userFromRepo.Id.ToString()),
                new Claim(ClaimTypes.Name, userFromRepo.FirstName)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config.Value.Token));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddDays(1),
                SigningCredentials = creds
            };

            var tokenHandler = new JwtSecurityTokenHandler();

            var token = tokenHandler.CreateToken(tokenDescriptor);

            return Ok(new
            {
                token = tokenHandler.WriteToken(token)
            }); ;
        }

        [AllowAnonymous]
        [HttpPost("register")]
        public async Task<IActionResult> Register(UserForRegistrationDto userForRegistrationDto)
        {
            if (await _repo.UserExist(userForRegistrationDto.Username))
                return BadRequest("Username already exists");

            var userToCreate = new User
            {
                FirstName = userForRegistrationDto.FirstName,
                Username = userForRegistrationDto.Username,
                Email = userForRegistrationDto.Email,
                TaskGroups = new List<TaskGroupModel>
                {
                    new TaskGroupModel()
                    {
                        Name = "Inbox"
                    }
                }
            };

            var createdUser = await _repo.Register(userToCreate, userForRegistrationDto.Password);

            // Created
            return StatusCode(201);
        }
    }
}
