using les3.Models;
using les3.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace les3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TasksController : ControllerBase
    {

        private readonly ITaskService _taskService;


        public TasksController(ITaskService taskService)
        {
            _taskService = taskService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var tasks = _taskService.GetTasks();
            return Ok(tasks);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var task = _taskService.GetTaskById(id);
            if (task == null)
            {
                return NotFound();
            }
            return Ok(task);
        }

        [HttpPost]
        public IActionResult Create(Tasks task)
        {
            _taskService.AddTask(task);
            return CreatedAtAction(nameof(Get), new { id = task.Id }, task);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, Tasks task)
        {
            if (id != task.Id)
            {
                return BadRequest();
            }

            _taskService.UpdateTask(task);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _taskService.DeleteTask(id);
            return NoContent();
        }

        // GET tasks by userId
        [HttpGet("/tasksByUserId/{userId}")]
        public IActionResult GetTasksByUser(int userId)
        {
            var tasks = _taskService.GetTasksByUser(userId);
            if (tasks == null)
                return NotFound("User not found");

            return Ok(tasks);
        }

        // GET tasks by projectId
        [HttpGet("/tasksByProjectId/{projectId}")]
        public IActionResult GetTasksByProject(int projectId)
        {
            var projects = _taskService.GetTasksByProject(projectId);
            if (projects == null)
                return NotFound("Project not found");

            return Ok(projects);
        }


    }
}
