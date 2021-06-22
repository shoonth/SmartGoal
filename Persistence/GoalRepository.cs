using Microsoft.EntityFrameworkCore;
using SmartGoalApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartGoalApp.Persistence
{
    public class GoalRepository : IGoalRepository
    {
        private ModelContext context;
        public GoalRepository(ModelContext context)
        {
            this.context = context;
        }
        public async Task<Goal> GetGoal(int id, bool includeRelated = true)
        {
            if (includeRelated)
                return await context.Goals
                        .Include(g => g.TaskList)
                        .SingleOrDefaultAsync(g => g.Id == id);

            return await context.Goals.FindAsync(id);
        }

        public void AddGoal(Goal goal)
        {
            context.Goals.Add(goal);
        }

        public void RemoveGoal(Goal goal)
        {
            context.Remove(goal);
        }
    }
}
