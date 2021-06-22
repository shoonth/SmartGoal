using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SmartGoalApp.Controllers.Resources;
using SmartGoalApp.Persistence;
using System.Threading.Tasks;
using Task = SmartGoalApp.Models.Task;

namespace SmartGoalApp.Controllers
{
    [Route("/api/tasks")]
    public class TasksController : Controller
    {
        private readonly IMapper mapper;
        private readonly ITaskRepository taskRepository;
        private readonly IUnitOfWork unitOfWork;
        public TasksController(IMapper mapper, ITaskRepository taskRepository, IUnitOfWork unitOfWork)
        {
            this.mapper = mapper;
            this.taskRepository = taskRepository;
            this.unitOfWork = unitOfWork;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetTask(int id)
        {
            var task = await taskRepository.GetTask(id);
            if (task == null)
                return NotFound();
            var taskResource = mapper.Map<Task, TaskResource>(task);
            return Ok(taskResource);
        }

        [HttpPost]
        public async Task<IActionResult> CreateTask([FromBody] SaveTaskResource taskResoure)
        {
            //Validate Model Binding issue happen
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var task = mapper.Map<SaveTaskResource, Task>(taskResoure);

            taskRepository.AddTask(task);
            await unitOfWork.Complete();

            await taskRepository.GetTask(task.Id);

            var result = mapper.Map<Task, TaskResource>(task);
            return Ok(result);
        }

        [HttpPut("{Id}")]
        public async Task<IActionResult> UpdateTask(int id, [FromBody] SaveTaskResource taskResoure)
        {
            //Validate Model Binding issue happen
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var task = await taskRepository.GetTask(id);

            if (task == null)
            {
                return NotFound();
            }

            mapper.Map<SaveTaskResource, Task>(taskResoure, task); 
            await unitOfWork.Complete();

            task = await taskRepository.GetTask(task.Id);

            var result = mapper.Map<Task, TaskResource>(task);
            return Ok(result);
        }

        [HttpDelete("{Id}")]
        public async Task<IActionResult> DeleteTask(int id)
        {
            //Validate Model Binding issue happen
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var task = await taskRepository.GetTask(id, false);

            if (task == null)
            {
                return NotFound();
            }
            taskRepository.RemoveTask(task);
            await unitOfWork.Complete();

            return Ok(id);
        }
    }
}
