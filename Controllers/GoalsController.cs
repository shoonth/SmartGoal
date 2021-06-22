using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SmartGoalApp.Controllers.Resources;
using SmartGoalApp.Models;
using SmartGoalApp.Persistence;
using System.Threading.Tasks;

namespace SmartGoalApp.Controllers
{
    [Route("/api/goals")]
    public class GoalsController : Controller
    {
        private readonly IMapper mapper;
        private readonly IGoalRepository goalRepository;
        private readonly IUnitOfWork unitOfWork;

        public GoalsController(IMapper mapper, IGoalRepository goalRepository, IUnitOfWork unitOfWork)
        {
            this.mapper = mapper;
            this.goalRepository = goalRepository;
            this.unitOfWork = unitOfWork;
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetGoal(int id)
        {
            var goal = await goalRepository.GetGoal(id);
            if (goal == null)
                return NotFound();
            var goalResource = mapper.Map<Goal, GoalResource>(goal);
            return Ok(goalResource);
        }
        [HttpPost]
        public async Task<IActionResult> CreateGoal([FromBody] SaveGoalResource goalResoure)
        {
            //Validate Model Binding issue happen
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var goal = mapper.Map<SaveGoalResource, Goal>(goalResoure);

            goalRepository.AddGoal(goal);
            await unitOfWork.Complete();

            await goalRepository.GetGoal(goal.Id);

            var result = mapper.Map<Goal, GoalResource>(goal);
            return Ok(result);
        }

        [HttpPut("{Id}")]
        public async Task<IActionResult> UpdateGoal(int id, [FromBody] SaveGoalResource goalResoure)
        {
            //Validate Model Binding issue happen
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var goal = await goalRepository.GetGoal(id);

            if (goal == null)
            {
                return NotFound();
            }

            mapper.Map<SaveGoalResource, Goal>(goalResoure, goal); // what is going on??
            await unitOfWork.Complete();

            goal = await goalRepository.GetGoal(goal.Id);

            var result = mapper.Map<Goal, GoalResource>(goal);
            return Ok(result);
        }
        [HttpDelete("{Id}")]
        public async Task<IActionResult> DeleteGoal(int id)
        {
            //Validate Model Binding issue happen
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var goal = await goalRepository.GetGoal(id, false);

            if (goal == null)
            {
                return NotFound();
            }
            goalRepository.RemoveGoal(goal);
            await unitOfWork.Complete();

            return Ok(id);
        }
    }
}
