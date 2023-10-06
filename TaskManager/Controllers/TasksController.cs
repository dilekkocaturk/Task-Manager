using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TaskManager.Data;
using TaskManager.Models;

namespace TaskManager.Controllers
{
    [ApiController]
    [Authorize]
    [Route("api/[controller]")]
    public class TasksController : ControllerBase
    {
        private readonly TaskManagerDbContext _context;

        public TasksController(TaskManagerDbContext context)
        {
            _context = context;
        }

        [HttpGet("GetTasks")]
        public ActionResult<IEnumerable<TaskModel>> GetTasks()
        {
            var tasks = _context.Tasks.ToList();
            return Ok(tasks);
        }

        [HttpPost("CreateTask")]
        public ActionResult<TaskModel> CreateTask(TaskModel task)
        {
            _context.Tasks.Add(task);
            _context.SaveChanges();

            return CreatedAtAction(nameof(GetTask), new { id = task.Id }, task);
        }

        [HttpGet("GetTask/{id}")]
        public ActionResult<TaskModel> GetTask(int id)
        {
            var task = _context.Tasks.FirstOrDefault(t => t.Id == id);

            if (task == null)
                return NotFound();

            return Ok(task);
        }

        [HttpPut("UpdateTask/{id}")]
        public IActionResult UpdateTask(int id, TaskModel task)
        {
            if (id != task.Id)
                return BadRequest();

            _context.Entry(task).State = EntityState.Modified;
            _context.SaveChanges();

            return NoContent();
        }

        [HttpDelete("DeleteTask/{id}")]
        public IActionResult DeleteTask(int id)
        {
            var task = _context.Tasks.FirstOrDefault(t => t.Id == id);

            if (task == null)
                return NotFound();

            _context.Tasks.Remove(task);
            _context.SaveChanges();

            return NoContent();
        }

        [HttpGet("GetDailyReport")]
        public ActionResult<IEnumerable<TaskModel>> GetDailyReport()
        {
            var today = DateTime.Today;

            var tasks = _context.Tasks
                .Where(t => t.CreatedAt.Date == today)
                .ToList();

            return Ok(tasks);
        }

        [HttpGet("GetWeeklyReport")]
        public ActionResult<IEnumerable<TaskModel>> GetWeeklyReport()
        {
            var startOfWeek = DateTime.Today.AddDays(-(int)DateTime.Today.DayOfWeek);
            var endOfWeek = startOfWeek.AddDays(7);

            var tasks = _context.Tasks
                .Where(t => t.CreatedAt.Date >= startOfWeek && t.CreatedAt.Date < endOfWeek)
                .ToList();

            return Ok(tasks);
        }

        [HttpGet("GetMonthlyReport")]
        public ActionResult<IEnumerable<TaskModel>> GetMonthlyReport()
        {
            var startOfMonth = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1);
            var endOfMonth = startOfMonth.AddMonths(1);

            var tasks = _context.Tasks
                .Where(t => t.CreatedAt.Date >= startOfMonth && t.CreatedAt.Date < endOfMonth)
                .ToList();

            return Ok(tasks);
        }
    }
}