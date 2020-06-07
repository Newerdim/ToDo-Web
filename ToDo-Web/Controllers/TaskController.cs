using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ToDo_Web.Data;
using ToDo_Web.Dtos;
using ToDo_Web.Models;

namespace ToDo_Web.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public TaskController(DataContext context, IMapper mapper)
        {
            this._context = context;
            this._mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetTasks()
        {
            var userId = GetUserId();

            if (userId == null)
                return BadRequest();

            var tasksInDb = await _context.TaskGroups
                .Where(tg => tg.UserId == userId)
                .Select(tg => tg.Tasks)
                .ToListAsync();

            if (!tasksInDb.Any())
                return NotFound();

            var tasks = _mapper.Map<List<TaskModelDto>>(tasksInDb);

            return Ok(tasks);
        }

        [HttpGet("{id}")]
        public IActionResult GetTask(int id)
        {
            var userId = GetUserId();

            if (userId == null)
                return BadRequest();

            var taskInDb = _context.TaskGroups
                .Where(tg => tg.UserId == userId)
                .Select(tg => tg.Tasks.FirstOrDefault(t => t.Id == id));

            if (taskInDb == null)
                return NotFound();

            var tasks = _mapper.Map<TaskModelDto>(taskInDb);

            return Ok(tasks);
        }

        [HttpPost]
        public Task<IActionResult> CreateTask(TaskModel taskModelDto)
        {

        }

        protected int? GetUserId()
        {
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (userId == null)
                return null;

            else return int.Parse(userId);
        }
    }
}
