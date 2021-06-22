using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SmartGoalApp.Controllers.Resources;
using SmartGoalApp.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartGoalApp.Controllers
{
    [Route("/api/matrixitems")]
    public class PriorityMatrixController : Controller
    {
        private readonly IMapper mapper;
        private readonly ITaskRepository taskRepository;
        private readonly IUnitOfWork unitOfWork;
        public PriorityMatrixController(IMapper mapper, ITaskRepository taskRepository, IUnitOfWork unitOfWork)
        {
            this.mapper = mapper;
            this.taskRepository = taskRepository;
            this.unitOfWork = unitOfWork;
        }

        [HttpGet("{email}")]
        public async Task<IActionResult> GetTasks(string email)
        {
            var tasks = await taskRepository.GetTasks(email);
            if (tasks == null || tasks.Count == 0)
                return NotFound();
            var taskResources = new List<TaskResource>();
            foreach(var t in tasks)
            {
                if (t.IsFinished) continue; //skip the one that is finished.
                taskResources.Add(mapper.Map<Models.Task, TaskResource>(t));
            }
            return Ok(taskResources);
        }
    }
}
